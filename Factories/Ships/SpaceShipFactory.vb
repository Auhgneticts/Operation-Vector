Public Class SpaceShipFactory
    Public Function GetBigShooter() As EnemyShip
        Dim tempEnemy As New SpaceShip
        With tempEnemy
            .imageName = "SaucerBig"
            .scale = 2
            .Size = gameBitmaps(.imageName).Size
            .shooter = True
            .name = "large space ship"
            .isAlive = True
            .scoreMulti = 1
            .baseScore = 50
            .xSpeedMax = 120
            .ySpeedMax = 20
            .leftSpeed = RandomInteger(40) * -1
            '.ySpeed = RandomInteger(20)
            .ySpeed = .leftSpeed / -3
            .Location = RandomY(.Size * 2)
            .pen = New Pen(Brushes.Red) With {
                .Width = 1}
        End With
        'tempEnemy.ammoLaserList = GetAmmoList(AmmoFactory.AmmoType.LaserRed, 2)
        Return tempEnemy
        tempEnemy = Nothing
    End Function

    Public Function GetSmallShooter() As EnemyShip
        Dim tempEnemy As New SpaceShip
        With tempEnemy
            .imageName = "saucerSmall"
            .scale = 1
            .Size = gameBitmaps(.imageName).Size
            .shooter = True
            .name = "small space ship"
            .isAlive = True
            .scoreMulti = 1
            .baseScore = 25
            .xSpeedMax = 40
            .ySpeedMax = 40
            .xSpeed = 10
            .ySpeed = 2
            .leftSpeed = -3
            .Location = RandomY(.Size * 2)
            .pen = New Pen(Brushes.Red) With {
                .Width = 1}
        End With
        'tempEnemy.ammoLaserList = GetAmmoList(AmmoFactory.AmmoType.LaserBlue, 3)
        Return tempEnemy
        tempEnemy = Nothing
    End Function

    Public Function GetSmallSlow() As EnemyShip
        Throw New NotImplementedException()
    End Function

    Public Function GetSmallFast() As EnemyShip
        Throw New NotImplementedException()
    End Function
End Class
