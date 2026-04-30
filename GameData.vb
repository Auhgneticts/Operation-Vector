Module GameData
    'Exposed Game Values for HUD
    'Handles Font and Drawing
    Private scoreValue As Integer
    Private ammoLocation As Point
    Private scoreLocation As Point
    Private ammoImage As Image

    Friend fontScore As New Font(FontFamily.GenericMonospace, 26, FontStyle.Bold)
    Friend fontAmmo As New Font(FontFamily.GenericMonospace, 28, FontStyle.Bold)
    Friend fontScoreColor As Brush
    Friend fontAmmoColor As Brush

    Friend Sub LoadFonts()
        fontScoreColor = Brushes.LightYellow
        fontAmmoColor = Brushes.OrangeRed
        'place in bottom left
        ammoLocation.X = fontAmmo.Height
        ammoLocation.Y = Box.Bottom - fontAmmo.Height
        scoreLocation.X = 200
        scoreLocation.Y = Box.Bottom - fontScore.Height
        'Adjust USER font settings
    End Sub
    Friend Sub DrawHUD(g As Graphics)
        g.DrawString(Ammo_Str, fontAmmo, fontAmmoColor, ammoLocation)

        g.DrawString("Score  " + Score_Str, fontScore, fontScoreColor, scoreLocation)

        g.DrawString("Enemies  " + enemyList.Count.ToString, fontScore, Brushes.Yellow, New Point(0, 20))
        g.DrawString("Ammo Type:  " + GetAmmoType(), fontScore, Brushes.LightYellow, New PointF(0, 60))

        If player.shotList.Count > 0 Then
            g.DrawString("Score  " + player.shotList.Count.ToString, fontScore, Brushes.LightYellow, New PointF(0, 80))

        End If
    End Sub
    Friend Property Ammo_Image As Image
        Get
            Return ammoImage
        End Get
        Set(value As Image)
            If value Is Nothing Then
                ammoImage = GetAmmoPowerImg()
            Else
                ammoImage = value
            End If
        End Set
    End Property

    Friend Property Score_Int As Integer
        Get
            Return scoreValue
        End Get
        Set(value As Integer)
            scoreValue = value
        End Set
    End Property
    Friend ReadOnly Property Score_Str As String
        Get
            Return scoreValue.ToString.PadLeft(5, "-"c)
        End Get
    End Property
    Friend ReadOnly Property Ammo_Int As Integer
        Get
            Return player.CheckAmmo
        End Get
    End Property
    Friend ReadOnly Property Ammo_Str As String
        Get
            Return Ammo_Int.ToString.PadLeft(3)
        End Get
    End Property

End Module
