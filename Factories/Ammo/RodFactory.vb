Public Class RodFactory
    Public Function GetBig() As AmmoRod
        Dim tempRod As New AmmoRod
        With tempRod
            .name = "Rod of punch"
            .length = 6
            .scale = globalScale
            .Size = New SizeF(4, 0)
            .ySpeed = -5
            .isAlive = True
            .pen = New Pen(Brushes.Yellow, 4)
        End With
        Return tempRod
    End Function
    Public Function GetSmall() As AmmoRod
        Dim tempRod As New AmmoRod
        With tempRod
            .name = "Rod of pinch"
            .length = 6
            .scale = globalScale
            .Size = New SizeF(4, 0)
            .ySpeed = -10
            .isAlive = True
            .pen = New Pen(Brushes.LightYellow, 4)
        End With
        Return tempRod
    End Function
End Class
