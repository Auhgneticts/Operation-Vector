Public Class AmmoFactory
    Enum AmmoType As Short
        Bullet
        BulletBig
        Rod
        RodBig
        LaserRed
        LaserGreen
        LaserBlue
    End Enum

    Private ReadOnly MakeBullet As New BulletFactory
    Private ReadOnly MakeRod As New RodFactory
    Public Function GetBullet(Type As AmmoType) As AmmoBullet
        Select Case Type
            Case AmmoType.Bullet
                Return MakeBullet.GetSmall()
            Case AmmoType.BulletBig
                Return MakeBullet.GetBig()
            Case Else
                Return Nothing
        End Select
    End Function
    Public Function GetRod(Type As AmmoType) As AmmoRod
        Select Case Type
            Case AmmoType.Rod
                Return MakeRod.GetSmall
            Case AmmoType.RodBig
                Return MakeRod.GetBig
            Case Else
                Return Nothing
        End Select
    End Function
End Class
