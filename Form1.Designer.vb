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
        Label1.ForeColor = SystemColors.Info
        Label1.Location = New Point(0, 1404)
        Label1.Name = "Label1"
        Label1.Size = New Size(156, 100)
        Label1.TabIndex = 0
        Label1.Text = "ESC      = Quit" & vbCrLf & "Arrows = Move" & vbCrLf & "Space  = Fire" & vbCrLf & " S        = Hold to Stop" & vbCrLf & "B         = Draw Bounds" & vbCrLf
        ' 
        ' outDebug
        ' 
        outDebug.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        outDebug.BorderStyle = BorderStyle.None
        outDebug.Enabled = False
        outDebug.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        outDebug.Location = New Point(162, 1408)
        outDebug.Multiline = True
        outDebug.Name = "outDebug"
        outDebug.Size = New Size(687, 96)
        outDebug.TabIndex = 0
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
    Friend WithEvents TimerSpaceShipDir As Timer
    Friend WithEvents TimerEnemySpawn As Timer
    Friend WithEvents Label1 As Label
    Friend WithEvents outDebug As TextBox

End Class
