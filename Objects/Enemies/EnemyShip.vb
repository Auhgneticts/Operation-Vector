Public MustInherit Class EnemyShip
    Inherits Ship
    Friend left As Boolean
    Friend up As Boolean
    Friend shooter As Boolean = False
    Friend explode As Boolean = False
    Friend boomStart As Boolean = False
    Friend tStart, tStop As New DateTime
    Friend tSpan As TimeSpan
    Friend baseScore As Integer
    Friend scoreMulti As Short
    Friend grow As Single = 1

    MustOverride Sub Draw(g As Graphics)
    MustOverride Sub DrawExplosion(g As Graphics)
    MustOverride Sub ChangeDirection()
End Class