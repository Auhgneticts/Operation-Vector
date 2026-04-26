
Public MustInherit Class Collectable
    Inherits BaseObject
    Implements ICollectable
    Private collectedValue As Boolean
    Friend cargoSize As UInteger

    Public Property Collected As Boolean Implements ICollectable.Collected
        Get
            Return collectedValue
        End Get
        Set(value As Boolean)
            collectedValue = value
        End Set
    End Property

    Public Sub New()
        Collected = False
    End Sub
End Class
