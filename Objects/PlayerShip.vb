Public Class PlayerShip
    Inherits Ship
    Public Sub Shoot()
        If ammoOrderList.Count = 0 Then Exit Sub

        Dim attempts As Integer = 0

        While attempts < ammoOrderList.Count
            Dim ammoType As AmmoFactory.AmmoType = ammoOrderList(selectedIndex)
            Dim q As Queue(Of Ammo) = allAmmo(ammoType)

            If q.Count > 0 Then
                Dim shot = q.Dequeue()
                shot.Location = OffsetLocation
                shotList.Add(shot)
                Return
            End If
            Debug.Print("Trying Next Ammo")
            selectedIndex = (selectedIndex + 1) Mod ammoOrderList.Count
            attempts += 1
        End While

        Debug.Print("All Ammo Empty")
    End Sub
    Public Overrides Function CheckAmmo() As Object
        If allAmmo.Count > 0 Then
            Return allAmmo(selectedIndex).Count
        Else Return 0
        End If
    End Function
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
