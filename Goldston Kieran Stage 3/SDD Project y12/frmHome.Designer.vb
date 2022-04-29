<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmHome
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
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

    'Required by the Windows Form Designer
    Private components As System.ComponentModel.IContainer

    'NOTE: The following procedure is required by the Windows Form Designer
    'It can be modified using the Windows Form Designer.  
    'Do not modify it using the code editor.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHome))
        Me.btnHighScores = New System.Windows.Forms.Button()
        Me.BtnPlay = New System.Windows.Forms.Button()
        Me.txtPlayer1 = New System.Windows.Forms.TextBox()
        Me.txtPlayer2 = New System.Windows.Forms.TextBox()
        Me.lblTitle = New System.Windows.Forms.Label()
        Me.lblPlayer1 = New System.Windows.Forms.Label()
        Me.lblPlayer2 = New System.Windows.Forms.Label()
        Me.btnHelp = New System.Windows.Forms.Button()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'btnHighScores
        '
        Me.btnHighScores.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnHighScores.BackgroundImage = Global.SDD_Project_y12.My.Resources.Resources.istockphoto_1145602814_612x612
        Me.btnHighScores.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHighScores.ForeColor = System.Drawing.Color.White
        Me.btnHighScores.Location = New System.Drawing.Point(45, 298)
        Me.btnHighScores.Name = "btnHighScores"
        Me.btnHighScores.Size = New System.Drawing.Size(113, 67)
        Me.btnHighScores.TabIndex = 165
        Me.btnHighScores.Text = "High Scores"
        Me.btnHighScores.UseVisualStyleBackColor = False
        '
        'BtnPlay
        '
        Me.BtnPlay.BackColor = System.Drawing.Color.LimeGreen
        Me.BtnPlay.BackgroundImage = Global.SDD_Project_y12.My.Resources.Resources.istockphoto_1145602814_612x612
        Me.BtnPlay.Font = New System.Drawing.Font("Microsoft Sans Serif", 20.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.BtnPlay.ForeColor = System.Drawing.Color.White
        Me.BtnPlay.Location = New System.Drawing.Point(45, 225)
        Me.BtnPlay.Name = "BtnPlay"
        Me.BtnPlay.Size = New System.Drawing.Size(113, 67)
        Me.BtnPlay.TabIndex = 166
        Me.BtnPlay.Text = "Play"
        Me.BtnPlay.UseVisualStyleBackColor = False
        '
        'txtPlayer1
        '
        Me.txtPlayer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.txtPlayer1.Location = New System.Drawing.Point(379, 268)
        Me.txtPlayer1.Name = "txtPlayer1"
        Me.txtPlayer1.Size = New System.Drawing.Size(266, 30)
        Me.txtPlayer1.TabIndex = 167
        Me.txtPlayer1.Text = "Player1"
        '
        'txtPlayer2
        '
        Me.txtPlayer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.txtPlayer2.Location = New System.Drawing.Point(379, 314)
        Me.txtPlayer2.Name = "txtPlayer2"
        Me.txtPlayer2.Size = New System.Drawing.Size(266, 30)
        Me.txtPlayer2.TabIndex = 168
        Me.txtPlayer2.Text = "Player2"
        '
        'lblTitle
        '
        Me.lblTitle.AutoSize = True
        Me.lblTitle.BackColor = System.Drawing.Color.Transparent
        Me.lblTitle.Font = New System.Drawing.Font("Stencil", 39.75!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblTitle.ForeColor = System.Drawing.Color.Black
        Me.lblTitle.Location = New System.Drawing.Point(196, 34)
        Me.lblTitle.Name = "lblTitle"
        Me.lblTitle.Size = New System.Drawing.Size(305, 63)
        Me.lblTitle.TabIndex = 169
        Me.lblTitle.Text = "Checkers"
        '
        'lblPlayer1
        '
        Me.lblPlayer1.AutoSize = True
        Me.lblPlayer1.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayer1.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lblPlayer1.Location = New System.Drawing.Point(222, 271)
        Me.lblPlayer1.Name = "lblPlayer1"
        Me.lblPlayer1.Size = New System.Drawing.Size(151, 25)
        Me.lblPlayer1.TabIndex = 170
        Me.lblPlayer1.Text = "Player 1 Name :"
        '
        'lblPlayer2
        '
        Me.lblPlayer2.AutoSize = True
        Me.lblPlayer2.BackColor = System.Drawing.Color.Transparent
        Me.lblPlayer2.Font = New System.Drawing.Font("Microsoft Sans Serif", 15.0!)
        Me.lblPlayer2.Location = New System.Drawing.Point(222, 317)
        Me.lblPlayer2.Name = "lblPlayer2"
        Me.lblPlayer2.Size = New System.Drawing.Size(151, 25)
        Me.lblPlayer2.TabIndex = 171
        Me.lblPlayer2.Text = "Player 2 Name :"
        '
        'btnHelp
        '
        Me.btnHelp.BackColor = System.Drawing.Color.SlateGray
        Me.btnHelp.Font = New System.Drawing.Font("Microsoft Sans Serif", 8.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnHelp.ForeColor = System.Drawing.Color.White
        Me.btnHelp.Location = New System.Drawing.Point(608, 12)
        Me.btnHelp.Name = "btnHelp"
        Me.btnHelp.Size = New System.Drawing.Size(78, 33)
        Me.btnHelp.TabIndex = 172
        Me.btnHelp.Text = "Help"
        Me.btnHelp.UseVisualStyleBackColor = False
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.BackColor = System.Drawing.Color.Transparent
        Me.Label1.Font = New System.Drawing.Font("Stencil", 17.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(185, 225)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(501, 27)
        Me.Label1.TabIndex = 173
        Me.Label1.Text = "Enter Player Names Before You Begin"
        '
        'frmHome
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SDD_Project_y12.My.Resources.Resources.Brown_wooden_parquet_texture
        Me.ClientSize = New System.Drawing.Size(698, 407)
        Me.Controls.Add(Me.Label1)
        Me.Controls.Add(Me.btnHelp)
        Me.Controls.Add(Me.lblPlayer2)
        Me.Controls.Add(Me.lblPlayer1)
        Me.Controls.Add(Me.lblTitle)
        Me.Controls.Add(Me.txtPlayer2)
        Me.Controls.Add(Me.txtPlayer1)
        Me.Controls.Add(Me.BtnPlay)
        Me.Controls.Add(Me.btnHighScores)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(714, 446)
        Me.MinimumSize = New System.Drawing.Size(714, 446)
        Me.Name = "frmHome"
        Me.Text = "Home Screen"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents btnHighScores As Button
    Friend WithEvents BtnPlay As Button
    Friend WithEvents txtPlayer1 As TextBox
    Friend WithEvents txtPlayer2 As TextBox
    Friend WithEvents lblTitle As Label
    Friend WithEvents lblPlayer1 As Label
    Friend WithEvents lblPlayer2 As Label
    Friend WithEvents btnHelp As Button
    Friend WithEvents Label1 As Label
End Class
