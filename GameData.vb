Module GameData
    Private scoreValue As Integer
    Public Property Score As Integer
        Get
            Return scoreValue
        End Get
        Set(value As Integer)
            scoreValue = value
        End Set
    End Property
End Module
