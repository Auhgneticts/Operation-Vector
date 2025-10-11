Public Class SpaceShip
    Inherits EnemyShip
    Public Overrides Sub ChangeDirection()
        If up = True Then
            downSpeed = 0
            upSpeed = xSpeed * -1
            up = False
            Exit Sub
        ElseIf up = False Then
            upSpeed = 0
            downSpeed = xSpeed
            up = True
            Exit Sub
        End If
    End Sub
    Sub New()
        'random initail move direction
        Dim value As Integer = CInt(Int((2 * Rnd()) + 1))
        If value = 1 Then
            up = True
        Else
            up = False
        End If
    End Sub
End Class
