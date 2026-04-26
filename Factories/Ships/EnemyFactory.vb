Public Class EnemyFactory
    Enum EnemyType As Short
        SpaceShip
        SpaceShipBig
        HeliBigShooter
        HeliSmallShooter
    End Enum
    Private ReadOnly MakeSpaceShip As New SpaceShipFactory
    'Private ReadOnly MakeHeli As New HeliFactory
    Public Function GetEnemy(type As EnemyType)
        Select Case type
            Case EnemyType.SpaceShip
                Return MakeSpaceShip.GetSmallShooter
            Case EnemyType.SpaceShipBig
                Return MakeSpaceShip.GetBigShooter
            Case EnemyType.HeliBigShooter
                Return Nothing
            Case EnemyType.HeliSmallShooter
                Return Nothing
            Case Else
                Return Nothing
        End Select
    End Function
    Public Function GetEnemyList(amount As Short)
        Dim tempEnemyList As New List(Of EnemyShip)
        For i = 1 To amount
            tempEnemyList.Add(GetEnemy(GetRandomEnemy))
        Next
        Return tempEnemyList
        OutText("Created " + amount.ToString + tempEnemyList(0).name + "s")
    End Function
    Public Function GetEnemyList(type As EnemyType, amount As Short)
        Dim tempEnemyList As New List(Of EnemyShip)
        For i = 1 To amount
            tempEnemyList.Add(GetEnemy(type))
        Next
        Return tempEnemyList
        OutText("Created " + amount.ToString + tempEnemyList(0).name + "s")
    End Function
    Public Function GetRandomEnemy()
        'how to automate finding number of enemies
        Dim rndShip As Integer 'number of availble enenmies
        rndShip = 2
        Return GetEnemy(RandomInteger(rndShip))
    End Function
End Class