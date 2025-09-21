Public Class GunEnergy
    Inherits Gun
    Enum GunTypeValue
        Plasma
        Sonic
        RF
        LaserRed
        LaserAmber
        LaserGreen
        LaserBlue
    End Enum
    Public gunType As GunTypeValue
    Public AmmoList As New List(Of AmmoEnergy)
    Sub New()
        'create Ammo and populate values
        Dim ammo As New AmmoEnergy With {
            .hitDamage = 5}

    End Sub
    Public Sub Shoot(shots As Short)
        'If shot leave Set IsAlive = True
    End Sub
    Public Sub Shoot(shots As Short, target As Ship) 'Target as Other???

    End Sub
End Class
