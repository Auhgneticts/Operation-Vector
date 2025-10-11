Public Class PlayerShip
    Inherits Ship
    'MAKE PLAYER SHIP CLASS
    '  Don't remeber what I meant here
    Private ammoLargeBullet As New List(Of AmmoBullet)
    Private ammoSmallBullet As New List(Of AmmoBullet)
    Private ammoRodList As New List(Of AmmoRod)

    Public Sub SwitchAmmo(NewAmmoList As List(Of Ammo))
        Dim oldAmmoList As List(Of Ammo)
        oldAmmoList = Me.ammoList
        Me.ammoList.Clear()
        Me.ammoList.AddRange(NewAmmoList.AsEnumerable)
        NewAmmoList = Nothing
    End Sub
    Public Sub AddAmmo()
        'modify ammolist of that type

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
