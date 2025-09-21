Imports System.IO
Public Module ImageLoader
    Dim workingBitmap As Bitmap
    Function Load() As SortedList(Of String, Bitmap)
        Dim workingPath As String
        Dim tempName As String
        Dim list As New SortedList(Of String, Bitmap)
        workingPath = My.Application.Info.DirectoryPath + "\bitbin"
        Dim workingDir As New DirectoryInfo(workingPath)
        For Each f In workingDir.EnumerateFiles
            Try
                workingBitmap = New Bitmap(f.FullName)
            Catch ex As ArgumentException
                MessageBox.Show("There was an error." _
            & "Check the path to the image file.")
            End Try
            workingBitmap.MakeTransparent(Color.Magenta)
            tempName = f.Name.Remove(f.Name.Length - 4)
            list.Add(tempName, workingBitmap)
            workingBitmap = Nothing
            tempName = ""
        Next
        Return list
        workingDir = Nothing
        workingPath = Nothing
    End Function
End Module