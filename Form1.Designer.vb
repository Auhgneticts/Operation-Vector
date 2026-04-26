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
        outDebug = New TextBox()
        PicBoxAmmoImage = New PictureBox()
        LableAmmoAmount = New Label()
        CType(PicBoxAmmoImage, ComponentModel.ISupportInitialize).BeginInit()
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
        ' outDebug
        ' 
        outDebug.BorderStyle = BorderStyle.None
        outDebug.Enabled = False
        outDebug.Font = New Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, CByte(0))
        outDebug.Location = New Point(600, 12)
        outDebug.Multiline = True
        outDebug.Name = "outDebug"
        outDebug.Size = New Size(687, 96)
        outDebug.TabIndex = 0
        ' 
        ' PicBoxAmmoImage
        ' 
        PicBoxAmmoImage.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        PicBoxAmmoImage.BackColor = Color.Transparent
        PicBoxAmmoImage.BackgroundImageLayout = ImageLayout.None
        PicBoxAmmoImage.Location = New Point(12, 1428)
        PicBoxAmmoImage.Name = "PicBoxAmmoImage"
        PicBoxAmmoImage.Size = New Size(64, 64)
        PicBoxAmmoImage.SizeMode = PictureBoxSizeMode.StretchImage
        PicBoxAmmoImage.TabIndex = 2
        PicBoxAmmoImage.TabStop = False
        ' 
        ' LableAmmoAmount
        ' 
        LableAmmoAmount.Anchor = AnchorStyles.Bottom Or AnchorStyles.Left
        LableAmmoAmount.AutoSize = True
        LableAmmoAmount.Font = New Font("Consolas", 22.2F, FontStyle.Bold, GraphicsUnit.Point, CByte(0))
        LableAmmoAmount.ForeColor = SystemColors.ControlLightLight
        LableAmmoAmount.Location = New Point(82, 1449)
        LableAmmoAmount.Name = "LableAmmoAmount"
        LableAmmoAmount.Size = New Size(79, 43)
        LableAmmoAmount.TabIndex = 3
        LableAmmoAmount.Text = "000"
        ' 
        ' Form1
        ' 
        AutoScaleDimensions = New SizeF(8F, 20F)
        AutoScaleMode = AutoScaleMode.Font
        AutoSize = True
        BackColor = Color.DimGray
        ClientSize = New Size(2573, 1504)
        Controls.Add(LableAmmoAmount)
        Controls.Add(PicBoxAmmoImage)
        Controls.Add(outDebug)
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
        CType(PicBoxAmmoImage, ComponentModel.ISupportInitialize).EndInit()
        ResumeLayout(False)
        PerformLayout()
    End Sub

    Friend WithEvents TimerDraw As Timer
    Friend WithEvents TimerSpaceShipDir As Timer
    Friend WithEvents TimerEnemySpawn As Timer
    Friend WithEvents outDebug As TextBox
    Friend WithEvents PicBoxAmmoImage As PictureBox
    Friend WithEvents LableAmmoAmount As Label

End Class
