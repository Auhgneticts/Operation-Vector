Module GameAmmo
    'Collection of Ammo handling Functions 

    Friend ammoFactory As New AmmoFactory
    Friend selectedAmmo As AmmoFactory.AmmoType
    Friend ammoAutoSelect As Boolean = False
    Friend allAmmo As New SortedList(Of AmmoFactory.AmmoType, List(Of Ammo))
    Friend ammoBulletBigList As New List(Of Ammo)
    Friend ammoBulletList As New List(Of Ammo)
    Friend ammoRodBigList As New List(Of Ammo)
    Friend ammoRodList As New List(Of Ammo)
    Friend outOfCurrentAmmo As Boolean = False
    Friend outOfAllAmmo As Boolean = False
    Friend Sub NextAmmoAvil()
        '''TESTING
        '''
        selectedAmmo += 1
        outOfCurrentAmmo = False
    End Sub
    Friend Function GetAmmoPwImage()
        Dim bit As Bitmap = gameBitmaps(GetAmmoPwImgName)
        bit.MakeTransparent()
        Return bit
    End Function
    Friend Function GetAmmoPwImgName()
        Dim tString As String = "Power" + allAmmo(0)(0).imageName
        Return tString
    End Function

    Friend ReadOnly Property GetAmmoString() As String
        '''
        '''What am I going to do for the HUD polling?
        Get
            Return allAmmo(selectedAmmo).Count.ToString.PadLeft(3)
        End Get
    End Property
    Friend ReadOnly Property GetAmmoInt() As Integer
        Get
            Return allAmmo(selectedAmmo).Count
        End Get
    End Property

    Friend Sub AmmoSelect(newAmmo As AmmoFactory.AmmoType)
        'If ammo.gunType = newAmmo.gunType ...
        Select Case newAmmo
            Case AmmoFactory.AmmoType.BulletBig
                If ammoBulletBigList.Count > 0 Then
                    selectedAmmo = AmmoFactory.AmmoType.BulletBig
                End If
            Case AmmoFactory.AmmoType.Bullet
                If ammoBulletList.Count > 0 Then
                    selectedAmmo = AmmoFactory.AmmoType.Bullet
                End If
                'Case AmmoFactory.AmmoType.Rod
                '    If ammoRodList.Count > 0 Then
                '        selectedAmmo = AmmoFactory.AmmoType.Rod
                '    End If
        End Select
    End Sub

    Friend Sub AddAmmo(ammoType As AmmoFactory.AmmoType, Optional amount As Integer = 0, Optional ammoRefill As List(Of Ammo) = Nothing)
        '''
        '''FIX THIS
        '''
        'get Ammo from Power Up Refills
        'Add the correct type to the ammo list
        '
        Dim tempAmmoList As New List(Of Ammo)

        If ammoRefill Is Nothing Then
            tempAmmoList = GetAmmoList(ammoType, amount)
            OutText("Created " + amount + " " + ammoType.ToString + " rounds")
        ElseIf ammoRefill IsNot Nothing Then
            tempAmmoList = ammoRefill
            OutText("Picked up a " + amount.ToString + "  rounds of " + ammoType.ToString + "s")
        End If
        Select Case ammoType
            Case AmmoFactory.AmmoType.Bullet
                ammoBulletList.AddRange(tempAmmoList.AsEnumerable)
                    ''
                    'Finish each case
            Case AmmoFactory.AmmoType.BulletBig
                ammoBulletBigList.AddRange(tempAmmoList.AsEnumerable)
            Case AmmoFactory.AmmoType.Rod
                ammoRodList.Add(ammoFactory.GetRod(AmmoFactory.AmmoType.Rod))
            Case AmmoFactory.AmmoType.RodBig
                ammoRodBigList.Add(ammoFactory.GetRod(AmmoFactory.AmmoType.RodBig))
            Case AmmoFactory.AmmoType.LaserBlue
            Case AmmoFactory.AmmoType.LaserGreen
            Case AmmoFactory.AmmoType.LaserRed
        End Select
        OutText("NOT created ammo!")
    End Sub
End Module
