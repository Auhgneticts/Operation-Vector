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
        SuspendLayout()
        ' 
        ' TimerDraw
        ' 
        TimerDraw.Interval = 13
        ' 
        ' TimerSpaceShipDir
        ' 
        ' 
        ' TimerEnemySpawn
        ' 
        TimerEnemySpawn.Interval = 3000
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.DimGray
        ClientSize = New Size(2573, 1504)
        DoubleBuffered = True
        FormBorderStyle = FormBorderStyle.None
        KeyPreview = True
        Margin = New Padding(3, 4, 3, 4)
        MaximizeBox = False
        MinimizeBox = False
        Name = "Form1"
        SizeGripStyle = SizeGripStyle.Hide
        StartPosition = FormStartPosition.CenterScreen
        Text = "Operation Vector"
        WindowState = FormWindowState.Maximized
        ResumeLayout(False)
    End Sub

    Friend WithEvents TimerDraw As Timer
    Friend WithEvents TimerSpaceShipDir As Timer
    Friend WithEvents TimerEnemySpawn As Timer

End Class
