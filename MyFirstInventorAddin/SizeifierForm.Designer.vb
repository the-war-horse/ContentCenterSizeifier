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
        Me.ListSizes = New System.Windows.Forms.ListBox()
        Me.tbCurrentPart = New System.Windows.Forms.TextBox()
        Me.cbbDesignation = New System.Windows.Forms.ComboBox()
        Me.cbMaterial = New System.Windows.Forms.CheckBox()
        Me.lblDesignation = New System.Windows.Forms.Label()
        Me.lblLength = New System.Windows.Forms.Label()
        Me.cbbLength = New System.Windows.Forms.ComboBox()
        Me.cbbMaterial = New System.Windows.Forms.ComboBox()
        Me.lblMaterial = New System.Windows.Forms.Label()
        Me.cbbDiameter = New System.Windows.Forms.ComboBox()
        Me.lblDiameter = New System.Windows.Forms.Label()
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
        'ListSizes
        '
        Me.ListSizes.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.ListSizes.FormattingEnabled = True
        Me.ListSizes.Location = New System.Drawing.Point(15, 171)
        Me.ListSizes.Name = "ListSizes"
        Me.ListSizes.Size = New System.Drawing.Size(226, 251)
        Me.ListSizes.TabIndex = 316
        '
        'tbCurrentPart
        '
        Me.tbCurrentPart.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.tbCurrentPart.Location = New System.Drawing.Point(12, 17)
        Me.tbCurrentPart.Name = "tbCurrentPart"
        Me.tbCurrentPart.Size = New System.Drawing.Size(229, 20)
        Me.tbCurrentPart.TabIndex = 317
        Me.tbCurrentPart.Text = "Current Designation or something"
        '
        'cbbDesignation
        '
        Me.cbbDesignation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbDesignation.FormattingEnabled = True
        Me.cbbDesignation.Location = New System.Drawing.Point(84, 43)
        Me.cbbDesignation.Name = "cbbDesignation"
        Me.cbbDesignation.Size = New System.Drawing.Size(157, 21)
        Me.cbbDesignation.TabIndex = 318
        '
        'cbMaterial
        '
        Me.cbMaterial.Anchor = CType((((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Bottom) _
            Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbMaterial.AutoSize = True
        Me.cbMaterial.Location = New System.Drawing.Point(15, 148)
        Me.cbMaterial.Name = "cbMaterial"
        Me.cbMaterial.Size = New System.Drawing.Size(130, 17)
        Me.cbMaterial.TabIndex = 319
        Me.cbMaterial.Text = "Use Material as ""Key"""
        Me.cbMaterial.UseVisualStyleBackColor = True
        '
        'lblDesignation
        '
        Me.lblDesignation.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblDesignation.AutoSize = True
        Me.lblDesignation.Location = New System.Drawing.Point(12, 46)
        Me.lblDesignation.Name = "lblDesignation"
        Me.lblDesignation.Size = New System.Drawing.Size(66, 13)
        Me.lblDesignation.TabIndex = 320
        Me.lblDesignation.Text = "Designation:"
        '
        'lblLength
        '
        Me.lblLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblLength.AutoSize = True
        Me.lblLength.Location = New System.Drawing.Point(12, 73)
        Me.lblLength.Name = "lblLength"
        Me.lblLength.Size = New System.Drawing.Size(43, 13)
        Me.lblLength.TabIndex = 321
        Me.lblLength.Text = "Length:"
        '
        'cbbLength
        '
        Me.cbbLength.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbLength.FormattingEnabled = True
        Me.cbbLength.Location = New System.Drawing.Point(84, 70)
        Me.cbbLength.Name = "cbbLength"
        Me.cbbLength.Size = New System.Drawing.Size(157, 21)
        Me.cbbLength.TabIndex = 322
        '
        'cbbMaterial
        '
        Me.cbbMaterial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbMaterial.FormattingEnabled = True
        Me.cbbMaterial.Location = New System.Drawing.Point(84, 124)
        Me.cbbMaterial.Name = "cbbMaterial"
        Me.cbbMaterial.Size = New System.Drawing.Size(157, 21)
        Me.cbbMaterial.TabIndex = 323
        '
        'lblMaterial
        '
        Me.lblMaterial.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.lblMaterial.AutoSize = True
        Me.lblMaterial.Location = New System.Drawing.Point(12, 127)
        Me.lblMaterial.Name = "lblMaterial"
        Me.lblMaterial.Size = New System.Drawing.Size(47, 13)
        Me.lblMaterial.TabIndex = 324
        Me.lblMaterial.Text = "Material:"
        '
        'cbbDiameter
        '
        Me.cbbDiameter.Anchor = CType(((System.Windows.Forms.AnchorStyles.Top Or System.Windows.Forms.AnchorStyles.Left) _
            Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.cbbDiameter.FormattingEnabled = True
        Me.cbbDiameter.Location = New System.Drawing.Point(84, 97)
        Me.cbbDiameter.Name = "cbbDiameter"
        Me.cbbDiameter.Size = New System.Drawing.Size(157, 21)
        Me.cbbDiameter.TabIndex = 325
        '
        'lblDiameter
        '
        Me.lblDiameter.AutoSize = True
        Me.lblDiameter.Location = New System.Drawing.Point(12, 100)
        Me.lblDiameter.Name = "lblDiameter"
        Me.lblDiameter.Size = New System.Drawing.Size(52, 13)
        Me.lblDiameter.TabIndex = 326
        Me.lblDiameter.Text = "Diameter:"
        '
        'SizeifierForm
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.AutoSize = True
        Me.AutoSizeMode = System.Windows.Forms.AutoSizeMode.GrowAndShrink
        Me.ClientSize = New System.Drawing.Size(250, 450)
        Me.Controls.Add(Me.lblDiameter)
        Me.Controls.Add(Me.cbbDiameter)
        Me.Controls.Add(Me.lblMaterial)
        Me.Controls.Add(Me.cbbMaterial)
        Me.Controls.Add(Me.cbbLength)
        Me.Controls.Add(Me.lblLength)
        Me.Controls.Add(Me.lblDesignation)
        Me.Controls.Add(Me.cbMaterial)
        Me.Controls.Add(Me.cbbDesignation)
        Me.Controls.Add(Me.tbCurrentPart)
        Me.Controls.Add(Me.ListSizes)
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
    Friend WithEvents ListSizes As Windows.Forms.ListBox
    Friend WithEvents tbCurrentPart As Windows.Forms.TextBox
    Friend WithEvents lblMaterial As Windows.Forms.Label
    Friend WithEvents cbbMaterial As Windows.Forms.ComboBox
    Friend WithEvents cbbLength As Windows.Forms.ComboBox
    Friend WithEvents lblLength As Windows.Forms.Label
    Friend WithEvents lblDesignation As Windows.Forms.Label
    Friend WithEvents cbMaterial As Windows.Forms.CheckBox
    Friend WithEvents cbbDesignation As Windows.Forms.ComboBox
    Friend WithEvents lblDiameter As Windows.Forms.Label
    Friend WithEvents cbbDiameter As Windows.Forms.ComboBox
End Class
