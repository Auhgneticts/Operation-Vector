Public Class GunProjectile
    Inherits Gun
    Enum GunTypeValue
        Bullet ' should have types?
        Rod
        DU
    End Enum
    Friend IsTraveling As Boolean = False
    Friend maxCapacity As Integer
    Public ShotList As New List(Of AmmoProjectile)
    Private Ammo As AmmoProjectile
    Public gunType As GunTypeValue
    Public AmmoList As New List(Of AmmoProjectile)

    Sub AddAmmo(amount As Integer)
        Dim tempAmmo As AmmoProjectile
        For I = 1 To amount
            tempAmmo = New AmmoProjectile("testAmmo" + I.ToString, 10, 4, 3)
            AmmoList.Add(tempAmmo)
            tempAmmo = Nothing
        Next I
    End Sub
    Sub New()

    End Sub
    Public Sub Shoot()
        'If shot leave Set IsTraveling
        If AmmoList.Count > 0 Then
            'shoot here
            'add one Bullet to Shot list
            ShotList.Add(AmmoList.First)
            'remove one Bullet from Ammo Capacity
            AmmoList.Remove(Ammo)
        End If
    End Sub
End Class
