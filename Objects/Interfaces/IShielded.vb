Public Interface IShielded
    Enum Shields As Integer
        Electric  'Volts
        Plate     'allowable Mass / Get from ship
        Active    'number of Agents
    End Enum
    Property ShieldType As Shields
    Property ShieldValue As Integer

End Interface
