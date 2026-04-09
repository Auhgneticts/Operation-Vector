Imports System.IO
Public Module ImageLoader
    Dim workingBitmap As Bitmap
    Function Load() As SortedList(Of String, Bitmap)
        'Dim imageFolder As String = "bitbin"
        Dim basePath As String = AppDomain.CurrentDomain.BaseDirectory
        Dim imagePath As String = Path.Combine(basePath, "bitbin")
        Dim list As New SortedList(Of String, Bitmap)
        Dim frameCount As Integer
        Dim imageName As String = ""
        For Each file As String In Directory.GetFiles(imagePath, "*.bmp")
            Try
                Dim fileName = Path.GetFileNameWithoutExtension(file)
                Dim i = fileName.LastIndexOf("-"c)
                If i > 0 Then
                    imageName = fileName.Substring(0, i)
                    Dim num As Integer
                    If Integer.TryParse(fileName.AsSpan(i + 1), num) Then frameCount = num
                End If
            Catch ex As ArgumentException
                MessageBox.Show("There was an error." _
            & "Check the path to the image file.")
            End Try
            workingBitmap = New Bitmap(file)
            workingBitmap.MakeTransparent(Color.Magenta)
            list.Add(imageName, workingBitmap)
            workingBitmap = Nothing
        Next
        Return list
    End Function
End Module