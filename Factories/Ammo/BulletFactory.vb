
Class BulletFactory

    Public Function GetBig() As AmmoBullet
        Dim tempBullet As New AmmoBullet
        With tempBullet
            .name = "Big Bullet"
            .isAlive = False
            .scale = 3
            .xSpeed = 10
            .Size = gameBitmaps("bullet").Size
        End With
        Return tempBullet
        tempBullet = Nothing
    End Function
    Public Function GetSmall() As AmmoBullet
        Dim tempBullet As New AmmoBullet
        With tempBullet
            .name = "Small Bullet"
            .isAlive = False
            .scale = 2
            .xSpeed = 10
            .Size = gameBitmaps("bullet").Size
        End With
        Return tempBullet
        tempBullet = Nothing
    End Function
End Class