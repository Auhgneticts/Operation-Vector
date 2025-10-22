Public Class Form1
    ''testing
    Dim qTime As TimeSpan
    Dim qStop, qStart As New DateTime
    ''testing

    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Hide()
        LoadData()
        LoadBitmaps()
        LoadPlayer()
        LoadEnemies()
        SetupTimers()
        StartGame()
    End Sub
    Private Sub Form1_KeyDown(sender As Object, e As KeyEventArgs) Handles Me.KeyDown
        Select Case e.KeyValue
            Case Keys.Space
                player.Shoot()
            Case Keys.Left
                player.Left()
            Case Keys.Right
                player.Right()
            Case Keys.Up
                player.Up()
            Case Keys.Down
                player.Down()
            Case Keys.Escape
                End
        End Select
    End Sub
    Private Sub Form1_KeyUp(sender As Object, e As KeyEventArgs) Handles Me.KeyUp
        Select Case e.KeyData
            Case Keys.Left
                player.leftSpeed = 0
            Case Keys.Right
                player.rightSpeed = 0
            Case Keys.Up
                player.upSpeed = 0
            Case Keys.Down
                player.downSpeed = 0
        End Select
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.None

        'draw background
        e.Graphics.DrawImage(gameBitmaps("desert"), 0, 0, Box.Right, Box.Bottom)

        'Player Ship
        player.Draw(e.Graphics, "heli") 'create Player Bitmap and change name

        'Enemy Ships
        If enemyList.Count > 0 Then
            For Each enemy As EnemyShip In enemyList
                enemy.Draw(e.Graphics)
                If enemy.explode Then
                    enemy.DrawExplosion(e.Graphics)
                End If
            Next
        End If

        'Player Ammo
        If player.shotList.Count > 0 Then
            For Each shot As Ammo In player.shotList
                shot.DrawImage(e.Graphics)
            Next
        End If
        e.Graphics.DrawString(player.GetAmmoAmount, SystemFonts.DialogFont, Brushes.White, New Point(0, 0))
        e.Graphics.DrawString("Enemies " + enemyList.Count.ToString, SystemFonts.DialogFont, Brushes.White, New Point(0, 10))

        e.Graphics.DrawString("Microseconds processing game", SystemFonts.DialogFont, Brushes.LightYellow, New PointF(0, 20))
        e.Graphics.DrawString(qTime.Microseconds.ToString, SystemFonts.DialogFont, Brushes.LightYellow, New PointF(0, 30))
        e.Graphics.DrawString("Score " + Score.ToString, fontScore, Brushes.LightYellow, New PointF(0, 60))

    End Sub
    Private Sub TimerDraw_Tick(sender As Object, e As EventArgs) Handles TimerDraw.Tick
        Me.Invalidate()
    End Sub
    Private Sub TimerCheck_Tick(sender As Object, e As EventArgs) Handles TimerCheck.Tick
        qStart = DateAndTime.Now

        ''''
        ''' Evauate the SHIPs first
        ''' 
        If enemyList.Count > 0 Then
            For Each enemy As EnemyShip In enemyList
                If player.shotList.Count > 0 Then
                    For Each playerShot As Ammo In player.shotList
                        'FIND FAST USE OF ITTERATOR
                        'As itterator
                        If playerShot.Rectangle.IntersectsWith(enemy.Rectangle) Then
                            Score += enemy.baseScore * enemy.scoreMulti
                            enemy.explode = True
                        End If
                        If playerShot.X > Box.Right Then
                            player.shotList.RemoveAt(player.shotList.IndexOf(playerShot))
                            Exit Sub
                        End If
                    Next
                End If
                If enemy.Rectangle.IntersectsWith(player.Rectangle) Then
                    ' Do Damage
                    enemy.explode = True
                    If MsgBox("YOU DIED", MsgBoxStyle.Critical, "You hit a " + enemy.name) = MsgBoxResult.Ok Then
                        End
                    End If
                    Exit Sub
                End If
                If enemy.X < Box.Left + enemy.Size.Width Then
                    Score -= enemy.baseScore * enemy.scoreMulti
                    enemy.isAlive = False
                End If
            Next
        End If
        'remove dead enemies
        For i = 0 To enemyList.Count - 1
            If enemyList(i).isAlive = False Then
                enemyList.RemoveAt(i)
                Exit Sub
            End If
        Next
        qStop = DateAndTime.Now
        qTime = qStop - qStart
    End Sub
    Private Sub TimerMove_Tick(sender As Object, e As EventArgs) Handles TimerMove.Tick
        player.Move()
        If player.shotList.Count > 0 Then
            For Each shot In player.shotList
                shot.Move()
            Next
        End If
        If enemyList.Count > 0 Then
            For Each enemy As EnemyShip In enemyList
                enemy.Move()
            Next
        End If
    End Sub
    Private Sub TimerSpaceShipDirection_Tick(sender As Object, e As EventArgs) Handles TimerSpaceShipDir.Tick
        For Each enemy As EnemyShip In enemyList
            If enemy.tag = "saucerSmall" Then
                enemy.ChangeDirection()
            End If
        Next
    End Sub

    Private Sub TimerEnemySpawn_Tick(sender As Object, e As EventArgs) Handles TimerEnemySpawn.Tick
        Dim tempEnemyList As List(Of EnemyShip)
        tempEnemyList = GetEnemyList(EnemyFactory.EnemyType.SpaceShipBigShooter, RandomInteger(6))
        enemyList.AddRange(tempEnemyList.AsEnumerable)
    End Sub

End Class
