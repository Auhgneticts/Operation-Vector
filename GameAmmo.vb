Module GameAmmo
    'Collection of Ammo handling Functions 

    Friend ammoFactory As New AmmoFactory
    Friend ammoOrderList As New List(Of AmmoFactory.AmmoType)
    Friend ammoAutoSelect As Boolean = False
    Friend ammoPool As Collection
    Friend allAmmo As New Dictionary(Of AmmoFactory.AmmoType, Queue(Of Ammo))
    Friend selectedIndex As Integer = 0
    Friend ammoBulletBigList As New Queue(Of Ammo)
    Friend ammoBulletList As New Queue(Of Ammo)
    Friend ammoRodBigList As New Queue(Of Ammo)
    Friend ammoRodList As New Queue(Of Ammo)

    Friend Function GetAmmoPowerImg()
        Dim bit As Bitmap = gameBitmaps(GetAmmoPowerImgName)
        bit.MakeTransparent()
        Return bit
    End Function
    Friend Function GetAmmoPowerImgName()
        Dim tString As String = "Power" + allAmmo(0)(0).imageName
        Return tString
    End Function
    Friend Function GetAmmoType()
        Return ammoOrderList(selectedIndex).ToString
    End Function

    Friend Sub AmmoSelect(newAmmo As AmmoFactory.AmmoType)
        'If ammo.gunType = newAmmo.gunType ...
        Select Case newAmmo
            Case AmmoFactory.AmmoType.BulletBig
                If ammoBulletBigList.Count > 0 Then
                    'ammoOrderList = AmmoFactory.AmmoType.BulletBig
                End If
            Case AmmoFactory.AmmoType.Bullet
                If ammoBulletList.Count > 0 Then
                    'ammoOrderList = AmmoFactory.AmmoType.Bullet
                End If
                'Case AmmoFactory.AmmoType.Rod
                '    If ammoRodList.Count > 0 Then
                '        selectedAmmo = AmmoFactory.AmmoType.Rod
                '    End If
        End Select
    End Sub

    Friend Sub AddAmmo(ammoType As AmmoFactory.AmmoType, ammoRefill As Queue(Of Ammo))
        '''
        '''FIX THIS
        '''
        'get Ammo from Power Up Refills
        'Add the correct type to the ammo list
        For Each a As Ammo In ammoRefill
            allAmmo(ammoType).Enqueue(a)
        Next

        OutText("Picked up " + ammoRefill.Count.ToString + "  rounds of " + ammoType.ToString + "s")

    End Sub
End Module