Public Class RodFactory
    ''' 
    ''' Do rods use Bitmaps or Draw Line?
    ''' would it  look too much like Laser Pulse?
    '''
    Public Function GetBig() As AmmoRod
        Dim tempRod As New AmmoRod
        With tempRod
            .imageName = "RodBig"
            .name = "Rod of punch"
            .length = 12
            .scale = globalScale
            .Size = gameBitmaps(.imageName).Size
            .moveSpeed = 5
            .isAlive = True
            .pen = New Pen(Brushes.Yellow, 4)
        End With
        Return tempRod
    End Function
    Public Function GetSmall() As AmmoRod
        Dim tempRod As New AmmoRod
        With tempRod
            .imageName = "RodSmall"
            .name = "Rod of pinch"
            .length = 6
            .scale = globalScale
            .Size = gameBitmaps(.imageName).Size
            .moveSpeed = 10
            .isAlive = True
            .pen = New Pen(Brushes.LightYellow, 4)
        End With
        Return tempRod
    End Function
End Class
