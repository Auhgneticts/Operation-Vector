
Class BulletFactory
    Public Function GetBigBullet() As AmmoBullet
        Dim tempBullet As New AmmoBullet
        With tempBullet
            .imageName = "BigBullet"
            .name = "Big Bullet"
            .isAlive = True
            .scale = 5
            .xSpeed = 25
            .Size = gameBitmaps(.imageName).Size
            .pen = Pens.Yellow
        End With
        Return tempBullet
        tempBullet = Nothing
    End Function
    Public Function GetBullet() As AmmoBullet
        Dim tempBullet As New AmmoBullet
        With tempBullet
            .imageName = "Bullet"
            .name = "Small Bullet"
            .isAlive = True
            .scale = 3
            .xSpeed = 40
            .Size = gameBitmaps(.imageName).Size
            .pen = Pens.Yellow
        End With
        Return tempBullet
        tempBullet = Nothing
    End Function
End Class