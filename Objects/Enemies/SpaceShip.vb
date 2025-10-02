Public Class SpaceShip
    Inherits EnemyShip
    Public Overrides Sub Draw(g As Graphics)
        g.DrawImage(gameBitmaps(imageName), Rectangle)
    End Sub
    Public Overrides Sub DrawExplosion(g As Graphics)
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
    Overrides Sub Move()
        X += leftSpeed
        X += rightSpeed
        Y += upSpeed
        Y += downSpeed
    End Sub
    Public Overrides Sub ChangeDirection()
        If up = True Then
            downSpeed = 0
            upSpeed = xSpeed * -1
            up = False
            Exit Sub
        ElseIf up = False Then
            upSpeed = 0
            downSpeed = xSpeed
            up = True
            Exit Sub
        End If
    End Sub
    Sub New()
        'random initail move direction
        Dim value As Integer = CInt(Int((2 * Rnd()) + 1))
        If value = 1 Then
            up = True
        Else
            up = False
        End If
    End Sub
End Class
