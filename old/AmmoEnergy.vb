Public Class AmmoEnergy
    Inherits Collectable
    Public hitDamage As Integer
    Public Sub DrawEnergy(ByRef graphics As Graphics, location As Point, pixels As Short)
        graphics.DrawRectangle(Pens.Yellow, New RectangleF(location, New SizeF(pixels, pixels)))
    End Sub
    Public Sub DrawEnergy(ByRef graphics As Graphics, pen As Pen, location As Point, pixels As Short)
        graphics.DrawRectangle(pen, New RectangleF(location, New SizeF(pixels, pixels)))
    End Sub
End Class
