<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()>
Partial Class Inicio
    Inherits System.Windows.Forms.Form

    'Form reemplaza a Dispose para limpiar la lista de componentes.
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

    'Requerido por el Diseñador de Windows Forms
    Private components As System.ComponentModel.IContainer

    'NOTA: el Diseñador de Windows Forms necesita el siguiente procedimiento
    'Se puede modificar usando el Diseñador de Windows Forms.  
    'No lo modifique con el editor de código.
    <System.Diagnostics.DebuggerStepThrough()>
    Private Sub InitializeComponent()
        Me.BarraTareas = New System.Windows.Forms.StatusStrip()
        Me.MainMenu = New System.Windows.Forms.MenuStrip()
        Me.SplitContainer1 = New System.Windows.Forms.SplitContainer()
        Me.DGVDev = New System.Windows.Forms.DataGridView()
        Me.SplitContainer2 = New System.Windows.Forms.SplitContainer()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListaMovsRef = New System.Windows.Forms.CheckedListBox()
        Me.SplitContainer3 = New System.Windows.Forms.SplitContainer()
        Me.Splitter1 = New System.Windows.Forms.Splitter()
        Me.PBDGVGestion = New System.Windows.Forms.ProgressBar()
        Me.DGVGestion = New System.Windows.Forms.DataGridView()
        Me.PBDGVLocales = New System.Windows.Forms.ProgressBar()
        Me.DGVSucursal = New System.Windows.Forms.DataGridView()
        Me.BGW1 = New System.ComponentModel.BackgroundWorker()
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.Panel2.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGVDev, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer2.Panel1.SuspendLayout()
        Me.SplitContainer2.Panel2.SuspendLayout()
        Me.SplitContainer2.SuspendLayout()
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer3.Panel1.SuspendLayout()
        Me.SplitContainer3.Panel2.SuspendLayout()
        Me.SplitContainer3.SuspendLayout()
        CType(Me.DGVGestion, System.ComponentModel.ISupportInitialize).BeginInit()
        CType(Me.DGVSucursal, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraTareas
        '
        Me.BarraTareas.Location = New System.Drawing.Point(0, 708)
        Me.BarraTareas.Name = "BarraTareas"
        Me.BarraTareas.Size = New System.Drawing.Size(1008, 22)
        Me.BarraTareas.TabIndex = 1
        Me.BarraTareas.Text = "StatusStrip1"
        '
        'MainMenu
        '
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(1008, 24)
        Me.MainMenu.TabIndex = 2
        Me.MainMenu.Text = "MenuStrip1"
        '
        'SplitContainer1
        '
        Me.SplitContainer1.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer1.Location = New System.Drawing.Point(0, 24)
        Me.SplitContainer1.Name = "SplitContainer1"
        '
        'SplitContainer1.Panel1
        '
        Me.SplitContainer1.Panel1.Controls.Add(Me.DGVDev)
        '
        'SplitContainer1.Panel2
        '
        Me.SplitContainer1.Panel2.Controls.Add(Me.SplitContainer2)
        Me.SplitContainer1.Size = New System.Drawing.Size(1008, 684)
        Me.SplitContainer1.SplitterDistance = 336
        Me.SplitContainer1.TabIndex = 3
        '
        'DGVDev
        '
        Me.DGVDev.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCellsExceptHeader
        Me.DGVDev.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DGVDev.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGVDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVDev.Location = New System.Drawing.Point(0, 0)
        Me.DGVDev.Name = "DGVDev"
        Me.DGVDev.RowHeadersVisible = False
        Me.DGVDev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVDev.Size = New System.Drawing.Size(336, 684)
        Me.DGVDev.TabIndex = 0
        '
        'SplitContainer2
        '
        Me.SplitContainer2.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer2.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer2.Name = "SplitContainer2"
        Me.SplitContainer2.Orientation = System.Windows.Forms.Orientation.Horizontal
        '
        'SplitContainer2.Panel1
        '
        Me.SplitContainer2.Panel1.Controls.Add(Me.Label1)
        Me.SplitContainer2.Panel1.Controls.Add(Me.ListaMovsRef)
        '
        'SplitContainer2.Panel2
        '
        Me.SplitContainer2.Panel2.Controls.Add(Me.SplitContainer3)
        Me.SplitContainer2.Size = New System.Drawing.Size(668, 684)
        Me.SplitContainer2.SplitterDistance = 157
        Me.SplitContainer2.TabIndex = 3
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Font = New System.Drawing.Font("Microsoft Sans Serif", 11.25!, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, CType(0, Byte))
        Me.Label1.Location = New System.Drawing.Point(3, 6)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(165, 18)
        Me.Label1.TabIndex = 4
        Me.Label1.Text = "Asignar movimientos"
        '
        'ListaMovsRef
        '
        Me.ListaMovsRef.FormattingEnabled = True
        Me.ListaMovsRef.Location = New System.Drawing.Point(3, 27)
        Me.ListaMovsRef.Name = "ListaMovsRef"
        Me.ListaMovsRef.Size = New System.Drawing.Size(336, 124)
        Me.ListaMovsRef.TabIndex = 3
        '
        'SplitContainer3
        '
        Me.SplitContainer3.Dock = System.Windows.Forms.DockStyle.Fill
        Me.SplitContainer3.Location = New System.Drawing.Point(0, 0)
        Me.SplitContainer3.Name = "SplitContainer3"
        '
        'SplitContainer3.Panel1
        '
        Me.SplitContainer3.Panel1.Controls.Add(Me.Splitter1)
        Me.SplitContainer3.Panel1.Controls.Add(Me.PBDGVGestion)
        Me.SplitContainer3.Panel1.Controls.Add(Me.DGVGestion)
        '
        'SplitContainer3.Panel2
        '
        Me.SplitContainer3.Panel2.Controls.Add(Me.PBDGVLocales)
        Me.SplitContainer3.Panel2.Controls.Add(Me.DGVSucursal)
        Me.SplitContainer3.Size = New System.Drawing.Size(668, 523)
        Me.SplitContainer3.SplitterDistance = 339
        Me.SplitContainer3.TabIndex = 0
        '
        'Splitter1
        '
        Me.Splitter1.Location = New System.Drawing.Point(0, 0)
        Me.Splitter1.Name = "Splitter1"
        Me.Splitter1.Size = New System.Drawing.Size(3, 523)
        Me.Splitter1.TabIndex = 2
        Me.Splitter1.TabStop = False
        '
        'PBDGVGestion
        '
        Me.PBDGVGestion.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBDGVGestion.Location = New System.Drawing.Point(59, 218)
        Me.PBDGVGestion.Name = "PBDGVGestion"
        Me.PBDGVGestion.Size = New System.Drawing.Size(218, 23)
        Me.PBDGVGestion.Style = System.Windows.Forms.ProgressBarStyle.Continuous
        Me.PBDGVGestion.TabIndex = 1
        Me.PBDGVGestion.Visible = False
        '
        'DGVGestion
        '
        Me.DGVGestion.AllowUserToAddRows = False
        Me.DGVGestion.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVGestion.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVGestion.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVGestion.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVGestion.Location = New System.Drawing.Point(0, 0)
        Me.DGVGestion.Name = "DGVGestion"
        Me.DGVGestion.RowHeadersVisible = False
        Me.DGVGestion.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVGestion.Size = New System.Drawing.Size(339, 523)
        Me.DGVGestion.TabIndex = 0
        '
        'PBDGVLocales
        '
        Me.PBDGVLocales.Anchor = CType((System.Windows.Forms.AnchorStyles.Left Or System.Windows.Forms.AnchorStyles.Right), System.Windows.Forms.AnchorStyles)
        Me.PBDGVLocales.Location = New System.Drawing.Point(57, 218)
        Me.PBDGVLocales.Name = "PBDGVLocales"
        Me.PBDGVLocales.Size = New System.Drawing.Size(218, 23)
        Me.PBDGVLocales.TabIndex = 2
        Me.PBDGVLocales.Visible = False
        '
        'DGVSucursal
        '
        Me.DGVSucursal.AllowUserToAddRows = False
        Me.DGVSucursal.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVSucursal.BorderStyle = System.Windows.Forms.BorderStyle.None
        Me.DGVSucursal.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVSucursal.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVSucursal.Location = New System.Drawing.Point(0, 0)
        Me.DGVSucursal.Name = "DGVSucursal"
        Me.DGVSucursal.RowHeadersVisible = False
        Me.DGVSucursal.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVSucursal.Size = New System.Drawing.Size(325, 523)
        Me.DGVSucursal.TabIndex = 0
        '
        'BGW1
        '
        Me.BGW1.WorkerReportsProgress = True
        '
        'Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(1008, 730)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BarraTareas)
        Me.Controls.Add(Me.MainMenu)
        Me.MainMenuStrip = Me.MainMenu
        Me.Name = "Inicio"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        Me.SplitContainer1.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGVDev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.Panel1.ResumeLayout(False)
        Me.SplitContainer2.Panel1.PerformLayout()
        Me.SplitContainer2.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer2, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer2.ResumeLayout(False)
        Me.SplitContainer3.Panel1.ResumeLayout(False)
        Me.SplitContainer3.Panel2.ResumeLayout(False)
        CType(Me.SplitContainer3, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer3.ResumeLayout(False)
        CType(Me.DGVGestion, System.ComponentModel.ISupportInitialize).EndInit()
        CType(Me.DGVSucursal, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraTareas As StatusStrip
    Friend WithEvents MainMenu As MenuStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DGVDev As DataGridView
    Friend WithEvents SplitContainer2 As SplitContainer
    Friend WithEvents Label1 As Label
    Friend WithEvents ListaMovsRef As CheckedListBox
    Friend WithEvents SplitContainer3 As SplitContainer
    Friend WithEvents DGVGestion As DataGridView
    Friend WithEvents DGVSucursal As DataGridView
    Friend WithEvents PBDGVGestion As ProgressBar
    Friend WithEvents PBDGVLocales As ProgressBar
    Friend WithEvents Splitter1 As Splitter
    Friend WithEvents BGW1 As System.ComponentModel.BackgroundWorker
End Class
