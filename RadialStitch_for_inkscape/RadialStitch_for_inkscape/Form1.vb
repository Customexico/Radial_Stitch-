Imports System
Imports System.IO
Imports System.Text
Imports Microsoft.VisualBasic.FileIO

Public Class Form1
    Private Const head As String = "<path style=" & Chr(34) & " fill : none;stroke:#000000;stroke-width:0.1;stroke-opacity:1" & Chr(34) & " d=" & Chr(34) & "M "
    Private Const head2 As String = Chr(34) & " id=" & Chr(34)

    Private Sub Label1_Click(sender As Object, e As EventArgs) Handles lblUpperCSV.Click

    End Sub

    Private Sub TextBox1_TextChanged(sender As Object, e As EventArgs) Handles txtUpper.TextChanged

    End Sub

    Private Sub btnUpperCSVDialog_Click(sender As Object, e As EventArgs) Handles btnUpperCSVDialog.Click
        Dim upofd As New OpenFileDialog()
        upofd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
        'ダイアログを表示する
        If upofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            txtUpper.Text = upofd.FileName
        End If
    End Sub

    Private Sub btnLowerCSVDialog_Click(sender As Object, e As EventArgs) Handles btnLowerCSVDialog.Click
        Dim loofd As New OpenFileDialog()
        loofd.Filter = "CSVファイル(*.csv)|*.csv|すべてのファイル(*.*)|*.*"
        'ダイアログを表示する
        If loofd.ShowDialog() = DialogResult.OK Then
            'OKボタンがクリックされたとき、選択されたファイル名を表示する
            txtLower.Text = loofd.FileName
        End If
    End Sub

    Private Sub btnRun_Click(sender As Object, e As EventArgs) Handles btnRun.Click
        '上弦の座標読み込み
        Dim UpPath As String = txtUpper.Text
        Dim UpCdn As ArrayList = New ArrayList()
        UpCdn = GetCoordinate_CSV(UpPath)
        '下弦の座標読み込み
        Dim LowPath As String = txtLower.Text
        Dim LowCdn As ArrayList = New ArrayList()
        LowCdn = GetCoordinate_CSV(LowPath)

        Dim LineAllPath As ArrayList = GetLinePath(UpCdn, LowCdn)

        Dim Cnt As Integer = 0
        For Each str As String In LineAllPath

            Console.WriteLine(head & str & head2 & "test" & Cnt.ToString & Chr(34) & " />")
            Cnt = Cnt + 1
        Next


    End Sub

    Private Function GetCoordinate_CSV(ByRef CSVpath As String) As ArrayList
        Dim Alrtn As ArrayList = New ArrayList()
        Dim line As String = ""

        Using sr As StreamReader = New StreamReader(CSVpath, Encoding.GetEncoding("Shift_JIS"))
            line = sr.ReadLine()
            Do Until line Is Nothing
                Alrtn.Add(line)
                line = sr.ReadLine()
            Loop
        End Using

        Return Alrtn

    End Function

    Private Function GetLinePath(ByRef alUp As ArrayList, ByRef alLow As ArrayList) As ArrayList

        Dim Cnt As Integer = alUp.Count
        '
        Dim blnfirst As Boolean = True
        '計算時の母数
        Dim SpreadParm As Integer = Integer.Parse(txtSpread.Text)
        '計算の回数
        Dim SpreadCnt As Integer = Integer.Parse(txtSpread.Text) - 1
        'ずらし数
        Dim Shift As Integer = Integer.Parse(txtShift.Text)

        '全ライン分出力
        Dim AllLineList As ArrayList = New ArrayList()

        'CSVから出力した座標を一行ずつ処理
        For i As Integer = 0 To Cnt - 1
            Dim Upstr() As String = alUp.Item(i).ToString.Split(",")
            Dim Lowstr() As String = alLow.Item(i).ToString.Split(",")

            Dim UpX As Decimal = Decimal.Parse(Upstr(0))
            Dim UpY As Decimal = Decimal.Parse(Upstr(1))
            Dim LowX As Decimal = Decimal.Parse(Lowstr(0))
            Dim LowY As Decimal = Decimal.Parse(Lowstr(1))


            '1行ごとパス計算
            Dim TempLinePoint As Decimal(,) = CalcPath(blnfirst, UpX, UpY, LowX, LowY, SpreadParm, SpreadCnt, Shift, i + 1)

            Dim TempPointStr As String = ""
            For j As Integer = 0 To TempLinePoint.GetLength(0) - 1
                TempPointStr = TempPointStr & TempLinePoint(j, 0).ToString() & "," & TempLinePoint(j, 1).ToString() & " "
            Next
            AllLineList.Add(TempPointStr)

            If blnfirst Then
                blnfirst = False
            Else
                blnfirst = True
            End If

        Next

        Return AllLineList

    End Function

    'CalcPath 渡された直線を示す座標から、
    Private Function CalcPath(ByRef blnfirst As Boolean, ByRef UpX As Decimal, ByRef UpY As Decimal, ByRef LowX As Decimal, ByRef LowY As Decimal,
                              ByRef SpreadParm As Integer, ByRef SpreadCnt As Integer, ByRef Shift As Integer, ByRef CntLine As Integer) As Decimal(,)

        'ずらし数計算

        'ずらし数計算の有無
        Dim blnShift As Boolean = False
        Dim intShiftMolec As Integer = 0
        '一巡している場合はずらしの計算は行わない
        If Not (CntLine = 1 OrElse (CntLine - 1) Mod Shift = 0) Then
            blnShift = True
            intShiftMolec = (CntLine - 1) Mod Shift
        End If

        '座標計算保持用（奇数と同様の内容）
        Dim tempPoint(SpreadParm, 1) As Decimal

        'If blnfirst Then
        tempPoint(0, 0) = UpX
        tempPoint(0, 1) = UpY
        tempPoint(SpreadParm, 0) = LowX
        tempPoint(SpreadParm, 1) = LowY
        '座標計算

        '引かれる値
        Dim PlusVal As Decimal = 0
        '引く値
        Dim MinusVal As Decimal = 0
        '原点からの増分
        Dim IncVal As Decimal = 0

        Dim XSta As Integer = 0
        Dim XEnd As Integer = 0
        Dim XSte As Integer = 0
        Dim YSta As Integer = 0
        Dim YEnd As Integer = 0
        Dim YSte As Integer = 0

        '上弦の座標が大きい（下方向）の場合
        '分子をカウントダウンして計算する。

        '上弦の座標が小さい（上方向）の場合
        '分子をカウントアップして計算する。

        'X方向の上弦座標が大きいか
        Dim blnUpX As Boolean = True
        'Y方向の上弦座標が大きいか
        Dim blnUpY As Boolean = True


        'X軸の計算
        If UpX > LowX Then
            PlusVal = UpX
            MinusVal = LowX
            IncVal = LowX
            blnUpX = True
            XSta = SpreadCnt
            XEnd = 1
            XSte = -1
        Else
            PlusVal = LowX
            MinusVal = UpX
            IncVal = UpX
            blnUpX = False
            XSta = 1
            XEnd = SpreadCnt
            XSte = 1
        End If

        '上弦、下弦が同じ場合は計算しない
        If UpX <> LowX Then

            '座標計算保持用添え字
            Dim TempXValCnt As Integer = 1

            For molec As Integer = XSta To XEnd Step XSte

                Dim tempX As Decimal = ((PlusVal - MinusVal) * (molec / SpreadParm)) + IncVal
                tempPoint(TempXValCnt, 0) = tempX
                Console.WriteLine(tempX)
                TempXValCnt = TempXValCnt + 1
            Next
        End If

        'Y軸の計算
        If UpY > LowY Then
            PlusVal = UpY
            MinusVal = LowY
            IncVal = LowY
            blnUpY = True
            YSta = SpreadCnt
            YEnd = 1
            YSte = -1
        Else
            PlusVal = LowY
            MinusVal = UpY
            IncVal = UpY
            blnUpY = False
            YSta = 1
            YEnd = SpreadCnt
            YSte = 1
        End If


        '上弦、下弦が同じ場合は計算しない
        If UpY <> LowY Then

            '座標計算保持用添え字
            Dim TempYValCnt As Integer = 1

            For molec As Integer = YSta To YEnd Step YSte

                Dim tempY As Decimal = ((PlusVal - MinusVal) * (molec / SpreadParm)) + IncVal
                tempPoint(TempYValCnt, 1) = tempY
                Console.WriteLine(tempY)
                TempYValCnt = TempYValCnt + 1
            Next
        End If

        'ずらし計算
        If blnShift Then

            'ずらした場合、パスが1つ増える
            Dim ShifttempPoint(SpreadParm + 1, 1) As Decimal
            'ずらし計算用添字
            Dim ShiftSubscript As Integer = 1
            Dim Molec As Integer = 0

            ShifttempPoint(0, 0) = tempPoint(0, 0)
            ShifttempPoint(0, 1) = tempPoint(0, 1)
            ShifttempPoint(SpreadParm + 1, 0) = tempPoint(tempPoint.GetLength(0) - 1, 0)
            ShifttempPoint(SpreadParm + 1, 1) = tempPoint(tempPoint.GetLength(0) - 1, 1)

            For j As Integer = 1 To tempPoint.GetLength(0) - 1
                Molec = 0
                'ShiftUpX
                Dim ShiftUpX = tempPoint(j - 1, 0)
                'ShiftUpY
                Dim ShiftUpY = tempPoint(j - 1, 1)
                'ShiftLowX
                Dim ShiftLowX = tempPoint(j, 0)
                'ShiftLowY
                Dim ShiftLowY = tempPoint(j, 1)

                'X軸の計算
                If ShiftUpX > ShiftLowX Then
                    PlusVal = ShiftUpX
                    MinusVal = ShiftLowX
                    IncVal = ShiftLowX
                    blnUpX = True
                    Molec = intShiftMolec
                Else
                    PlusVal = ShiftLowX
                    MinusVal = ShiftUpX
                    IncVal = ShiftUpX
                    blnUpX = False
                    Molec = Shift - intShiftMolec
                End If

                '上弦、下弦が同じ場合は計算しない
                If ShiftUpX <> ShiftLowX Then
                    Dim tempX As Decimal = ((PlusVal - MinusVal) * (Molec / Shift)) + IncVal
                    ShifttempPoint(ShiftSubscript, 0) = tempX
                End If

                'Y軸の計算
                If ShiftUpY > ShiftLowY Then
                    PlusVal = ShiftUpY
                    MinusVal = ShiftLowY
                    IncVal = ShiftLowY
                    blnUpX = True
                    Molec = intShiftMolec
                Else
                    PlusVal = ShiftLowY
                    MinusVal = ShiftUpY
                    IncVal = ShiftUpY
                    blnUpX = False
                    Molec = Shift - intShiftMolec
                End If

                '上弦、下弦が同じ場合は計算しない
                If ShiftUpY <> ShiftLowY Then
                    Dim tempY As Decimal = ((PlusVal - MinusVal) * (Molec / Shift)) + IncVal
                    ShifttempPoint(ShiftSubscript, 1) = tempY
                End If

                ShiftSubscript = ShiftSubscript + 1

            Next

            If Not blnfirst Then
                ShifttempPoint = Reverse_TwoDimensional_dec(ShifttempPoint)
            End If

            Return ShifttempPoint

            Exit Function

        End If

        If Not blnfirst Then
            tempPoint = Reverse_TwoDimensional_dec(tempPoint)
        End If

        Return tempPoint


    End Function

    'Decimalの二次元配列を逆転する
    Private Function Reverse_TwoDimensional_dec(ByVal Array(,) As Decimal) As Decimal(,)

        Dim ReArray(Array.GetLength(0) - 1, Array.GetLength(1) - 1) As Decimal

        Dim ReAryCnt As Integer = Array.GetLength(0) - 1

        For AryCnt As Integer = 0 To Array.GetLength(0) - 1
            ReArray(ReAryCnt, 0) = Array(AryCnt, 0)
            ReArray(ReAryCnt, 1) = Array(AryCnt, 1)

            ReAryCnt = ReAryCnt - 1
        Next

        Return ReArray

    End Function


End Class
