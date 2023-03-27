<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
    Inherits System.Windows.Forms.Form

    'フォームがコンポーネントの一覧をクリーンアップするために dispose をオーバーライドします。
    <System.Diagnostics.DebuggerNonUserCode()> _
    Protected Overrides Sub Dispose(ByVal disposing As Boolean)
        Try
            If disposing AndAlso components IsNot Nothing Then
                components.Dispose()
            End If
        Finally
            MyBase.Dispose(disposing)
        End Try
    End Sub

    'Windows フォーム デザイナーで必要です。
    Private components As System.ComponentModel.IContainer

    'メモ: 以下のプロシージャは Windows フォーム デザイナーで必要です。
    'Windows フォーム デザイナーを使用して変更できます。  
    'コード エディターを使って変更しないでください。
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.btnRun = New System.Windows.Forms.Button()
        Me.lblUpperCSV = New System.Windows.Forms.Label()
        Me.lblLowerCSV = New System.Windows.Forms.Label()
        Me.txtUpper = New System.Windows.Forms.TextBox()
        Me.btnUpperCSVDialog = New System.Windows.Forms.Button()
        Me.btnLowerCSVDialog = New System.Windows.Forms.Button()
        Me.txtLower = New System.Windows.Forms.TextBox()
        Me.lblspred = New System.Windows.Forms.Label()
        Me.txtSpread = New System.Windows.Forms.TextBox()
        Me.txtShift = New System.Windows.Forms.TextBox()
        Me.lblShift = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnRun
        '
        Me.btnRun.Location = New System.Drawing.Point(423, 143)
        Me.btnRun.Name = "btnRun"
        Me.btnRun.Size = New System.Drawing.Size(131, 52)
        Me.btnRun.TabIndex = 0
        Me.btnRun.Text = "実行"
        Me.btnRun.UseVisualStyleBackColor = True
        '
        'lblUpperCSV
        '
        Me.lblUpperCSV.AutoSize = True
        Me.lblUpperCSV.Location = New System.Drawing.Point(17, 18)
        Me.lblUpperCSV.Name = "lblUpperCSV"
        Me.lblUpperCSV.Size = New System.Drawing.Size(52, 12)
        Me.lblUpperCSV.TabIndex = 1
        Me.lblUpperCSV.Text = "上弦CSV"
        '
        'lblLowerCSV
        '
        Me.lblLowerCSV.AutoSize = True
        Me.lblLowerCSV.Location = New System.Drawing.Point(17, 45)
        Me.lblLowerCSV.Name = "lblLowerCSV"
        Me.lblLowerCSV.Size = New System.Drawing.Size(52, 12)
        Me.lblLowerCSV.TabIndex = 2
        Me.lblLowerCSV.Text = "下弦CSV"
        '
        'txtUpper
        '
        Me.txtUpper.Location = New System.Drawing.Point(100, 15)
        Me.txtUpper.Name = "txtUpper"
        Me.txtUpper.Size = New System.Drawing.Size(317, 19)
        Me.txtUpper.TabIndex = 3
        '
        'btnUpperCSVDialog
        '
        Me.btnUpperCSVDialog.Location = New System.Drawing.Point(423, 15)
        Me.btnUpperCSVDialog.Name = "btnUpperCSVDialog"
        Me.btnUpperCSVDialog.Size = New System.Drawing.Size(69, 19)
        Me.btnUpperCSVDialog.TabIndex = 4
        Me.btnUpperCSVDialog.Text = "参照"
        Me.btnUpperCSVDialog.UseVisualStyleBackColor = True
        '
        'btnLowerCSVDialog
        '
        Me.btnLowerCSVDialog.Location = New System.Drawing.Point(423, 45)
        Me.btnLowerCSVDialog.Name = "btnLowerCSVDialog"
        Me.btnLowerCSVDialog.Size = New System.Drawing.Size(69, 19)
        Me.btnLowerCSVDialog.TabIndex = 5
        Me.btnLowerCSVDialog.Text = "参照"
        Me.btnLowerCSVDialog.UseVisualStyleBackColor = True
        '
        'txtLower
        '
        Me.txtLower.Location = New System.Drawing.Point(100, 42)
        Me.txtLower.Name = "txtLower"
        Me.txtLower.Size = New System.Drawing.Size(317, 19)
        Me.txtLower.TabIndex = 6
        '
        'lblspred
        '
        Me.lblspred.AutoSize = True
        Me.lblspred.Location = New System.Drawing.Point(12, 70)
        Me.lblspred.Name = "lblspred"
        Me.lblspred.Size = New System.Drawing.Size(81, 12)
        Me.lblspred.TabIndex = 7
        Me.lblspred.Text = "1列目の分割数"
        '
        'txtSpread
        '
        Me.txtSpread.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtSpread.Location = New System.Drawing.Point(99, 67)
        Me.txtSpread.Name = "txtSpread"
        Me.txtSpread.ShortcutsEnabled = False
        Me.txtSpread.Size = New System.Drawing.Size(60, 19)
        Me.txtSpread.TabIndex = 8
        '
        'txtShift
        '
        Me.txtShift.ImeMode = System.Windows.Forms.ImeMode.Disable
        Me.txtShift.Location = New System.Drawing.Point(100, 96)
        Me.txtShift.Name = "txtShift"
        Me.txtShift.ShortcutsEnabled = False
        Me.txtShift.Size = New System.Drawing.Size(60, 19)
        Me.txtShift.TabIndex = 9
        '
        'lblShift
        '
        Me.lblShift.AutoSize = True
        Me.lblShift.Location = New System.Drawing.Point(13, 99)
        Me.lblShift.Name = "lblShift"
        Me.lblShift.Size = New System.Drawing.Size(44, 12)
        Me.lblShift.TabIndex = 10
        Me.lblShift.Text = "ずらし数"
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 12.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(619, 255)
        Me.Controls.Add(Me.lblShift)
        Me.Controls.Add(Me.txtShift)
        Me.Controls.Add(Me.txtSpread)
        Me.Controls.Add(Me.lblspred)
        Me.Controls.Add(Me.txtLower)
        Me.Controls.Add(Me.btnLowerCSVDialog)
        Me.Controls.Add(Me.btnUpperCSVDialog)
        Me.Controls.Add(Me.txtUpper)
        Me.Controls.Add(Me.lblLowerCSV)
        Me.Controls.Add(Me.lblUpperCSV)
        Me.Controls.Add(Me.btnRun)
        Me.Name = "Form1"
        Me.Text = "Form1"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnRun As Button
    Friend WithEvents lblUpperCSV As Label
    Friend WithEvents lblLowerCSV As Label
    Friend WithEvents txtUpper As TextBox
    Friend WithEvents btnUpperCSVDialog As Button
    Friend WithEvents btnLowerCSVDialog As Button
    Friend WithEvents txtLower As TextBox
    Friend WithEvents lblspred As Label
    Friend WithEvents txtSpread As TextBox
    Friend WithEvents txtShift As TextBox
    Friend WithEvents lblShift As Label
End Class
