Public Class SpaceShipFactory
    Public Function GetBigShooter() As EnemyShip
        Dim tempEnemy As New SpaceShip
        With tempEnemy
            .ammoList = GetAmmoList(AmmoFactory.AmmoType.BulletBig, 20)
            .imageName = "saucerSmall"
            .scale = 2
            .Size = gameBitmaps(.imageName).Size
            .shooter = True
            .tag = "saucerSmall"
            .name = "Space Ship big shooter"
            .isAlive = True
            .scoreMulti = 1
            .baseScore = 50
            .xSpeedMax = 10
            .ySpeedMax = 20
            .xSpeed = 1
            .ySpeed = 20
            .leftSpeed = -1
            .Location = RandomY(.Size * 2)
        End With
        Return tempEnemy
        tempEnemy = Nothing
    End Function

    Public Function GetSmallShooter() As EnemyShip
        Dim tempEnemy As New SpaceShip
        With tempEnemy
            .ammoList = GetAmmoList(AmmoFactory.AmmoType.Bullet, 10)
            .scale = 1
            .Size = gameBitmaps("saucerSmall").Size
            .shooter = True
            .tag = "saucerSmall"
            .name = "Space Ship small shooter"
            .isAlive = True
            .scoreMulti = 1
            .baseScore = 25
            .xSpeedMax = 10
            .ySpeedMax = 20
            .xSpeed = 10
            .ySpeed = 2
            .leftSpeed = -3
            .Location = RandomY(.Size * 2)
        End With
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
