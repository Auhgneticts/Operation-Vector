Module GameFunctions
    Structure Area
        'form1.left is slow
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
    Friend ammoBullets As New List(Of AmmoBullet)
    Friend ammoRods As New List(Of AmmoRod)
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
    End Sub
    Public Sub SetupTimers()
        With Form1
            .TimerDraw.Interval = 15
            .TimerMove.Interval = 15
            .TimerCheck.Interval = 30
            .TimerSpaceShipDir.Interval = 500
            .TimerEnemySpawn.Interval = 3000
        End With
    End Sub
    Public Sub LoadEnemies()
        Dim tempEnemyList As List(Of EnemyShip)
        tempEnemyList = GetEnemyList(EnemyFactory.EnemyType.SpaceShipBigShooter, 5)
        enemyList.AddRange(tempEnemyList.AsEnumerable)
    End Sub
    Public Sub LoadBitmaps()
        gameBitmaps = ImageLoader.Load()
    End Sub
    Public Sub LoadPlayer()
        Dim tempAmmoList As List(Of Ammo)
        Dim temptwoAmmoList As List(Of Ammo)
        tempAmmoList = GetBulletList(AmmoFactory.AmmoType.BulletBigFast, 100)
        temptwoAmmoList = GetBulletList(AmmoFactory.AmmoType.BulletSmallFast, 50)
        With player
            .ammoList.AddRange(tempAmmoList.AsEnumerable)
            .name = "David"
            .scale = 2
            .Size = gameBitmaps("heli").Size
            .Location = New PointF(Box.Left + .Size.Width, Box.Bottom \ 2 - .Size.Height)
            .pen = Pens.IndianRed
            .Offset = New PointF(30, 9)
            .xSpeed = 6
            .ySpeed = 6
            .xSpeedMax = 30
            .ySpeedMax = 24
        End With
        ''' Testing '''

    End Sub
    Public Sub LoadData()
        dataPath = My.Application.Info.DirectoryPath + "data"
        globalScale = 1
        Box.Right = Form1.Right
        Box.Left = Form1.Left
        Box.Top = Form1.Top
        Box.Bottom = Form1.Bottom - 100
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
    Public Function GetBulletList(type As AmmoFactory.AmmoType, Number As Integer)
        Dim Bullets As New List(Of Ammo)
        For I As Integer = 0 To Number
            Bullets.Add(ammoFactory.GetBullet(type))
        Next
        Return Bullets
    End Function
End Module