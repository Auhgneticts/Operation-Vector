Public Class AmmoFactory
    Enum AmmoType As Short
        BulletBigSlow
        BulletBigFast
        BulletSmallSlow
        BulletSmallFast
        RodBigSlow
        RodBigFast
        RodSmallSlow
        RodSmallFast
    End Enum

    Private ReadOnly MakeBullet As New BulletFactory
    Private ReadOnly MakeRod As RodFactory
    Public Function GetBullet(Type As AmmoType) As AmmoBullet
        Select Case Type
            Case AmmoType.BulletBigSlow
                Return MakeBullet.GetBigSlow()
            Case AmmoType.BulletBigFast
                Return MakeBullet.GetBigFast()
            Case AmmoType.BulletSmallSlow
                Return MakeBullet.GetSmallSlow
            Case AmmoType.BulletSmallFast
                Return MakeBullet.GetSmallFast
            Case Else
                Return Nothing
        End Select
    End Function
    Public Function GetRod(Type As AmmoType) As AmmoRod
        Select Case Type
            Case AmmoType.RodBigFast
                Return MakeRod.GetBigFast
            Case AmmoType.RodBigSlow
                Return MakeRod.GetBigSlow
            Case AmmoType.RodSmallFast
                Return MakeRod.GetSmallFast
            Case AmmoType.RodSmallSlow
                Return MakeRod.GetSmallSlow
            Case Else
                Return Nothing
        End Select
    End Function

End Class
