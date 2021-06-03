Public Module Pelco_d

    ' смещения 
    'Const OFFSET_PACKET_HEAD = 0
    'Const OFFSET_PACKET_ADR = 1
    'Const OFFSET_PACKET_CMD1 = 2
    'Const OFFSET_PACKET_CMD2 = 3
    'Const OFFSET_PACKET_DAT1 = 4
    'Const OFFSET_PACKET_DAT2 = 5
    'Const OFFSET_PACKET_CRC = 6

    ' битовые поля CMD1
    Public Const CMD1_SENSE = &H80
    Public Const CMD1_RESERV6 = &H40
    Public Const CMD1_RESERV5 = &H20
    Public Const CMD1_AUTO_MANUAL_SCAN = &H10
    Public Const CMD1_CAMERA_ON_OFF = &H8
    Public Const CMD1_IRIS_CLOSE = &H4
    Public Const CMD1_IRIS_OPEN = &H2
    Public Const CMD1_FOCUS_NEAR = &H1
    Public Const CMD1_ZOOM_TELE = &H0
    Public Const CMD1_ZOOM_WIDE = &H0

    ' битовые поля CMD2
    Public Const CMD2_FOCUS_FAR = &H80
    Public Const CMD2_ZOOM_WIDE = &H40
    Public Const CMD2_ZOOM_TELE = &H20
    Public Const CMD2_DOWN = &H10
    Public Const CMD2_UP = &H8
    Public Const CMD2_LEFT = &H4
    Public Const CMD2_RIGTH = &H2
    Public Const CMD2_ALWAYS0 = &H1


    ' Структура пакета Pelco-D
    Public Structure packet_pelco_d_st
        Dim head As Byte
        Dim adr As Byte
        Dim cmd1 As Byte
        Dim cmd2 As Byte
        Dim dat1 As Byte
        Dim dat2 As Byte
        Dim crc As Byte
    End Structure

    '--------------------------------------------------------------------------
    ' Расчет контрольной суммы Pelco-D для структуры
    '--------------------------------------------------------------------------
    Function pelco_d_calc_crc(ByVal d As packet_pelco_d_st) As Byte
        Dim crc As UInteger = 0

        crc = crc + d.adr
        crc = crc + d.cmd1
        crc = crc + d.cmd2
        crc = crc + d.dat1
        crc = crc + d.dat2

        Return crc And &HFF

    End Function

End Module