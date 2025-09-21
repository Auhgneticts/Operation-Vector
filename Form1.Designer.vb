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
        SuspendLayout()
        ' 
        ' TimerDraw
        ' 
        TimerDraw.Interval = 14
        ' 
        ' TimerCheck
        ' 
        TimerCheck.Enabled = True
        TimerCheck.Interval = 30
        ' 
        ' TimerMove
        ' 
        TimerMove.Interval = 15
        ' 
        ' TimerSpaceShipDir
        ' 
        TimerSpaceShipDir.Interval = 500
        ' 
        ' TimerEnemySpawn
        ' 
        TimerEnemySpawn.Interval = 3000
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(7F, 15F)
        AutoScaleMode = AutoScaleMode.Font
        BackColor = Color.DimGray
        ClientSize = New Size(990, 526)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "SpaceMech"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub

    Friend WithEvents TimerDraw As Timer
    Friend WithEvents TimerCheck As Timer
    Friend WithEvents TimerMove As Timer
    Friend WithEvents TimerSpaceShipDir As Timer
    Friend WithEvents TimerEnemySpawn As Timer

End Class
