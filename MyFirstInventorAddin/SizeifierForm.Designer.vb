<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class SizeifierForm
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
        Me.components = New System.ComponentModel.Container()
        Me.lbAddinName = New System.Windows.Forms.Label()
        Me.ErrorProvider1 = New System.Windows.Forms.ErrorProvider(Me.components)
        Me.ToolTip1 = New System.Windows.Forms.ToolTip(Me.components)
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.tbCurrentPart = New System.Windows.Forms.TextBox()
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'lbAddinName
        '
        Me.lbAddinName.AutoSize = True
        Me.lbAddinName.Font = New System.Drawing.Font("Arial", 6.0!)
        Me.lbAddinName.Location = New System.Drawing.Point(3, -2)
        Me.lbAddinName.Name = "lbAddinName"
        Me.lbAddinName.Size = New System.Drawing.Size(24, 10)
        Me.lbAddinName.TabIndex = 315
        Me.lbAddinName.Text = "v1.0.0"
        Me.lbAddinName.Visible = False
        '
        'ErrorProvider1
        '
        Me.ErrorProvider1.ContainerControl = Me
        '
        'ToolTip1
        '
        Me.ToolTip1.AutomaticDelay = 250
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(12, 49)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(261, 303)
        Me.ListBox1.TabIndex = 316
        '
        'tbCurrentPart
        '
        Me.tbCurrentPart.Location = New System.Drawing.Point(12, 17)
        Me.tbCurrentPart.Name = "tbCurrentPart"
        Me.tbCurrentPart.Size = New System.Drawing.Size(260, 20)
        Me.tbCurrentPart.TabIndex = 317
        '
        'SizeifierForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(285, 361)
        Me.Controls.Add(Me.tbCurrentPart)
        Me.Controls.Add(Me.ListBox1)
        Me.Controls.Add(Me.lbAddinName)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None
        Me.Name = "SizeifierForm"
        Me.SizeGripStyle = System.Windows.Forms.SizeGripStyle.Hide
        Me.Text = "iPropertiesForm"
        CType(Me.ErrorProvider1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub
    Friend WithEvents lbAddinName As Windows.Forms.Label
    Friend WithEvents ErrorProvider1 As Windows.Forms.ErrorProvider
    Friend WithEvents ToolTip1 As Windows.Forms.ToolTip
    Friend WithEvents ListBox1 As Windows.Forms.ListBox
    Friend WithEvents tbCurrentPart As Windows.Forms.TextBox
End Class
