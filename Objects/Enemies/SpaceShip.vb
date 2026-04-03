Public Class SpaceShip
    Inherits EnemyShip
    Friend ammoLaserList As List(Of AmmoLaser)
    Public Overrides Sub ChangeDirection()
        If up = True Then
            downSpeed = 0
            upSpeed = ySpeed * -1
            up = False
            Exit Sub
        ElseIf up = False Then
            upSpeed = 0
            downSpeed = ySpeed
            up = True
            Exit Sub
        End If
    End Sub
    Overrides Function GetAmmoAmount() As Integer
        Return ammoLaserList.Count
    End Function
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
