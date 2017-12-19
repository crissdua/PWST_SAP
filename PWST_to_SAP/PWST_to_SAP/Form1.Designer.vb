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
        Me.TabControl1 = New System.Windows.Forms.TabControl()
        Me.PWST = New System.Windows.Forms.TabPage()
        Me.Carga_Docs = New System.Windows.Forms.Button()
        Me.Plan_Medida = New System.Windows.Forms.Button()
        Me.Unid_Medida = New System.Windows.Forms.Button()
        Me.Carga_Precio = New System.Windows.Forms.Button()
        Me.Saldo_Cliente = New System.Windows.Forms.Button()
        Me.Carga_Producto = New System.Windows.Forms.Button()
        Me.Saldo_bodega = New System.Windows.Forms.Button()
        Me.Lista_precio = New System.Windows.Forms.Button()
        Me.Encabezado_factura = New System.Windows.Forms.Button()
        Me.Clientes_Lista = New System.Windows.Forms.Button()
        Me.Marcas = New System.Windows.Forms.Button()
        Me.Casas = New System.Windows.Forms.Button()
        Me.Encabezado_Promocion = New System.Windows.Forms.Button()
        Me.Tipo_producto = New System.Windows.Forms.Button()
        Me.Bodegas_Vendedores = New System.Windows.Forms.Button()
        Me.Clientes = New System.Windows.Forms.Button()
        Me.Cuentas_Bancarias = New System.Windows.Forms.Button()
        Me.Bonificaciones = New System.Windows.Forms.Button()
        Me.Bancos = New System.Windows.Forms.Button()
        Me.Vendedores = New System.Windows.Forms.Button()
        Me.Canales = New System.Windows.Forms.Button()
        Me.SAP = New System.Windows.Forms.TabPage()
        Me.Label1 = New System.Windows.Forms.Label()
        Me.ListBox1 = New System.Windows.Forms.ListBox()
        Me.Button2 = New System.Windows.Forms.Button()
        Me.DGV = New System.Windows.Forms.DataGridView()
        Me.CLEAN = New System.Windows.Forms.TabPage()
        Me.Button5 = New System.Windows.Forms.Button()
        Me.Button8 = New System.Windows.Forms.Button()
        Me.Button9 = New System.Windows.Forms.Button()
        Me.Button10 = New System.Windows.Forms.Button()
        Me.Button12 = New System.Windows.Forms.Button()
        Me.Button13 = New System.Windows.Forms.Button()
        Me.Button14 = New System.Windows.Forms.Button()
        Me.Button15 = New System.Windows.Forms.Button()
        Me.Button16 = New System.Windows.Forms.Button()
        Me.Button17 = New System.Windows.Forms.Button()
        Me.Button18 = New System.Windows.Forms.Button()
        Me.Button19 = New System.Windows.Forms.Button()
        Me.Button20 = New System.Windows.Forms.Button()
        Me.Button21 = New System.Windows.Forms.Button()
        Me.Button22 = New System.Windows.Forms.Button()
        Me.Button23 = New System.Windows.Forms.Button()
        Me.Button24 = New System.Windows.Forms.Button()
        Me.Button25 = New System.Windows.Forms.Button()
        Me.Button26 = New System.Windows.Forms.Button()
        Me.Button27 = New System.Windows.Forms.Button()
        Me.Button28 = New System.Windows.Forms.Button()
        Me.Button3 = New System.Windows.Forms.Button()
        Me.Button4 = New System.Windows.Forms.Button()
        Me.TabControl1.SuspendLayout()
        Me.PWST.SuspendLayout()
        Me.SAP.SuspendLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).BeginInit()
        Me.CLEAN.SuspendLayout()
        Me.SuspendLayout()
        '
        'Button1
        '
        Me.Button1.Location = New System.Drawing.Point(26, 7)
        Me.Button1.Name = "Button1"
        Me.Button1.Size = New System.Drawing.Size(75, 23)
        Me.Button1.TabIndex = 0
        Me.Button1.Text = "Pedidos"
        Me.Button1.UseVisualStyleBackColor = True
        '
        'Button_Cobros
        '
        Me.Button_Cobros.Location = New System.Drawing.Point(299, 7)
        Me.Button_Cobros.Name = "Button_Cobros"
        Me.Button_Cobros.Size = New System.Drawing.Size(75, 23)
        Me.Button_Cobros.TabIndex = 1
        Me.Button_Cobros.Text = "Cobros"
        Me.Button_Cobros.UseVisualStyleBackColor = True
        '
        'TabControl1
        '
        Me.TabControl1.Controls.Add(Me.PWST)
        Me.TabControl1.Controls.Add(Me.SAP)
        Me.TabControl1.Controls.Add(Me.CLEAN)
        Me.TabControl1.Location = New System.Drawing.Point(12, 15)
        Me.TabControl1.Name = "TabControl1"
        Me.TabControl1.SelectedIndex = 0
        Me.TabControl1.Size = New System.Drawing.Size(409, 291)
        Me.TabControl1.TabIndex = 6
        '
        'PWST
        '
        Me.PWST.Controls.Add(Me.Carga_Docs)
        Me.PWST.Controls.Add(Me.Plan_Medida)
        Me.PWST.Controls.Add(Me.Unid_Medida)
        Me.PWST.Controls.Add(Me.Carga_Precio)
        Me.PWST.Controls.Add(Me.Saldo_Cliente)
        Me.PWST.Controls.Add(Me.Carga_Producto)
        Me.PWST.Controls.Add(Me.Saldo_bodega)
        Me.PWST.Controls.Add(Me.Lista_precio)
        Me.PWST.Controls.Add(Me.Encabezado_factura)
        Me.PWST.Controls.Add(Me.Clientes_Lista)
        Me.PWST.Controls.Add(Me.Marcas)
        Me.PWST.Controls.Add(Me.Casas)
        Me.PWST.Controls.Add(Me.Encabezado_Promocion)
        Me.PWST.Controls.Add(Me.Tipo_producto)
        Me.PWST.Controls.Add(Me.Bodegas_Vendedores)
        Me.PWST.Controls.Add(Me.Clientes)
        Me.PWST.Controls.Add(Me.Cuentas_Bancarias)
        Me.PWST.Controls.Add(Me.Bonificaciones)
        Me.PWST.Controls.Add(Me.Bancos)
        Me.PWST.Controls.Add(Me.Vendedores)
        Me.PWST.Controls.Add(Me.Canales)
        Me.PWST.Location = New System.Drawing.Point(4, 22)
        Me.PWST.Name = "PWST"
        Me.PWST.Padding = New System.Windows.Forms.Padding(3)
        Me.PWST.Size = New System.Drawing.Size(332, 265)
        Me.PWST.TabIndex = 1
        Me.PWST.Text = "PWST"
        Me.PWST.UseVisualStyleBackColor = True
        '
        'Carga_Docs
        '
        Me.Carga_Docs.Enabled = False
        Me.Carga_Docs.Location = New System.Drawing.Point(125, 221)
        Me.Carga_Docs.Name = "Carga_Docs"
        Me.Carga_Docs.Size = New System.Drawing.Size(75, 37)
        Me.Carga_Docs.TabIndex = 24
        Me.Carga_Docs.Text = "Carga Descuentos"
        Me.Carga_Docs.UseVisualStyleBackColor = True
        '
        'Plan_Medida
        '
        Me.Plan_Medida.Location = New System.Drawing.Point(168, 178)
        Me.Plan_Medida.Name = "Plan_Medida"
        Me.Plan_Medida.Size = New System.Drawing.Size(75, 37)
        Me.Plan_Medida.TabIndex = 21
        Me.Plan_Medida.Text = "Plan de Medida"
        Me.Plan_Medida.UseVisualStyleBackColor = True
        '
        'Unid_Medida
        '
        Me.Unid_Medida.Location = New System.Drawing.Point(249, 178)
        Me.Unid_Medida.Name = "Unid_Medida"
        Me.Unid_Medida.Size = New System.Drawing.Size(75, 37)
        Me.Unid_Medida.TabIndex = 20
        Me.Unid_Medida.Text = "Unidades Medida"
        Me.Unid_Medida.UseVisualStyleBackColor = True
        '
        'Carga_Precio
        '
        Me.Carga_Precio.Location = New System.Drawing.Point(87, 178)
        Me.Carga_Precio.Name = "Carga_Precio"
        Me.Carga_Precio.Size = New System.Drawing.Size(75, 37)
        Me.Carga_Precio.TabIndex = 19
        Me.Carga_Precio.Text = "Carga Precios"
        Me.Carga_Precio.UseVisualStyleBackColor = True
        '
        'Saldo_Cliente
        '
        Me.Saldo_Cliente.Location = New System.Drawing.Point(6, 178)
        Me.Saldo_Cliente.Name = "Saldo_Cliente"
        Me.Saldo_Cliente.Size = New System.Drawing.Size(75, 37)
        Me.Saldo_Cliente.TabIndex = 17
        Me.Saldo_Cliente.Text = "Saldo Clientes"
        Me.Saldo_Cliente.UseVisualStyleBackColor = True
        '
        'Carga_Producto
        '
        Me.Carga_Producto.Location = New System.Drawing.Point(6, 135)
        Me.Carga_Producto.Name = "Carga_Producto"
        Me.Carga_Producto.Size = New System.Drawing.Size(75, 37)
        Me.Carga_Producto.TabIndex = 16
        Me.Carga_Producto.Text = "Carga Productos"
        Me.Carga_Producto.UseVisualStyleBackColor = True
        '
        'Saldo_bodega
        '
        Me.Saldo_bodega.Location = New System.Drawing.Point(87, 135)
        Me.Saldo_bodega.Name = "Saldo_bodega"
        Me.Saldo_bodega.Size = New System.Drawing.Size(75, 37)
        Me.Saldo_bodega.TabIndex = 15
        Me.Saldo_bodega.Text = "Saldo por Bodega"
        Me.Saldo_bodega.UseVisualStyleBackColor = True
        '
        'Lista_precio
        '
        Me.Lista_precio.Location = New System.Drawing.Point(168, 135)
        Me.Lista_precio.Name = "Lista_precio"
        Me.Lista_precio.Size = New System.Drawing.Size(75, 37)
        Me.Lista_precio.TabIndex = 14
        Me.Lista_precio.Text = "Lista Precios"
        Me.Lista_precio.UseVisualStyleBackColor = True
        '
        'Encabezado_factura
        '
        Me.Encabezado_factura.Location = New System.Drawing.Point(249, 135)
        Me.Encabezado_factura.Name = "Encabezado_factura"
        Me.Encabezado_factura.Size = New System.Drawing.Size(75, 37)
        Me.Encabezado_factura.TabIndex = 13
        Me.Encabezado_factura.Text = "Encabezado Factura"
        Me.Encabezado_factura.UseVisualStyleBackColor = True
        '
        'Clientes_Lista
        '
        Me.Clientes_Lista.Location = New System.Drawing.Point(249, 92)
        Me.Clientes_Lista.Name = "Clientes_Lista"
        Me.Clientes_Lista.Size = New System.Drawing.Size(75, 37)
        Me.Clientes_Lista.TabIndex = 12
        Me.Clientes_Lista.Text = "Cliente x Lista"
        Me.Clientes_Lista.UseVisualStyleBackColor = True
        '
        'Marcas
        '
        Me.Marcas.Location = New System.Drawing.Point(168, 92)
        Me.Marcas.Name = "Marcas"
        Me.Marcas.Size = New System.Drawing.Size(75, 37)
        Me.Marcas.TabIndex = 11
        Me.Marcas.Text = "Marcas"
        Me.Marcas.UseVisualStyleBackColor = True
        '
        'Casas
        '
        Me.Casas.Location = New System.Drawing.Point(87, 92)
        Me.Casas.Name = "Casas"
        Me.Casas.Size = New System.Drawing.Size(75, 37)
        Me.Casas.TabIndex = 10
        Me.Casas.Text = "Casas"
        Me.Casas.UseVisualStyleBackColor = True
        '
        'Encabezado_Promocion
        '
        Me.Encabezado_Promocion.Location = New System.Drawing.Point(6, 92)
        Me.Encabezado_Promocion.Name = "Encabezado_Promocion"
        Me.Encabezado_Promocion.Size = New System.Drawing.Size(75, 37)
        Me.Encabezado_Promocion.TabIndex = 9
        Me.Encabezado_Promocion.Text = "Encabezado Promociones"
        Me.Encabezado_Promocion.UseVisualStyleBackColor = True
        '
        'Tipo_producto
        '
        Me.Tipo_producto.Location = New System.Drawing.Point(6, 49)
        Me.Tipo_producto.Name = "Tipo_producto"
        Me.Tipo_producto.Size = New System.Drawing.Size(75, 37)
        Me.Tipo_producto.TabIndex = 8
        Me.Tipo_producto.Text = "Tipo Producto"
        Me.Tipo_producto.UseVisualStyleBackColor = True
        '
        'Bodegas_Vendedores
        '
        Me.Bodegas_Vendedores.Location = New System.Drawing.Point(87, 49)
        Me.Bodegas_Vendedores.Name = "Bodegas_Vendedores"
        Me.Bodegas_Vendedores.Size = New System.Drawing.Size(75, 37)
        Me.Bodegas_Vendedores.TabIndex = 7
        Me.Bodegas_Vendedores.Text = "Bodegas Vendedores"
        Me.Bodegas_Vendedores.UseVisualStyleBackColor = True
        '
        'Clientes
        '
        Me.Clientes.Location = New System.Drawing.Point(168, 49)
        Me.Clientes.Name = "Clientes"
        Me.Clientes.Size = New System.Drawing.Size(75, 37)
        Me.Clientes.TabIndex = 6
        Me.Clientes.Text = "Clientes"
        Me.Clientes.UseVisualStyleBackColor = True
        '
        'Cuentas_Bancarias
        '
        Me.Cuentas_Bancarias.Location = New System.Drawing.Point(249, 49)
        Me.Cuentas_Bancarias.Name = "Cuentas_Bancarias"
        Me.Cuentas_Bancarias.Size = New System.Drawing.Size(75, 37)
        Me.Cuentas_Bancarias.TabIndex = 5
        Me.Cuentas_Bancarias.Text = "Cuentas Bancarias"
        Me.Cuentas_Bancarias.UseVisualStyleBackColor = True
        '
        'Bonificaciones
        '
        Me.Bonificaciones.Enabled = False
        Me.Bonificaciones.Location = New System.Drawing.Point(249, 6)
        Me.Bonificaciones.Name = "Bonificaciones"
        Me.Bonificaciones.Size = New System.Drawing.Size(75, 37)
        Me.Bonificaciones.TabIndex = 4
        Me.Bonificaciones.Text = "Bonificaciones"
        Me.Bonificaciones.UseVisualStyleBackColor = True
        '
        'Bancos
        '
        Me.Bancos.Location = New System.Drawing.Point(168, 6)
        Me.Bancos.Name = "Bancos"
        Me.Bancos.Size = New System.Drawing.Size(75, 37)
        Me.Bancos.TabIndex = 3
        Me.Bancos.Text = "Bancos"
        Me.Bancos.UseVisualStyleBackColor = True
        '
        'Vendedores
        '
        Me.Vendedores.Location = New System.Drawing.Point(87, 6)
        Me.Vendedores.Name = "Vendedores"
        Me.Vendedores.Size = New System.Drawing.Size(75, 37)
        Me.Vendedores.TabIndex = 2
        Me.Vendedores.Text = "Vendedores"
        Me.Vendedores.UseVisualStyleBackColor = True
        '
        'Canales
        '
        Me.Canales.Location = New System.Drawing.Point(6, 6)
        Me.Canales.Name = "Canales"
        Me.Canales.Size = New System.Drawing.Size(75, 37)
        Me.Canales.TabIndex = 1
        Me.Canales.Text = "Canales"
        Me.Canales.UseVisualStyleBackColor = True
        '
        'SAP
        '
        Me.SAP.Controls.Add(Me.Button4)
        Me.SAP.Controls.Add(Me.Label1)
        Me.SAP.Controls.Add(Me.ListBox1)
        Me.SAP.Controls.Add(Me.Button2)
        Me.SAP.Controls.Add(Me.DGV)
        Me.SAP.Controls.Add(Me.Button1)
        Me.SAP.Controls.Add(Me.Button_Cobros)
        Me.SAP.Location = New System.Drawing.Point(4, 22)
        Me.SAP.Name = "SAP"
        Me.SAP.Padding = New System.Windows.Forms.Padding(3)
        Me.SAP.Size = New System.Drawing.Size(401, 265)
        Me.SAP.TabIndex = 0
        Me.SAP.Text = "SAP"
        Me.SAP.UseVisualStyleBackColor = True
        '
        'Label1
        '
        Me.Label1.AutoSize = True
        Me.Label1.Location = New System.Drawing.Point(23, 168)
        Me.Label1.Name = "Label1"
        Me.Label1.Size = New System.Drawing.Size(0, 13)
        Me.Label1.TabIndex = 8
        '
        'ListBox1
        '
        Me.ListBox1.FormattingEnabled = True
        Me.ListBox1.Location = New System.Drawing.Point(124, 167)
        Me.ListBox1.Name = "ListBox1"
        Me.ListBox1.Size = New System.Drawing.Size(140, 95)
        Me.ListBox1.TabIndex = 7
        Me.ListBox1.Visible = False
        '
        'Button2
        '
        Me.Button2.Enabled = False
        Me.Button2.Location = New System.Drawing.Point(143, 6)
        Me.Button2.Name = "Button2"
        Me.Button2.Size = New System.Drawing.Size(114, 23)
        Me.Button2.TabIndex = 4
        Me.Button2.Text = "Realiza Cobro"
        Me.Button2.UseVisualStyleBackColor = True
        Me.Button2.Visible = False
        '
        'DGV
        '
        Me.DGV.AllowUserToAddRows = False
        Me.DGV.AllowUserToDeleteRows = False
        Me.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize
        Me.DGV.Location = New System.Drawing.Point(6, 46)
        Me.DGV.Name = "DGV"
        Me.DGV.Size = New System.Drawing.Size(389, 115)
        Me.DGV.TabIndex = 2
        '
        'CLEAN
        '
        Me.CLEAN.Controls.Add(Me.Button5)
        Me.CLEAN.Controls.Add(Me.Button8)
        Me.CLEAN.Controls.Add(Me.Button9)
        Me.CLEAN.Controls.Add(Me.Button10)
        Me.CLEAN.Controls.Add(Me.Button12)
        Me.CLEAN.Controls.Add(Me.Button13)
        Me.CLEAN.Controls.Add(Me.Button14)
        Me.CLEAN.Controls.Add(Me.Button15)
        Me.CLEAN.Controls.Add(Me.Button16)
        Me.CLEAN.Controls.Add(Me.Button17)
        Me.CLEAN.Controls.Add(Me.Button18)
        Me.CLEAN.Controls.Add(Me.Button19)
        Me.CLEAN.Controls.Add(Me.Button20)
        Me.CLEAN.Controls.Add(Me.Button21)
        Me.CLEAN.Controls.Add(Me.Button22)
        Me.CLEAN.Controls.Add(Me.Button23)
        Me.CLEAN.Controls.Add(Me.Button24)
        Me.CLEAN.Controls.Add(Me.Button25)
        Me.CLEAN.Controls.Add(Me.Button26)
        Me.CLEAN.Controls.Add(Me.Button27)
        Me.CLEAN.Controls.Add(Me.Button28)
        Me.CLEAN.Location = New System.Drawing.Point(4, 22)
        Me.CLEAN.Name = "CLEAN"
        Me.CLEAN.Size = New System.Drawing.Size(333, 265)
        Me.CLEAN.TabIndex = 2
        Me.CLEAN.Text = "CLEAN"
        Me.CLEAN.UseVisualStyleBackColor = True
        '
        'Button5
        '
        Me.Button5.Enabled = False
        Me.Button5.Location = New System.Drawing.Point(125, 221)
        Me.Button5.Name = "Button5"
        Me.Button5.Size = New System.Drawing.Size(75, 37)
        Me.Button5.TabIndex = 51
        Me.Button5.Text = "Carga Descuentos"
        Me.Button5.UseVisualStyleBackColor = True
        '
        'Button8
        '
        Me.Button8.Location = New System.Drawing.Point(168, 178)
        Me.Button8.Name = "Button8"
        Me.Button8.Size = New System.Drawing.Size(75, 37)
        Me.Button8.TabIndex = 48
        Me.Button8.Text = "Plan de Medida"
        Me.Button8.UseVisualStyleBackColor = True
        '
        'Button9
        '
        Me.Button9.Location = New System.Drawing.Point(249, 178)
        Me.Button9.Name = "Button9"
        Me.Button9.Size = New System.Drawing.Size(75, 37)
        Me.Button9.TabIndex = 47
        Me.Button9.Text = "Unidades Medida"
        Me.Button9.UseVisualStyleBackColor = True
        '
        'Button10
        '
        Me.Button10.Location = New System.Drawing.Point(87, 178)
        Me.Button10.Name = "Button10"
        Me.Button10.Size = New System.Drawing.Size(75, 37)
        Me.Button10.TabIndex = 46
        Me.Button10.Text = "Carga Precios"
        Me.Button10.UseVisualStyleBackColor = True
        '
        'Button12
        '
        Me.Button12.Location = New System.Drawing.Point(6, 178)
        Me.Button12.Name = "Button12"
        Me.Button12.Size = New System.Drawing.Size(75, 37)
        Me.Button12.TabIndex = 44
        Me.Button12.Text = "Saldo Clientes"
        Me.Button12.UseVisualStyleBackColor = True
        '
        'Button13
        '
        Me.Button13.Location = New System.Drawing.Point(6, 135)
        Me.Button13.Name = "Button13"
        Me.Button13.Size = New System.Drawing.Size(75, 37)
        Me.Button13.TabIndex = 43
        Me.Button13.Text = "Carga Productos"
        Me.Button13.UseVisualStyleBackColor = True
        '
        'Button14
        '
        Me.Button14.Location = New System.Drawing.Point(87, 135)
        Me.Button14.Name = "Button14"
        Me.Button14.Size = New System.Drawing.Size(75, 37)
        Me.Button14.TabIndex = 42
        Me.Button14.Text = "Saldo por Bodega"
        Me.Button14.UseVisualStyleBackColor = True
        '
        'Button15
        '
        Me.Button15.Location = New System.Drawing.Point(168, 135)
        Me.Button15.Name = "Button15"
        Me.Button15.Size = New System.Drawing.Size(75, 37)
        Me.Button15.TabIndex = 41
        Me.Button15.Text = "Lista Precios"
        Me.Button15.UseVisualStyleBackColor = True
        '
        'Button16
        '
        Me.Button16.Location = New System.Drawing.Point(249, 135)
        Me.Button16.Name = "Button16"
        Me.Button16.Size = New System.Drawing.Size(75, 37)
        Me.Button16.TabIndex = 40
        Me.Button16.Text = "Encabezado Factura"
        Me.Button16.UseVisualStyleBackColor = True
        '
        'Button17
        '
        Me.Button17.Location = New System.Drawing.Point(249, 92)
        Me.Button17.Name = "Button17"
        Me.Button17.Size = New System.Drawing.Size(75, 37)
        Me.Button17.TabIndex = 39
        Me.Button17.Text = "Cliente x Lista"
        Me.Button17.UseVisualStyleBackColor = True
        '
        'Button18
        '
        Me.Button18.Location = New System.Drawing.Point(168, 92)
        Me.Button18.Name = "Button18"
        Me.Button18.Size = New System.Drawing.Size(75, 37)
        Me.Button18.TabIndex = 38
        Me.Button18.Text = "Marcas"
        Me.Button18.UseVisualStyleBackColor = True
        '
        'Button19
        '
        Me.Button19.Location = New System.Drawing.Point(87, 92)
        Me.Button19.Name = "Button19"
        Me.Button19.Size = New System.Drawing.Size(75, 37)
        Me.Button19.TabIndex = 37
        Me.Button19.Text = "Casas"
        Me.Button19.UseVisualStyleBackColor = True
        '
        'Button20
        '
        Me.Button20.Location = New System.Drawing.Point(6, 92)
        Me.Button20.Name = "Button20"
        Me.Button20.Size = New System.Drawing.Size(75, 37)
        Me.Button20.TabIndex = 36
        Me.Button20.Text = "Encabezado Promociones"
        Me.Button20.UseVisualStyleBackColor = True
        '
        'Button21
        '
        Me.Button21.Location = New System.Drawing.Point(6, 49)
        Me.Button21.Name = "Button21"
        Me.Button21.Size = New System.Drawing.Size(75, 37)
        Me.Button21.TabIndex = 35
        Me.Button21.Text = "Tipo Producto"
        Me.Button21.UseVisualStyleBackColor = True
        '
        'Button22
        '
        Me.Button22.Location = New System.Drawing.Point(87, 49)
        Me.Button22.Name = "Button22"
        Me.Button22.Size = New System.Drawing.Size(75, 37)
        Me.Button22.TabIndex = 34
        Me.Button22.Text = "Bodegas Vendedores"
        Me.Button22.UseVisualStyleBackColor = True
        '
        'Button23
        '
        Me.Button23.Location = New System.Drawing.Point(168, 49)
        Me.Button23.Name = "Button23"
        Me.Button23.Size = New System.Drawing.Size(75, 37)
        Me.Button23.TabIndex = 33
        Me.Button23.Text = "Clientes"
        Me.Button23.UseVisualStyleBackColor = True
        '
        'Button24
        '
        Me.Button24.Location = New System.Drawing.Point(249, 49)
        Me.Button24.Name = "Button24"
        Me.Button24.Size = New System.Drawing.Size(75, 37)
        Me.Button24.TabIndex = 32
        Me.Button24.Text = "Cuentas Bancarias"
        Me.Button24.UseVisualStyleBackColor = True
        '
        'Button25
        '
        Me.Button25.Enabled = False
        Me.Button25.Location = New System.Drawing.Point(249, 6)
        Me.Button25.Name = "Button25"
        Me.Button25.Size = New System.Drawing.Size(75, 37)
        Me.Button25.TabIndex = 31
        Me.Button25.Text = "Bonificaciones"
        Me.Button25.UseVisualStyleBackColor = True
        '
        'Button26
        '
        Me.Button26.Location = New System.Drawing.Point(168, 6)
        Me.Button26.Name = "Button26"
        Me.Button26.Size = New System.Drawing.Size(75, 37)
        Me.Button26.TabIndex = 30
        Me.Button26.Text = "Bancos"
        Me.Button26.UseVisualStyleBackColor = True
        '
        'Button27
        '
        Me.Button27.Location = New System.Drawing.Point(87, 6)
        Me.Button27.Name = "Button27"
        Me.Button27.Size = New System.Drawing.Size(75, 37)
        Me.Button27.TabIndex = 29
        Me.Button27.Text = "Vendedores"
        Me.Button27.UseVisualStyleBackColor = True
        '
        'Button28
        '
        Me.Button28.Location = New System.Drawing.Point(6, 6)
        Me.Button28.Name = "Button28"
        Me.Button28.Size = New System.Drawing.Size(75, 37)
        Me.Button28.TabIndex = 28
        Me.Button28.Text = "Canales"
        Me.Button28.UseVisualStyleBackColor = True
        '
        'Button3
        '
        Me.Button3.BackColor = System.Drawing.Color.DarkRed
        Me.Button3.ForeColor = System.Drawing.SystemColors.ControlLightLight
        Me.Button3.Location = New System.Drawing.Point(172, 312)
        Me.Button3.Name = "Button3"
        Me.Button3.Size = New System.Drawing.Size(75, 23)
        Me.Button3.TabIndex = 7
        Me.Button3.Text = "Salir"
        Me.Button3.UseVisualStyleBackColor = False
        '
        'Button4
        '
        Me.Button4.Enabled = False
        Me.Button4.Location = New System.Drawing.Point(143, 7)
        Me.Button4.Name = "Button4"
        Me.Button4.Size = New System.Drawing.Size(114, 23)
        Me.Button4.TabIndex = 9
        Me.Button4.Text = "Realiza Pedido"
        Me.Button4.UseVisualStyleBackColor = True
        Me.Button4.Visible = False
        '
        'Form1
        '
        Me.AutoScaleDimensions = New System.Drawing.SizeF(6.0!, 13.0!)
        Me.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font
        Me.ClientSize = New System.Drawing.Size(430, 365)
        Me.Controls.Add(Me.Button3)
        Me.Controls.Add(Me.TabControl1)
        Me.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow
        Me.Name = "Form1"
        Me.Text = "PWST_SAP"
        Me.TabControl1.ResumeLayout(False)
        Me.PWST.ResumeLayout(False)
        Me.SAP.ResumeLayout(False)
        Me.SAP.PerformLayout()
        CType(Me.DGV, System.ComponentModel.ISupportInitialize).EndInit()
        Me.CLEAN.ResumeLayout(False)
        Me.ResumeLayout(False)

    End Sub

    Friend WithEvents Button1 As Button
    Friend WithEvents Button_Cobros As Button
    Friend WithEvents TabControl1 As TabControl
    Friend WithEvents SAP As TabPage
    Friend WithEvents PWST As TabPage
    Friend WithEvents Carga_Docs As Button
    Friend WithEvents Plan_Medida As Button
    Friend WithEvents Unid_Medida As Button
    Friend WithEvents Carga_Precio As Button
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
    Friend WithEvents CLEAN As TabPage
    Friend WithEvents Button5 As Button
    Friend WithEvents Button8 As Button
    Friend WithEvents Button9 As Button
    Friend WithEvents Button10 As Button
    Friend WithEvents Button12 As Button
    Friend WithEvents Button13 As Button
    Friend WithEvents Button14 As Button
    Friend WithEvents Button15 As Button
    Friend WithEvents Button16 As Button
    Friend WithEvents Button17 As Button
    Friend WithEvents Button18 As Button
    Friend WithEvents Button19 As Button
    Friend WithEvents Button20 As Button
    Friend WithEvents Button21 As Button
    Friend WithEvents Button22 As Button
    Friend WithEvents Button23 As Button
    Friend WithEvents Button24 As Button
    Friend WithEvents Button25 As Button
    Friend WithEvents Button26 As Button
    Friend WithEvents Button27 As Button
    Friend WithEvents Button28 As Button
    Friend WithEvents DGV As DataGridView
    Friend WithEvents Button2 As Button
    Friend WithEvents ListBox1 As ListBox
    Friend WithEvents Label1 As Label
    Friend WithEvents Button3 As Button
    Friend WithEvents Button4 As Button
End Class
