Public Class PlayerShip
    Inherits Ship
    Private selectedAmmo As AmmoFactory.AmmoType
    Friend allAmmo As New SortedList(Of AmmoFactory.AmmoType, List(Of Ammo))
    Friend ammoTypeNumber As Integer
    Friend ammoBulletBigList As New List(Of Ammo)
    Friend ammoBulletList As New List(Of Ammo)
    Friend ammoRodBigList As New List(Of Ammo)
    Friend ammoRodList As New List(Of Ammo)
    Friend ammoAutoSelect As Boolean = False

    Public Overrides Function GetAmmoAmount() As Integer
        Return ammoBulletBigList.Count
    End Function
    Public Sub AddAmmo(type As AmmoFactory.AmmoType, Amount As Integer)
        Select Case type
            Case AmmoFactory.AmmoType.Bullet
                ammoBulletList.Add(GameFunctions.ammoFactory.GetBullet(AmmoFactory.AmmoType.Bullet))
            Case AmmoFactory.AmmoType.BulletBig
                ammoBulletBigList.Add(GameFunctions.ammoFactory.GetBullet(AmmoFactory.AmmoType.BulletBig))
            Case AmmoFactory.AmmoType.Rod
                ammoRodList.Add(GameFunctions.ammoFactory.GetRod(AmmoFactory.AmmoType.Rod))
            Case AmmoFactory.AmmoType.RodBig
                ammoRodBigList.Add(GameFunctions.ammoFactory.GetRod(AmmoFactory.AmmoType.RodBig))
            Case AmmoFactory.AmmoType.LaserBlue
            Case AmmoFactory.AmmoType.LaserGreen
            Case AmmoFactory.AmmoType.LaserRed
        End Select
    End Sub
    Public Sub NextAmmoAvil()
        'reset  flag
        outOfCurrentAmmo = False
        'next AmmoType
        'NEED TO WALK PER GUN TREE
        selectedAmmo += 1
        If allAmmo(selectedAmmo).Count = 0 Then
            outOfCurrentAmmo = True
            selectedAmmo += 1
        End If
        'do more
        If outOfCurrentAmmo Then
            outText("Out of NEXT Ammo!")
            ammoTypeNumber -= 1
            Exit Sub
        ElseIf ammoTypeNumber > 0 Then
            'if ship has more ammo to use
            outText("Swithing Ammo")
            NextAmmoAvil()
        ElseIf ammoTypeNumber = 0 Then
            'if ship is completely out of ammo
            outOfAllAmmo = True
            outText("ALL ammo empty!")
            Exit Sub
        End If
    End Sub
    Public Sub AmmoSelect(newAmmo As AmmoFactory.AmmoType)
        'If ammo.gunType = newAmmo.gunType ...
        Select Case newAmmo
            Case AmmoFactory.AmmoType.BulletBig
                If ammoBulletBigList.Count > 0 Then
                    selectedAmmo = AmmoFactory.AmmoType.BulletBig
                End If
            Case AmmoFactory.AmmoType.Bullet
                If ammoBulletList.Count > 0 Then
                    selectedAmmo = AmmoFactory.AmmoType.Bullet
                End If
            Case AmmoFactory.AmmoType.Rod
                If ammoRodList.Count > 0 Then
                    selectedAmmo = AmmoFactory.AmmoType.Rod
                End If
        End Select
    End Sub
    Public Sub Shoot()
        If Not outOfCurrentAmmo Then
            Select Case selectedAmmo
                Case AmmoFactory.AmmoType.Bullet
                    If ammoBulletList.Count <> 0 Then
                        currentShot = ammoBulletList.Last
                        outText(ammoBulletList.Count.ToString + " " + ammoBulletList.First.name + " remaining")
                        ammoBulletList.Remove(ammoBulletList.Last)
                    End If
                Case AmmoFactory.AmmoType.BulletBig
                    If ammoBulletBigList.Count <> 0 Then
                        currentShot = ammoBulletBigList.Last
                        outText(ammoBulletBigList.Count.ToString + " " + ammoBulletBigList.First.name + " remaining")
                        ammoBulletBigList.Remove(ammoBulletBigList.Last)
                    End If
                Case Else
                    outOfCurrentAmmo = True
            End Select
            currentShot.Location = OffsetLocation
            shotList.Add(currentShot)
            currentShot = Nothing
        ElseIf ammoAutoSelect Then
            outText("out of current ammo!")
            ' Switch ammo then shoot again.
            NextAmmoAvil()
            Shoot()
        End If
        currentShot = Nothing
    End Sub
    Public Sub Left()
        leftSpeed = xSpeed * -1
    End Sub
    Public Sub Right()
        rightSpeed = xSpeed
    End Sub
    Public Sub Up()
        upSpeed = ySpeed * -1
    End Sub
    Public Sub Down()
        downSpeed = ySpeed
    End Sub
    Public Overrides Sub Move()
        X += leftSpeed
        X += rightSpeed
        Y += upSpeed
        Y += downSpeed
    End Sub
    Sub Draw(g As Graphics, image As String)
        g.DrawImage(gameBitmaps(image), Rectangle)
    End Sub
    Overrides Sub DrawBounds(g As Graphics)
        'highlight bounding box
        g.DrawRectangle(player.pen, player.Rectangle)
    End Sub
    Sub New()
    End Sub
End Class
