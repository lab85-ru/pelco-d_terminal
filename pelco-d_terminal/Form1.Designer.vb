<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.components = New System.ComponentModel.Container
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(Form1))
        Me.gbPort = New System.Windows.Forms.GroupBox
        Me.cbSpeed = New System.Windows.Forms.ComboBox
        Me.cbPorts = New System.Windows.Forms.ComboBox
        Me.btPOpen = New System.Windows.Forms.Button
        Me.btScanComPort = New System.Windows.Forms.Button
        Me.gbRxLog = New System.Windows.Forms.GroupBox
        Me.btClearRxLog = New System.Windows.Forms.Button
        Me.tbLogRx = New System.Windows.Forms.TextBox
        Me.SerialPort1 = New System.IO.Ports.SerialPort(Me.components)
        Me.gbLogFile = New System.Windows.Forms.GroupBox
        Me.cbLogFile = New System.Windows.Forms.CheckBox
        Me.Timer1 = New System.Windows.Forms.Timer(Me.components)
        Me.OpenFileDialog1 = New System.Windows.Forms.OpenFileDialog
        Me.StatusStrip1 = New System.Windows.Forms.StatusStrip
        Me.tsslRxCounter = New System.Windows.Forms.ToolStripStatusLabel
        Me.tsslTxCounter = New System.Windows.Forms.ToolStripStatusLabel
        Me.tspbBar = New System.Windows.Forms.ToolStripProgressBar
        Me.Timer2 = New System.Windows.Forms.Timer(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.TabControl1 = New System.Windows.Forms.TabControl
        Me.TabPage1 = New System.Windows.Forms.TabPage
        Me.GroupBox8 = New System.Windows.Forms.GroupBox
        Me.btPresetGo = New System.Windows.Forms.Button
        Me.btPresetSet = New System.Windows.Forms.Button
        Me.NumUD_Preset = New System.Windows.Forms.NumericUpDown
        Me.GroupBox7 = New System.Windows.Forms.GroupBox
        Me.tbCamFocusFAR = New System.Windows.Forms.Button
        Me.tbCamFocusNEAR = New System.Windows.Forms.Button
        Me.GroupBox6 = New System.Windows.Forms.GroupBox
        Me.tbCamZoomWIDE = New System.Windows.Forms.Button
        Me.tbCamZoomTELE = New System.Windows.Forms.Button
        Me.tb_CamZoom = New System.Windows.Forms.TrackBar
        Me.Label10 = New System.Windows.Forms.Label
        Me.tb_SetCameraZoom = New System.Windows.Forms.TextBox
        Me.btCamQueryZoom = New System.Windows.Forms.Button
        Me.btCamSetZoom = New System.Windows.Forms.Button
        Me.GroupBox2 = New System.Windows.Forms.GroupBox
        Me.Label9 = New System.Windows.Forms.Label
        Me.Label8 = New System.Windows.Forms.Label
        Me.mtb_DAT2 = New System.Windows.Forms.MaskedTextBox
        Me.mtb_DAT1 = New System.Windows.Forms.MaskedTextBox
        Me.TrackBar_DAT2 = New System.Windows.Forms.TrackBar
        Me.TrackBar_DAT1 = New System.Windows.Forms.TrackBar
        Me.GroupBox4 = New System.Windows.Forms.GroupBox
        Me.cb_CMD2_Always_0 = New System.Windows.Forms.CheckBox
        Me.cb_CMD2_Rigth = New System.Windows.Forms.CheckBox
        Me.cb_CMD2_Left = New System.Windows.Forms.CheckBox
        Me.cb_CMD2_Up = New System.Windows.Forms.CheckBox
        Me.cb_CMD2_Down = New System.Windows.Forms.CheckBox
        Me.cb_CMD2_Zoom_Tele = New System.Windows.Forms.CheckBox
        Me.cb_CMD2_Zoom_Wide = New System.Windows.Forms.CheckBox
        Me.cb_CMD2_Focus_Far = New System.Windows.Forms.CheckBox
        Me.GroupBox3 = New System.Windows.Forms.GroupBox
        Me.cb_CMD1_Focus_near = New System.Windows.Forms.CheckBox
        Me.cb_CMD1_Iris_open = New System.Windows.Forms.CheckBox
        Me.cb_CMD1_Iris_close = New System.Windows.Forms.CheckBox
        Me.cb_CMD1_Camera_on_off = New System.Windows.Forms.CheckBox
        Me.cb_CMD1_Auto_Manual_scan = New System.Windows.Forms.CheckBox
        Me.cb_CMD1_reserv5 = New System.Windows.Forms.CheckBox
        Me.cb_CMD1_reserv6 = New System.Windows.Forms.CheckBox
        Me.cb_CMD1_Sense = New System.Windows.Forms.CheckBox
        Me.bt_Send_Packet_Pelco_D_zero = New System.Windows.Forms.Button
        Me.bt_Send_Packet_Pelco_D_ = New System.Windows.Forms.Button
        Me.Label7 = New System.Windows.Forms.Label
        Me.Label6 = New System.Windows.Forms.Label
        Me.Label5 = New System.Windows.Forms.Label
        Me.Label4 = New System.Windows.Forms.Label
        Me.Label3 = New System.Windows.Forms.Label
        Me.Label2 = New System.Windows.Forms.Label
        Me.Label1 = New System.Windows.Forms.Label
        Me.mtb_PACKET_CRC = New System.Windows.Forms.MaskedTextBox
        Me.mtb_PACKET_DAT2 = New System.Windows.Forms.MaskedTextBox
        Me.mtb_PACKET_DAT1 = New System.Windows.Forms.MaskedTextBox
        Me.mtb_PACKET_CMD2 = New System.Windows.Forms.MaskedTextBox
        Me.mtb_PACKET_CMD1 = New System.Windows.Forms.MaskedTextBox
        Me.mtb_PACKET_ADR = New System.Windows.Forms.MaskedTextBox
        Me.mtb_PACKET_HEAD = New System.Windows.Forms.MaskedTextBox
        Me.GroupBox1 = New System.Windows.Forms.GroupBox
        Me.bt_Query_Pan = New System.Windows.Forms.Button
        Me.bt_QueryTilt = New System.Windows.Forms.Button
        Me.Label12 = New System.Windows.Forms.Label
        Me.Label11 = New System.Windows.Forms.Label
        Me.tb_CamSpeed_Num = New System.Windows.Forms.TextBox
        Me.tb_CamMovsSpeed = New System.Windows.Forms.TrackBar
        Me.btCamMoveSTOP = New System.Windows.Forms.Button
        Me.btCamMoveDOWNRIGHT = New System.Windows.Forms.Button
        Me.btCamMoveUPLEFT = New System.Windows.Forms.Button
        Me.btCamMoveDOWN = New System.Windows.Forms.Button
        Me.btCamMoveUP = New System.Windows.Forms.Button
        Me.btCamMoveDOWNLEFT = New System.Windows.Forms.Button
        Me.btCamMoveUPRIGHT = New System.Windows.Forms.Button
        Me.btCamMoveRIGTH = New System.Windows.Forms.Button
        Me.btCamMoveLEFT = New System.Windows.Forms.Button
        Me.TabPage2 = New System.Windows.Forms.TabPage
        Me.GroupBox5 = New System.Windows.Forms.GroupBox
        Me.mtb_Camera_Adr = New System.Windows.Forms.MaskedTextBox
        Me.bt_Load_TXT_File = New System.Windows.Forms.Button
        Me.tbFileSendN = New System.Windows.Forms.TextBox
        Me.lblFileSendN = New System.Windows.Forms.Label
        Me.gbPort.SuspendLayout()
        Me.gbRxLog.SuspendLayout()
        Me.gbLogFile.SuspendLayout()
        Me.StatusStrip1.SuspendLayout()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.GroupBox8.SuspendLayout()
        CType(Me.NumUD_Preset, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox7.SuspendLayout()
        Me.GroupBox6.SuspendLayout()
        CType(Me.tb_CamZoom, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox2.SuspendLayout()
        CType(Me.TrackBar_DAT2, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.TrackBar_DAT1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox4.SuspendLayout()
        Me.GroupBox3.SuspendLayout()
        Me.GroupBox1.SuspendLayout()
        CType(Me.tb_CamMovsSpeed, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.GroupBox5.SuspendLayout()
        Me.SuspendLayout()
        '
        'gbPort
        '
        Me.gbPort.Controls.Add(Me.cbSpeed)
        Me.gbPort.Controls.Add(Me.cbPorts)
        Me.gbPort.Controls.Add(Me.btPOpen)
        Me.gbPort.Controls.Add(Me.btScanComPort)
        Me.gbPort.Location = New System.Drawing.Point(12, 6)
        Me.gbPort.Name = "gbPort"
        Me.gbPort.Size = New System.Drawing.Size(148, 94)
        Me.gbPort.TabIndex = 0
        Me.gbPort.TabStop = False
        Me.gbPort.Text = "COM Порт"
        '
        'cbSpeed
        '
        Me.cbSpeed.FormattingEnabled = True
        Me.cbSpeed.Items.AddRange(New Object() {"2400", "4800", "9600", "19200", "38400", "57600", "115200"})
        Me.cbSpeed.Location = New System.Drawing.Point(8, 69)
        Me.cbSpeed.Name = "cbSpeed"
        Me.cbSpeed.Size = New System.Drawing.Size(58, 21)
        Me.cbSpeed.TabIndex = 3
        Me.cbSpeed.Tag = ""
        '
        'cbPorts
        '
        Me.cbPorts.FormattingEnabled = True
        Me.cbPorts.Location = New System.Drawing.Point(8, 42)
        Me.cbPorts.Name = "cbPorts"
        Me.cbPorts.Size = New System.Drawing.Size(58, 21)
        Me.cbPorts.TabIndex = 2
        Me.ToolTip1.SetToolTip(Me.cbPorts, "Выберите СОМ порт с которым собираетесь работать.")
        '
        'btPOpen
        '
        Me.btPOpen.Location = New System.Drawing.Point(72, 15)
        Me.btPOpen.Name = "btPOpen"
        Me.btPOpen.Size = New System.Drawing.Size(70, 73)
        Me.btPOpen.TabIndex = 1
        Me.btPOpen.Text = "Открыть"
        Me.ToolTip1.SetToolTip(Me.btPOpen, "Открытие/Закрытие СОМ порта.")
        Me.btPOpen.UseVisualStyleBackColor = True
        '
        'btScanComPort
        '
        Me.btScanComPort.Location = New System.Drawing.Point(8, 15)
        Me.btScanComPort.Name = "btScanComPort"
        Me.btScanComPort.Size = New System.Drawing.Size(58, 23)
        Me.btScanComPort.TabIndex = 0
        Me.btScanComPort.Text = "Поиск"
        Me.ToolTip1.SetToolTip(Me.btScanComPort, "Поиск СОМ портов в системе. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Вставили новый адаптер USB-TO-COM  произведите поис" & _
                "к.")
        Me.btScanComPort.UseVisualStyleBackColor = True
        '
        'gbRxLog
        '
        Me.gbRxLog.Controls.Add(Me.btClearRxLog)
        Me.gbRxLog.Controls.Add(Me.tbLogRx)
        Me.gbRxLog.Location = New System.Drawing.Point(12, 106)
        Me.gbRxLog.Name = "gbRxLog"
        Me.gbRxLog.Size = New System.Drawing.Size(522, 664)
        Me.gbRxLog.TabIndex = 1
        Me.gbRxLog.TabStop = False
        Me.gbRxLog.Text = "Прием"
        '
        'btClearRxLog
        '
        Me.btClearRxLog.Location = New System.Drawing.Point(425, -10)
        Me.btClearRxLog.Name = "btClearRxLog"
        Me.btClearRxLog.Size = New System.Drawing.Size(75, 23)
        Me.btClearRxLog.TabIndex = 2
        Me.btClearRxLog.Text = "Очистка"
        Me.ToolTip1.SetToolTip(Me.btClearRxLog, "Очистка содержимого окна приема данных.")
        Me.btClearRxLog.UseVisualStyleBackColor = True
        '
        'tbLogRx
        '
        Me.tbLogRx.Font = New System.Drawing.Font("Lucida Console", 9.75!, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.tbLogRx.Location = New System.Drawing.Point(8, 19)
        Me.tbLogRx.MaxLength = 4096
        Me.tbLogRx.Multiline = True
        Me.tbLogRx.Name = "tbLogRx"
        Me.tbLogRx.ScrollBars = System.Windows.Forms.ScrollBars.Vertical
        Me.tbLogRx.Size = New System.Drawing.Size(507, 639)
        Me.tbLogRx.TabIndex = 0
        Me.ToolTip1.SetToolTip(Me.tbLogRx, "Окно приема данных. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Все принимаемые символы выводятся в данном поле. " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "Если кур" & _
                "сор находится в данном окне то все нажатые на " & Global.Microsoft.VisualBasic.ChrW(13) & Global.Microsoft.VisualBasic.ChrW(10) & "клавиатуре символы будут отправл" & _
                "ятся в СОМ порт.")
        '
        'SerialPort1
        '
        Me.SerialPort1.BaudRate = 115200
        '
        'gbLogFile
        '
        Me.gbLogFile.Controls.Add(Me.cbLogFile)
        Me.gbLogFile.Location = New System.Drawing.Point(166, 12)
        Me.gbLogFile.Name = "gbLogFile"
        Me.gbLogFile.Size = New System.Drawing.Size(117, 40)
        Me.gbLogFile.TabIndex = 5
        Me.gbLogFile.TabStop = False
        Me.gbLogFile.Text = "Лог файл"
        '
        'cbLogFile
        '
        Me.cbLogFile.AutoSize = True
        Me.cbLogFile.Location = New System.Drawing.Point(6, 22)
        Me.cbLogFile.Name = "cbLogFile"
        Me.cbLogFile.Size = New System.Drawing.Size(112, 17)
        Me.cbLogFile.TabIndex = 0
        Me.cbLogFile.Text = "Записать в файл"
        Me.ToolTip1.SetToolTip(Me.cbLogFile, "Запись всех принятых байт в файл (для последующего анализа)")
        Me.cbLogFile.UseVisualStyleBackColor = True
        '
        'Timer1
        '
        Me.Timer1.Enabled = True
        Me.Timer1.Interval = 10
        '
        'OpenFileDialog1
        '
        Me.OpenFileDialog1.FileName = "OpenFileDialog1"
        '
        'StatusStrip1
        '
        Me.StatusStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.tsslRxCounter, Me.tsslTxCounter, Me.tspbBar})
        Me.StatusStrip1.Location = New System.Drawing.Point(0, 772)
        Me.StatusStrip1.Name = "StatusStrip1"
        Me.StatusStrip1.Size = New System.Drawing.Size(994, 24)
        Me.StatusStrip1.TabIndex = 9
        Me.StatusStrip1.Text = "StatusStrip1"
        '
        'tsslRxCounter
        '
        Me.tsslRxCounter.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslRxCounter.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tsslRxCounter.Name = "tsslRxCounter"
        Me.tsslRxCounter.Size = New System.Drawing.Size(28, 19)
        Me.tsslRxCounter.Text = "RX:"
        '
        'tsslTxCounter
        '
        Me.tsslTxCounter.BorderSides = CType((System.Windows.Forms.ToolStripStatusLabelBorderSides.Left Or System.Windows.Forms.ToolStripStatusLabelBorderSides.Right), System.Windows.Forms.ToolStripStatusLabelBorderSides)
        Me.tsslTxCounter.BorderStyle = System.Windows.Forms.Border3DStyle.Etched
        Me.tsslTxCounter.Name = "tsslTxCounter"
        Me.tsslTxCounter.Size = New System.Drawing.Size(28, 19)
        Me.tsslTxCounter.Text = "TX:"
        '
        'tspbBar
        '
        Me.tspbBar.Name = "tspbBar"
        Me.tspbBar.Size = New System.Drawing.Size(100, 18)
        '
        'Timer2
        '
        Me.Timer2.Interval = 1000
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(540, 106)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(454, 663)
        Me.TabControl1.TabIndex = 11
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.GroupBox8)
        Me.TabPage1.Controls.Add(Me.GroupBox7)
        Me.TabPage1.Controls.Add(Me.GroupBox6)
        Me.TabPage1.Controls.Add(Me.GroupBox2)
        Me.TabPage1.Controls.Add(Me.GroupBox1)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(446, 637)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "Pelco-D"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'GroupBox8
        '
        Me.GroupBox8.Controls.Add(Me.btPresetGo)
        Me.GroupBox8.Controls.Add(Me.btPresetSet)
        Me.GroupBox8.Controls.Add(Me.NumUD_Preset)
        Me.GroupBox8.Location = New System.Drawing.Point(307, 88)
        Me.GroupBox8.Name = "GroupBox8"
        Me.GroupBox8.Size = New System.Drawing.Size(128, 104)
        Me.GroupBox8.TabIndex = 13
        Me.GroupBox8.TabStop = False
        Me.GroupBox8.Text = "Preset"
        '
        'btPresetGo
        '
        Me.btPresetGo.Location = New System.Drawing.Point(6, 70)
        Me.btPresetGo.Name = "btPresetGo"
        Me.btPresetGo.Size = New System.Drawing.Size(116, 30)
        Me.btPresetGo.TabIndex = 2
        Me.btPresetGo.Text = "Go"
        Me.btPresetGo.UseVisualStyleBackColor = True
        '
        'btPresetSet
        '
        Me.btPresetSet.Location = New System.Drawing.Point(6, 42)
        Me.btPresetSet.Name = "btPresetSet"
        Me.btPresetSet.Size = New System.Drawing.Size(116, 30)
        Me.btPresetSet.TabIndex = 1
        Me.btPresetSet.Text = "Set"
        Me.btPresetSet.UseVisualStyleBackColor = True
        '
        'NumUD_Preset
        '
        Me.NumUD_Preset.Location = New System.Drawing.Point(6, 19)
        Me.NumUD_Preset.Maximum = New Decimal(New Integer() {255, 0, 0, 0})
        Me.NumUD_Preset.Name = "NumUD_Preset"
        Me.NumUD_Preset.Size = New System.Drawing.Size(116, 20)
        Me.NumUD_Preset.TabIndex = 0
        '
        'GroupBox7
        '
        Me.GroupBox7.Controls.Add(Me.tbCamFocusFAR)
        Me.GroupBox7.Controls.Add(Me.tbCamFocusNEAR)
        Me.GroupBox7.Location = New System.Drawing.Point(308, 12)
        Me.GroupBox7.Name = "GroupBox7"
        Me.GroupBox7.Size = New System.Drawing.Size(130, 77)
        Me.GroupBox7.TabIndex = 12
        Me.GroupBox7.TabStop = False
        Me.GroupBox7.Text = "FOCUS"
        '
        'tbCamFocusFAR
        '
        Me.tbCamFocusFAR.Location = New System.Drawing.Point(71, 19)
        Me.tbCamFocusFAR.Name = "tbCamFocusFAR"
        Me.tbCamFocusFAR.Size = New System.Drawing.Size(53, 51)
        Me.tbCamFocusFAR.TabIndex = 1
        Me.tbCamFocusFAR.Text = "Far"
        Me.tbCamFocusFAR.UseVisualStyleBackColor = True
        '
        'tbCamFocusNEAR
        '
        Me.tbCamFocusNEAR.Location = New System.Drawing.Point(6, 19)
        Me.tbCamFocusNEAR.Name = "tbCamFocusNEAR"
        Me.tbCamFocusNEAR.Size = New System.Drawing.Size(53, 51)
        Me.tbCamFocusNEAR.TabIndex = 0
        Me.tbCamFocusNEAR.Text = "Near"
        Me.tbCamFocusNEAR.UseVisualStyleBackColor = True
        '
        'GroupBox6
        '
        Me.GroupBox6.Controls.Add(Me.tbCamZoomWIDE)
        Me.GroupBox6.Controls.Add(Me.tbCamZoomTELE)
        Me.GroupBox6.Controls.Add(Me.tb_CamZoom)
        Me.GroupBox6.Controls.Add(Me.Label10)
        Me.GroupBox6.Controls.Add(Me.tb_SetCameraZoom)
        Me.GroupBox6.Controls.Add(Me.btCamQueryZoom)
        Me.GroupBox6.Controls.Add(Me.btCamSetZoom)
        Me.GroupBox6.Location = New System.Drawing.Point(6, 192)
        Me.GroupBox6.Name = "GroupBox6"
        Me.GroupBox6.Size = New System.Drawing.Size(429, 94)
        Me.GroupBox6.TabIndex = 11
        Me.GroupBox6.TabStop = False
        Me.GroupBox6.Text = "ZOOM"
        '
        'tbCamZoomWIDE
        '
        Me.tbCamZoomWIDE.Location = New System.Drawing.Point(370, 13)
        Me.tbCamZoomWIDE.Name = "tbCamZoomWIDE"
        Me.tbCamZoomWIDE.Size = New System.Drawing.Size(53, 51)
        Me.tbCamZoomWIDE.TabIndex = 21
        Me.tbCamZoomWIDE.Text = "Wide"
        Me.tbCamZoomWIDE.UseVisualStyleBackColor = True
        '
        'tbCamZoomTELE
        '
        Me.tbCamZoomTELE.Location = New System.Drawing.Point(308, 13)
        Me.tbCamZoomTELE.Name = "tbCamZoomTELE"
        Me.tbCamZoomTELE.Size = New System.Drawing.Size(53, 51)
        Me.tbCamZoomTELE.TabIndex = 20
        Me.tbCamZoomTELE.Text = "Tele"
        Me.tbCamZoomTELE.UseVisualStyleBackColor = True
        '
        'tb_CamZoom
        '
        Me.tb_CamZoom.Location = New System.Drawing.Point(9, 13)
        Me.tb_CamZoom.Maximum = 16384
        Me.tb_CamZoom.Name = "tb_CamZoom"
        Me.tb_CamZoom.Size = New System.Drawing.Size(286, 45)
        Me.tb_CamZoom.TabIndex = 19
        '
        'Label10
        '
        Me.Label10.AutoSize = True
        Me.Label10.Location = New System.Drawing.Point(10, 67)
        Me.Label10.Name = "Label10"
        Me.Label10.Size = New System.Drawing.Size(46, 13)
        Me.Label10.TabIndex = 3
        Me.Label10.Text = "0-16384"
        '
        'tb_SetCameraZoom
        '
        Me.tb_SetCameraZoom.Location = New System.Drawing.Point(62, 64)
        Me.tb_SetCameraZoom.Name = "tb_SetCameraZoom"
        Me.tb_SetCameraZoom.Size = New System.Drawing.Size(57, 20)
        Me.tb_SetCameraZoom.TabIndex = 2
        Me.tb_SetCameraZoom.Text = "8192"
        Me.tb_SetCameraZoom.TextAlign = System.Windows.Forms.HorizontalAlignment.Right
        '
        'btCamQueryZoom
        '
        Me.btCamQueryZoom.Location = New System.Drawing.Point(216, 60)
        Me.btCamQueryZoom.Name = "btCamQueryZoom"
        Me.btCamQueryZoom.Size = New System.Drawing.Size(78, 27)
        Me.btCamQueryZoom.TabIndex = 1
        Me.btCamQueryZoom.Text = "Query Zoom"
        Me.btCamQueryZoom.UseVisualStyleBackColor = True
        '
        'btCamSetZoom
        '
        Me.btCamSetZoom.Location = New System.Drawing.Point(138, 60)
        Me.btCamSetZoom.Name = "btCamSetZoom"
        Me.btCamSetZoom.Size = New System.Drawing.Size(66, 27)
        Me.btCamSetZoom.TabIndex = 0
        Me.btCamSetZoom.Text = "Set Zoom"
        Me.btCamSetZoom.UseVisualStyleBackColor = True
        '
        'GroupBox2
        '
        Me.GroupBox2.Controls.Add(Me.Label9)
        Me.GroupBox2.Controls.Add(Me.Label8)
        Me.GroupBox2.Controls.Add(Me.mtb_DAT2)
        Me.GroupBox2.Controls.Add(Me.mtb_DAT1)
        Me.GroupBox2.Controls.Add(Me.TrackBar_DAT2)
        Me.GroupBox2.Controls.Add(Me.TrackBar_DAT1)
        Me.GroupBox2.Controls.Add(Me.GroupBox4)
        Me.GroupBox2.Controls.Add(Me.GroupBox3)
        Me.GroupBox2.Controls.Add(Me.bt_Send_Packet_Pelco_D_zero)
        Me.GroupBox2.Controls.Add(Me.bt_Send_Packet_Pelco_D_)
        Me.GroupBox2.Controls.Add(Me.Label7)
        Me.GroupBox2.Controls.Add(Me.Label6)
        Me.GroupBox2.Controls.Add(Me.Label5)
        Me.GroupBox2.Controls.Add(Me.Label4)
        Me.GroupBox2.Controls.Add(Me.Label3)
        Me.GroupBox2.Controls.Add(Me.Label2)
        Me.GroupBox2.Controls.Add(Me.Label1)
        Me.GroupBox2.Controls.Add(Me.mtb_PACKET_CRC)
        Me.GroupBox2.Controls.Add(Me.mtb_PACKET_DAT2)
        Me.GroupBox2.Controls.Add(Me.mtb_PACKET_DAT1)
        Me.GroupBox2.Controls.Add(Me.mtb_PACKET_CMD2)
        Me.GroupBox2.Controls.Add(Me.mtb_PACKET_CMD1)
        Me.GroupBox2.Controls.Add(Me.mtb_PACKET_ADR)
        Me.GroupBox2.Controls.Add(Me.mtb_PACKET_HEAD)
        Me.GroupBox2.Location = New System.Drawing.Point(6, 285)
        Me.GroupBox2.Name = "GroupBox2"
        Me.GroupBox2.Size = New System.Drawing.Size(300, 346)
        Me.GroupBox2.TabIndex = 10
        Me.GroupBox2.TabStop = False
        Me.GroupBox2.Text = "Пакет"
        '
        'Label9
        '
        Me.Label9.AutoSize = True
        Me.Label9.Location = New System.Drawing.Point(261, 217)
        Me.Label9.Name = "Label9"
        Me.Label9.Size = New System.Drawing.Size(35, 13)
        Me.Label9.TabIndex = 23
        Me.Label9.Text = "DAT2"
        '
        'Label8
        '
        Me.Label8.AutoSize = True
        Me.Label8.Location = New System.Drawing.Point(259, 167)
        Me.Label8.Name = "Label8"
        Me.Label8.Size = New System.Drawing.Size(35, 13)
        Me.Label8.TabIndex = 22
        Me.Label8.Text = "DAT1"
        '
        'mtb_DAT2
        '
        Me.mtb_DAT2.Location = New System.Drawing.Point(264, 243)
        Me.mtb_DAT2.Name = "mtb_DAT2"
        Me.mtb_DAT2.Size = New System.Drawing.Size(27, 20)
        Me.mtb_DAT2.TabIndex = 21
        Me.mtb_DAT2.Text = "00"
        '
        'mtb_DAT1
        '
        Me.mtb_DAT1.Location = New System.Drawing.Point(264, 192)
        Me.mtb_DAT1.Name = "mtb_DAT1"
        Me.mtb_DAT1.Size = New System.Drawing.Size(27, 20)
        Me.mtb_DAT1.TabIndex = 20
        Me.mtb_DAT1.Text = "00"
        '
        'TrackBar_DAT2
        '
        Me.TrackBar_DAT2.Location = New System.Drawing.Point(13, 218)
        Me.TrackBar_DAT2.Maximum = 255
        Me.TrackBar_DAT2.Name = "TrackBar_DAT2"
        Me.TrackBar_DAT2.Size = New System.Drawing.Size(242, 45)
        Me.TrackBar_DAT2.TabIndex = 19
        '
        'TrackBar_DAT1
        '
        Me.TrackBar_DAT1.Location = New System.Drawing.Point(13, 167)
        Me.TrackBar_DAT1.Maximum = 255
        Me.TrackBar_DAT1.Name = "TrackBar_DAT1"
        Me.TrackBar_DAT1.Size = New System.Drawing.Size(242, 45)
        Me.TrackBar_DAT1.TabIndex = 18
        '
        'GroupBox4
        '
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Always_0)
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Rigth)
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Left)
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Up)
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Down)
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Zoom_Tele)
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Zoom_Wide)
        Me.GroupBox4.Controls.Add(Me.cb_CMD2_Focus_Far)
        Me.GroupBox4.Location = New System.Drawing.Point(157, 19)
        Me.GroupBox4.Name = "GroupBox4"
        Me.GroupBox4.Size = New System.Drawing.Size(139, 142)
        Me.GroupBox4.TabIndex = 17
        Me.GroupBox4.TabStop = False
        Me.GroupBox4.Text = "CMD 2"
        '
        'cb_CMD2_Always_0
        '
        Me.cb_CMD2_Always_0.AutoSize = True
        Me.cb_CMD2_Always_0.Location = New System.Drawing.Point(6, 125)
        Me.cb_CMD2_Always_0.Name = "cb_CMD2_Always_0"
        Me.cb_CMD2_Always_0.Size = New System.Drawing.Size(83, 17)
        Me.cb_CMD2_Always_0.TabIndex = 15
        Me.cb_CMD2_Always_0.Text = "0 - Always 0"
        Me.cb_CMD2_Always_0.UseVisualStyleBackColor = True
        '
        'cb_CMD2_Rigth
        '
        Me.cb_CMD2_Rigth.AutoSize = True
        Me.cb_CMD2_Rigth.Location = New System.Drawing.Point(6, 110)
        Me.cb_CMD2_Rigth.Name = "cb_CMD2_Rigth"
        Me.cb_CMD2_Rigth.Size = New System.Drawing.Size(66, 17)
        Me.cb_CMD2_Rigth.TabIndex = 14
        Me.cb_CMD2_Rigth.Text = "1 - Right"
        Me.cb_CMD2_Rigth.UseVisualStyleBackColor = True
        '
        'cb_CMD2_Left
        '
        Me.cb_CMD2_Left.AutoSize = True
        Me.cb_CMD2_Left.Location = New System.Drawing.Point(6, 95)
        Me.cb_CMD2_Left.Name = "cb_CMD2_Left"
        Me.cb_CMD2_Left.Size = New System.Drawing.Size(59, 17)
        Me.cb_CMD2_Left.TabIndex = 13
        Me.cb_CMD2_Left.Text = "2 - Left"
        Me.cb_CMD2_Left.UseVisualStyleBackColor = True
        '
        'cb_CMD2_Up
        '
        Me.cb_CMD2_Up.AutoSize = True
        Me.cb_CMD2_Up.Location = New System.Drawing.Point(6, 80)
        Me.cb_CMD2_Up.Name = "cb_CMD2_Up"
        Me.cb_CMD2_Up.Size = New System.Drawing.Size(55, 17)
        Me.cb_CMD2_Up.TabIndex = 12
        Me.cb_CMD2_Up.Text = "3 - Up"
        Me.cb_CMD2_Up.UseVisualStyleBackColor = True
        '
        'cb_CMD2_Down
        '
        Me.cb_CMD2_Down.AutoSize = True
        Me.cb_CMD2_Down.Location = New System.Drawing.Point(6, 65)
        Me.cb_CMD2_Down.Name = "cb_CMD2_Down"
        Me.cb_CMD2_Down.Size = New System.Drawing.Size(69, 17)
        Me.cb_CMD2_Down.TabIndex = 11
        Me.cb_CMD2_Down.Text = "4 - Down"
        Me.cb_CMD2_Down.UseVisualStyleBackColor = True
        '
        'cb_CMD2_Zoom_Tele
        '
        Me.cb_CMD2_Zoom_Tele.AutoSize = True
        Me.cb_CMD2_Zoom_Tele.Location = New System.Drawing.Point(6, 50)
        Me.cb_CMD2_Zoom_Tele.Name = "cb_CMD2_Zoom_Tele"
        Me.cb_CMD2_Zoom_Tele.Size = New System.Drawing.Size(92, 17)
        Me.cb_CMD2_Zoom_Tele.TabIndex = 10
        Me.cb_CMD2_Zoom_Tele.Text = "5 - Zoom Tele"
        Me.cb_CMD2_Zoom_Tele.UseVisualStyleBackColor = True
        '
        'cb_CMD2_Zoom_Wide
        '
        Me.cb_CMD2_Zoom_Wide.AutoSize = True
        Me.cb_CMD2_Zoom_Wide.Location = New System.Drawing.Point(6, 35)
        Me.cb_CMD2_Zoom_Wide.Name = "cb_CMD2_Zoom_Wide"
        Me.cb_CMD2_Zoom_Wide.Size = New System.Drawing.Size(96, 17)
        Me.cb_CMD2_Zoom_Wide.TabIndex = 9
        Me.cb_CMD2_Zoom_Wide.Text = "6 - Zoom Wide"
        Me.cb_CMD2_Zoom_Wide.UseVisualStyleBackColor = True
        '
        'cb_CMD2_Focus_Far
        '
        Me.cb_CMD2_Focus_Far.AutoSize = True
        Me.cb_CMD2_Focus_Far.Location = New System.Drawing.Point(6, 19)
        Me.cb_CMD2_Focus_Far.Name = "cb_CMD2_Focus_Far"
        Me.cb_CMD2_Focus_Far.Size = New System.Drawing.Size(88, 17)
        Me.cb_CMD2_Focus_Far.TabIndex = 8
        Me.cb_CMD2_Focus_Far.Text = "7 - Focus Far"
        Me.cb_CMD2_Focus_Far.UseVisualStyleBackColor = True
        '
        'GroupBox3
        '
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_Focus_near)
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_Iris_open)
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_Iris_close)
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_Camera_on_off)
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_Auto_Manual_scan)
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_reserv5)
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_reserv6)
        Me.GroupBox3.Controls.Add(Me.cb_CMD1_Sense)
        Me.GroupBox3.Location = New System.Drawing.Point(11, 20)
        Me.GroupBox3.Name = "GroupBox3"
        Me.GroupBox3.Size = New System.Drawing.Size(140, 141)
        Me.GroupBox3.TabIndex = 16
        Me.GroupBox3.TabStop = False
        Me.GroupBox3.Text = "CMD 1"
        '
        'cb_CMD1_Focus_near
        '
        Me.cb_CMD1_Focus_near.AutoSize = True
        Me.cb_CMD1_Focus_near.Location = New System.Drawing.Point(6, 124)
        Me.cb_CMD1_Focus_near.Name = "cb_CMD1_Focus_near"
        Me.cb_CMD1_Focus_near.Size = New System.Drawing.Size(96, 17)
        Me.cb_CMD1_Focus_near.TabIndex = 7
        Me.cb_CMD1_Focus_near.Text = "0 - Focus Near"
        Me.cb_CMD1_Focus_near.UseVisualStyleBackColor = True
        '
        'cb_CMD1_Iris_open
        '
        Me.cb_CMD1_Iris_open.AutoSize = True
        Me.cb_CMD1_Iris_open.Location = New System.Drawing.Point(6, 109)
        Me.cb_CMD1_Iris_open.Name = "cb_CMD1_Iris_open"
        Me.cb_CMD1_Iris_open.Size = New System.Drawing.Size(83, 17)
        Me.cb_CMD1_Iris_open.TabIndex = 6
        Me.cb_CMD1_Iris_open.Text = "1 - Iris Open"
        Me.cb_CMD1_Iris_open.UseVisualStyleBackColor = True
        '
        'cb_CMD1_Iris_close
        '
        Me.cb_CMD1_Iris_close.AutoSize = True
        Me.cb_CMD1_Iris_close.Location = New System.Drawing.Point(6, 94)
        Me.cb_CMD1_Iris_close.Name = "cb_CMD1_Iris_close"
        Me.cb_CMD1_Iris_close.Size = New System.Drawing.Size(83, 17)
        Me.cb_CMD1_Iris_close.TabIndex = 5
        Me.cb_CMD1_Iris_close.Text = "2 - Iris Close"
        Me.cb_CMD1_Iris_close.UseVisualStyleBackColor = True
        '
        'cb_CMD1_Camera_on_off
        '
        Me.cb_CMD1_Camera_on_off.AutoSize = True
        Me.cb_CMD1_Camera_on_off.Location = New System.Drawing.Point(6, 79)
        Me.cb_CMD1_Camera_on_off.Name = "cb_CMD1_Camera_on_off"
        Me.cb_CMD1_Camera_on_off.Size = New System.Drawing.Size(119, 17)
        Me.cb_CMD1_Camera_on_off.TabIndex = 4
        Me.cb_CMD1_Camera_on_off.Text = "3 - Camera On/OFF"
        Me.cb_CMD1_Camera_on_off.UseVisualStyleBackColor = True
        '
        'cb_CMD1_Auto_Manual_scan
        '
        Me.cb_CMD1_Auto_Manual_scan.AutoSize = True
        Me.cb_CMD1_Auto_Manual_scan.Location = New System.Drawing.Point(6, 64)
        Me.cb_CMD1_Auto_Manual_scan.Name = "cb_CMD1_Auto_Manual_scan"
        Me.cb_CMD1_Auto_Manual_scan.Size = New System.Drawing.Size(129, 17)
        Me.cb_CMD1_Auto_Manual_scan.TabIndex = 3
        Me.cb_CMD1_Auto_Manual_scan.Text = "4 - Auto/Manual scan"
        Me.cb_CMD1_Auto_Manual_scan.UseVisualStyleBackColor = True
        '
        'cb_CMD1_reserv5
        '
        Me.cb_CMD1_reserv5.AutoSize = True
        Me.cb_CMD1_reserv5.Location = New System.Drawing.Point(6, 49)
        Me.cb_CMD1_reserv5.Name = "cb_CMD1_reserv5"
        Me.cb_CMD1_reserv5.Size = New System.Drawing.Size(75, 17)
        Me.cb_CMD1_reserv5.TabIndex = 2
        Me.cb_CMD1_reserv5.Text = "5 - Reserv"
        Me.cb_CMD1_reserv5.UseVisualStyleBackColor = True
        '
        'cb_CMD1_reserv6
        '
        Me.cb_CMD1_reserv6.AutoSize = True
        Me.cb_CMD1_reserv6.Location = New System.Drawing.Point(6, 34)
        Me.cb_CMD1_reserv6.Name = "cb_CMD1_reserv6"
        Me.cb_CMD1_reserv6.Size = New System.Drawing.Size(75, 17)
        Me.cb_CMD1_reserv6.TabIndex = 1
        Me.cb_CMD1_reserv6.Text = "6 - Reserv"
        Me.cb_CMD1_reserv6.UseVisualStyleBackColor = True
        '
        'cb_CMD1_Sense
        '
        Me.cb_CMD1_Sense.AutoSize = True
        Me.cb_CMD1_Sense.Location = New System.Drawing.Point(6, 19)
        Me.cb_CMD1_Sense.Name = "cb_CMD1_Sense"
        Me.cb_CMD1_Sense.Size = New System.Drawing.Size(71, 17)
        Me.cb_CMD1_Sense.TabIndex = 0
        Me.cb_CMD1_Sense.Text = "7 - Sense"
        Me.cb_CMD1_Sense.UseVisualStyleBackColor = True
        '
        'bt_Send_Packet_Pelco_D_zero
        '
        Me.bt_Send_Packet_Pelco_D_zero.Location = New System.Drawing.Point(5, 308)
        Me.bt_Send_Packet_Pelco_D_zero.Name = "bt_Send_Packet_Pelco_D_zero"
        Me.bt_Send_Packet_Pelco_D_zero.Size = New System.Drawing.Size(130, 33)
        Me.bt_Send_Packet_Pelco_D_zero.TabIndex = 15
        Me.bt_Send_Packet_Pelco_D_zero.Text = "Отправка Пуст. пакет"
        Me.bt_Send_Packet_Pelco_D_zero.UseVisualStyleBackColor = True
        '
        'bt_Send_Packet_Pelco_D_
        '
        Me.bt_Send_Packet_Pelco_D_.Location = New System.Drawing.Point(163, 308)
        Me.bt_Send_Packet_Pelco_D_.Name = "bt_Send_Packet_Pelco_D_"
        Me.bt_Send_Packet_Pelco_D_.Size = New System.Drawing.Size(131, 33)
        Me.bt_Send_Packet_Pelco_D_.TabIndex = 14
        Me.bt_Send_Packet_Pelco_D_.Text = "Отправка пакета"
        Me.bt_Send_Packet_Pelco_D_.UseVisualStyleBackColor = True
        '
        'Label7
        '
        Me.Label7.AutoSize = True
        Me.Label7.Location = New System.Drawing.Point(267, 266)
        Me.Label7.Name = "Label7"
        Me.Label7.Size = New System.Drawing.Size(31, 13)
        Me.Label7.TabIndex = 13
        Me.Label7.Text = "SUM"
        '
        'Label6
        '
        Me.Label6.AutoSize = True
        Me.Label6.Location = New System.Drawing.Point(223, 266)
        Me.Label6.Name = "Label6"
        Me.Label6.Size = New System.Drawing.Size(35, 13)
        Me.Label6.TabIndex = 12
        Me.Label6.Text = "DAT2"
        '
        'Label5
        '
        Me.Label5.AutoSize = True
        Me.Label5.Location = New System.Drawing.Point(179, 266)
        Me.Label5.Name = "Label5"
        Me.Label5.Size = New System.Drawing.Size(35, 13)
        Me.Label5.TabIndex = 11
        Me.Label5.Text = "DAT1"
        '
        'Label4
        '
        Me.Label4.AutoSize = True
        Me.Label4.Location = New System.Drawing.Point(135, 266)
        Me.Label4.Name = "Label4"
        Me.Label4.Size = New System.Drawing.Size(37, 13)
        Me.Label4.TabIndex = 10
        Me.Label4.Text = "CMD2"
        '
        'Label3
        '
        Me.Label3.AutoSize = True
        Me.Label3.Location = New System.Drawing.Point(91, 266)
        Me.Label3.Name = "Label3"
        Me.Label3.Size = New System.Drawing.Size(37, 13)
        Me.Label3.TabIndex = 9
        Me.Label3.Text = "CMD1"
        '
        'Label2
        '
        Me.Label2.AutoSize = True
        Me.Label2.Location = New System.Drawing.Point(47, 266)
        Me.Label2.Name = "Label2"
        Me.Label2.Size = New System.Drawing.Size(30, 13)
        Me.Label2.TabIndex = 8
        Me.Label2.Text = "ADR"
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(6, 266)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(37, 13)
        Me.Label1.TabIndex = 7
        Me.Label1.Text = "HEAD"
        '
        'mtb_PACKET_CRC
        '
        Me.mtb_PACKET_CRC.Enabled = False
        Me.mtb_PACKET_CRC.Location = New System.Drawing.Point(269, 282)
        Me.mtb_PACKET_CRC.Name = "mtb_PACKET_CRC"
        Me.mtb_PACKET_CRC.Size = New System.Drawing.Size(22, 20)
        Me.mtb_PACKET_CRC.TabIndex = 6
        Me.mtb_PACKET_CRC.Text = "00"
        '
        'mtb_PACKET_DAT2
        '
        Me.mtb_PACKET_DAT2.Location = New System.Drawing.Point(225, 282)
        Me.mtb_PACKET_DAT2.Name = "mtb_PACKET_DAT2"
        Me.mtb_PACKET_DAT2.Size = New System.Drawing.Size(22, 20)
        Me.mtb_PACKET_DAT2.TabIndex = 5
        Me.mtb_PACKET_DAT2.Text = "00"
        '
        'mtb_PACKET_DAT1
        '
        Me.mtb_PACKET_DAT1.Location = New System.Drawing.Point(181, 282)
        Me.mtb_PACKET_DAT1.Name = "mtb_PACKET_DAT1"
        Me.mtb_PACKET_DAT1.Size = New System.Drawing.Size(22, 20)
        Me.mtb_PACKET_DAT1.TabIndex = 4
        Me.mtb_PACKET_DAT1.Text = "00"
        '
        'mtb_PACKET_CMD2
        '
        Me.mtb_PACKET_CMD2.Location = New System.Drawing.Point(137, 282)
        Me.mtb_PACKET_CMD2.Name = "mtb_PACKET_CMD2"
        Me.mtb_PACKET_CMD2.Size = New System.Drawing.Size(22, 20)
        Me.mtb_PACKET_CMD2.TabIndex = 3
        Me.mtb_PACKET_CMD2.Text = "00"
        '
        'mtb_PACKET_CMD1
        '
        Me.mtb_PACKET_CMD1.Location = New System.Drawing.Point(93, 282)
        Me.mtb_PACKET_CMD1.Name = "mtb_PACKET_CMD1"
        Me.mtb_PACKET_CMD1.Size = New System.Drawing.Size(22, 20)
        Me.mtb_PACKET_CMD1.TabIndex = 2
        Me.mtb_PACKET_CMD1.Text = "00"
        '
        'mtb_PACKET_ADR
        '
        Me.mtb_PACKET_ADR.Location = New System.Drawing.Point(49, 282)
        Me.mtb_PACKET_ADR.Name = "mtb_PACKET_ADR"
        Me.mtb_PACKET_ADR.Size = New System.Drawing.Size(22, 20)
        Me.mtb_PACKET_ADR.TabIndex = 1
        Me.mtb_PACKET_ADR.Text = "00"
        '
        'mtb_PACKET_HEAD
        '
        Me.mtb_PACKET_HEAD.Enabled = False
        Me.mtb_PACKET_HEAD.Location = New System.Drawing.Point(5, 282)
        Me.mtb_PACKET_HEAD.Name = "mtb_PACKET_HEAD"
        Me.mtb_PACKET_HEAD.Size = New System.Drawing.Size(22, 20)
        Me.mtb_PACKET_HEAD.TabIndex = 0
        Me.mtb_PACKET_HEAD.Text = "FF"
        '
        'GroupBox1
        '
        Me.GroupBox1.Controls.Add(Me.bt_Query_Pan)
        Me.GroupBox1.Controls.Add(Me.bt_QueryTilt)
        Me.GroupBox1.Controls.Add(Me.Label12)
        Me.GroupBox1.Controls.Add(Me.Label11)
        Me.GroupBox1.Controls.Add(Me.tb_CamSpeed_Num)
        Me.GroupBox1.Controls.Add(Me.tb_CamMovsSpeed)
        Me.GroupBox1.Controls.Add(Me.btCamMoveSTOP)
        Me.GroupBox1.Controls.Add(Me.btCamMoveDOWNRIGHT)
        Me.GroupBox1.Controls.Add(Me.btCamMoveUPLEFT)
        Me.GroupBox1.Controls.Add(Me.btCamMoveDOWN)
        Me.GroupBox1.Controls.Add(Me.btCamMoveUP)
        Me.GroupBox1.Controls.Add(Me.btCamMoveDOWNLEFT)
        Me.GroupBox1.Controls.Add(Me.btCamMoveUPRIGHT)
        Me.GroupBox1.Controls.Add(Me.btCamMoveRIGTH)
        Me.GroupBox1.Controls.Add(Me.btCamMoveLEFT)
        Me.GroupBox1.Location = New System.Drawing.Point(6, 6)
        Me.GroupBox1.Name = "GroupBox1"
        Me.GroupBox1.Size = New System.Drawing.Size(298, 186)
        Me.GroupBox1.TabIndex = 9
        Me.GroupBox1.TabStop = False
        Me.GroupBox1.Text = "Перемещение"
        '
        'bt_Query_Pan
        '
        Me.bt_Query_Pan.Location = New System.Drawing.Point(190, 73)
        Me.bt_Query_Pan.Name = "bt_Query_Pan"
        Me.bt_Query_Pan.Size = New System.Drawing.Size(47, 48)
        Me.bt_Query_Pan.TabIndex = 24
        Me.bt_Query_Pan.Text = "Q Pan"
        Me.bt_Query_Pan.UseVisualStyleBackColor = True
        '
        'bt_QueryTilt
        '
        Me.bt_QueryTilt.Location = New System.Drawing.Point(190, 19)
        Me.bt_QueryTilt.Name = "bt_QueryTilt"
        Me.bt_QueryTilt.Size = New System.Drawing.Size(47, 48)
        Me.bt_QueryTilt.TabIndex = 23
        Me.bt_QueryTilt.Text = "Q Tilt"
        Me.bt_QueryTilt.UseVisualStyleBackColor = True
        '
        'Label12
        '
        Me.Label12.AutoSize = True
        Me.Label12.Location = New System.Drawing.Point(240, 6)
        Me.Label12.Name = "Label12"
        Me.Label12.Size = New System.Drawing.Size(55, 13)
        Me.Label12.TabIndex = 22
        Me.Label12.Text = "Скорость"
        '
        'Label11
        '
        Me.Label11.AutoSize = True
        Me.Label11.Location = New System.Drawing.Point(257, 143)
        Me.Label11.Name = "Label11"
        Me.Label11.Size = New System.Drawing.Size(28, 13)
        Me.Label11.TabIndex = 21
        Me.Label11.Text = "1-63"
        '
        'tb_CamSpeed_Num
        '
        Me.tb_CamSpeed_Num.Location = New System.Drawing.Point(243, 159)
        Me.tb_CamSpeed_Num.Name = "tb_CamSpeed_Num"
        Me.tb_CamSpeed_Num.ReadOnly = True
        Me.tb_CamSpeed_Num.RightToLeft = System.Windows.Forms.RightToLeft.Yes
        Me.tb_CamSpeed_Num.Size = New System.Drawing.Size(47, 20)
        Me.tb_CamSpeed_Num.TabIndex = 20
        '
        'tb_CamMovsSpeed
        '
        Me.tb_CamMovsSpeed.Location = New System.Drawing.Point(243, 22)
        Me.tb_CamMovsSpeed.Maximum = 255
        Me.tb_CamMovsSpeed.Minimum = 1
        Me.tb_CamMovsSpeed.Name = "tb_CamMovsSpeed"
        Me.tb_CamMovsSpeed.Orientation = System.Windows.Forms.Orientation.Vertical
        Me.tb_CamMovsSpeed.Size = New System.Drawing.Size(45, 116)
        Me.tb_CamMovsSpeed.TabIndex = 19
        Me.tb_CamMovsSpeed.TickStyle = System.Windows.Forms.TickStyle.Both
        Me.tb_CamMovsSpeed.Value = 31
        '
        'btCamMoveSTOP
        '
        Me.btCamMoveSTOP.Location = New System.Drawing.Point(65, 73)
        Me.btCamMoveSTOP.Name = "btCamMoveSTOP"
        Me.btCamMoveSTOP.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveSTOP.TabIndex = 4
        Me.btCamMoveSTOP.Text = "СТОП"
        Me.btCamMoveSTOP.UseVisualStyleBackColor = True
        '
        'btCamMoveDOWNRIGHT
        '
        Me.btCamMoveDOWNRIGHT.Location = New System.Drawing.Point(121, 129)
        Me.btCamMoveDOWNRIGHT.Name = "btCamMoveDOWNRIGHT"
        Me.btCamMoveDOWNRIGHT.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveDOWNRIGHT.TabIndex = 8
        Me.btCamMoveDOWNRIGHT.Text = "Down-R"
        Me.btCamMoveDOWNRIGHT.UseVisualStyleBackColor = True
        '
        'btCamMoveUPLEFT
        '
        Me.btCamMoveUPLEFT.Location = New System.Drawing.Point(9, 17)
        Me.btCamMoveUPLEFT.Name = "btCamMoveUPLEFT"
        Me.btCamMoveUPLEFT.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveUPLEFT.TabIndex = 0
        Me.btCamMoveUPLEFT.Text = "Up-L"
        Me.btCamMoveUPLEFT.UseVisualStyleBackColor = True
        '
        'btCamMoveDOWN
        '
        Me.btCamMoveDOWN.Location = New System.Drawing.Point(65, 129)
        Me.btCamMoveDOWN.Name = "btCamMoveDOWN"
        Me.btCamMoveDOWN.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveDOWN.TabIndex = 7
        Me.btCamMoveDOWN.Text = "Down"
        Me.btCamMoveDOWN.UseVisualStyleBackColor = True
        '
        'btCamMoveUP
        '
        Me.btCamMoveUP.Location = New System.Drawing.Point(65, 17)
        Me.btCamMoveUP.Name = "btCamMoveUP"
        Me.btCamMoveUP.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveUP.TabIndex = 1
        Me.btCamMoveUP.Text = "Up"
        Me.btCamMoveUP.UseVisualStyleBackColor = True
        '
        'btCamMoveDOWNLEFT
        '
        Me.btCamMoveDOWNLEFT.Location = New System.Drawing.Point(9, 129)
        Me.btCamMoveDOWNLEFT.Name = "btCamMoveDOWNLEFT"
        Me.btCamMoveDOWNLEFT.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveDOWNLEFT.TabIndex = 6
        Me.btCamMoveDOWNLEFT.Text = "DOWN-L"
        Me.btCamMoveDOWNLEFT.UseVisualStyleBackColor = True
        '
        'btCamMoveUPRIGHT
        '
        Me.btCamMoveUPRIGHT.Location = New System.Drawing.Point(121, 17)
        Me.btCamMoveUPRIGHT.Name = "btCamMoveUPRIGHT"
        Me.btCamMoveUPRIGHT.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveUPRIGHT.TabIndex = 2
        Me.btCamMoveUPRIGHT.Text = "Up-R"
        Me.btCamMoveUPRIGHT.UseVisualStyleBackColor = True
        '
        'btCamMoveRIGTH
        '
        Me.btCamMoveRIGTH.Location = New System.Drawing.Point(121, 73)
        Me.btCamMoveRIGTH.Name = "btCamMoveRIGTH"
        Me.btCamMoveRIGTH.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveRIGTH.TabIndex = 5
        Me.btCamMoveRIGTH.Text = "Rigth"
        Me.btCamMoveRIGTH.UseVisualStyleBackColor = True
        '
        'btCamMoveLEFT
        '
        Me.btCamMoveLEFT.Location = New System.Drawing.Point(9, 73)
        Me.btCamMoveLEFT.Name = "btCamMoveLEFT"
        Me.btCamMoveLEFT.Size = New System.Drawing.Size(50, 50)
        Me.btCamMoveLEFT.TabIndex = 3
        Me.btCamMoveLEFT.Text = "Left"
        Me.btCamMoveLEFT.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(446, 637)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "Visca"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'GroupBox5
        '
        Me.GroupBox5.Controls.Add(Me.mtb_Camera_Adr)
        Me.GroupBox5.Location = New System.Drawing.Point(166, 58)
        Me.GroupBox5.Name = "GroupBox5"
        Me.GroupBox5.Size = New System.Drawing.Size(118, 42)
        Me.GroupBox5.TabIndex = 12
        Me.GroupBox5.TabStop = False
        Me.GroupBox5.Text = "Адрес камеры"
        '
        'mtb_Camera_Adr
        '
        Me.mtb_Camera_Adr.Location = New System.Drawing.Point(30, 16)
        Me.mtb_Camera_Adr.Name = "mtb_Camera_Adr"
        Me.mtb_Camera_Adr.Size = New System.Drawing.Size(27, 20)
        Me.mtb_Camera_Adr.TabIndex = 21
        Me.mtb_Camera_Adr.Text = "01"
        '
        'bt_Load_TXT_File
        '
        Me.bt_Load_TXT_File.Location = New System.Drawing.Point(866, 12)
        Me.bt_Load_TXT_File.Name = "bt_Load_TXT_File"
        Me.bt_Load_TXT_File.Size = New System.Drawing.Size(116, 39)
        Me.bt_Load_TXT_File.TabIndex = 13
        Me.bt_Load_TXT_File.Text = "Проиграть TXT файл сценария"
        Me.bt_Load_TXT_File.UseVisualStyleBackColor = True
        '
        'tbFileSendN
        '
        Me.tbFileSendN.Location = New System.Drawing.Point(814, 31)
        Me.tbFileSendN.Name = "tbFileSendN"
        Me.tbFileSendN.Size = New System.Drawing.Size(46, 20)
        Me.tbFileSendN.TabIndex = 14
        Me.tbFileSendN.Text = "1"
        '
        'lblFileSendN
        '
        Me.lblFileSendN.AutoSize = True
        Me.lblFileSendN.Location = New System.Drawing.Point(654, 34)
        Me.lblFileSendN.Name = "lblFileSendN"
        Me.lblFileSendN.Size = New System.Drawing.Size(155, 13)
        Me.lblFileSendN.TabIndex = 15
        Me.lblFileSendN.Text = "Сколько раз проиграть файл"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(994, 796)
        Me.Controls.Add(Me.lblFileSendN)
        Me.Controls.Add(Me.tbFileSendN)
        Me.Controls.Add(Me.bt_Load_TXT_File)
        Me.Controls.Add(Me.GroupBox5)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.StatusStrip1)
        Me.Controls.Add(Me.gbLogFile)
        Me.Controls.Add(Me.gbRxLog)
        Me.Controls.Add(Me.gbPort)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximizeBox = False
        Me.Name = "Form1"
        Me.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen
        Me.Text = "Pelco-D Терминал.  (C) 2021 LAB85.RU info@lab85.ru"
        Me.gbPort.ResumeLayout(False)
        Me.gbRxLog.ResumeLayout(False)
        Me.gbRxLog.PerformLayout()
        Me.gbLogFile.ResumeLayout(False)
        Me.gbLogFile.PerformLayout()
        Me.StatusStrip1.ResumeLayout(False)
        Me.StatusStrip1.PerformLayout()
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.GroupBox8.ResumeLayout(False)
        CType(Me.NumUD_Preset, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox7.ResumeLayout(False)
        Me.GroupBox6.ResumeLayout(False)
        Me.GroupBox6.PerformLayout()
        CType(Me.tb_CamZoom, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox2.ResumeLayout(False)
        Me.GroupBox2.PerformLayout()
        CType(Me.TrackBar_DAT2, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.TrackBar_DAT1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox4.ResumeLayout(False)
        Me.GroupBox4.PerformLayout()
        Me.GroupBox3.ResumeLayout(False)
        Me.GroupBox3.PerformLayout()
        Me.GroupBox1.ResumeLayout(False)
        Me.GroupBox1.PerformLayout()
        CType(Me.tb_CamMovsSpeed, System.ComponentModel.ISupportInitialize).EndInit()
        Me.GroupBox5.ResumeLayout(False)
        Me.GroupBox5.PerformLayout()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents gbPort As System.Windows.Forms.GroupBox
    Friend WithEvents gbRxLog As System.Windows.Forms.GroupBox
    Friend WithEvents tbLogRx As System.Windows.Forms.TextBox
    Friend WithEvents btScanComPort As System.Windows.Forms.Button
    Friend WithEvents SerialPort1 As System.IO.Ports.SerialPort
    Friend WithEvents btPOpen As System.Windows.Forms.Button
    Friend WithEvents cbPorts As System.Windows.Forms.ComboBox
    Friend WithEvents gbLogFile As System.Windows.Forms.GroupBox
    Friend WithEvents cbLogFile As System.Windows.Forms.CheckBox
    Friend WithEvents Timer1 As System.Windows.Forms.Timer
    Friend WithEvents OpenFileDialog1 As System.Windows.Forms.OpenFileDialog
    Friend WithEvents StatusStrip1 As System.Windows.Forms.StatusStrip
    Friend WithEvents tsslRxCounter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tsslTxCounter As System.Windows.Forms.ToolStripStatusLabel
    Friend WithEvents tspbBar As System.Windows.Forms.ToolStripProgressBar
    Friend WithEvents Timer2 As System.Windows.Forms.Timer
    Friend WithEvents btClearRxLog As System.Windows.Forms.Button
    Friend WithEvents ToolTip1 As System.Windows.Forms.ToolTip
    Friend WithEvents cbSpeed As System.Windows.Forms.ComboBox
    Friend WithEvents TabControl1 As System.Windows.Forms.TabControl
    Friend WithEvents TabPage1 As System.Windows.Forms.TabPage
    Friend WithEvents TabPage2 As System.Windows.Forms.TabPage
    Friend WithEvents GroupBox1 As System.Windows.Forms.GroupBox
    Friend WithEvents btCamMoveSTOP As System.Windows.Forms.Button
    Friend WithEvents btCamMoveDOWNRIGHT As System.Windows.Forms.Button
    Friend WithEvents btCamMoveUPLEFT As System.Windows.Forms.Button
    Friend WithEvents btCamMoveDOWN As System.Windows.Forms.Button
    Friend WithEvents btCamMoveUP As System.Windows.Forms.Button
    Friend WithEvents btCamMoveDOWNLEFT As System.Windows.Forms.Button
    Friend WithEvents btCamMoveUPRIGHT As System.Windows.Forms.Button
    Friend WithEvents btCamMoveRIGTH As System.Windows.Forms.Button
    Friend WithEvents btCamMoveLEFT As System.Windows.Forms.Button
    Friend WithEvents GroupBox2 As System.Windows.Forms.GroupBox
    Friend WithEvents mtb_PACKET_HEAD As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_PACKET_CRC As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_PACKET_DAT2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_PACKET_DAT1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_PACKET_CMD2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_PACKET_CMD1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_PACKET_ADR As System.Windows.Forms.MaskedTextBox
    Friend WithEvents Label1 As System.Windows.Forms.Label
    Friend WithEvents Label2 As System.Windows.Forms.Label
    Friend WithEvents Label7 As System.Windows.Forms.Label
    Friend WithEvents Label6 As System.Windows.Forms.Label
    Friend WithEvents Label5 As System.Windows.Forms.Label
    Friend WithEvents Label4 As System.Windows.Forms.Label
    Friend WithEvents Label3 As System.Windows.Forms.Label
    Friend WithEvents bt_Send_Packet_Pelco_D_ As System.Windows.Forms.Button
    Friend WithEvents bt_Send_Packet_Pelco_D_zero As System.Windows.Forms.Button
    Friend WithEvents GroupBox4 As System.Windows.Forms.GroupBox
    Friend WithEvents GroupBox3 As System.Windows.Forms.GroupBox
    Friend WithEvents cb_CMD1_Focus_near As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD1_Iris_open As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD1_Iris_close As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD1_Camera_on_off As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD1_Auto_Manual_scan As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD1_reserv5 As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD1_reserv6 As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD1_Sense As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Always_0 As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Rigth As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Left As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Up As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Down As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Zoom_Tele As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Zoom_Wide As System.Windows.Forms.CheckBox
    Friend WithEvents cb_CMD2_Focus_Far As System.Windows.Forms.CheckBox
    Friend WithEvents Label9 As System.Windows.Forms.Label
    Friend WithEvents Label8 As System.Windows.Forms.Label
    Friend WithEvents mtb_DAT2 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents mtb_DAT1 As System.Windows.Forms.MaskedTextBox
    Friend WithEvents TrackBar_DAT2 As System.Windows.Forms.TrackBar
    Friend WithEvents TrackBar_DAT1 As System.Windows.Forms.TrackBar
    Friend WithEvents GroupBox5 As System.Windows.Forms.GroupBox
    Friend WithEvents mtb_Camera_Adr As System.Windows.Forms.MaskedTextBox
    Friend WithEvents bt_Load_TXT_File As System.Windows.Forms.Button
    Friend WithEvents GroupBox6 As System.Windows.Forms.GroupBox
    Friend WithEvents btCamQueryZoom As System.Windows.Forms.Button
    Friend WithEvents btCamSetZoom As System.Windows.Forms.Button
    Friend WithEvents tb_SetCameraZoom As System.Windows.Forms.TextBox
    Friend WithEvents Label10 As System.Windows.Forms.Label
    Friend WithEvents Label12 As System.Windows.Forms.Label
    Friend WithEvents Label11 As System.Windows.Forms.Label
    Friend WithEvents tb_CamSpeed_Num As System.Windows.Forms.TextBox
    Friend WithEvents tb_CamMovsSpeed As System.Windows.Forms.TrackBar
    Friend WithEvents bt_QueryTilt As System.Windows.Forms.Button
    Friend WithEvents bt_Query_Pan As System.Windows.Forms.Button
    Friend WithEvents GroupBox7 As System.Windows.Forms.GroupBox
    Friend WithEvents tbCamFocusFAR As System.Windows.Forms.Button
    Friend WithEvents tbCamFocusNEAR As System.Windows.Forms.Button
    Friend WithEvents GroupBox8 As System.Windows.Forms.GroupBox
    Friend WithEvents btPresetGo As System.Windows.Forms.Button
    Friend WithEvents btPresetSet As System.Windows.Forms.Button
    Friend WithEvents NumUD_Preset As System.Windows.Forms.NumericUpDown
    Friend WithEvents tb_CamZoom As System.Windows.Forms.TrackBar
    Friend WithEvents tbCamZoomWIDE As System.Windows.Forms.Button
    Friend WithEvents tbCamZoomTELE As System.Windows.Forms.Button
    Friend WithEvents tbFileSendN As System.Windows.Forms.TextBox
    Friend WithEvents lblFileSendN As System.Windows.Forms.Label

End Class
