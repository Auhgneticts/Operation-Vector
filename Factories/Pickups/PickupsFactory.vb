
Public Class PickupsFactory
    Enum BatteryType As Short
        Normal
        Boosted
        Supercharged
    End Enum
    Enum OrbType As Short
        Power
        Shield
        Fuel
        Speed
    End Enum

    Private ReadOnly MakeBattery As BatteryFactory
    Private ReadOnly MakeOrb As OrbFactory
    Public Function GetBattery(Type As BatteryType) As Battery
        Select Case Type
            Case BatteryType.Normal
                Return MakeBattery.GetNormal
            Case BatteryType.Boosted
                Return MakeBattery.GetBoosted
            Case BatteryType.Supercharged
                Return MakeBattery.GetSuperCharged
            Case Else
                Return Nothing
        End Select
    End Function
    Public Function GetOrb(Type As OrbType) As Orb
        Select Case Type
            Case OrbType.Power
                Return MakeOrb.GetPower
            Case OrbType.Shield
                Return MakeOrb.GetShield
            Case OrbType.Fuel
                Return MakeOrb.GetFuel
            Case OrbType.Speed
                Return MakeOrb.GetSpeed
            Case Else
                Return Nothing
        End Select
    End Function


End Class
