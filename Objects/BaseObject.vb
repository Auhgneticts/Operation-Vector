Public Class BaseObject
    Private rectangleValueF As RectangleF
    Private frameRects As List(Of RectangleF)
    Private offsetValue As PointF
    Friend weight As Integer
    Friend health As Integer
    Friend tag As String
    Friend imageName As String
    Friend scale As Integer
    Friend moveSpeed As Double
    Friend xSpeed, ySpeed As Integer
    Friend xSpeedMax, ySpeedMax As Double
    Friend pen As Pen
    Friend brush As Brush
    'public
    Public isAlive As Boolean = False
    Public name As String
    Property Location As PointF
        Get
            Return rectangleValueF.Location
        End Get
        Set(value As PointF)
            rectangleValueF.Location = value
        End Set
    End Property
    ReadOnly Property OffsetLocation As PointF
        Get
            Return New PointF(rectangleValueF.X + (offsetValue.X * scale * globalScale), rectangleValueF.Y + (offsetValue.Y * scale * globalScale))
        End Get
    End Property
    WriteOnly Property Offset As PointF
        Set(value As PointF)
            offsetValue = value
        End Set
    End Property
    ReadOnly Property Rectangle
        Get
            Return New RectangleF(Location, Size)
        End Get
    End Property
    Property Size As SizeF
        Get
            Return rectangleValueF.Size * scale * globalScale
        End Get
        Set(value As SizeF)
            rectangleValueF.Size = value
        End Set
    End Property
    Property X As Single
        Get
            Return rectangleValueF.X
        End Get
        Set(value As Single)
            rectangleValueF.X = value
        End Set
    End Property
    Property Y As Single
        Get
            Return rectangleValueF.Y
        End Get
        Set(value As Single)
            rectangleValueF.Y = value
        End Set
    End Property
    Overridable Sub Move()

    End Sub
    Overridable Sub DrawPolly(g As Graphics)

    End Sub
    Overridable Sub DrawImage(g As Graphics)

    End Sub
End Class