Public Class PlayerShip
    Inherits Ship
    Public Sub Shoot()
        If Not outOfCurrentAmmo Then
            Select Case selectedAmmo
                Case AmmoFactory.AmmoType.Bullet
                    If ammoBulletList.Count <> 0 Then
                        currentShot = ammoBulletList.Last
                        ammoBulletList.Remove(ammoBulletList.Last)
                    Else
                        '
                        'remove empty ammo list frmo allAmmo
                        outOfCurrentAmmo = True
                        allAmmo.RemoveAt(selectedAmmo)
                        Exit Sub
                    End If
                Case AmmoFactory.AmmoType.BulletBig
                    If ammoBulletBigList.Count <> 0 Then
                        currentShot = ammoBulletBigList.Last
                        ammoBulletBigList.Remove(ammoBulletBigList.Last)
                    Else
                        outOfCurrentAmmo = True
                        allAmmo.RemoveAt(selectedAmmo)
                        Exit Sub
                    End If
                Case Else
                    outOfCurrentAmmo = True
            End Select
            currentShot.Location = OffsetLocation
            shotList.Add(currentShot)
            currentShot = Nothing
        ElseIf ammoAutoSelect Then
            outText("out of current ammo!")

            NextAmmoAvil()
        End If
        UpdateHudValues("ammo")
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
