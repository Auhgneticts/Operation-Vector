Public Class AmmoRod
    Inherits Ammo
    Friend length As Short
    Public Overrides Sub DrawPolly(g As Graphics)
        g.DrawLine(pen, Location, New PointF(Location.X, Location.Y - length))
    End Sub
    Public Overrides Sub Move()
        Y += ySpeed
    End Sub
End Class
