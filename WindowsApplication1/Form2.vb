Imports System.Drawing
Public Class Form2
    Public Property no As Byte = 0
    Dim total As Long = 0, proper As Long = 0
    Dim gra As Graphics
    Const radius As Single = 205
    Const pi As Single = 3.1415926
    Private Sub Form2_Load(sender As Object, e As EventArgs) Handles Me.Load
        If no = 0 Then Me.Dispose()
        Select Case no
            Case 1
                Label5.Text = "圆上按照均等的概率" & Chr(10) & "放置点并连接成弦"
            Case 2
                Label5.Text = "圆内按照均等的弦心距" & Chr(10) & "水平作出弦"
            Case 3
                Label5.Text = "圆内按照均等的概率" & Chr(10) & "放置垂足并连接成弦"
        End Select
        TextBox1.Text = "20"
        TextBox2.Text = "0"
        TextBox3.Text = "0"
        Timer1.Interval = Int(1000 / Val(TextBox1.Text))
    End Sub
    Sub Draw()
        gra = Me.CreateGraphics
        '圆心(225,225)，半径205
        gra.DrawEllipse(Pens.Red, 20, 20, 410, 410)
        gra.FillEllipse(Brushes.Red, 222, 222, 6, 6)
    End Sub
    Private Sub Form2_Shown(sender As Object, e As EventArgs) Handles Me.Shown
        Draw()
    End Sub

    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Timer1.Enabled = Not (Timer1.Enabled)
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        On Error Resume Next
        Timer1.Interval = Int(1000 / Val(TextBox1.Text))
    End Sub

    Private Sub Timer1_Tick(sender As Object, e As EventArgs) Handles Timer1.Tick
        Randomize()
        Dim random As Single '表示弧度
        Dim rand As Random = New Random
        Dim point1 As Point = New Point, point2 As Point = New Point
        Select Case no
            Case 1
                random = -pi + rand.NextDouble * 2 * pi
                point1.X = 225 + CSng(radius * Math.Cos(random))
                point1.Y = 225 + CSng(radius * Math.Sin(random))
                random = -pi + rand.NextDouble * 2 * pi
                point2.X = 225 + CSng(radius * Math.Cos(random))
                point2.Y = 225 + CSng(radius * Math.Sin(random))

            Case 2
                random = Int(-radius + rand.NextDouble * radius * 2)
                point1.Y = 225 + random
                point2.Y = 225 + random
                point1.X = 225 - Math.Sqrt(radius ^ 2 - random ^ 2)
                point2.X = 225 + Math.Sqrt(radius ^ 2 - random ^ 2)
            Case 3
                Dim d As Single
                Do
                    random = Int(-radius + rand.NextDouble * radius * 2)
                    point1.X = 225 + random
                    random = Int(-radius + rand.NextDouble * radius * 2)
                    point1.Y = 225 + random
                    d = length(point1, New Point(225, 225))
                Loop Until d <= radius
                d = Math.Sqrt(radius ^ 2 - d ^ 2)
                point2.X = point1.X + d * Math.Sin(Math.Atan((point1.Y - 225) / (point1.X - 225)))
                point2.Y = point1.Y - d * Math.Cos(Math.Atan((point1.Y - 225) / (point1.X - 225)))
                point1.X = 2 * point1.X - point2.X
                point1.Y = 2 * point1.Y - point2.Y
        End Select
        'gra.FillEllipse(Brushes.Black, point1.X - 2, point1.Y - 2, 4, 4)
        'gra.FillEllipse(Brushes.Black, point2.X - 2, point2.Y - 2, 4, 4)
        gra.DrawLine(Pens.Black, point1, point2)
        total += 1
        If length(point1, point2) > Math.Sqrt(3) * radius Then proper += 1
        TextBox2.Text = total
        TextBox3.Text = proper
        TextBox4.Text = proper / total
    End Sub
    Function length(p1 As Point, p2 As Point) As Single
        Return Math.Sqrt((p1.X - p2.X) ^ 2 + (p1.Y - p2.Y) ^ 2)
    End Function
End Class