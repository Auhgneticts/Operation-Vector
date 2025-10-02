Public Class Ship
    Inherits BaseObject
    'holds collectables. as lists???
    Friend ammoCargoList As New List(Of Ammo)
    'ammoList holds all ammo ship has
    Friend ammoList As New List(Of Ammo)
    Friend shotList As New List(Of Ammo)
    Friend currentShot As Ammo
    Public leftSpeed, rightSpeed, upSpeed, downSpeed As Single
    Public Function GetAmmoAmount() As Integer
        Return ammoList.Count
    End Function
    Public Function GetShipType() As String
        Return tag.ToString
    End Function
    Sub TakeDamage(amount As Single)

    End Sub
    Overrides Sub Move()

    End Sub

End Class
