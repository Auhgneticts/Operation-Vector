Public Class PlayerShip
    Inherits Ship
    'MAKE PLAYER SHIP CLASS
    '  Don't remeber what I meant here
    Private ammoLargeBullet As New List(Of Ammo)
    Private ammoSmallBullet As New List(Of Ammo)
    Private ammoRod As New List(Of Ammo)


    Public Sub AddAmmo(AddedAmmoList As List(Of Ammo))
        Dim oldAmmoList As List(Of Ammo)
        oldAmmoList = Me.ammoList
        Me.ammoList = Nothing
        Me.ammoList = AddedAmmoList
        AddedAmmoList = Nothing
        'Update count ??
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
