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
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SplitContainer1.Panel1.SuspendLayout()
        Me.SplitContainer1.SuspendLayout()
        CType(Me.DGVDev, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.SuspendLayout()
        '
        'BarraTareas
        '
        Me.BarraTareas.Location = New System.Drawing.Point(0, 437)
        Me.BarraTareas.Name = "BarraTareas"
        Me.BarraTareas.Size = New System.Drawing.Size(756, 22)
        Me.BarraTareas.TabIndex = 1
        Me.BarraTareas.Text = "StatusStrip1"
        '
        'MainMenu
        '
        Me.MainMenu.Location = New System.Drawing.Point(0, 0)
        Me.MainMenu.Name = "MainMenu"
        Me.MainMenu.Size = New System.Drawing.Size(756, 24)
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
        Me.SplitContainer1.Size = New System.Drawing.Size(756, 413)
        Me.SplitContainer1.SplitterDistance = 252
        Me.SplitContainer1.TabIndex = 3
        '
        'DGVDev
        '
        Me.DGVDev.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill
        Me.DGVDev.BackgroundColor = System.Drawing.SystemColors.ActiveCaption
        Me.DGVDev.CellBorderStyle = System.Windows.Forms.DataGridViewCellBorderStyle.None
        Me.DGVDev.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGVDev.Dock = System.Windows.Forms.DockStyle.Fill
        Me.DGVDev.Location = New System.Drawing.Point(0, 0)
        Me.DGVDev.Name = "DGVDev"
        Me.DGVDev.RowHeadersVisible = False
        Me.DGVDev.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect
        Me.DGVDev.Size = New System.Drawing.Size(252, 413)
        Me.DGVDev.TabIndex = 0
        '
        'Inicio
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(756, 459)
        Me.Controls.Add(Me.SplitContainer1)
        Me.Controls.Add(Me.BarraTareas)
        Me.Controls.Add(Me.MainMenu)
        Me.MainMenuStrip = Me.MainMenu
        Me.Name = "Inicio"
        Me.Text = "Form1"
        Me.WindowState = System.Windows.Forms.FormWindowState.Maximized
        Me.SplitContainer1.Panel1.ResumeLayout(False)
        CType(Me.SplitContainer1, System.ComponentModel.ISupportInitialize).EndInit()
        Me.SplitContainer1.ResumeLayout(False)
        CType(Me.DGVDev, System.ComponentModel.ISupportInitialize).EndInit()
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents BarraTareas As StatusStrip
    Friend WithEvents MainMenu As MenuStrip
    Friend WithEvents SplitContainer1 As SplitContainer
    Friend WithEvents DGVDev As DataGridView
End Class
