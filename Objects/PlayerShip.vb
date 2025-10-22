Public Class PlayerShip
    Inherits Ship
    Private ammoBulletList As New List(Of Ammo)
    Private ammoRodList As New List(Of Ammo)
    Private allAmmo As New SortedList(Of AmmoFactory.AmmoType, List(Of Ammo))
    Private selectedAmmo As AmmoFactory.AmmoType
    Public outOfAmmo As Boolean = False

    Public Sub AddAmmo()
        'modify ammolist of that type
    End Sub
    Public Sub NextAmmoAvil()
        'check out of ammo flag
        If outOfAmmo Then
            'alert Out of Ammo
            Exit Sub
        End If
        selectedAmmo += 1
        If allAmmo(selectedAmmo).Count = 0 Then selectedAmmo += 1
        'do more
    End Sub
    Public Sub AmmoSelect(newAmmo As AmmoFactory.AmmoType)
        selectedAmmo = newAmmo
    End Sub
    Public Sub Shoot()
        Select Case selectedAmmo
            Case AmmoFactory.AmmoType.Bullet

            Case AmmoFactory.AmmoType.BulletBig

        End Select
        If ammoList.Count = 0 Then
            'alert NO Ammo
            Exit Sub
        End If
        currentShot = ammoList.Last
        ammoList.Remove(ammoList.Last)
        'add ammo offsets
        currentShot.Location = OffsetLocation
        shotList.Add(currentShot)
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
    Sub New()
        ammoBulletList = ammoList.AsEnumerable
        allAmmo.Add(AmmoFactory.AmmoType.Bullet, ammoBulletList)
        'allAmmo.Add(SelectedAmmo.Rod, ammoRodList.AsEnumerable)
    End Sub
End Class
