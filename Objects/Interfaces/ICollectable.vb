Public Interface ICollectable
    ReadOnly Property cargoSize As Integer
    ReadOnly Property itemLimit As Integer
    Sub RemoveItem(List As SortedList(Of String, Collectable))
End Interface
