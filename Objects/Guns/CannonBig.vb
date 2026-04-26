Public Class CannonBig
    Implements IShielded, ICollectable

    'Can Only shoot BulletBig
    'finish GUNS
    'Private ammoType As AmmoFactory.AmmoType = AmmoFactory.AmmoType.BulletBig

    '' when Gun Selected, SelectAmmo(AmmoType)
    ''when Gun Broken report and 
    ''Call AutoSelectGun or SelectGun =+1

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

    Public Property Collected As Boolean Implements ICollectable.Collected
        Get
            Throw New NotImplementedException()
        End Get
        Set(value As Boolean)
            Throw New NotImplementedException()
        End Set
    End Property
End Class
