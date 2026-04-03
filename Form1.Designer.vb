<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
    Protected Overrides Sub Dispose(disposing As Boolean)
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        components = New ComponentModel.Container()
        TimerDraw = New Timer(components)
        TimerCheck = New Timer(components)
        TimerMove = New Timer(components)
        TimerSpaceShipDir = New Timer(components)
        TimerEnemySpawn = New Timer(components)
        Label1 = New Label()
        outDebug = New TextBox()
        SuspendLayout()
        ' 
        ' TimerDraw
        ' 
        TimerDraw.Interval = 15
        ' 
        ' TimerCheck
        ' 
        TimerCheck.Enabled = True
        TimerCheck.Interval = 8
        ' 
        ' TimerMove
        ' 
        TimerMove.Interval = 15
        ' 
        ' TimerSpaceShipDir
        ' 
        ' 
        ' TimerEnemySpawn
        ' 
        TimerEnemySpawn.Interval = 3000
        ' 
        ' Label1
        ' 
        Label1.AutoSize = True
        Label1.Dock = DockStyle.Bottom
        Label1.Location = New Point(0, 1424)
        Label1.Name = "Label1"
        Label1.Size = New Size(110, 80)
        Label1.TabIndex = 0
        Label1.Text = "HUD area" & vbCrLf & "ESC = quit" & vbCrLf & "Arrows = move" & vbCrLf & "Space = Fire"
        ' 
        ' outDebug
        ' 
        outDebug.Anchor = AnchorStyles.Bottom
        outDebug.BackColor = SystemColors.Window
        outDebug.BorderStyle = BorderStyle.FixedSingle
        outDebug.Font = New Font("Segoe UI Semibold", 7.8F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        outDebug.Location = New Point(150, 1387)
        outDebug.MaximumSize = New Size(0, 150)
        outDebug.MinimumSize = New Size(300, 50)
        outDebug.Multiline = True
        outDebug.Name = "outDebug"
        outDebug.ReadOnly = True
        outDebug.ScrollBars = ScrollBars.Vertical
        outDebug.ShortcutsEnabled = False
        outDebug.Size = New Size(874, 117)
        outDebug.TabIndex = 1
        outDebug.TabStop = False
        outDebug.WordWrap = False
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.DimGray
        ClientSize = New Size(2573, 1504)
        Controls.Add(outDebug)
        Controls.Add(Label1)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "SpaceMech"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TimerDraw As Timer
    Friend WithEvents TimerCheck As Timer
    Friend WithEvents TimerMove As Timer
    Friend WithEvents TimerSpaceShipDir As Timer
    Friend WithEvents TimerEnemySpawn As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents outDebug As TextBox

End Class
