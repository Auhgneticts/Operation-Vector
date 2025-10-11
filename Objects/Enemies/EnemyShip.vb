Public MustInherit Class EnemyShip
    Inherits Ship
    Friend left As Boolean
    Friend up As Boolean
    Friend shooter As Boolean = False
    Friend baseScore As Integer
    Friend scoreMulti As Short

    Public Sub Draw(g As Graphics)
        g.DrawImage(gameBitmaps(imageName), Rectangle)
    End Sub
    Overrides Sub Move()
        X += leftSpeed
        X += rightSpeed
        Y += upSpeed
        Y += downSpeed
    End Sub
    MustOverride Sub ChangeDirection()
End Class