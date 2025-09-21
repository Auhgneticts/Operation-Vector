
Class BulletFactory
    Public Function GetBigSlow() As AmmoBullet
        Throw New NotImplementedException()
    End Function

    Public Function GetBigFast() As AmmoBullet
        Dim tempBullet As New AmmoBullet
        With tempBullet
            .isAlive = False
            .pen = Pens.Red
            .scale = 2
            .xSpeed = 10
            .Size = gameBitmaps("bullet").Size
        End With
        Return tempBullet
        tempBullet = Nothing
    End Function

    Public Function GetSmallSlow() As AmmoBullet
        Throw New NotImplementedException()
    End Function

    Public Function GetSmallFast() As AmmoBullet
        Throw New NotImplementedException()
    End Function
End Class