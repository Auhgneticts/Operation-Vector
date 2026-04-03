Imports System.Runtime.InteropServices.JavaScript.JSType

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
    Public Sub StartGame()
        With Form1
            .TimerDraw.Start()
            .TimerMove.Start()
            .TimerCheck.Start()
            .TimerSpaceShipDir.Start()
            .TimerEnemySpawn.Start()
        End With
        outText("Game Started")
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
        tempEnemyList = GetEnemyList(enemyFactory.EnemyType.SpaceShipBig, 5)
        enemyList.AddRange(tempEnemyList)
        outText("Enimies Loaded")
    End Sub

    Public Sub LoadBitmaps()
        gameBitmaps = ImageLoader.Load()
    End Sub
    Public Sub LoadPlayer()
        With player
            .name = "David"
            .scale = 2
            .Size = gameBitmaps("heli").Size
            .Location = New PointF(Box.Left + .Size.Width, Box.Bottom \ 2 - .Size.Height)
            .pen = Pens.IndianRed
            .Offset = New PointF(30, 9)
            .xSpeed = 16
            .ySpeed = 16
            .xSpeedMax = 30
            .ySpeedMax = 24
            .ammoBulletBigList = GetAmmoList(ammoFactory.AmmoType.BulletBig, 9)
            '.ammoRodList = GetAmmoList(AmmoFactory.AmmoType.Rod, 75)
            .AmmoSelect(ammoFactory.AmmoType.BulletBig)
            'Select ammo as would GUI
            'Finish allAmmo
            '.allAmmo.Add(AmmoFactory.AmmoType.Rod, .ammoRodList)
            ''SELECT BULLET TO SHOOOT on ship
        End With
        ''' Testing '''
    End Sub
    End Sub
    Public Sub outText(value As String)
        Form1.outDebug.AppendText(value)
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
    End Function
    Public Function GetRandomEnemy()
        'how to automate finding number of enemies
        Dim rndShip As Integer 'number of availble enenmies
        rndShip = 2
        Return enemyFactory.GetEnemy(RandomInteger(rndShip))
    End Function
    Public Function GetEnemyList(type As EnemyFactory.EnemyType, amount As Short)
        Dim tempEnemyList As New List(Of EnemyShip)
        For i = 1 To amount
            tempEnemyList.Add(enemyFactory.GetEnemy(type))
        Next
        Return tempEnemyList
    End Function
    Public Function GetAmmo(type As AmmoFactory.AmmoType)
        Select Case type
            Case ammoFactory.AmmoType.Bullet Or ammoFactory.AmmoType.BulletBig
                Return ammoFactory.GetBullet(type)
            Case ammoFactory.AmmoType.Rod Or ammoFactory.AmmoType.RodBig
                Return ammoFactory.GetRod(type)
                'Case AmmoFactory.AmmoType.LaserBlue Or AmmoFactory.AmmoType.LaserGreen Or AmmoFactory.AmmoType.LaserRed
                'return ammoFactory.GetLaser(type)
        End Select
        Return Nothing
    End Function
    Public Function GetAmmoList(type As AmmoFactory.AmmoType, Number As Integer)
        Select Case type
        'Bullets
            Case ammoFactory.AmmoType.Bullet Or ammoFactory.AmmoType.BulletBig
                Dim tempAmmoList As New List(Of AmmoBullet)
                For I = 1 To Number
                    tempAmmoList.Add(ammoFactory.GetBullet(type))
                Next
                Return tempAmmoList
                tempAmmoList = Nothing
            Case ammoFactory.AmmoType.Rod Or ammoFactory.AmmoType.RodBig
                Dim tempAmmoList As New List(Of AmmoRod)
                For I = 1 To Number
                    tempAmmoList.Add(ammoFactory.GetRod(type))
                Next
                Return tempAmmoList
                tempAmmoList = Nothing
            Case ammoFactory.AmmoType.LaserBlue Or ammoFactory.AmmoType.LaserGreen Or ammoFactory.AmmoType.LaserRed
                Dim tempAmmoList As New List(Of AmmoLaser)
                For I = 1 To Number
                    'tempAmmoList.Add(ammoFactory.GetLaser(type))
                Next
                Return tempAmmoList
                tempAmmoList = Nothing
        End Select
        Return Nothing
    End Function
End Module