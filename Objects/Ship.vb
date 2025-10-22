Public Class Ship
    Inherits BaseObject
    'holds collectables. as lists???
    Friend cargoList As New List(Of Collectable)
    Friend ammoList As New List(Of Ammo)
    Friend shotList As New List(Of Ammo)
    Friend currentShot As Ammo
    Friend explode As Boolean = False
    Friend boomStart As Boolean = False
    Friend tStart, tStop As New DateTime
    Friend tSpan As TimeSpan
    Friend grow As Single = 1
    Public leftSpeed, rightSpeed, upSpeed, downSpeed As Single
    Public Function GetAmmoAmount() As Integer
        Return ammoList.Count
    End Function
    Public Sub DrawExplosion(g As Graphics)
        ''' if slow think of global
        If boomStart = False Then
            tStart = DateAndTime.Now
            boomStart = True
        End If
        'create and add different offsets
        g.DrawImage(gameBitmaps("boom"), New RectangleF(Location, gameBitmaps("boom").Size * grow))
        grow += 0.4
        tStop = DateAndTime.Now
        Dim tSpan As TimeSpan = tStop - tStart
        If tSpan.Milliseconds > TimeFastExplosionMicro Then
            explode = False
            isAlive = False
            tStart = Nothing
            Exit Sub
        End If
    End Sub
    Sub TakeDamage(amount As Single)
        If amount > Me.health Then
            'explode
            explode = True
            Me.isAlive = False
        Else
            Me.health = Me.health - amount
        End If
    End Sub
    Overrides Sub Move()

    End Sub

End Class
