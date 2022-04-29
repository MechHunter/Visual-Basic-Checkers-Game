<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class frmScores
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
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmScores))
        Me.lstScores = New System.Windows.Forms.ListBox()
        Me.btnBack = New System.Windows.Forms.Button()
        Me.btnRefresh = New System.Windows.Forms.Button()
        Me.SuspendLayout()
        '
        'lstScores
        '
        Me.lstScores.FormattingEnabled = True
        Me.lstScores.Location = New System.Drawing.Point(12, 30)
        Me.lstScores.Name = "lstScores"
        Me.lstScores.Size = New System.Drawing.Size(470, 251)
        Me.lstScores.TabIndex = 0
        '
        'btnBack
        '
        Me.btnBack.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnBack.BackgroundImage = Global.SDD_Project_y12.My.Resources.Resources.istockphoto_1145602814_612x612
        Me.btnBack.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnBack.ForeColor = System.Drawing.Color.White
        Me.btnBack.Location = New System.Drawing.Point(541, 214)
        Me.btnBack.Name = "btnBack"
        Me.btnBack.Size = New System.Drawing.Size(113, 67)
        Me.btnBack.TabIndex = 166
        Me.btnBack.Text = "Back"
        Me.btnBack.UseVisualStyleBackColor = False
        '
        'btnRefresh
        '
        Me.btnRefresh.BackColor = System.Drawing.Color.DodgerBlue
        Me.btnRefresh.FlatAppearance.MouseDownBackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.FlatAppearance.MouseOverBackColor = System.Drawing.Color.Transparent
        Me.btnRefresh.FlatStyle = System.Windows.Forms.FlatStyle.System
        Me.btnRefresh.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.btnRefresh.ForeColor = System.Drawing.Color.White
        Me.btnRefresh.Location = New System.Drawing.Point(541, 30)
        Me.btnRefresh.Name = "btnRefresh"
        Me.btnRefresh.Size = New System.Drawing.Size(113, 40)
        Me.btnRefresh.TabIndex = 167
        Me.btnRefresh.Text = "Refresh"
        Me.btnRefresh.UseVisualStyleBackColor = False
        Me.btnRefresh.Visible = False
        '
        'frmScores
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.BackgroundImage = Global.SDD_Project_y12.My.Resources.Resources.Brown_wooden_parquet_texture
        Me.ClientSize = New System.Drawing.Size(689, 294)
        Me.Controls.Add(Me.btnRefresh)
        Me.Controls.Add(Me.btnBack)
        Me.Controls.Add(Me.lstScores)
        Me.HelpButton = True
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.MaximumSize = New System.Drawing.Size(705, 333)
        Me.MinimumSize = New System.Drawing.Size(705, 333)
        Me.Name = "frmScores"
        Me.Text = "frmScores"
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents lstScores As ListBox
    Friend WithEvents btnBack As Button
    Friend WithEvents btnRefresh As Button
End Class
