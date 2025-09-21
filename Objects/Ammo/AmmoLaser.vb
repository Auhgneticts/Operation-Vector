Public Class AmmoLaser
    Inherits Ammo
    Friend lineWidth As Short

    Public Overloads Sub Draw(g As Graphics, offset As PointF, target As PointF)
        g.DrawLine(Pens.DarkGoldenrod, offset, target)
    End Sub
End Class