<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class frmHelp
    Inherits System.Windows.Forms.Form

    'Form overrides dispose to clean up the component list.
    <System.Diagnostics.DebuggerNonUserCode()>
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
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Dim resources As System.ComponentModel.ComponentResourceManager = New System.ComponentModel.ComponentResourceManager(GetType(frmHelp))
        Me.lblHelpTitle = New System.Windows.Forms.Label()
        Me.lblHelpText = New System.Windows.Forms.Label()
        Me.SuspendLayout()
        '
        'lblHelpTitle
        '
        Me.lblHelpTitle.AutoSize = True
        Me.lblHelpTitle.Font = New System.Drawing.Font("Microsoft Sans Serif", 30.0!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.lblHelpTitle.Location = New System.Drawing.Point(117, 9)
        Me.lblHelpTitle.Name = "lblHelpTitle"
        Me.lblHelpTitle.Size = New System.Drawing.Size(259, 46)
        Me.lblHelpTitle.TabIndex = 0
        Me.lblHelpTitle.Text = "How To Play"
        '
        'lblHelpText
        '
        Me.lblHelpText.BackColor = System.Drawing.Color.Transparent
        Me.lblHelpText.Font = New System.Drawing.Font("Microsoft Sans Serif", 12.0!)
        Me.lblHelpText.Location = New System.Drawing.Point(12, 78)
        Me.lblHelpText.Name = "lblHelpText"
        Me.lblHelpText.Size = New System.Drawing.Size(490, 355)
        Me.lblHelpText.TabIndex = 1
        Me.lblHelpText.Text = resources.GetString("lblHelpText.Text")
        '
        'frmHelp
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(514, 442)
        Me.Controls.Add(Me.lblHelpText)
        Me.Controls.Add(Me.lblHelpTitle)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Icon = CType(resources.GetObject("$this.Icon"), System.Drawing.Icon)
        Me.Name = "frmHelp"
        Me.Text = "Help"
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents lblHelpTitle As Label
    Friend WithEvents lblHelpText As Label
End Class
