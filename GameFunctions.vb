
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
    Private dataPath As String = ""
    Friend Const TimeFastExplosionMicro = 75
    Friend globalScale As Integer
    Friend Box As Area
    Friend player As New PlayerShip
    Friend objectFactory As New PickupsFactory
    Friend enemyFactory As New EnemyFactory
    Friend ammoFactory As New AmmoFactory
    Friend enemyList As New List(Of EnemyShip)
    Friend gameBitmaps As New SortedList(Of String, Bitmap)
    Friend fontScore As New Font(FontFamily.GenericMonospace, 14)
    Friend outOfCurrentAmmo As Boolean = False
    Friend outOfAllAmmo As Boolean = False
    Friend drawBounds As Boolean = False
    Public Sub StartGame()
        With Form1
            .TimerDraw.Start()
            .TimerMove.Start()
            .TimerCheck.Start()
            .TimerSpaceShipDir.Start()
            .TimerEnemySpawn.Start()
        End With
        OutText("Game Started")
    End Sub
    Public Sub PauseGame(Optional message As String = "", Optional title As String = "")
        With Form1
            .TimerSpaceShipDir.Stop()
            .TimerEnemySpawn.Stop()
            .TimerMove.Stop()
            .TimerCheck.Stop()
        End With
        If message <> Nothing Then
            MsgBox(message, MsgBoxStyle.Information, title)
        End If
    End Sub
    Public Sub UnpauseGame()
        With Form1
            .TimerSpaceShipDir.Start()
            .TimerEnemySpawn.Start()
            .TimerMove.Start()
            .TimerCheck.Start()
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
    Public Sub SetupTimers()
        With Form1
            .TimerDraw.Interval = 15
            .TimerMove.Interval = 15
            .TimerCheck.Interval = 15

            'make Varibles
            .TimerSpaceShipDir.Interval = 200
            .TimerEnemySpawn.Interval = 3000
        End With
    End Sub
    Public Sub LoadEnemies()
        Dim tempEnemyList As List(Of EnemyShip)
        tempEnemyList = GetEnemyList(EnemyFactory.EnemyType.SpaceShipBig, 5)
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
            .Size = gameBitmaps("heli").Size
            .Location = New PointF(Box.Left + .Size.Width, Box.Bottom \ 2 - .Size.Height)
            .pen = New Pen(Brushes.Yellow) With {
                .Width = 1}
            .Offset = New PointF(30, 9)
            .xSpeed = 16
            .ySpeed = 16
            .xSpeedMax = 30
            .ySpeedMax = 24
            'Select ammo as would GUI
            ''SELECT BULLET TO SHOOOT on ship
            .ammoBulletList = GetAmmoList(AmmoFactory.AmmoType.Bullet, 10)

        End With
        OutText("Player Created")
        player.ammoBulletBigList = GetAmmoList(AmmoFactory.AmmoType.BulletBig, 9)
        player.allAmmo.Add(AmmoFactory.AmmoType.Bullet, player.ammoBulletList)
        player.allAmmo.Add(AmmoFactory.AmmoType.BulletBig, player.ammoBulletBigList)
        player.AmmoSelect(AmmoFactory.AmmoType.BulletBig)

        'must increment on ammo pickup
        player.ammoTypeNumber = player.allAmmo.Count
        OutText("Added Ammo to PLayer Ship")

        'Testing
        player.ammoAutoSelect = True
    End Sub
    Public Sub OutText(value As String)
        Form1.outDebug.AppendText(vbCrLf + value)
    End Sub
    Public Sub LoadData()
        dataPath = My.Application.Info.DirectoryPath + "data"
        globalScale = 2
        Box.Right = Form1.Right
        Box.Left = Form1.Left
        Box.Top = Form1.Top
        Box.Bottom = Form1.Bottom - (0.08 * Form1.Height)
        Box.Width = Form1.Width
        Box.Height = Form1.Height
        OutText("Game Data Loaded")
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
    Public Function GetEnemyList(amount As Short)
        Dim tempEnemyList As New List(Of EnemyShip)
        For i = 1 To amount
            tempEnemyList.Add(enemyFactory.GetEnemy(GetRandomEnemy))
        Next
        Return tempEnemyList
        OutText("Created " + amount.ToString + tempEnemyList(0).name + "s")
    End Function
    Public Function GetEnemyList(type As EnemyFactory.EnemyType, amount As Short)
        Dim tempEnemyList As New List(Of EnemyShip)
        For i = 1 To amount
            tempEnemyList.Add(enemyFactory.GetEnemy(type))
        Next
        Return tempEnemyList
        OutText("Created " + amount.ToString + tempEnemyList(0).name + "s")
    End Function
    Public Function GetRandomEnemy()
        'how to automate finding number of enemies
        Dim rndShip As Integer 'number of availble enenmies
        rndShip = 2
        Return enemyFactory.GetEnemy(RandomInteger(rndShip))
    End Function
    Public Function GetAmmo(type As AmmoFactory.AmmoType)
        Select Case type
            Case AmmoFactory.AmmoType.Bullet Or AmmoFactory.AmmoType.BulletBig
                Return ammoFactory.GetBullet(type)
            Case AmmoFactory.AmmoType.Rod Or AmmoFactory.AmmoType.RodBig
                Return ammoFactory.GetRod(type)
                'Case AmmoFactory.AmmoType.LaserBlue Or AmmoFactory.AmmoType.LaserGreen Or AmmoFactory.AmmoType.LaserRed
                'return ammoFactory.GetLaser(type)
        End Select
        Return Nothing
        OutText("NOT created ammo!")
    End Function
    Public Function GetAmmoList(type As AmmoFactory.AmmoType, Number As Integer)
        Dim tempAmmoList As New List(Of Ammo)
        Select Case type
      ' Small Bullet/Big Bullet
            Case AmmoFactory.AmmoType.Bullet Or AmmoFactory.AmmoType.BulletBig
                For I = 1 To Number
                    tempAmmoList.Add(ammoFactory.GetBullet(type))
                Next
      ' Rod/Big Rod
            Case AmmoFactory.AmmoType.Rod Or AmmoFactory.AmmoType.RodBig
                For I = 1 To Number
                    tempAmmoList.Add(ammoFactory.GetRod(type))
                Next
      ' Blue Laser/Green Laser/Red Laser
            Case AmmoFactory.AmmoType.LaserBlue Or AmmoFactory.AmmoType.LaserGreen Or AmmoFactory.AmmoType.LaserRed
                For I = 1 To Number
                    'tempAmmoList.Add(ammoFactory.GetLaser(type))
                Next
            Case Else
                Return Nothing
                OutText("NOT created Ammo List!")
        End Select
        Return tempAmmoList
        OutText("Created " + Number + " " + tempAmmoList(0).name + "s")
    End Function
End Module