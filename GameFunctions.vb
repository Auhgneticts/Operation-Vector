
Module GameFunctions
    Enum EndGameEvent As UShort
        Shot
        Collision
        TimeUp
    End Enum
    Structure Area
        Dim Left As Integer
        Dim Right As Integer
        Dim Top As Integer
        Dim Bottom As Integer
        Dim Width As Integer
        Dim Height As Integer
    End Structure

    'Private dataPath As String = ""
    Friend qTime As TimeSpan
    Friend qStop, qStart As New DateTime
    Friend Const TimeFastExplosionMicro = 75
    Friend globalScale As UInteger
    Friend Box As Area
    Friend player As New PlayerShip
    Friend objectFactory As New PickupsFactory
    Friend enemyFactory As New EnemyFactory
    Friend enemyList As New List(Of EnemyShip)
    Friend gameBitmaps As New SortedList(Of String, Bitmap)
    Friend fontScore As New Font(FontFamily.GenericMonospace, 14, FontStyle.Bold)
    Friend drawBounds As Boolean = False

    ''TESTING
    Friend powerUps As List(Of PowerBullet)

    Friend DestRect As RectangleF
    Friend SourceRect As RectangleF
    Friend ScreenScaleX, ScreenScaleY As UInteger
    Friend ScreenRatioX, ScreenRatioY As UInteger

    Public Sub StartGame()
        StartTimers()
        UpdateHudValues()
        OutText("Game Started")
    End Sub
    Public Sub PauseGame(Optional message As String = "", Optional title As String = "")
        StopTimers()
        If message <> Nothing Then
            MsgBox(message, MsgBoxStyle.Information, title)
        End If
        OutText("Game Paused")
    End Sub
    Public Sub UnpauseGame()
        StartTimers()
        OutText("Game Unpaused")
    End Sub
    Public Sub SetupTimers()
        With Form1
            .TimerDraw.Interval = 13
            'make Varibles
            .TimerSpaceShipDir.Interval = 200
            .TimerEnemySpawn.Interval = 3000
        End With
    End Sub
    Public Sub StartTimers()
        With Form1
            .TimerDraw.Start()
            .TimerSpaceShipDir.Start()
            '.TimerEnemySpawn.Start()
        End With
    End Sub
    Public Sub StopTimers()
        With Form1
            .TimerDraw.Stop()
            .TimerSpaceShipDir.Stop()
            .TimerEnemySpawn.Stop()
        End With
    End Sub
    Public Sub EndGame(endEvent As EndGameEvent, Optional ship As Ship = Nothing, Optional enemy As EnemyShip = Nothing, Optional ammoName As String = "")
        Select Case endEvent
            Case EndGameEvent.Collision
                PauseGame()
                If MsgBox("You hit a " + ship.name, MsgBoxStyle.Critical, "You didn't make it.") = MsgBoxResult.Ok Then
                    End
                End If
            Case EndGameEvent.Shot
                If MsgBox("Your craft " + ship.name + " was taken down by a " + enemy.name + " using " + ammoName + "s!", MsgBoxStyle.Critical, "We will continue the fight without you.") = MsgBoxResult.Ok Then
                    End
                End If
            Case EndGameEvent.TimeUp
                If MsgBox(" it apears that the time giving for the exersise has elapsed.", MsgBoxStyle.Critical, "So sorry " + player.name + "Opps, there's a timer!") = MsgBoxResult.Ok Then
                    End
                End If
        End Select
    End Sub
    Public Sub LoadEnemies()
        Dim tempEnemyList As List(Of EnemyShip)
        tempEnemyList = enemyFactory.GetEnemyList(EnemyFactory.EnemyType.SpaceShipBig, 5)
        enemyList.AddRange(tempEnemyList)
        OutText("Enimies Loaded")
    End Sub
    Public Sub LoadBitmaps()
        gameBitmaps = ImageLoader.Load()
        OutText("Bitmap Images Loaded")
    End Sub
    Public Sub LoadPlayer()
        With player
            .name = "David"
            .scale = 2
            .Size = gameBitmaps("Heli").Size
            .Location = New PointF(Box.Left + .Size.Width, Box.Bottom \ 2 - .Size.Height)
            .pen = New Pen(Brushes.Yellow) With {
                .Width = 1}
            .Offset = New PointF(30, 9)
            .xSpeed = 16
            .ySpeed = 16
            .xSpeedMax = 30
            .ySpeedMax = 24
            .imageName = "heli"
        End With
        OutText("Player Created")
        ammoBulletList = GetAmmoList(AmmoFactory.AmmoType.Bullet, 20)
        ammoBulletBigList = GetAmmoList(AmmoFactory.AmmoType.BulletBig, 10)
        allAmmo.Add(AmmoFactory.AmmoType.Bullet, ammoBulletList)
        allAmmo.Add(AmmoFactory.AmmoType.BulletBig, ammoBulletBigList)
        'Select ammo as would GUI
        ''SELECT BULLET TO SHOOOT on ship
        AmmoSelect(AmmoFactory.AmmoType.BulletBig)
        OutText("Added Ammo to PLayer Ship")
        'Testing
        ammoAutoSelect = True

    End Sub
    Public Sub LoadPowerUps()
        '''Testing
        '''move to Object/PowerUp Factory
        '''
        powerUps = New List(Of PowerBullet)
        Dim tempPower As PowerBullet
        For p = 1 To 10
            tempPower = New PowerBullet(AmmoFactory.AmmoType.BulletBig, 20)
            With tempPower
                .scale = 1
                .name = "Big Bullet Power Up"
                .imageName = "PowerBigBullet"
                .Size = gameBitmaps(.imageName).Size
                .isAlive = True
                .pen = Pens.Green
                .Location = New Point(p * 50, 100)
                'Number of cargo spaces to occupy
                .cargoSize = 1
            End With
            powerUps.Add(tempPower)
        Next

    End Sub
    Public Sub LoadData()
        'dataPath = My.Application.Info.DirectoryPath + "data"
        globalScale = 2
        'Fix this
        Box.Right = Form1.Right
        Box.Left = Form1.Left
        Box.Top = Form1.Top
        Box.Bottom = Form1.Bottom - (0.08 * Form1.Height)
        Box.Width = Form1.Width
        Box.Height = Form1.Height
        OutText("Game Data Loaded")

        ''' TESTING
        ''' 
        ScreenRatioX = 16
        ScreenRatioY = 9
        ScreenScaleX = 6
        ScreenScaleY = 6
        ScreenScaleX = ScreenRatioX * ScreenScaleX
        ScreenScaleY = ScreenRatioY * ScreenScaleY

        'Point to Source REct
        SourceRect.Width = ScreenScaleX
        SourceRect.Height = ScreenScaleY
        Dim tempLocation As New PointF((gameBitmaps("SkyCloudsBlue").Height \ 2) - SourceRect.Width, (gameBitmaps("SkyCloudsBlue").Width * 0.5) - SourceRect.Height)
        SourceRect.X = tempLocation.X
        SourceRect.Y = tempLocation.Y
        'get ratio from scren size
        'trying to overdraw
        DestRect = New RectangleF(New PointF(-1, -1), New SizeF(Form1.Size.Width + ScreenScaleX, Form1.Size.Height + ScreenScaleY))
    End Sub

    Public Sub OutText(value As String)
        Form1.outDebug.AppendText(vbCrLf + value)
    End Sub

    Public Function RandomY(size As SizeF) As PointF
        Dim y As Single
        Dim x As Single = Box.Width + size.Width
        Rnd(System.TimeOnly.MinValue.Second * -1)
        Randomize()
        y = (Box.Bottom - size.Height) * Rnd() + size.Height
        Return New PointF(x, y)
    End Function
    Public Function RandomInteger(max As Integer) As Integer
        Dim rndNum As Integer
        Rnd(System.TimeOnly.MinValue.Second * -1)
        Randomize()
        rndNum = CInt(Int((max * Rnd()) + 1))
        Return rndNum
    End Function

    Public Function GetAmmoList(type As AmmoFactory.AmmoType, Number As Integer)
        '''
        '''Where do I put this???
        '''
        Dim tempAmmoList As New List(Of Ammo)
        Select Case type
      ' Small Bullet/Big Bullet
            Case AmmoFactory.AmmoType.Bullet, AmmoFactory.AmmoType.BulletBig
                For I = 1 To Number
                    tempAmmoList.Add(GameAmmo.ammoFactory.GetBullet(type))
                Next
      ' Rod/Big Rod
            Case AmmoFactory.AmmoType.Rod Or AmmoFactory.AmmoType.RodBig
                For I = 1 To Number
                    tempAmmoList.Add(GameAmmo.ammoFactory.GetRod(type))
                Next
      ' Blue Laser/Green Laser/Red Laser
            Case AmmoFactory.AmmoType.LaserBlue Or AmmoFactory.AmmoType.LaserGreen Or AmmoFactory.AmmoType.LaserRed
                For I = 1 To Number
                    'tempAmmoList.Add(Ammo.GetLaser(type))
                Next
            Case Else
                Return Nothing
                OutText("NOT created Ammo List!")
        End Select
        Return tempAmmoList
        tempAmmoList = Nothing
        OutText("Created " + Number + " " + tempAmmoList(0).name + "s")
    End Function
    Public Sub UpdateHudValues(Optional what As String = "")
        'No params then Itterate through and update ALL Displayable Info

        'Player Data
        '       get ammo count from player current ammo
        'Update player ammo, for extern SHOOT to call
        If what = "ammo" Or what = "" Then
            Form1.LableAmmoAmount.Text = GetAmmoString()
        End If
        'If what = "ammo" Then
        'Exit Sub
        'End If

        'Hud Images
        '       get image from player current ammo
        If what = "" Then
            Form1.PicBoxAmmoImage.Image = GetAmmoPwImage()
        End If
        'bit.Dispose()

        'Enemy Data

        'World Data

        'Mission Data

        If what <> "" Then
            OutText("ERROR No need for string " + what + " in UpdateHudValues")
        End If
    End Sub
End Module