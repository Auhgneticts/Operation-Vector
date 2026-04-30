Public MustInherit Class Ammo
    Inherits BaseObject

    Friend xAccel, yAccel As Single
    'Damage delt
    Friend power As Single
    Public Overrides Sub DrawBounds(g As Graphics)
        g.DrawRectangle(pen, Rectangle)
    End Sub
    Public Overrides Sub Move()
        X += xSpeed
        If Not Box.Box.Contains(New Point(X, Y)) Then
            MyBase.isAlive = False
        End If

        For Each enemy As EnemyShip In enemyList
            If Rectangle.IntersectsWith(enemy.Rectangle) Then
                Score_Int += enemy.baseScore * enemy.scoreMulti
                'remove shot after hit
                isAlive = False
                enemy.explode = True
            End If
        Next
    End Sub
End Class
