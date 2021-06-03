Imports System
Imports System.IO
Imports System.IO.Ports


Public Class Form1

    Dim CMD2_UP As Byte = &H8
    Dim CMD2_DOWN As Byte = &H10
    Dim CMD2_LEFT As Byte = &H4
    Dim CMD2_RIGHT As Byte = &H2
    Dim CMD2_UPLEFT As Byte = &HC
    Dim CMD2_UPRIGHT As Byte = &HA
    Dim CMD2_DOWNLEFT As Byte = &H14
    Dim CMD2_DOWNRIGHT As Byte = &H12

    Dim CMD2_QUERY_ZOOM As Byte = &H55
    Dim CMD2_SET_ZOOM As Byte = &H4F
    Dim CMD2_QUERY_PAN As Byte = &H51
    Dim CMD2_QUERY_TILT As Byte = &H53
    Dim CMD2_PRESET_SET As Byte = &H3
    Dim CMD2_PRESET_GO As Byte = &H7

    Dim PACKET_SIZE = 7

    Dim CamSpeed As Integer = 0 ' Расчитаное значение скорости перемещения камеры


    Dim packet_from_pc(PACKET_SIZE) As Byte

    Const PORT_OPEN As String = "Открыть"
    Const PORT_CLOSE As String = "Закрыть"

    Const SEND_STR_START As String = "Строка"
    Const SEND_STR_STOP As String = "СТОП"

    Const SEND_FILE_START As String = "Файл"
    Const SEND_FILE_STOP As String = "СТОП"

    Const RX_COUNT_TXT As String = "RX: "
    Dim rx_counter_global As Long = 0     ' статистика, счетчик общего количества принятых байт
    Const TX_COUNT_TXT As String = "TX: "
    Dim tx_counter_global As Long = 0     ' статистика, счетчик общего количества переданных байт

    Enum port_status_e
        open = 1
        close = 0
    End Enum

    ' структура с информацией о передаваемом файле
    Structure file_send_st
        Dim fs As FileStream
        Const BUF_SIZE = 1024 * 1024
        Dim buf() As Byte
        Dim res As Integer
        Dim f As IO.FileInfo
        Dim file_size As Long
        Dim file_count As Long
    End Structure

    Dim f_send_st As file_send_st


    Dim packet_buffer_tx(PACKET_SIZE) ' Массив собираем пакет сюда
    Dim manual_packet_tx_pelco_d As Pelco_d.packet_pelco_d_st  ' сюда помещаем пакет собранный вручную (при помощи галочек) 
    Dim uart_queue_rx As New Queue(Of Byte) ' очередь - принятых байт


    Dim flag_write_log As Boolean      ' = 1 запись лога в файл
    Dim Ports As String()              ' список портов в системе
    Dim CPortStatus As port_status_e   ' состояниесом порта открыт - закрыт

    Dim f_log As FileStream             ' Лог файл
    '----------------------------------------------------------------------------------------------

    Enum avtomat_decoder_string_t
        wait
        hex
        delay

    End Enum
    '--------------------------------------------------------------------------
    ' Создание Пакет и передача
    '--------------------------------------------------------------------------    
    Sub PelcoD_Create_and_Send(ByVal cmd1 As Byte, ByVal cmd2 As Byte, ByVal data1 As Byte, ByVal data2 As Byte)
        Dim p As Pelco_d.packet_pelco_d_st
        p.head = &HFF
        p.adr = Convert.ToByte(mtb_Camera_Adr.Text)
        p.cmd1 = cmd1
        p.cmd2 = cmd2
        p.dat1 = data1
        p.dat2 = data2
        p.crc = pelco_d_calc_crc(p)
        Dim packet_byte() As Byte = p.ToByteArray
        SerialPort_data_send(packet_byte, packet_byte.Length)
    End Sub


    '--------------------------------------------------------------------------
    ' Преобразование символа в байт
    '--------------------------------------------------------------------------
    Function convert_char_to_byte(ByVal c As Byte) As Byte
        Dim b As Byte

        If (c >= Asc("0") And c <= Asc("9")) Then
            b = c - &H30
        ElseIf (c >= Asc("A") And c <= Asc("F")) Then
            b = c - &H37
        End If

        Return b
    End Function

    '--------------------------------------------------------------------------
    ' Преобразование пяти символов в число
    '--------------------------------------------------------------------------
    Function build_hex(ByVal h As Byte, ByVal l As Byte) As Byte
        Dim bl, bh As Byte

        bh = convert_char_to_byte(h) * 16
        bl = convert_char_to_byte(l)

        Return bh Or bl
    End Function


    '--------------------------------------------------------------------------
    ' Преобразование двух символов в байт
    '--------------------------------------------------------------------------
    Function build_delay(ByVal array() As Byte, ByVal len As UInteger) As UInteger
        Select Case len
            Case 1
                Return (array(0) - &H30)
            Case 2
                Return (array(0) - &H30) * 10 + (array(1) - &H30)
            Case 3
                Return (array(0) - &H30) * 100 + (array(1) - &H30) * 10 + (array(2) - &H30)
            Case 4
                Return (array(0) - &H30) * 1000 + (array(1) - &H30) * 100 + (array(2) - &H30) * 10 + (array(3) - &H30)
            Case 5
                Return (array(0) - &H30) * 10000 + (array(1) - &H30) * 1000 + (array(2) - &H30) * 100 + (array(3) - &H30) * 10 + (array(4) - &H30)
            Case Else
                Return 0
        End Select
    End Function



    '--------------------------------------------------------------------------
    ' Проигрыватель строки
    '
    ' 0..f - перевод в hex и передача в порт
    ' >12345 - задержка в мс(пробел между > и числом не допускается)
    '
    ' 00 01 02 af b e -> 00 01 02 af 0b 0e 
    ' >100 -> задержка 100 мс
    ' >12345 -> задержка 12345 мс
    '
    '--------------------------------------------------------------------------
    Public Sub decode_txt_hex_codes(ByVal s As String)

        Dim c As Char ' символ из строки
        Dim i As Integer = 1 ' индекс по входной строке

        Dim delay_ms As UInteger ' задержка в мс, пересчет из delay_num
        Dim delay_cnt As UInteger ' счетчик числа символов в delay_num
        Dim delay_num(5) As Byte ' массив для сборки числа

        Dim hex1, hex2 As Byte ' hex старший, младший байт
        Dim send_byte As Byte ' байт для послылки в порт
        Dim st As avtomat_decoder_string_t = avtomat_decoder_string_t.wait
        Dim su As String = s.ToUpper
        Dim ss As Char

        ' накопительный буфер для формирования последовательности на передачу
        Const TX_ARRAY_SIZE = 1024
        Dim tx_array(TX_ARRAY_SIZE) As Byte
        Dim tx_array_cnt As UInteger = 0

        If s.Length = 0 Then
            Exit Sub
        End If

        While i <> s.Length
            ss = Mid(su, i, 1)
            c = Convert.ToChar(ss)
            i = i + 1

            Select Case st
                Case avtomat_decoder_string_t.wait
                    If (c >= "0" And c <= "9") Or (c >= "A" And c <= "F") Then
                        hex1 = Convert.ToByte(c)
                        st = avtomat_decoder_string_t.hex
                    ElseIf (c = ">") Then
                        st = avtomat_decoder_string_t.delay
                    End If

                Case avtomat_decoder_string_t.hex
                    If (c >= "0" And c <= "9") Or (c >= "A" And c <= "F") Then
                        hex2 = Convert.ToByte(c)
                        send_byte = build_hex(hex1, hex2)
                        tx_array(tx_array_cnt) = send_byte
                        tx_array_cnt = tx_array_cnt + 1
                        'print_log(send_byte.ToString("X2") + " ")
                        hex1 = 0
                        hex2 = 0
                        st = avtomat_decoder_string_t.wait
                    ElseIf (c = ">") Then
                        send_byte = build_hex(0, hex1)
                        'print_log(send_byte.ToString("X2") + " ")
                        tx_array(tx_array_cnt) = send_byte
                        tx_array_cnt = tx_array_cnt + 1
                        hex1 = 0
                        hex2 = 0
                        st = avtomat_decoder_string_t.delay
                    Else
                        send_byte = build_hex(0, hex1)
                        'print_log(send_byte.ToString("X2") + " ")
                        tx_array(tx_array_cnt) = send_byte
                        tx_array_cnt = tx_array_cnt + 1
                        hex1 = 0
                        hex2 = 0
                        st = avtomat_decoder_string_t.wait
                    End If

                Case avtomat_decoder_string_t.delay
                    If (c >= "0" And c <= "9") Then
                        If delay_cnt < 5 Then
                            delay_num(delay_cnt) = Convert.ToByte(c)
                            delay_cnt = delay_cnt + 1
                        End If
                    Else
                        delay_ms = build_delay(delay_num, delay_cnt)
                        print_log(vbCrLf + "Delay:" + Str(delay_ms) + vbCrLf)
                        delay_cnt = 0

                        Threading.Thread.Sleep(delay_ms)

                        st = avtomat_decoder_string_t.wait
                    End If

            End Select

            ' Передача массива при: переводе строки(построчная передача) или достижении максимального размера буфера
            If ((c = vbCr Or c = vbLf) And tx_array_cnt <> 0) Or tx_array_cnt = TX_ARRAY_SIZE Then
                SerialPort_data_send(tx_array, tx_array_cnt)
                tx_array_cnt = 0
            End If

        End While

    End Sub

    '--------------------------------------------------------------------------
    ' Вывод в окно лога + в файл
    '--------------------------------------------------------------------------
    Sub print_log(ByVal txt As String)

        tbLogRx.AppendText(txt)

        ' Запись в лог файл Приема
        If flag_write_log = True And txt.Length > 0 Then
            f_log.Write(System.Text.Encoding.Default.GetBytes(txt), 0, txt.Length)
        End If

    End Sub

    '--------------------------------------------------------------------------
    ' проверка пакета
    ' возврат = 0 - ок
    '--------------------------------------------------------------------------
    Function packet_check(ByVal packet() As Byte) As Integer
        Dim p As Pelco_d.packet_pelco_d_st = packet.ToStructure(Of packet_pelco_d_st)()

        If p.head = &HFF And p.crc = pelco_d_calc_crc(p) Then
            Return 0 ' OK
        End If

        Return 1 ' Error

    End Function

    '--------------------------------------------------------------------------
    ' возвращает пакет из буфера приема
    '--------------------------------------------------------------------------
    Function get_paket() As Byte()
        Dim len As Integer = PACKET_SIZE
        Dim i As Integer
        Dim buf_tmp(PACKET_SIZE) As Byte

        'For i = 0 To 3
        'buf_tmp(i) = uart_queue_rx.Dequeue()
        'Next

        For i = 0 To len - 1
            buf_tmp(i) = uart_queue_rx.Dequeue()
        Next
        get_paket = buf_tmp

    End Function

    '--------------------------------------------------------------------------
    ' Посылка пакета
    '--------------------------------------------------------------------------
    Sub SerialPort_data_send(ByVal data() As Byte, ByVal len As Integer)

        Dim s As String = ""

        If CPortStatus = port_status_e.close Then
            print_log("Ошибка: Порт закрыт.")
            Exit Sub
        End If

        SerialPort1.Write(data, 0, len)

        s = "TX:" + vbCrLf
        print_log(s)

        s = ConvArrayByteToHEX(data, len)
        print_log(s)

    End Sub


    '--------------------------------------------------------------------------
    ' Поиск СОМ портов в системе
    '--------------------------------------------------------------------------
    Sub find_com_port()
        Dim port As String
        Const STR_TIRE = "--------------------------------------"

        Ports = SerialPort.GetPortNames
        cbPorts.Items.Clear()

        print_log(vbCrLf + STR_TIRE + vbCrLf)
        print_log("Доступные СОМ порты в системе:" + vbCrLf)
        For Each port In Ports
            print_log(port + vbCrLf)
            cbPorts.Items.Add(port)
        Next port
        print_log(STR_TIRE + vbCrLf)

        cbPorts.SelectedIndex = 0 ' Всегда выбираем самый первый порт, для заполнения поля а то ПУСТОЕ плохо смотриться

    End Sub

    Private Sub btScanComPort_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btScanComPort.Click
        find_com_port()
    End Sub

    Private Sub btPOpen_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPOpen.Click

        Dim com_port_parameter As String = ""

        If cbPorts.SelectedItem <> "" And CPortStatus = port_status_e.close Then

            rx_counter_global = 0
            tx_counter_global = 0

            SerialPort1.BaudRate = cbSpeed.SelectedItem ' cbSpeed.Items
            SerialPort1.PortName = cbPorts.SelectedItem

            Try
                SerialPort1.Open()
            Catch ex As Exception
                print_log(vbCrLf + "Ошибка: открытия порта." + vbCrLf)
                Exit Sub
            End Try

            uart_queue_rx.Clear()

            'If ComPortInit(cbPorts.SelectedItem, com_port_speed_int, com_port_parity, com_port_stop_bit) = False Then
            'print_log(vbCrLf + "Ошибка: открытия порта." + vbCrLf)
            'Exit Sub
            'End If

            CPortStatus = port_status_e.open
            btPOpen.Text = PORT_CLOSE

            rx_counter_global = 0 ' Сбрасываем счетчик принятых и переданных байт
            tx_counter_global = 0

            cbPorts.Enabled = False ' выключаем выбор номера порта

            print_log(vbCrLf + "Порт Открыт." + vbCrLf)

            Timer2.Enabled = 1

        ElseIf CPortStatus = port_status_e.open Then ' Закрываем СОМ порт -------------------------------------
            'ComPortClose()
            SerialPort1.Close()

            cbPorts.Enabled = True ' включаем выбор номера порта

            Timer2.Enabled = False

            CPortStatus = port_status_e.close
            btPOpen.Text = PORT_OPEN
            print_log(vbCrLf + "Порт == закрыт ===." + vbCrLf)
        End If
    End Sub

    Private Sub Form1_Load(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles MyBase.Load

        tb_CamSpeed_Num.Text = tb_CamMovsSpeed.Value
        CamSpeed = Int(tb_CamSpeed_Num.Text)

        'Значение ZOOM по умолчанию
        tb_CamZoom.Value = 8192
        tb_SetCameraZoom.Text = tb_CamZoom.Value

        'Dim bin() As Byte
        'Dim packet_tx As packet_pelco_d
        'packet_tx.head = &HFF
        'packet_tx.adr = &H0
        'packet_tx.cmd1 = &H1
        'packet_tx.cmd2 = &H2
        'packet_tx.dat1 = &H3
        'packet_tx.dat2 = &H4
        'packet_tx.crc = &HAA
        'bin = packet_tx.ToByteArray()
        'print_log(ConvArrayByteToHEX(bin, bin.Length))

        'decode_txt_hex_codes(" 01 20 0a e d f" + vbCrLf + " >12345" + " ab ac ef" + vbCrLf)

        CPortStatus = port_status_e.close
        btPOpen.Text = PORT_OPEN

        cbSpeed.SelectedIndex = 6 ' значение скорости по умолчанию

        flag_write_log = 0

        tx_counter_global = 0
        rx_counter_global = 0
        trx_count_update() ' обновление счетчиков TX RX в строке статуса

        ' изменяет размер метки в строке статуса
        tsslRxCounter.AutoSize = False
        Dim slab As Size = New Size(100, tsslRxCounter.Size.Height)
        tsslRxCounter.Size = slab

        tsslTxCounter.AutoSize = False
        slab = New Size(100, tsslRxCounter.Size.Height)
        tsslTxCounter.Size = slab

        find_com_port() ' Производим поиск ком портов в системы

        ToolTip1.IsBalloon = True ' Подсказка в стиле комикса
    End Sub

    '--------------------------------------------------------------------------
    ' таймер настроен на 10 мс (при 100 мс - неуспевает принимать, теряются данные)
    '--------------------------------------------------------------------------
    Private Sub Timer1_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer1.Tick
        Dim s As String = ""      ' строка в виде НЕХ
        Dim s1 As String = ""     ' строка в виде БИН
        Dim s_out As String = ""  ' строка на вывод
        Dim sl_n As Integer = 0   ' счетчик длинны строки
        Dim sc As String = ""     ' строка одного символа НЕХ
        Dim sw As String = ""     ' строка для сохранения в файл
        Dim l_n As Integer = 0    ' количество линий
        Dim l_n2 As Integer = 0   ' количество линий в строке (для расчета)
        Const LINES_MAX = 25 * 10 ' максимальное количество строк в техт боксе
        Dim packet_rx(PACKET_SIZE) As Byte

        If CPortStatus = port_status_e.close Then
            Exit Sub
        End If

        If uart_queue_rx.Count < PACKET_SIZE Then
            Exit Sub
        End If

        packet_rx = get_paket()
        s_out = ConvArrayByteToHEX(packet_rx, PACKET_SIZE)
        print_log(s_out)

        rx_counter_global = rx_counter_global + PACKET_SIZE

        l_n = tbLogRx.Lines.Count
        If l_n > LINES_MAX + 100 Then
            Del_Str(tbLogRx, LINES_MAX)
        End If

        trx_count_update() ' обновление счетчиков TX RX в строке статуса

        If (packet_check(packet_rx) = 1) Then
            print_log("ERROR: rx packet, header-error" + vbCrLf)
            Exit Sub
        End If

        ' Декодируем пакет
        pelco_d_decode_packet(packet_rx)

    End Sub

    '--------------------------------------------------------------------------
    ' Обработка смены состояния: запись лог файла
    '--------------------------------------------------------------------------
    Private Sub cbLogFile_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cbLogFile.CheckedChanged
        Dim fname As String = ""

        If cbLogFile.Checked = True Then
            flag_write_log = True
            fname = CreateLogFileName()
            f_log = New FileStream(fname, FileMode.CreateNew, FileAccess.Write)
        Else
            flag_write_log = False
            f_log.Close()
        End If
    End Sub

    '--------------------------------------------------------------------------
    ' Формируем имя файла для лога
    ' создает строку с текущей датой и расширением .log
    '--------------------------------------------------------------------------
    Function CreateLogFileName() As String
        Dim str As String
        Dim cc As String
        Dim i As Integer
        Dim str_date As String
        Dim str_date_out As String

        str_date = DateTime.Now
        str_date_out = str_date.ToString()

        str = ""
        For i = 1 To Len(str_date_out)
            cc = Mid(str_date_out, i, 1)
            If cc = "." Or cc = ":" Or cc = " " Then
                cc = "_"
            End If
            str = str + cc
        Next
        str = str + ".log"

        CreateLogFileName = str
    End Function

    '--------------------------------------------------------------------------
    ' обновление счетчиков TX RX в строке статуса
    '--------------------------------------------------------------------------
    Sub trx_count_update()
        tsslRxCounter.Text = RX_COUNT_TXT + Str(rx_counter_global)
        tsslTxCounter.Text = TX_COUNT_TXT + Str(tx_counter_global)
    End Sub

    '--------------------------------------------------------------------------
    ' Удаление строк
    ' str_store - количество строк которое необходимо сохранить
    '--------------------------------------------------------------------------
    Sub Del_Str(ByRef tb As TextBox, ByVal str_store As Integer)
        Dim l_n As Integer    ' количество линий
        Dim l As Integer      ' счетчик линий

        ' удаляем строки
        l_n = tb.Lines.Count

        ' Для отладки
        'tbLogTx.AppendText(Str(l_n) + vbCrLf)

        If l_n > str_store Then
            Dim newList As List(Of String) = tb.Lines.ToList
            For l = 0 To l_n - str_store
                newList.RemoveAt(0)        ' удаляем самую вернюю строку т.к. после удаления строки сдвигаются в верх
            Next
            tb.Clear()
            tb.Lines = newList.ToArray

            tb.SelectionStart = tb.Text.Length - 1
            tb.ScrollToCaret()
        End If

    End Sub

    '--------------------------------------------------------------------------
    ' Таймер переодической передачи cmd door get status
    '--------------------------------------------------------------------------
    Private Sub Timer2_Tick(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles Timer2.Tick

    End Sub

    '--------------------------------------------------------------------------
    ' Очистка лога приема
    '--------------------------------------------------------------------------
    Private Sub btClearRxLog_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btClearRxLog.Click
        tbLogRx.Clear()
    End Sub

    '--------------------------------------------------------------------------
    ' принимаем и помещаем в очередь
    '--------------------------------------------------------------------------
    Private Sub SerialPort1_DataReceived(ByVal sender As System.Object, ByVal e As System.IO.Ports.SerialDataReceivedEventArgs) Handles SerialPort1.DataReceived
        Dim i As Integer
        Dim len As Integer
        Dim buf(4096) As Byte

        len = SerialPort1.BytesToRead
        For i = 0 To len - 1
            SerialPort1.Read(buf, i, 1)
            uart_queue_rx.Enqueue(buf(i))
        Next i

    End Sub

    '--------------------------------------------------------------------------
    ' Обходим все поля CMD 1 и возращаем байт
    '--------------------------------------------------------------------------
    Function get_checkbox_cmd1() As Byte
        Dim v As Byte = 0

        If cb_CMD1_reserv5.Checked = True Then
            v = v Or CMD1_RESERV5
        End If

        If cb_CMD1_reserv6.Checked = True Then
            v = v Or CMD1_RESERV6
        End If

        If cb_CMD1_Auto_Manual_scan.Checked = True Then
            v = v Or CMD1_AUTO_MANUAL_SCAN
        End If

        If cb_CMD1_Camera_on_off.Checked = True Then
            v = v Or CMD1_CAMERA_ON_OFF
        End If

        If cb_CMD1_Focus_near.Checked = True Then
            v = v Or CMD1_FOCUS_NEAR
        End If

        If cb_CMD1_Iris_close.Checked = True Then
            v = v Or CMD1_IRIS_CLOSE
        End If

        If cb_CMD1_Iris_open.Checked = True Then
            v = v Or CMD1_IRIS_OPEN
        End If

        If cb_CMD1_Sense.Checked = True Then
            v = v Or CMD1_SENSE
        End If

        Return v
    End Function

    '--------------------------------------------------------------------------
    ' Обходим все поля CMD 2 и возращаем байт
    '--------------------------------------------------------------------------
    Function get_checkbox_cmd2() As Byte
        Dim v As Byte = 0

        If cb_CMD2_Always_0.Checked = True Then
            v = v Or CMD2_ALWAYS0
        End If

        If cb_CMD2_Down.Checked = True Then
            v = v Or CMD2_DOWN
        End If

        If cb_CMD2_Focus_Far.Checked = True Then
            v = v Or CMD2_FOCUS_FAR
        End If

        If cb_CMD2_Left.Checked = True Then
            v = v Or CMD2_LEFT
        End If

        If cb_CMD2_Rigth.Checked = True Then
            v = v Or CMD2_RIGTH
        End If

        If cb_CMD2_Up.Checked = True Then
            v = v Or CMD2_UP
        End If

        If cb_CMD2_Zoom_Tele.Checked = True Then
            v = v Or CMD2_ZOOM_TELE
        End If

        If cb_CMD2_Zoom_Wide.Checked = True Then
            v = v Or CMD2_ZOOM_WIDE
        End If

        Return v
    End Function


    '--------------------------------------------------------------------------
    ' Обходим все поля CheckBox-ы и составляем пакет
    '--------------------------------------------------------------------------
    Public Function create_manual_packet() As Pelco_d.packet_pelco_d_st

        Dim p As packet_pelco_d_st

        p.head = &HFF
        p.adr = Convert.ToByte(mtb_Camera_Adr.Text)
        p.cmd1 = get_checkbox_cmd1()
        p.cmd2 = get_checkbox_cmd2()
        p.dat1 = TrackBar_DAT1.Value
        p.dat2 = TrackBar_DAT2.Value
        p.crc = pelco_d_calc_crc(p)

        mtb_PACKET_ADR.Text = p.adr.ToString("X2")
        mtb_PACKET_CMD1.Text = p.cmd1.ToString("X2")
        mtb_PACKET_CMD2.Text = p.cmd2.ToString("X2")
        mtb_PACKET_DAT1.Text = p.dat1.ToString("X2")
        mtb_PACKET_DAT2.Text = p.dat2.ToString("X2")
        mtb_PACKET_CRC.Text = p.crc.ToString("X2")

        Return p

    End Function

    Private Sub cb_CMD1_Sense_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD1_Sense.Click
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD1_Auto_Manual_scan_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD1_Auto_Manual_scan.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD1_Camera_on_off_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD1_Camera_on_off.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD1_Iris_close_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD1_Iris_close.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD1_Iris_open_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD1_Iris_open.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD1_Focus_near_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD1_Focus_near.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD2_Focus_Far_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD2_Focus_Far.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD2_Zoom_Wide_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD2_Zoom_Wide.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD2_Zoom_Tele_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD2_Zoom_Tele.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD2_Down_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD2_Down.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD2_Up_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD2_Up.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD2_Left_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD2_Left.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub cb_CMD2_Rigth_CheckedChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles cb_CMD2_Rigth.CheckedChanged
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub TrackBar_DAT1_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar_DAT1.ValueChanged
        mtb_DAT1.Text = TrackBar_DAT1.Value.ToString("X2")
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    Private Sub TrackBar_DAT2_ValueChanged(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles TrackBar_DAT2.ValueChanged
        mtb_DAT2.Text = TrackBar_DAT2.Value.ToString("X2")
        manual_packet_tx_pelco_d = create_manual_packet()
    End Sub

    '--------------------------------------------------------------------------
    ' КНОПКА: Отправка пакета собранного в интерфейсе
    '--------------------------------------------------------------------------
    Private Sub bt_Send_Packet_Pelco_D__Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Send_Packet_Pelco_D_.Click
        manual_packet_tx_pelco_d = create_manual_packet()
        Dim packet_byte() As Byte = manual_packet_tx_pelco_d.ToByteArray
        SerialPort_data_send(packet_byte, packet_byte.Length)
    End Sub

    '--------------------------------------------------------------------------
    ' КНОПКА: Отправка пустого пакета
    '--------------------------------------------------------------------------
    Private Sub bt_Send_Packet_Pelco_D_zero_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Send_Packet_Pelco_D_zero.Click
        Dim p As Pelco_d.packet_pelco_d_st
        p.head = &HFF
        p.adr = Convert.ToByte(mtb_Camera_Adr.Text)
        p.cmd1 = 0
        p.cmd2 = 0
        p.dat1 = 0
        p.dat2 = 0
        p.crc = pelco_d_calc_crc(p)
        Dim packet_byte() As Byte = p.ToByteArray
        SerialPort_data_send(packet_byte, packet_byte.Length)
    End Sub

    Private Sub bt_Load_TXT_File_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Load_TXT_File.Click
        OpenFileDialog1.FileName = ""
        OpenFileDialog1.InitialDirectory = "." '    "C:\"
        OpenFileDialog1.Filter = "All files (*.*)|*.*"
        OpenFileDialog1.FilterIndex = 2
        OpenFileDialog1.RestoreDirectory = True

        Dim file_send_cnt As Integer

        ReDim f_send_st.buf(file_send_st.BUF_SIZE)

        If OpenFileDialog1.ShowDialog() <> System.Windows.Forms.DialogResult.OK Then
            print_log("ERROR: open file script.")
            Exit Sub
        End If

        file_send_cnt = Int(tbFileSendN.Text)

        If file_send_cnt = 0 Then
            file_send_cnt = 1
            tbFileSendN.Text = "1"
        End If


        For i = 1 To file_send_cnt Step 1

            f_send_st.f = New IO.FileInfo(OpenFileDialog1.FileName)
            f_send_st.file_size = f_send_st.f.Length   ' длинна файла нужна чтобы знать сколько всего байт передавать и расчитывать проценты
            If f_send_st.file_size = 0 Then
                Exit Sub
            End If

            Dim fileReader As System.IO.StreamReader
            fileReader = My.Computer.FileSystem.OpenTextFileReader(OpenFileDialog1.FileName)
            Dim stringReader As String

            If CPortStatus = port_status_e.close Then
                print_log("Ошибка порт не открыт, СТОП ..." + vbCrLf)
                Exit Sub
            End If

            print_log("Проигрывание сценария из файла..." + vbCrLf)
            print_log("+++ СТАРТ №" + Str(i) + "++++++++++++++++++++++++++++++++" + vbCrLf)
            Do
                stringReader = fileReader.ReadLine()
                'print_log(stringReader + vbCrLf)

                ' Добавили перевод строки, используется как разделитель т.к. алгоритм ожидает конец строки
                ' а при чтении ReadLine - конец строки не поподает в строку
                decode_txt_hex_codes(stringReader + vbCrLf)

            Loop While stringReader <> Nothing ' .Length > 0

            print_log("+++ СТОП +++++++++++++++++++++++++++++++++" + vbCrLf)

            fileReader.Close()

        Next


        'f_send_st.fs = New FileStream(OpenFileDialog1.FileName, FileMode.Open, FileAccess.Read)

        'print_log(vbCrLf + "Загрузка файла (размер = " + Str(f_send_st.file_size) + " байт) ..." + vbCrLf)

        'f_send_st.res = f_send_st.fs.Read(f_send_st.buf, 0, file_send_st.BUF_SIZE)
        'print_log("Прочитали файл длинной = " + Str(f_send_st.res) + " байт" + vbCrLf)

        'If CPortStatus = port_status_e.close Then
        'print_log("Ошибка порт не открыт, СТОП ..." + vbCrLf)
        'Exit Sub
        'End If

        'print_log("Проигрывание сценария из файла..." + vbCrLf)
        'decode_txt_hex_codes(System.Text.Encoding.UTF8.GetString(f_send_st.buf))

    End Sub

    '--------------------------------------------------------------------------
    ' Декодер пакетов
    '--------------------------------------------------------------------------    
    Sub pelco_d_decode_packet(ByVal p() As Byte)

        ' Response Query ZOOM
        If p(2) = &H0 And p(3) = &H5D Then
            tb_CamZoom.Value = p(4) * 256 + p(5)
            tb_SetCameraZoom.Text = tb_CamZoom.Value
        End If




    End Sub

    '--------------------------------------------------------------------------
    ' Ползунок скорость перемещения камеры
    '--------------------------------------------------------------------------    
    Private Sub tb_CamMovsSpeed_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_CamMovsSpeed.Scroll
        tb_CamSpeed_Num.Text = tb_CamMovsSpeed.Value
        CamSpeed = Int(tb_CamMovsSpeed.Value)
    End Sub







    '--------------------------------------------------------------------------
    ' Перемещение СТОП
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveSTOP_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCamMoveSTOP.Click
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub








    '--------------------------------------------------------------------------
    ' Query Zoom - запрос велечины Зума у камеры
    '--------------------------------------------------------------------------    
    Private Sub btCamQueryZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCamQueryZoom.Click
        PelcoD_Create_and_Send(0, CMD2_QUERY_ZOOM, 0, 0)
    End Sub

    '--------------------------------------------------------------------------
    ' Set Zoom - Установка велечины Зума в камере
    '--------------------------------------------------------------------------    
    Private Sub btCamSetZoom_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btCamSetZoom.Click
        Dim new_zoom As UInt16

        Try
            new_zoom = Int(tb_SetCameraZoom.Text)
        Catch ex As Exception
            tb_SetCameraZoom.Text = "8192"
        End Try

        If new_zoom > 16384 Then
            new_zoom = 16384
            tb_SetCameraZoom.Text = "16384"
        End If

        tb_CamZoom.Value = new_zoom
        PelcoD_Create_and_Send(0, CMD2_SET_ZOOM, (new_zoom And &HFF00) >> 8, new_zoom And &HFF)
    End Sub
    '--------------------------------------------------------------------------
    ' Запрос Tilt
    '--------------------------------------------------------------------------    
    Private Sub bt_QueryTilt_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_QueryTilt.Click
        PelcoD_Create_and_Send(0, CMD2_QUERY_TILT, 0, 0)
    End Sub

    '--------------------------------------------------------------------------
    ' Запрос Pan
    '--------------------------------------------------------------------------    
    Private Sub bt_Query_Pan_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles bt_Query_Pan.Click
        PelcoD_Create_and_Send(0, CMD2_QUERY_PAN, 0, 0)
    End Sub



    '--------------------------------------------------------------------------
    ' Preset Set
    '--------------------------------------------------------------------------    
    Private Sub btPresetSet_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPresetSet.Click
        PelcoD_Create_and_Send(0, CMD2_PRESET_SET, 0, NumUD_Preset.Value)
    End Sub

    '--------------------------------------------------------------------------
    ' Preset Go
    '--------------------------------------------------------------------------    
    Private Sub btPresetGo_Click(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles btPresetGo.Click
        PelcoD_Create_and_Send(0, CMD2_PRESET_GO, 0, NumUD_Preset.Value)
    End Sub

    Private Sub tb_CamZoom_Scroll(ByVal sender As System.Object, ByVal e As System.EventArgs) Handles tb_CamZoom.Scroll
        Dim new_zoom As UInt16

        new_zoom = tb_CamZoom.Value
        tb_SetCameraZoom.Text = Int(new_zoom)

        PelcoD_Create_and_Send(0, CMD2_SET_ZOOM, (new_zoom And &HFF00) >> 8, new_zoom And &HFF)
    End Sub


    Private Sub btCamMoveUP_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveUP.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub btCamMoveDOWN_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveDOWN.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub btCamMoveRIGTH_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveRIGTH.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub btCamMoveLEFT_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveLEFT.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub btCamMoveUPLEFT_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveUPLEFT.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub btCamMoveUPRIGHT_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveUPRIGHT.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub btCamMoveDOWNRIGHT_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveDOWNRIGHT.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub btCamMoveDOWNLEFT_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveDOWNLEFT.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub tbCamFocusNEAR_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamFocusNEAR.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub tbCamFocusFAR_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamFocusFAR.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub tbCamZoomTELE_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamZoomTELE.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub

    Private Sub tbCamZoomWIDE_MouseUp(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamZoomWIDE.MouseUp
        PelcoD_Create_and_Send(0, 0, 0, 0)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение в лево - верх - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveUPLEFT_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveUPLEFT.MouseDown
        PelcoD_Create_and_Send(0, CMD2_UPLEFT, CamSpeed, CamSpeed)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение вверх - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveUP_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveUP.MouseDown
        PelcoD_Create_and_Send(0, CMD2_UP, 0, CamSpeed)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение в право-верх - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveUPRIGHT_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveUPRIGHT.MouseDown
        PelcoD_Create_and_Send(0, CMD2_UPRIGHT, CamSpeed, CamSpeed)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение в право - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveRIGTH_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveRIGTH.MouseDown
        PelcoD_Create_and_Send(0, CMD2_RIGHT, CamSpeed, 0)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение в право-верх - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveDOWNRIGHT_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveDOWNRIGHT.MouseDown
        PelcoD_Create_and_Send(0, CMD2_DOWNRIGHT, CamSpeed, CamSpeed)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение вниз - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveDOWN_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveDOWN.MouseDown
        PelcoD_Create_and_Send(0, CMD2_DOWN, 0, CamSpeed)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение в лево - верх - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveDOWNLEFT_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveDOWNLEFT.MouseDown
        PelcoD_Create_and_Send(0, CMD2_DOWNLEFT, CamSpeed, CamSpeed)
    End Sub
    '--------------------------------------------------------------------------
    ' Перемещение в лево - посылаем перемещение
    '--------------------------------------------------------------------------    
    Private Sub btCamMoveLEFT_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles btCamMoveLEFT.MouseDown
        PelcoD_Create_and_Send(0, CMD2_LEFT, CamSpeed, 0)
    End Sub
    '--------------------------------------------------------------------------
    ' Focus Near
    '--------------------------------------------------------------------------    
    Private Sub tbCamFocusNEAR_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamFocusNEAR.MouseDown
        PelcoD_Create_and_Send(CMD1_FOCUS_NEAR, 0, 0, 0)
    End Sub
    '--------------------------------------------------------------------------
    ' Focus Far
    '--------------------------------------------------------------------------    
    Private Sub tbCamFocusFAR_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamFocusFAR.MouseDown
        PelcoD_Create_and_Send(0, CMD2_FOCUS_FAR, 0, 0)
    End Sub
    '--------------------------------------------------------------------------
    ' Zoom Tele
    '--------------------------------------------------------------------------    
    Private Sub tbCamZoomTELE_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamZoomTELE.MouseDown
        PelcoD_Create_and_Send(CMD1_ZOOM_TELE, CMD2_ZOOM_TELE, 0, 0)
    End Sub
    '--------------------------------------------------------------------------
    ' Zoom Wide
    '--------------------------------------------------------------------------    
    Private Sub tbCamZoomWIDE_MouseDown(ByVal sender As System.Object, ByVal e As System.Windows.Forms.MouseEventArgs) Handles tbCamZoomWIDE.MouseDown
        PelcoD_Create_and_Send(CMD1_ZOOM_WIDE, CMD2_ZOOM_WIDE, 0, 0)
    End Sub

End Class
