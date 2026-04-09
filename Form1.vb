Public Class Form1
    ''testing
    Dim qTime As TimeSpan
    Dim qStop, qStart As New DateTime
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
            Case Keys.S
                PauseGame()
            Case Keys.B
                drawBounds = True
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
            Case Keys.S
                UnpauseGame()
        End Select
    End Sub
    Private Sub Form1_Paint(sender As Object, e As PaintEventArgs) Handles Me.Paint
        e.Graphics.InterpolationMode = Drawing2D.InterpolationMode.NearestNeighbor
        e.Graphics.PixelOffsetMode = Drawing2D.PixelOffsetMode.None

        'draw background
        'TESTING
        'sky_clouds_blue > desert
        e.Graphics.DrawImage(gameBitmaps("skyCloudsBlue"), 0, 0, Box.Right, Box.Bottom)

        'Player Ship
        player.Draw(e.Graphics, "heli") 'create Player Bitmap and change name
        'Draw bounding box if selected
        If drawBounds Then player.DrawBounds(e.Graphics)

        'Enemy Ships
        If enemyList.Count > 0 Then
            For Each enemy As EnemyShip In enemyList
                enemy.Draw(e.Graphics)
                If drawBounds Then enemy.DrawBounds(e.Graphics)
                If enemy.explode Then
                    enemy.DrawExplosion(e.Graphics)
                End If
            Next
        End If

        'Player Ammo
        If player.shotList.Count > 0 Then
            For Each shot As Ammo In player.shotList
                shot.DrawImage(e.Graphics)
                If drawBounds Then shot.DrawBounds(e.Graphics)
            Next
        End If

        'HUD
        e.Graphics.DrawString("Current Ammo Count  " + player.GetAmmoAmount.ToString, fontScore, Brushes.Yellow, New Point(0, 0))
        e.Graphics.DrawString("Enemies  " + enemyList.Count.ToString, fontScore, Brushes.Yellow, New Point(0, 20))
        e.Graphics.DrawString("Frame Time  " + qTime.Microseconds.ToString, fontScore, Brushes.Yellow, New PointF(0, 40))
        e.Graphics.DrawString("Score  " + Score.ToString, fontScore, Brushes.LightYellow, New PointF(0, 60))

    End Sub
    Private Sub Checks()
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
                            'remove shot after hit
                            playerShot.isAlive = False
                            enemy.explode = True
                        End If
                        If playerShot.isAlive Or playerShot.X > Box.Right Then
                            player.shotList.RemoveAt(player.shotList.IndexOf(playerShot))
                            Exit Sub
                        End If
                    Next
                End If
                If enemy.Rectangle.IntersectsWith(player.Rectangle) Then
                    enemy.explode = True
                    'TODO
                    'player.explode
                    EndGame(EndGameEvent.Collision, enemy)
                    Exit Sub
                End If
                If enemy.X < Box.Left - enemy.Size.Width Then
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
    Private Sub Moves()
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
    Private Sub TimerDraw_Tick(sender As Object, e As EventArgs) Handles TimerDraw.Tick
        Moves()
        Me.Invalidate()
        Checks()
    End Sub
    Private Sub TimerSpaceShipDirection_Tick(sender As Object, e As EventArgs) Handles TimerSpaceShipDir.Tick
        'TODO
        'Build this to use a TimeSpan within the object
        For Each enemy As EnemyShip In enemyList
            If enemy.imageName = "saucerSmall" Or enemy.imageName = "saucerBig" Then
                enemy.ChangeDirection()
            End If
        Next
    End Sub

    Private Sub TimerEnemySpawn_Tick(sender As Object, e As EventArgs) Handles TimerEnemySpawn.Tick
        Dim tempEnemyList As List(Of EnemyShip)
        tempEnemyList = GetEnemyList(EnemyFactory.EnemyType.SpaceShipBig, RandomInteger(6))
        enemyList.AddRange(tempEnemyList.AsEnumerable)
    End Sub
End Class
