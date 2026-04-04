Public Class SpaceShipFactory
    Public Function GetBigShooter() As EnemyShip
        Dim tempEnemy As New SpaceShip
        With tempEnemy
            .imageName = "saucerBig"
            .scale = 2
            .Size = gameBitmaps(.imageName).Size
            .shooter = True
            .name = "Space ship big shooter"
            .isAlive = True
            .scoreMulti = 1
            .baseScore = 50
            .xSpeedMax = 120
            .ySpeedMax = 20
            .leftSpeed = RandomInteger(40) * -1
            '.ySpeed = RandomInteger(20)
            .ySpeed = .leftSpeed / -3
            .Location = RandomY(.Size * 2)
            .pen = New Pen(Brushes.White) With {
                .Width = 1}
        End With
        tempEnemy.ammoLaserList = GetAmmoList(AmmoFactory.AmmoType.LaserRed, 2)
        Return tempEnemy
        tempEnemy = Nothing
    End Function

    Public Function GetSmallShooter() As EnemyShip
        Dim tempEnemy As New SpaceShip
        With tempEnemy
            .scale = 1
            .Size = gameBitmaps(.imageName).Size
            .shooter = True
            .name = "Space Ship small shooter"
            .isAlive = True
            .scoreMulti = 1
            .baseScore = 25
            .xSpeedMax = 40
            .ySpeedMax = 40
            .xSpeed = 10
            .ySpeed = 2
            .leftSpeed = -3
            .Location = RandomY(.Size * 2)
            .pen = New Pen(Brushes.CornflowerBlue) With {
                .Width = 4}
        End With
        tempEnemy.ammoLaserList = GetAmmoList(AmmoFactory.AmmoType.LaserBlue, 3)
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
