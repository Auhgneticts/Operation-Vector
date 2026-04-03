Public Class PlayerShip
    Inherits Ship
    Private selectedAmmo As AmmoFactory.AmmoType
    Friend allAmmo As New SortedList(Of AmmoFactory.AmmoType, List(Of Ammo))
    Friend ammoBulletBigList As New List(Of Ammo)
    Friend ammoBulletList As New List(Of Ammo)
    Friend ammoRodBigList As New List(Of Ammo)
    Friend ammoRodList As New List(Of Ammo)
    Friend outOfCurrentAmmo As Boolean = False
    Friend outOfAllAmmo As Boolean = False
    Friend ammoAutoSelect As Boolean = False

    Public Overrides Function GetAmmoAmount() As Integer
        Return ammoBulletBigList.Count
    End Function
    Public Sub AddAmmo(type As AmmoFactory.AmmoType, Amount As Integer)
        Select Case selectedAmmo
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
        'check out of ammo flag
        If outOfCurrentAmmo Then
            'alert Out of Ammo
            Exit Sub
        End If
        selectedAmmo += 1
        If allAmmo(selectedAmmo).Count = 0 Then selectedAmmo += 1
        'do more
    End Sub
    Public Sub AmmoSelect(newAmmo As AmmoFactory.AmmoType)
        'If ammo.gunType = newAmmo.gunType ...
        Select Case newAmmo
            Case AmmoFactory.AmmoType.BulletBig
                If ammoBulletBigList.Count > 0 Then
                    selectedAmmo = AmmoFactory.AmmoType.BulletBig
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
                    'currentShot = allAmmo(AmmoFactory.AmmoType.Bullet).Last
                    If ammoBulletList.Count <> 0 Then
                        currentShot = ammoBulletList.Last
                    Else
                        outText("Out of Ammo" + ammoBulletList.ToString)
                        Exit Select
                    End If
                'allAmmo(AmmoFactory.AmmoType.Bullet).Remove(allAmmo(AmmoFactory.AmmoType.Bullet).Last)
                Case AmmoFactory.AmmoType.BulletBig
                    If ammoBulletBigList.Count <> 0 Then
                        currentShot = ammoBulletBigList.Last
                        outText(ammoBulletBigList.Count.ToString + " " + ammoBulletBigList.First.name + " remaining")
                        ammoBulletBigList.Remove(ammoBulletBigList.Last)
                        currentShot.Location = OffsetLocation
                        shotList.Add(currentShot)
                        currentShot = Nothing
                    Else
                        outOfCurrentAmmo = True
                        If ammoAutoSelect Then
                            NextAmmoAvil()
                        End If
                        PauseGame("Out of Ammo", "Demo Done")
                    End If
            End Select
        End If
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
    Sub New()
    End Sub
End Class
