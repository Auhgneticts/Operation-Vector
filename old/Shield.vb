Public Class Shield
    Enum ShieldStateValue As Short
        Depleted
        Full
    End Enum
    Private shieldValue As Integer
    Private capacity As Integer
    Public name As String
    Public shieldState As ShieldStateValue
    Public state As ShieldStateValue
    Public location As Point
    WriteOnly Property Deplete As Integer
        Set(value As Integer)
            If shieldValue <= 0 Then shieldState = ShieldStateValue.Depleted
        End Set
    End Property
    Public WriteOnly Property Replenish As Integer
        Set(value As Integer)
            shieldValue += value
        End Set
    End Property
    Public Sub New()
        'Add init code
    End Sub
End Class