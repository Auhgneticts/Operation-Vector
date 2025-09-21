Public Class BaseObject
    'FIX BITMAP LOADING
    Friend bitmapValue As Drawing.Bitmap 'Load from Main to Handle???
    Friend bitmapIntPtr As IntPtr
    Friend locationValueF As PointF
    Friend sizeF As SizeF
    Friend rectangleValueF As RectangleF
    Friend weight As Integer
    Friend health As Integer
    Public isAlive As Boolean = False
    Public name As String
    Friend group As String
    Friend scale As Short
End Class