Imports WinGame.GameFunctions
Imports WinGame.GameAmmo
Public Class Form1
    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        Cursor.Hide()
        LoadBitmaps()
        LoadData()

        'LoadEnemies()

        LoadPowerUps()

        LoadPlayer()
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
        e.Graphics.DrawImage(gameBitmaps("SkyCloudsBlue"), DestRect, SourceRect, GraphicsUnit.Pixel)

        'Player Ship
        player.Draw(e.Graphics, "Heli") 'create Player Bitmap and change name
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

        'Power Ups
        If powerUps.Count > 0 Then
            For Each power In powerUps
                power.DrawImage(e.Graphics)
                If drawBounds Then power.DrawBounds(e.Graphics)
            Next
        End If
        'HUD
        e.Graphics.DrawString("Current Ammo Count  " + GetAmmoString.ToString, fontScore, Brushes.Yellow, New Point(0, 0))
        e.Graphics.DrawString("Enemies  " + enemyList.Count.ToString, fontScore, Brushes.Yellow, New Point(0, 20))
        e.Graphics.DrawString("Frame Time  " + qTime.Microseconds.ToString, fontScore, Brushes.Yellow, New PointF(0, 40))
        'e.Graphics.DrawString("Score  " + Score.ToString, fontScore, Brushes.LightYellow, New PointF(0, 60))
        If player.shotList.Count > 0 Then
            e.Graphics.DrawString("Score  " + player.shotList.Count.ToString, fontScore, Brushes.LightYellow, New PointF(0, 60))
        End If

    End Sub
    Private Sub Checks()
        qStart = DateAndTime.Now

        'player BULLETS vs enemy SHIPS
        If player.shotList.Count > 0 Then
            For Each playerShot As Ammo In player.shotList

                'check enemys
                If enemyList.Count > 0 Then
                    For Each enemy As EnemyShip In enemyList
                        If playerShot.Rectangle.IntersectsWith(enemy.Rectangle) Then
                            Score += enemy.baseScore * enemy.scoreMulti
                            'remove shot after hit
                            playerShot.isAlive = False
                            enemy.explode = True
                        End If
                    Next
                End If
            Next
        End If

        If enemyList.Count > 0 Then
            For Each enemy As EnemyShip In enemyList
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

        'check POWER UPS
        If powerUps.Count > 0 Then
            'FIX power up types
            For Each power As PowerBullet In powerUps
                If power.isAlive Then
                    If power.Rectangle.IntersectsWith(player.Rectangle) Then
                        'do pick up EFFECTS
                        power.isAlive = False

                        'separate Power up types
                        AddAmmo(power.ammoType, 0, power.GetAmmo)
                        UpdateHudValues("ammo")
                    End If
                End If
            Next
        End If
        RemoveObjects()
        qStop = DateAndTime.Now : qTime = qStop - qStart
    End Sub
    Private Sub RemoveObjects()

        'remove dead enemies
        For i = 0 To enemyList.Count - 1
            If enemyList(i).isAlive = False Then
                enemyList.RemoveAt(i)
            End If
        Next

        'remove collected powerups
        If powerUps.Count > 0 Then
            For i As Integer = powerUps.Count - 1 To 0 Step -1
                If Not powerUps(i).isAlive Then
                    powerUps.RemoveAt(i)
                End If
            Next
        End If

        'remove player SHots
        If player.shotList.Count > 0 Then
            For i As Integer = player.shotList.Count - 1 To 0 Step -1
                If player.shotList(i).isAlive = False Then
                    player.shotList.RemoveAt(i)
                End If
            Next i
        End If
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
        'get a portion of the player's X and Y speed
        'to translate the background image
        SourceRect.X += (player.leftSpeed + player.rightSpeed) * 0.003
        SourceRect.Y += (player.upSpeed + player.downSpeed) * 0.0015
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
        tempEnemyList = GameFunctions.enemyFactory.GetEnemyList(EnemyFactory.EnemyType.SpaceShipBig, RandomInteger(6))
        enemyList.AddRange(tempEnemyList.AsEnumerable)
    End Sub
End Class
