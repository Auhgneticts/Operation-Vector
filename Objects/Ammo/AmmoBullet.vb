Public Class AmmoBullet
    Inherits Ammo
    Public Overrides Sub DrawBounds(g As Graphics)
        g.DrawRectangle(pen, Rectangle)
    End Sub
    Public Overrides Sub DrawImage(g As Graphics)
        g.DrawImage(gameBitmaps("Bullet"), Rectangle)
    End Sub
    Public Overrides Sub Move()
        X += xSpeed
        If X > Box.Right Then
            MyBase.isAlive = False
        End If
    End Sub
End Class