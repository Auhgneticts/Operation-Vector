Module DataPolling
    Dim PilotName As String
    Dim CraftName As String
    Dim Damage As String
    Dim GunSelect As String
    Private Property Score As String

    Friend Function AmmoSelect() As String
        '' if no gun return main
        Return "Main"
    End Function
    Friend Function AmmoAmount() As String
        Return player.GetAmmoAmount.ToString
    End Function
End Module
