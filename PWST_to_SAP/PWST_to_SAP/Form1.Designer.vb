<Global.Microsoft.VisualBasic.CompilerServices.DesignerGenerated()> _
Partial Class Form1
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
        Me.Button1 = New System.Windows.Forms.Button()
        Me.Button_Cobros = New System.Windows.Forms.Button()
        Me.MonthCalendar1 = New System.Windows.Forms.MonthCalendar()
        Me.TextBox1 = New System.Windows.Forms.TextBox()
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.TabPage1 = New System.Windows.Forms.TabPage()
        Me.TabPage2 = New System.Windows.Forms.TabPage()
        Me.LimpiaTablas = New System.Windows.Forms.Button()
        Me.Canales = New System.Windows.Forms.Button()
        Me.Vendedores = New System.Windows.Forms.Button()
        Me.Bancos = New System.Windows.Forms.Button()
        Me.Bonificaciones = New System.Windows.Forms.Button()
        Me.Cuentas_Bancarias = New System.Windows.Forms.Button()
        Me.Clientes = New System.Windows.Forms.Button()
        Me.Bodegas_Vendedores = New System.Windows.Forms.Button()
        Me.Tipo_producto = New System.Windows.Forms.Button()
        Me.Encabezado_Promocion = New System.Windows.Forms.Button()
        Me.Casas = New System.Windows.Forms.Button()
        Me.Marcas = New System.Windows.Forms.Button()
        Me.Clientes_Lista = New System.Windows.Forms.Button()
        Me.Encabezado_factura = New System.Windows.Forms.Button()
        Me.Lista_precio = New System.Windows.Forms.Button()
        Me.Saldo_bodega = New System.Windows.Forms.Button()
        Me.Carga_Producto = New System.Windows.Forms.Button()
        Me.Saldo_Cliente = New System.Windows.Forms.Button()
        Me.Detalle_Factura = New System.Windows.Forms.Button()
        Me.Carga_Precio = New System.Windows.Forms.Button()
        Me.Unid_Medida = New System.Windows.Forms.Button()
        Me.Plan_Medida = New System.Windows.Forms.Button()
        Me.Cliente_Especial = New System.Windows.Forms.Button()
        Me.Territorios = New System.Windows.Forms.Button()
        Me.Carga_Docs = New System.Windows.Forms.Button()
        Me.Consolidado_asesores = New System.Windows.Forms.Button()
        Me.Actualiza_Log = New System.Windows.Forms.Button()
        Me.Actualiza_Fechas = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.TabPage1.SuspendLayout()
        Me.TabPage2.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(176, 122)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Pedidos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_Cobros
        '
        Me.Button_Cobros.Location = New System.Drawing.Point(176, 151)
        Me.Button_Cobros.Name = "Button_Cobros"
        Me.Button_Cobros.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cobros.TabIndex = 1
        Me.Button_Cobros.Text = "Cobros"
        Me.Button_Cobros.UseVisualStyleBackColor = True
        '
        'MonthCalendar1
        '
        Me.MonthCalendar1.Location = New System.Drawing.Point(18, 85)
        Me.MonthCalendar1.MaxSelectionCount = 1
        Me.MonthCalendar1.Name = "MonthCalendar1"
        Me.MonthCalendar1.TabIndex = 4
        '
        'TextBox1
        '
        Me.TextBox1.Location = New System.Drawing.Point(65, 245)
        Me.TextBox1.Name = "TextBox1"
        Me.TextBox1.Size = New System.Drawing.Size(100, 20)
        Me.TextBox1.TabIndex = 5
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.TabPage1)
        Me.TabControl1.Controls.Add(Me.TabPage2)
        Me.TabControl1.Location = New System.Drawing.Point(222, 16)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(409, 336)
        Me.TabControl1.TabIndex = 6
        '
        'TabPage1
        '
        Me.TabPage1.Controls.Add(Me.Button1)
        Me.TabPage1.Controls.Add(Me.Button_Cobros)
        Me.TabPage1.Location = New System.Drawing.Point(4, 22)
        Me.TabPage1.Name = "TabPage1"
        Me.TabPage1.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage1.Size = New System.Drawing.Size(401, 310)
        Me.TabPage1.TabIndex = 0
        Me.TabPage1.Text = "SAP"
        Me.TabPage1.UseVisualStyleBackColor = True
        '
        'TabPage2
        '
        Me.TabPage2.Controls.Add(Me.Actualiza_Fechas)
        Me.TabPage2.Controls.Add(Me.Actualiza_Log)
        Me.TabPage2.Controls.Add(Me.Consolidado_asesores)
        Me.TabPage2.Controls.Add(Me.Carga_Docs)
        Me.TabPage2.Controls.Add(Me.Territorios)
        Me.TabPage2.Controls.Add(Me.Cliente_Especial)
        Me.TabPage2.Controls.Add(Me.Plan_Medida)
        Me.TabPage2.Controls.Add(Me.Unid_Medida)
        Me.TabPage2.Controls.Add(Me.Carga_Precio)
        Me.TabPage2.Controls.Add(Me.Detalle_Factura)
        Me.TabPage2.Controls.Add(Me.Saldo_Cliente)
        Me.TabPage2.Controls.Add(Me.Carga_Producto)
        Me.TabPage2.Controls.Add(Me.Saldo_bodega)
        Me.TabPage2.Controls.Add(Me.Lista_precio)
        Me.TabPage2.Controls.Add(Me.Encabezado_factura)
        Me.TabPage2.Controls.Add(Me.Clientes_Lista)
        Me.TabPage2.Controls.Add(Me.Marcas)
        Me.TabPage2.Controls.Add(Me.Casas)
        Me.TabPage2.Controls.Add(Me.Encabezado_Promocion)
        Me.TabPage2.Controls.Add(Me.Tipo_producto)
        Me.TabPage2.Controls.Add(Me.Bodegas_Vendedores)
        Me.TabPage2.Controls.Add(Me.Clientes)
        Me.TabPage2.Controls.Add(Me.Cuentas_Bancarias)
        Me.TabPage2.Controls.Add(Me.Bonificaciones)
        Me.TabPage2.Controls.Add(Me.Bancos)
        Me.TabPage2.Controls.Add(Me.Vendedores)
        Me.TabPage2.Controls.Add(Me.Canales)
        Me.TabPage2.Controls.Add(Me.LimpiaTablas)
        Me.TabPage2.Location = New System.Drawing.Point(4, 22)
        Me.TabPage2.Name = "TabPage2"
        Me.TabPage2.Padding = New System.Windows.Forms.Padding(3)
        Me.TabPage2.Size = New System.Drawing.Size(401, 310)
        Me.TabPage2.TabIndex = 1
        Me.TabPage2.Text = "PWST"
        Me.TabPage2.UseVisualStyleBackColor = True
        '
        'LimpiaTablas
        '
        Me.LimpiaTablas.Location = New System.Drawing.Point(6, 6)
        Me.LimpiaTablas.Name = "LimpiaTablas"
        Me.LimpiaTablas.Size = New System.Drawing.Size(75, 37)
        Me.LimpiaTablas.TabIndex = 0
        Me.LimpiaTablas.Text = "Limpiar Tablas"
        Me.LimpiaTablas.UseVisualStyleBackColor = True
        '
        'Canales
        '
        Me.Canales.Location = New System.Drawing.Point(112, 6)
        Me.Canales.Name = "Canales"
        Me.Canales.Size = New System.Drawing.Size(75, 37)
        Me.Canales.TabIndex = 1
        Me.Canales.Text = "Canales"
        Me.Canales.UseVisualStyleBackColor = True
        '
        'Vendedores
        '
        Me.Vendedores.Location = New System.Drawing.Point(216, 6)
        Me.Vendedores.Name = "Vendedores"
        Me.Vendedores.Size = New System.Drawing.Size(75, 37)
        Me.Vendedores.TabIndex = 2
        Me.Vendedores.Text = "Vendedores"
        Me.Vendedores.UseVisualStyleBackColor = True
        '
        'Bancos
        '
        Me.Bancos.Location = New System.Drawing.Point(317, 6)
        Me.Bancos.Name = "Bancos"
        Me.Bancos.Size = New System.Drawing.Size(75, 37)
        Me.Bancos.TabIndex = 3
        Me.Bancos.Text = "Bancos"
        Me.Bancos.UseVisualStyleBackColor = True
        '
        'Bonificaciones
        '
        Me.Bonificaciones.Location = New System.Drawing.Point(317, 49)
        Me.Bonificaciones.Name = "Bonificaciones"
        Me.Bonificaciones.Size = New System.Drawing.Size(75, 37)
        Me.Bonificaciones.TabIndex = 4
        Me.Bonificaciones.Text = "Bonificaciones"
        Me.Bonificaciones.UseVisualStyleBackColor = True
        '
        'Cuentas_Bancarias
        '
        Me.Cuentas_Bancarias.Location = New System.Drawing.Point(216, 49)
        Me.Cuentas_Bancarias.Name = "Cuentas_Bancarias"
        Me.Cuentas_Bancarias.Size = New System.Drawing.Size(75, 37)
        Me.Cuentas_Bancarias.TabIndex = 5
        Me.Cuentas_Bancarias.Text = "Cuentas Bancarias"
        Me.Cuentas_Bancarias.UseVisualStyleBackColor = True
        '
        'Clientes
        '
        Me.Clientes.Location = New System.Drawing.Point(112, 49)
        Me.Clientes.Name = "Clientes"
        Me.Clientes.Size = New System.Drawing.Size(75, 37)
        Me.Clientes.TabIndex = 6
        Me.Clientes.Text = "Clientes"
        Me.Clientes.UseVisualStyleBackColor = True
        '
        'Bodegas_Vendedores
        '
        Me.Bodegas_Vendedores.Location = New System.Drawing.Point(6, 49)
        Me.Bodegas_Vendedores.Name = "Bodegas_Vendedores"
        Me.Bodegas_Vendedores.Size = New System.Drawing.Size(75, 37)
        Me.Bodegas_Vendedores.TabIndex = 7
        Me.Bodegas_Vendedores.Text = "Bodegas Vendedores"
        Me.Bodegas_Vendedores.UseVisualStyleBackColor = True
        '
        'Tipo_producto
        '
        Me.Tipo_producto.Location = New System.Drawing.Point(6, 92)
        Me.Tipo_producto.Name = "Tipo_producto"
        Me.Tipo_producto.Size = New System.Drawing.Size(75, 37)
        Me.Tipo_producto.TabIndex = 8
        Me.Tipo_producto.Text = "Tipo Producto"
        Me.Tipo_producto.UseVisualStyleBackColor = True
        '
        'Encabezado_Promocion
        '
        Me.Encabezado_Promocion.Location = New System.Drawing.Point(112, 92)
        Me.Encabezado_Promocion.Name = "Encabezado_Promocion"
        Me.Encabezado_Promocion.Size = New System.Drawing.Size(75, 37)
        Me.Encabezado_Promocion.TabIndex = 9
        Me.Encabezado_Promocion.Text = "Encabezado Promociones"
        Me.Encabezado_Promocion.UseVisualStyleBackColor = True
        '
        'Casas
        '
        Me.Casas.Location = New System.Drawing.Point(216, 92)
        Me.Casas.Name = "Casas"
        Me.Casas.Size = New System.Drawing.Size(75, 37)
        Me.Casas.TabIndex = 10
        Me.Casas.Text = "Casas"
        Me.Casas.UseVisualStyleBackColor = True
        '
        'Marcas
        '
        Me.Marcas.Location = New System.Drawing.Point(317, 92)
        Me.Marcas.Name = "Marcas"
        Me.Marcas.Size = New System.Drawing.Size(75, 37)
        Me.Marcas.TabIndex = 11
        Me.Marcas.Text = "Marcas"
        Me.Marcas.UseVisualStyleBackColor = True
        '
        'Clientes_Lista
        '
        Me.Clientes_Lista.Location = New System.Drawing.Point(317, 135)
        Me.Clientes_Lista.Name = "Clientes_Lista"
        Me.Clientes_Lista.Size = New System.Drawing.Size(75, 37)
        Me.Clientes_Lista.TabIndex = 12
        Me.Clientes_Lista.Text = "Cliente x Lista"
        Me.Clientes_Lista.UseVisualStyleBackColor = True
        '
        'Encabezado_factura
        '
        Me.Encabezado_factura.Location = New System.Drawing.Point(216, 135)
        Me.Encabezado_factura.Name = "Encabezado_factura"
        Me.Encabezado_factura.Size = New System.Drawing.Size(75, 37)
        Me.Encabezado_factura.TabIndex = 13
        Me.Encabezado_factura.Text = "Encabezado Factura"
        Me.Encabezado_factura.UseVisualStyleBackColor = True
        '
        'Lista_precio
        '
        Me.Lista_precio.Location = New System.Drawing.Point(112, 135)
        Me.Lista_precio.Name = "Lista_precio"
        Me.Lista_precio.Size = New System.Drawing.Size(75, 37)
        Me.Lista_precio.TabIndex = 14
        Me.Lista_precio.Text = "Lista Precios"
        Me.Lista_precio.UseVisualStyleBackColor = True
        '
        'Saldo_bodega
        '
        Me.Saldo_bodega.Location = New System.Drawing.Point(6, 135)
        Me.Saldo_bodega.Name = "Saldo_bodega"
        Me.Saldo_bodega.Size = New System.Drawing.Size(75, 37)
        Me.Saldo_bodega.TabIndex = 15
        Me.Saldo_bodega.Text = "Saldo por Bodega"
        Me.Saldo_bodega.UseVisualStyleBackColor = True
        '
        'Carga_Producto
        '
        Me.Carga_Producto.Location = New System.Drawing.Point(6, 178)
        Me.Carga_Producto.Name = "Carga_Producto"
        Me.Carga_Producto.Size = New System.Drawing.Size(75, 37)
        Me.Carga_Producto.TabIndex = 16
        Me.Carga_Producto.Text = "Carga Productos"
        Me.Carga_Producto.UseVisualStyleBackColor = True
        '
        'Saldo_Cliente
        '
        Me.Saldo_Cliente.Location = New System.Drawing.Point(112, 178)
        Me.Saldo_Cliente.Name = "Saldo_Cliente"
        Me.Saldo_Cliente.Size = New System.Drawing.Size(75, 37)
        Me.Saldo_Cliente.TabIndex = 17
        Me.Saldo_Cliente.Text = "Saldo Clientes"
        Me.Saldo_Cliente.UseVisualStyleBackColor = True
        '
        'Detalle_Factura
        '
        Me.Detalle_Factura.Location = New System.Drawing.Point(216, 178)
        Me.Detalle_Factura.Name = "Detalle_Factura"
        Me.Detalle_Factura.Size = New System.Drawing.Size(75, 37)
        Me.Detalle_Factura.TabIndex = 18
        Me.Detalle_Factura.Text = "Detalle Facturas"
        Me.Detalle_Factura.UseVisualStyleBackColor = True
        '
        'Carga_Precio
        '
        Me.Carga_Precio.Location = New System.Drawing.Point(317, 178)
        Me.Carga_Precio.Name = "Carga_Precio"
        Me.Carga_Precio.Size = New System.Drawing.Size(75, 37)
        Me.Carga_Precio.TabIndex = 19
        Me.Carga_Precio.Text = "Carga Precios"
        Me.Carga_Precio.UseVisualStyleBackColor = True
        '
        'Unid_Medida
        '
        Me.Unid_Medida.Location = New System.Drawing.Point(317, 221)
        Me.Unid_Medida.Name = "Unid_Medida"
        Me.Unid_Medida.Size = New System.Drawing.Size(75, 37)
        Me.Unid_Medida.TabIndex = 20
        Me.Unid_Medida.Text = "Unidades Medida"
        Me.Unid_Medida.UseVisualStyleBackColor = True
        '
        'Plan_Medida
        '
        Me.Plan_Medida.Location = New System.Drawing.Point(216, 221)
        Me.Plan_Medida.Name = "Plan_Medida"
        Me.Plan_Medida.Size = New System.Drawing.Size(75, 37)
        Me.Plan_Medida.TabIndex = 21
        Me.Plan_Medida.Text = "Plan de Medida"
        Me.Plan_Medida.UseVisualStyleBackColor = True
        '
        'Cliente_Especial
        '
        Me.Cliente_Especial.Location = New System.Drawing.Point(112, 221)
        Me.Cliente_Especial.Name = "Cliente_Especial"
        Me.Cliente_Especial.Size = New System.Drawing.Size(75, 37)
        Me.Cliente_Especial.TabIndex = 22
        Me.Cliente_Especial.Text = "Clientes Especiales"
        Me.Cliente_Especial.UseVisualStyleBackColor = True
        '
        'Territorios
        '
        Me.Territorios.Location = New System.Drawing.Point(6, 221)
        Me.Territorios.Name = "Territorios"
        Me.Territorios.Size = New System.Drawing.Size(75, 37)
        Me.Territorios.TabIndex = 23
        Me.Territorios.Text = "Territorios"
        Me.Territorios.UseVisualStyleBackColor = True
        '
        'Carga_Docs
        '
        Me.Carga_Docs.Location = New System.Drawing.Point(6, 264)
        Me.Carga_Docs.Name = "Carga_Docs"
        Me.Carga_Docs.Size = New System.Drawing.Size(75, 37)
        Me.Carga_Docs.TabIndex = 24
        Me.Carga_Docs.Text = "Carga Documentos"
        Me.Carga_Docs.UseVisualStyleBackColor = True
        '
        'Consolidado_asesores
        '
        Me.Consolidado_asesores.Location = New System.Drawing.Point(112, 264)
        Me.Consolidado_asesores.Name = "Consolidado_asesores"
        Me.Consolidado_asesores.Size = New System.Drawing.Size(75, 37)
        Me.Consolidado_asesores.TabIndex = 25
        Me.Consolidado_asesores.Text = "Consolidad Asesores"
        Me.Consolidado_asesores.UseVisualStyleBackColor = True
        '
        'Actualiza_Log
        '
        Me.Actualiza_Log.Location = New System.Drawing.Point(216, 264)
        Me.Actualiza_Log.Name = "Actualiza_Log"
        Me.Actualiza_Log.Size = New System.Drawing.Size(75, 37)
        Me.Actualiza_Log.TabIndex = 26
        Me.Actualiza_Log.Text = "Actualiza Log Facturas"
        Me.Actualiza_Log.UseVisualStyleBackColor = True
        '
        'Actualiza_Fechas
        '
        Me.Actualiza_Fechas.Location = New System.Drawing.Point(317, 264)
        Me.Actualiza_Fechas.Name = "Actualiza_Fechas"
        Me.Actualiza_Fechas.Size = New System.Drawing.Size(75, 37)
        Me.Actualiza_Fechas.TabIndex = 27
        Me.Actualiza_Fechas.Text = "Actualiza Fechas"
        Me.Actualiza_Fechas.UseVisualStyleBackColor = True
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(647, 363)
        Me.Controls.Add(Me.TabControl1)
        Me.Controls.Add(Me.TextBox1)
        Me.Controls.Add(Me.MonthCalendar1)
        Me.Name = "Form1"
        Me.Text = "PWST_SAP"
        Me.TabControl1.ResumeLayout(False)
        Me.TabPage1.ResumeLayout(False)
        Me.TabPage2.ResumeLayout(False)
        Me.ResumeLayout(False)
        Me.PerformLayout()

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button_Cobros As Button
    Friend WithEvents MonthCalendar1 As MonthCalendar
    Friend WithEvents TextBox1 As TextBox
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents TabPage1 As TabPage
    Friend WithEvents TabPage2 As TabPage
    Friend WithEvents Actualiza_Fechas As Button
    Friend WithEvents Actualiza_Log As Button
    Friend WithEvents Consolidado_asesores As Button
    Friend WithEvents Carga_Docs As Button
    Friend WithEvents Territorios As Button
    Friend WithEvents Cliente_Especial As Button
    Friend WithEvents Plan_Medida As Button
    Friend WithEvents Unid_Medida As Button
    Friend WithEvents Carga_Precio As Button
    Friend WithEvents Detalle_Factura As Button
    Friend WithEvents Saldo_Cliente As Button
    Friend WithEvents Carga_Producto As Button
    Friend WithEvents Saldo_bodega As Button
    Friend WithEvents Lista_precio As Button
    Friend WithEvents Encabezado_factura As Button
    Friend WithEvents Clientes_Lista As Button
    Friend WithEvents Marcas As Button
    Friend WithEvents Casas As Button
    Friend WithEvents Encabezado_Promocion As Button
    Friend WithEvents Tipo_producto As Button
    Friend WithEvents Bodegas_Vendedores As Button
    Friend WithEvents Clientes As Button
    Friend WithEvents Cuentas_Bancarias As Button
    Friend WithEvents Bonificaciones As Button
    Friend WithEvents Bancos As Button
    Friend WithEvents Vendedores As Button
    Friend WithEvents Canales As Button
    Friend WithEvents LimpiaTablas As Button
End Class
