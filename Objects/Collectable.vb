Public MustInherit Class Collectable
    Private sizeValue As SizeF
    Private weightValue As Integer
    Public name As String
    Property size As SizeF
        Get
            Return sizeValue
        End Get
        Set(value As SizeF)
            sizeValue = value
        End Set
    End Property
    Property weight As Integer
        Get
            Return weightValue
        End Get
        Set(value As Integer)
            weightValue = value
        End Set
    End Property
    Sub RemoveItem(List As SortedList(Of String, Collectable))

    End Sub
End Class
