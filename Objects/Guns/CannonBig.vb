Public Class CannonBig
    Implements IShielded, ICollectable

    'Can Only shoot BulletBig
    Private ammoType As AmmoFactory.AmmoType = AmmoFactory.AmmoType.BulletBig
    '' when Gun Selected, SelectAmmo(AmmoType)
    ''when Gun Broken report and 
    ''Call AutoSelectGun or SelectGun =+1

    Public ReadOnly Property cargoSize As Integer Implements ICollectable.cargoSize
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public ReadOnly Property itemLimit As Integer Implements ICollectable.itemLimit
        Get
            Throw New NotImplementedException()
        End Get
    End Property

    Public Property ShieldType As IShielded.Shields Implements IShielded.ShieldType
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As IShielded.Shields)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Property ShieldValue As Integer Implements IShielded.ShieldValue
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Integer)
            Throw New NotImplementedException()
        End Set
    End Property

    Public Sub RemoveItem(List As SortedList(Of String, Collectable)) Implements ICollectable.RemoveItem
        Throw New NotImplementedException()
    End Sub
End Class
