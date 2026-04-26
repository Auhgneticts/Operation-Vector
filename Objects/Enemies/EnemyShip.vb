Public MustInherit Class EnemyShip
    Inherits Ship
    Friend left As Boolean
    Friend up As Boolean
    Friend shooter As Boolean = False
    Friend baseScore As Integer
    Friend scoreMulti As Short
    Friend AmmoEnemy As List(Of Ammo)
    Public Sub Draw(g As Graphics)
        g.DrawImage(gameBitmaps(imageName), Rectangle)
    End Sub
    Public Overrides Sub DrawBounds(g As Graphics)
        'offsets bounding box Width
        g.DrawRectangle(pen, New Rectangle(New Point(X - pen.Width, Y - pen.Width), New Size(Size.Width - pen.Width * 2, Size.Height - pen.Width * 2)))
    End Sub
    Overrides Sub Move()
        X += leftSpeed
        X += rightSpeed
        Y += upSpeed
        Y += downSpeed
    End Sub
    MustOverride Sub ChangeDirection()
End Class