Public Class EnemyFactory
    Enum EnemyType As Short
        SpaceShipBigShooter
        SpaceShipSmallShooter
        HeliBigShooter
        HeliSmallShooter
    End Enum
    Private ReadOnly MakeSpaceShip As New SpaceShipFactory
    'Private ReadOnly MakeHeli As New HeliFactory
    Public Function GetEnemy(type As EnemyType)
        Select Case type
            Case EnemyType.SpaceShipBigShooter
                Return MakeSpaceShip.GetBigShooter
            Case EnemyType.SpaceShipSmallShooter
                Return MakeSpaceShip.GetSmallShooter
            Case EnemyType.HeliBigShooter
                Return Nothing
            Case EnemyType.HeliSmallShooter
                Return Nothing
            Case Else
                Return Nothing
        End Select
    End Function
    ''' Only ship making and geting here
    ''' Multi and list making..LOADING  goes into GameFunctions
End Class