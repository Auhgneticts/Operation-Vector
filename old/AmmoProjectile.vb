Public Class AmmoProjectile
    Inherits Collectable
    Public hitDamage As Integer
    Public Property location As PointF
        Get
            Return locationValueF
        End Get
        Set(value As PointF)
            UpdateRectangleF(value)
        End Set
    End Property
    Public ReadOnly Property rectangleF As RectangleF
        Get
            UpdateRectangleF()
            Return rectangleValueF
        End Get
    End Property
    Private Sub UpdateRectangleF()
        'Syncs PointF and RectF Locations
        rectangleValueF.Location = locationValueF
    End Sub
    Private Sub UpdateRectangleF(pointF As PointF)
        'Syncs PointF and RectF Locations
        rectangleValueF.Location = pointF
        locationValueF = pointF
    End Sub
    Public Sub DrawProjectile()
        Form1.graphics.DrawImage(bitmapValue, rectangleF)
    End Sub
    Public Sub New(Group As String, Weight As Short, Scale As Short, Width As Short)
        With Me
            .group = Group
            .weight = Weight
            .scale = Scale
            .sizeF = New SizeF(Width, Width)
            ' FIX Bitmaps???
            .bitmapValue = Form1.BulletBitmap
        End With
    End Sub
End Class
