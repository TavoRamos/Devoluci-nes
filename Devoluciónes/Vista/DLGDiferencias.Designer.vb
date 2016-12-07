<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class DLGDiferencias
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()> _
    Private Sub InitializeComponent()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.ToolStrip1 = New System.Windows.Forms.ToolStrip()
        Me.BTNSobrante = New System.Windows.Forms.ToolStripButton()
        Me.BTNFaltante = New System.Windows.Forms.ToolStripButton()
        Me.BTNDesglosar = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton1 = New System.Windows.Forms.ToolStripButton()
        Me.ToolStripButton2 = New System.Windows.Forms.ToolStripButton()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.DGVDiferenciasGes = New System.Windows.Forms.DataGridView()
        Me.DGVDiferenciasSuc = New System.Windows.Forms.DataGridView()
        Me.BGWDif = New System.ComponentModel.BackgroundWorker()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        Me.ToolStrip1.SuspendLayout()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.DGVDiferenciasGes, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVDiferenciasSuc, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer1.Name = "SplitContainer1"
        Me.SplitContainer1.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.ToolStrip1)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(837, 498)
        Me.SplitContainer1.SplitterDistance = 25
        Me.SplitContainer1.TabIndex = 0
        '
        'ToolStrip1
        '
        Me.ToolStrip1.Items.AddRange(New System.Windows.Forms.ToolStripItem() {Me.BTNSobrante, Me.BTNFaltante, Me.BTNDesglosar, Me.ToolStripButton1, Me.ToolStripButton2})
        Me.ToolStrip1.Location = New System.Drawing.Point(0, 0)
        Me.ToolStrip1.Name = "ToolStrip1"
        Me.ToolStrip1.Size = New System.Drawing.Size(837, 25)
        Me.ToolStrip1.TabIndex = 0
        Me.ToolStrip1.Text = "ToolStrip1"
        '
        'BTNSobrante
        '
        Me.BTNSobrante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTNSobrante.Image = Global.Devoluciónes.My.Resources.Resources.Plus_16px
        Me.BTNSobrante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNSobrante.Name = "BTNSobrante"
        Me.BTNSobrante.Size = New System.Drawing.Size(23, 22)
        Me.BTNSobrante.Text = "Marcar como sobrante"
        Me.BTNSobrante.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNSobrante.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'BTNFaltante
        '
        Me.BTNFaltante.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTNFaltante.Image = Global.Devoluciónes.My.Resources.Resources.Minus_16px_1
        Me.BTNFaltante.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNFaltante.Name = "BTNFaltante"
        Me.BTNFaltante.Size = New System.Drawing.Size(23, 22)
        Me.BTNFaltante.Text = "Marcar como faltante"
        Me.BTNFaltante.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNFaltante.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'BTNDesglosar
        '
        Me.BTNDesglosar.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.BTNDesglosar.Image = Global.Devoluciónes.My.Resources.Resources.Download_16px
        Me.BTNDesglosar.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.BTNDesglosar.Name = "BTNDesglosar"
        Me.BTNDesglosar.Size = New System.Drawing.Size(23, 22)
        Me.BTNDesglosar.Text = "Desglosar"
        Me.BTNDesglosar.TextAlign = System.Drawing.ContentAlignment.BottomCenter
        Me.BTNDesglosar.TextImageRelation = System.Windows.Forms.TextImageRelation.TextAboveImage
        '
        'ToolStripButton1
        '
        Me.ToolStripButton1.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton1.Image = Global.Devoluciónes.My.Resources.Resources.Double_Left_32px
        Me.ToolStripButton1.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton1.Name = "ToolStripButton1"
        Me.ToolStripButton1.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton1.Text = "ToolStripButton1"
        '
        'ToolStripButton2
        '
        Me.ToolStripButton2.DisplayStyle = System.Windows.Forms.ToolStripItemDisplayStyle.Image
        Me.ToolStripButton2.Image = Global.Devoluciónes.My.Resources.Resources.Double_Right_32px
        Me.ToolStripButton2.ImageTransparentColor = System.Drawing.Color.Magenta
        Me.ToolStripButton2.Name = "ToolStripButton2"
        Me.ToolStripButton2.Size = New System.Drawing.Size(23, 22)
        Me.ToolStripButton2.Text = "ToolStripButton2"
        '
        'SplitContainer2
        '
        Me.SplitContainer2.BackColor = System.Drawing.Color.DeepSkyBlue
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.DGVDiferenciasGes)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.DGVDiferenciasSuc)
        Me.SplitContainer2.Size = New System.Drawing.Size(837, 469)
        Me.SplitContainer2.SplitterDistance = 410
        Me.SplitContainer2.SplitterWidth = 10
        Me.SplitContainer2.TabIndex = 1
        '
        'DGVDiferenciasGes
        '
        Me.DGVDiferenciasGes.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVDiferenciasGes.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDiferenciasGes.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVDiferenciasGes.Location = New System.Drawing.Point(0, 0)
        Me.DGVDiferenciasGes.Name = "DGVDiferenciasGes"
        Me.DGVDiferenciasGes.Size = New System.Drawing.Size(410, 469)
        Me.DGVDiferenciasGes.TabIndex = 0
        '
        'DGVDiferenciasSuc
        '
        Me.DGVDiferenciasSuc.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVDiferenciasSuc.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDiferenciasSuc.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVDiferenciasSuc.Location = New System.Drawing.Point(0, 0)
        Me.DGVDiferenciasSuc.Name = "DGVDiferenciasSuc"
        Me.DGVDiferenciasSuc.Size = New System.Drawing.Size(417, 469)
        Me.DGVDiferenciasSuc.TabIndex = 1
        '
        'DLGDiferencias
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(837, 498)
        Me.Controls.Add(Me.SplitContainer1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "DLGDiferencias"
        Me.Text = "DLGDiferencias"
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel1.PerformLayout()
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        Me.ToolStrip1.ResumeLayout(False)
        Me.ToolStrip1.PerformLayout()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        CType(Me.DGVDiferenciasGes, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVDiferenciasSuc, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DGVDiferenciasGes As DataGridView
    Friend WithEvents BGWDif As System.ComponentModel.BackgroundWorker
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents DGVDiferenciasSuc As DataGridView
    Friend WithEvents ToolStrip1 As ToolStrip
    Friend WithEvents BTNSobrante As ToolStripButton
    Friend WithEvents BTNFaltante As ToolStripButton
    Friend WithEvents BTNDesglosar As ToolStripButton
    Friend WithEvents ToolStripButton1 As ToolStripButton
    Friend WithEvents ToolStripButton2 As ToolStripButton
End Class
