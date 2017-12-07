
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Imports System.Globalization

Public Class Form1
    Public Shared SQL_Conexion As SqlConnection = New SqlConnection()
    Dim connectionString As String '= "Data Source=127.0.0.1;" + "Initial Catalog=istmaniaPWST;" + "User id=sa;" + "Password=12345;"
    Dim tabla As String
    Dim valrecibo As String
    Dim valseries As String
    Private Property _oCompany As SAPbobsCOM.Company
    Public Property oCompany() As SAPbobsCOM.Company
        Get
            Return _oCompany
        End Get
        Set(ByVal value As SAPbobsCOM.Company)
            _oCompany = value
        End Set
    End Property
    Public Function MakeConnectionSAP() As Boolean
        Dim Connected As Boolean = False
        '' Dim cnnParam As New Settings
        Dim ip As String
        Dim db As String
        Dim user As String
        Dim password As String

        Dim DbUserName As String
        Dim DbPassword As String
        Dim Server As String
        Dim CompanyDB As String
        Dim UserName As String
        Dim hPassword As String
        Dim LicenseServer As String

        Dim entra As String = Application.StartupPath + "\Conexion.xml"
        Dim Xml As XmlDocument = New XmlDocument()
        Xml.Load(entra)
        Dim ArticleList As XmlNodeList = Xml.SelectNodes("body/SQL")
        For Each xnDoc As XmlNode In ArticleList
            ip = xnDoc.SelectSingleNode("ip").InnerText
            db = xnDoc.SelectSingleNode("db").InnerText
            user = xnDoc.SelectSingleNode("user").InnerText
            password = xnDoc.SelectSingleNode("password").InnerText
        Next

        connectionString = "Data Source=" + ip + ";" + "Initial Catalog=" + db + ";" + "User id=" + user + ";" + "Password=" + password + ";"

        Dim ArticleList2 As XmlNodeList = Xml.SelectNodes("body/HANA")
        For Each xnDoc2 As XmlNode In ArticleList2
            DbUserName = xnDoc2.SelectSingleNode("DbUserName").InnerText
            DbPassword = xnDoc2.SelectSingleNode("DbPassword").InnerText
            Server = xnDoc2.SelectSingleNode("Server").InnerText
            CompanyDB = xnDoc2.SelectSingleNode("CompanyDB").InnerText
            UserName = xnDoc2.SelectSingleNode("UserName").InnerText
            hPassword = xnDoc2.SelectSingleNode("Password").InnerText
            LicenseServer = xnDoc2.SelectSingleNode("LicenseServer").InnerText
        Next


        Try
            Connected = -1
            'oCompany = New SAPbobsCOM.Company
            'oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012
            'oCompany.DbUserName = DbUserName
            'oCompany.DbPassword = DbPassword
            'oCompany.Server = Server
            'oCompany.CompanyDB = CompanyDB
            'oCompany.UserName = UserName
            'oCompany.Password = hPassword
            'oCompany.LicenseServer = LicenseServer
            'oCompany.UseTrusted = False
            'Connected = oCompany.Connect()

            oCompany = New SAPbobsCOM.Company
            oCompany.DbUserName = DbUserName
            oCompany.DbPassword = DbPassword
            oCompany.Server = Server
            oCompany.CompanyDB = CompanyDB
            oCompany.UserName = UserName
            oCompany.Password = hPassword
            oCompany.LicenseServer = LicenseServer
            oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB
            oCompany.UseTrusted = False
            Connected = oCompany.Connect()

            If Connected <> 0 Then
                Connected = False
                MsgBox(oCompany.GetLastErrorDescription)
            Else
                'MsgBox("Conexión con SAP exitosa")
                Connected = True
            End If
            Return Connected
        Catch ex As Exception
            Throw New Exception(ex.Message)
        End Try

    End Function

    Private Sub TabControl1_SelectedIndexChanged(sender As Object, e As EventArgs) _
     Handles TabControl1.SelectedIndexChanged

        'suppose your *finance tab* instance is TabPageFinance 
        If TabControl1.SelectedTab Is PWST Then
            Size = New Size(441, 349)
        End If
        If TabControl1.SelectedTab Is SAP Then
            Size = New Size(641, 349)
            CargaGridRecibo()
        End If
        If TabControl1.SelectedTab Is CLEAN Then
            Size = New Size(441, 349)
        End If
    End Sub

#Region "Pedidos Recibidos"
    Public Function Pedidos()
        Dim docistm As String
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("SELECT T0.ID_PWST AS ID_PWST,T0.EMPRESA AS EMPRESA,T0.SERIE AS SERIE,T0.NUMEROPEDIDO AS NUMPEDIDO,T0.FECHAPEDIDO AS 'DocDate',T0.FECHAENTREGA AS 'DocDueDate',T0.MONTO AS 'DocTotal',T0.OBSERVACIONES AS 'Comments',T0.TIPODOC AS TIPODOC,T0.CLIENTE AS 'CardCode',T0.VENDEDOR AS 'SlpCode',T0.STATUS AS DOCSTATUS,T0.BODEGA AS BODEGA FROM INT_CABECERAPEDIDOSPWST T0 where T0.FECHAPEDIDO = '" + DateTime.Today.AddDays(-1).ToShortDateString + "'", con)
        Dim DT_dat As DataTable = New DataTable()
        SQL_da.Fill(DT_dat)
        con.Close()
        For Each row As DataRow In DT_dat.Rows

            Dim oReturn As Integer = -1
            Dim oError As Integer = 0
            Dim errMsg As String = ""
            Dim sql As String
            Dim Order As SAPbobsCOM.Documents = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oPurchaseOrders)

            docistm = row("NUMPEDIDO").ToString()
            Order.Series = 12
            Order.DocDate = row("DocDate").ToString()
            Order.CardCode = row("CardCode").ToString()
            Order.DocDueDate = row("DocDueDate").ToString()
            Order.DocTotal = Convert.ToDouble(row("DocTotal").ToString())
            Order.UserFields.Fields.Item("U_PWST").Value = row("ID_PWST").ToString()
            Order.UserFields.Fields.Item("U_EMPRESA").Value = row("EMPRESA").ToString()
            Order.UserFields.Fields.Item("U_SERIE").Value = row("SERIE").ToString()
            Order.UserFields.Fields.Item("U_NUMPEDIDO").Value = row("NUMPEDIDO").ToString()
            Order.UserFields.Fields.Item("U_BODEGA").Value = row("BODEGA").ToString()
            Order.UserFields.Fields.Item("U_TIPODOC").Value = row("TIPODOC").ToString()
            Order.UserFields.Fields.Item("U_DOCSTATUS").Value = row("DOCSTATUS").ToString()
            Order.DocType = SAPbobsCOM.BoDocumentTypes.dDocument_Items

            con.Open()
            Dim SQL_daDET As SqlDataAdapter = New SqlDataAdapter("select T0.ARTICULO,1 as 'UNIDADES',T0.PRECIOVENTA from INT_DETALLEPEDIDOSPWST T0 WHERE T0.NUMEROPEDIDO = '" + row("NUMPEDIDO").ToString() + "'", con)
            Dim DT_datDET As DataTable = New DataTable()
            SQL_daDET.Fill(DT_datDET)
            con.Close()

            For Each rowDET As DataRow In DT_datDET.Rows

                Order.Lines.ItemCode = rowDET("ARTICULO").ToString()
                Order.Lines.Quantity = rowDET("UNIDADES").ToString()
                Order.Lines.PriceAfterVAT = rowDET("PRECIOVENTA").ToString()
                Order.Lines.Add()
            Next
            Order.Comments = row("Comments").ToString()
            oReturn = Order.Add()
            If oReturn <> 0 Then
                oCompany.GetLastError(oError, errMsg)
                MsgBox(errMsg)
            Else
                Dim cons As SqlConnection = New SqlConnection(connectionString)
                cons.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("UPDATE INT_CABECERAPEDIDOSPWST SET SAP = 1 WHERE NUMEROPEDIDO = '" + row("NUMPEDIDO").ToString() + "'", cons)
                SQL_daUp.ExecuteNonQuery()
                cons.Close()

            End If
        Next
    End Function
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        If oCompany.Connected = True Then
            Pedidos()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Pedidos()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
#End Region
#Region "Pagos Recibidos"
    Public Function Recibos(valoresrecibos As String, valoresseries As String)
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("SELECT ID AS 'ID_PWST',EMPRESA,SERIE,NUMERORECIBO as 'NUMRECIBO',FECHA as 'DocDate',CLIENTE as 'CardCode',MONTO as 'CashSum',moneda as 'Moneda',VENDEDOR,TIPODOC,BANCO,CUENTA FROM INT_CABECERACOBRANZAPWST T0 where T0.FECHA = '10/10/2017' and NUMERORECIBO in (" + valoresrecibos + ") and SERIE in (" + valoresseries + ") and STATUS = '1'", con)
        Dim DT_dat As DataTable = New DataTable()
        SQL_da.Fill(DT_dat)
        Dim i As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        Dim existe As Boolean = DGV.Columns.Cast(Of DataGridViewColumn).Any(Function(x) x.Name = "CHK")
        If existe = False Then
            DGV.Columns.Add(i)
            i.HeaderText = "CHK"
            i.Name = "CHK"
            i.Width = 32
            i.DisplayIndex = 0
        End If
        DGV.DataSource = DT_dat
        con.Close()
        For Each row As DataRow In DT_dat.Rows

            Dim oReturn As Integer = -1
            Dim oError As Integer = 0
            Dim errMsg As String = ""
            Dim sql As String

            Dim oPayment As SAPbobsCOM.Payments = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.oIncomingPayments)

            oPayment.Series = 14
            oPayment.DocDate = row("DocDate").ToString()
            oPayment.CardCode = row("CardCode").ToString()
            oPayment.DocType = oPayment.DocType.rCustomer
            oPayment.CashSum = Convert.ToDouble(row("CashSum").ToString())
            oPayment.CashAccount = "_SYS00000000004"
            oPayment.UserFields.Fields.Item("U_PWST").Value = row("ID_PWST").ToString()
            oPayment.UserFields.Fields.Item("U_EMPRESA").Value = row("EMPRESA").ToString()
            oPayment.UserFields.Fields.Item("U_SERIE").Value = row("SERIE").ToString()
            oPayment.UserFields.Fields.Item("U_NUMRECIBO").Value = row("NUMRECIBO").ToString()
            oPayment.UserFields.Fields.Item("U_MONEDA").Value = row("Moneda").ToString()
            oPayment.UserFields.Fields.Item("U_TIPODOC").Value = row("TIPODOC").ToString()
            oPayment.UserFields.Fields.Item("U_VENDEDOR").Value = row("VENDEDOR").ToString()
            oPayment.UserFields.Fields.Item("U_BANCO").Value = row("BANCO").ToString()
            oPayment.UserFields.Fields.Item("U_CUENTA").Value = row("CUENTA").ToString()

            'sql = ("select top 1 " & Chr(34) & "DocEntry" & Chr(34) & " from oinv where " & Chr(34) & "DocNum" & Chr(34) & " = " + row("CUENTA").ToString())
            'Dim oRecordSet As SAPbobsCOM.Recordset
            'oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            'oRecordSet.DoQuery(sql)
            'If oRecordSet.RecordCount > 0 Then
            '    oPayment.Invoices.DocEntry = oRecordSet.Fields.Item(0).Value
            'End If
            'oPayment.Invoices.InvoiceType = "13"
            'oPayment.Invoices.SumApplied = Convert.ToDouble(row("CashSum").ToString())
            'oPayment.Invoices.Add()
            'System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            'oRecordSet = Nothing
            'GC.Collect()

            oReturn = oPayment.Add()
            If oReturn <> 0 Then
                oCompany.GetLastError(oError, errMsg)
                MsgBox(errMsg)
            Else
                Dim cons As SqlConnection = New SqlConnection(connectionString)
                cons.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("UPDATE INT_CABECERACOBRANZAPWST SET STATUS = 2 WHERE NUMERORECIBO = '" + row("NUMRECIBO").ToString() + "'", cons)
                SQL_daUp.ExecuteNonQuery()
                cons.Close()
            End If
            CargaGridRecibo()
        Next
    End Function
    Private Sub Button_Cobros_Click(sender As Object, e As EventArgs) Handles Button_Cobros.Click
        If oCompany.Connected = True Then
            CargaGridRecibo()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                CargaGridRecibo()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
#End Region


    Private Sub Form1_Load(sender As Object, e As EventArgs) Handles MyBase.Load
        MakeConnectionSAP()
        'TextBox1.Text = DateTime.Today.AddDays(-1).ToShortDateString '51395613
    End Sub

    'INT_CANAL /////////////////////////////////////////FALTA
    Public Function Canal()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('canal','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_CANAL VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Canales_Click(sender As Object, e As EventArgs) Handles Canales.Click
        If oCompany.Connected = True Then
            Canal()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Canal()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_VENDEDORES
    Public Function Vendedor()
        Dim sql As String
        Dim splcode As String
        Dim splname As String
        sql = ("call PWST_SAP('vendedor','','')")
        Dim oRecordSet As SAPbobsCOM.Recordset
        oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        oRecordSet.DoQuery(sql)
        While oRecordSet.EoF = False
            Dim con As SqlConnection = New SqlConnection(connectionString)
            con.Open()
            Dim SQL_daUp As SqlCommand = New SqlCommand("insert into INT_VENDEDORES values ('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
            SQL_daUp.ExecuteNonQuery()
            con.Close()
            oRecordSet.MoveNext()
        End While
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
        oRecordSet = Nothing
        GC.Collect()
        MessageBox.Show("Proceso Finalizado")
    End Function
    Private Sub Vendedores_Click(sender As Object, e As EventArgs) Handles Vendedores.Click
        If oCompany.Connected = True Then
            Vendedor()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Vendedor()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_BANCOS
    Public Function Banco()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('banco','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_BANCOS VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Bancos_Click(sender As Object, e As EventArgs) Handles Bancos.Click
        If oCompany.Connected = True Then
            Banco()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Banco()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_DETALLEBONIFICACIONES /////////////////////////////////////////FALTA
    Public Function Bonificacion()
        Dim sql As String
        Try
            sql = ("select BankCode,BankName from ODSC")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_BANCOS VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Bonificaciones_Click(sender As Object, e As EventArgs) Handles Bonificaciones.Click
        If oCompany.Connected = True Then
            Bonificacion()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Bonificacion()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_CUENTASXBANCO
    Public Function cuentasxbanco()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('cuentasxbanco','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_CUENTASXBANCO VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "','" + oRecordSet.Fields.Item(3).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Cuentas_Bancarias_Click(sender As Object, e As EventArgs) Handles Cuentas_Bancarias.Click
        If oCompany.Connected = True Then
            cuentasxbanco()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                cuentasxbanco()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_CLIENTES_PWST
    Public Function Cliente()
        Dim sql As String
        Dim splcode As String
        Dim splname As String
        Try
            sql = ("call PWST_SAP('cliente','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_CLIENTES_PWST VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + Replace(oRecordSet.Fields.Item(1).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(2).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(3).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(4).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(5).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(6).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(7).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(8).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(9).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(10).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(11).Value.ToString, "'", "") + "','" + Replace(oRecordSet.Fields.Item(12).Value.ToString, "'", "") + "','" + oRecordSet.Fields.Item(13).Value.ToString + "','" + oRecordSet.Fields.Item(14).Value.ToString + "','" + oRecordSet.Fields.Item(15).Value.ToString + "','" + oRecordSet.Fields.Item(16).Value.ToString + "','" + oRecordSet.Fields.Item(17).Value.ToString + "','" + oRecordSet.Fields.Item(18).Value.ToString + "','" + oRecordSet.Fields.Item(19).Value.ToString + "','" + oRecordSet.Fields.Item(20).Value.ToString + "','" + oRecordSet.Fields.Item(21).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Clientes_Click(sender As Object, e As EventArgs) Handles Clientes.Click
        If oCompany.Connected = True Then
            Cliente()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Cliente()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_BODEGASXVENDEDOR  /////////////////////////////////////////FALTA
    Public Function Bodegaxvendedor()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('bodegaxvendedor','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_BODEGASXVENDEDOR VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Bodegas_Vendedores_Click(sender As Object, e As EventArgs) Handles Bodegas_Vendedores.Click
        If oCompany.Connected = True Then
            Bodegaxvendedor()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Bodegaxvendedor()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_TIPOPRODUCTO  /////////////////////////////////////////FALTA
    Public Function tipoproducto()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('tipoproducto','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_TIPOPRODUCTO VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Tipo_producto_Click(sender As Object, e As EventArgs) Handles Tipo_producto.Click
        If oCompany.Connected = True Then
            tipoproducto()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                tipoproducto()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'Enc_Promociones  /////////////////////////////////////////FALTA
    Public Function EncPromocion()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('encpromocion','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_CABECERABONIFICACIONES VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "','" + oRecordSet.Fields.Item(3).Value.ToString + "','" + oRecordSet.Fields.Item(4).Value.ToString + "','" + oRecordSet.Fields.Item(5).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Encabezado_Promocion_Click(sender As Object, e As EventArgs) Handles Encabezado_Promocion.Click
        If oCompany.Connected = True Then
            EncPromocion()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                EncPromocion()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_FAMILIA  /////////////////////////////////////////FALTA
    Public Function Familia()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('familia','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_FAMILIA VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Casas_Click(sender As Object, e As EventArgs) Handles Casas.Click
        If oCompany.Connected = True Then
            Familia()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Familia()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub

    'INT_MARCAS  /////////////////////////////////////////FALTA
    Public Function Marca()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('marca','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_MARCAS VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Marcas_Click(sender As Object, e As EventArgs) Handles Marcas.Click
        If oCompany.Connected = True Then
            Marca()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Marca()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_LISTAXCLIENTE
    Public Function ListaXcliente()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('listaxcliente','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_LISTAXCLIENTE VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Clientes_Lista_Click(sender As Object, e As EventArgs) Handles Clientes_Lista.Click
        If oCompany.Connected = True Then
            ListaXcliente()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                ListaXcliente()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_CABECERAFACTURASGP  ////////////VERIFICAR STATUS
    Public Function CabFactura()
        Dim sql As String
        Dim docentry As String
        Try
            sql = ("call PWST_SAP('encfactura','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_CABECERAFACTURASGP VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "','" + oRecordSet.Fields.Item(3).Value.ToString + "'," + oRecordSet.Fields.Item(4).Value.ToString + ",'" + oRecordSet.Fields.Item(5).Value.ToString + "','" + oRecordSet.Fields.Item(6).Value.ToString + "')", con)
                Dim st As String = "1"
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                docentry = oRecordSet.Fields.Item(7).Value.ToString
                DetFactura(docentry)
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Public Sub DetFactura(docentry As String)
        Dim sql As String
        Try
            sql = ("call PWST_SAP('detfactura','" + docentry + "','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_DETALLEFACTURASGP VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "','" + oRecordSet.Fields.Item(3).Value.ToString + "','" + oRecordSet.Fields.Item(4).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub

    Private Sub Encabezado_factura_Click(sender As Object, e As EventArgs) Handles Encabezado_factura.Click
        If oCompany.Connected = True Then
            CabFactura()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                CabFactura()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_LISTAPRECIO
    Public Function ListaPrecio()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('listaprecio','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_LISTAPRECIO VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Lista_precio_Click(sender As Object, e As EventArgs) Handles Lista_precio.Click
        If oCompany.Connected = True Then
            ListaPrecio()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                ListaPrecio()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub

    'inventario por bodega
    Public Function InvBodega()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('invbodega','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_INVENTARIOXBODEGAS VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Saldo_bodega_Click(sender As Object, e As EventArgs) Handles Saldo_bodega.Click
        If oCompany.Connected = True Then
            InvBodega()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                InvBodega()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_PRODUCTOS        ////////CAMPOS FALTANTES
    Public Function productos()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('productos','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_PRODUCTOS VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "','" + oRecordSet.Fields.Item(3).Value.ToString + "','" + oRecordSet.Fields.Item(4).Value.ToString + "','" + oRecordSet.Fields.Item(5).Value.ToString + "','" + oRecordSet.Fields.Item(6).Value.ToString + "','" + oRecordSet.Fields.Item(7).Value.ToString + "','" + oRecordSet.Fields.Item(8).Value.ToString + "','" + oRecordSet.Fields.Item(9).Value.ToString + "','" + oRecordSet.Fields.Item(10).Value.ToString + "','" + oRecordSet.Fields.Item(11).Value.ToString + "','" + oRecordSet.Fields.Item(12).Value.ToString + "','" + oRecordSet.Fields.Item(13).Value.ToString + "','" + oRecordSet.Fields.Item(14).Value.ToString + "','" + oRecordSet.Fields.Item(15).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
            MessageBox.Show("Proceso Finalizado")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Carga_Producto_Click(sender As Object, e As EventArgs) Handles Carga_Producto.Click
        If oCompany.Connected = True Then
            productos()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                productos()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'SaldoCliente    /////////////////////////////////////////FALTA
    Public Function saldocliente()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('saldocliente','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_LISTAPRECIO VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Saldo_Cliente_Click(sender As Object, e As EventArgs) Handles Saldo_Cliente.Click
        If oCompany.Connected = True Then
            saldocliente()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                saldocliente()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_DETALLEFACTURAS    /////////////////////////////////////////FALTA
    'Public Function DetFactura()
    '    Dim sql As String
    '    Try
    '        sql = ("SELECT ListNum,ListName  FROM OPLN")
    '        Dim oRecordSet As SAPbobsCOM.Recordset
    '        oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
    '        oRecordSet.DoQuery(sql)
    '        While oRecordSet.EoF = False
    '            Dim con As SqlConnection = New SqlConnection(connectionString)
    '            con.Open()
    '            Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_LISTAPRECIO VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
    '            SQL_daUp.ExecuteNonQuery()
    '            con.Close()
    '            oRecordSet.MoveNext()
    '        End While
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
    '        oRecordSet = Nothing
    '        GC.Collect()
    '    Catch ex As Exception
    '        MessageBox.Show(ex.Message)
    '    End Try
    'End Function
    'Private Sub Detalle_Factura_Click(sender As Object, e As EventArgs) Handles Detalle_Factura.Click
    '    If oCompany.Connected = True Then
    '        DetFactura()
    '    Else
    '        System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
    '        oCompany = Nothing
    '        GC.Collect()
    '        If MakeConnectionSAP() Then
    '            DetFactura()
    '        Else
    '            MessageBox.Show("Error de Conexion")
    '        End If
    '    End If
    'End Sub
    'INT_PRECIOSPRODUCTOS       /////////////////////////////////////////FALTA
    Public Function PrecioProducto()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('precioproducto','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_PRECIOSPRODUCTOS VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Carga_Precio_Click(sender As Object, e As EventArgs) Handles Carga_Precio.Click
        If oCompany.Connected = True Then
            PrecioProducto()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                PrecioProducto()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_UNIDADES_MEDIDA       /////////////////////////////////////////FALTA
    Public Function unidadesmedida()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('unidadesmedida','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_UNIDADES_MEDIDA VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "','" + oRecordSet.Fields.Item(3).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Unid_Medida_Click(sender As Object, e As EventArgs) Handles Unid_Medida.Click
        If oCompany.Connected = True Then
            unidadesmedida()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                unidadesmedida()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'PlanMedida       /////////////////////////////////////////FALTA
    Public Function PlanMedida()
        Dim sql As String
        Try
            sql = ("call PWST_SAP('planmedida','','')")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_UOFM VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "','" + oRecordSet.Fields.Item(2).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Plan_Medida_Click(sender As Object, e As EventArgs) Handles Plan_Medida.Click
        If oCompany.Connected = True Then
            PlanMedida()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                PlanMedida()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_CLIENTES_ESPECIALES       /////////////////////////////////////////FALTA
    Public Function clienteespecial()
        Dim sql As String
        Try
            sql = ("SELECT ListNum,ListName  FROM OPLN")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_UOFM VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function
    Private Sub Cliente_Especial_Click(sender As Object, e As EventArgs)
        If oCompany.Connected = True Then
            clienteespecial()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                clienteespecial()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub
    'INT_TERRITORIOS       /////////////////////////////////////////FALTA
    Public Function territorio()
        Dim sql As String
        Try
            sql = ("SELECT ListNum,ListName  FROM OPLN")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_LISTAPRECIO VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub Territorios_Click_1(sender As Object, e As EventArgs)

    End Sub

    'DESCUENTOS       /////////////////////////////////////////FALTA
    Public Function Descuento()
        Dim sql As String
        Try
            sql = ("SELECT ListNum,ListName  FROM OPLN")
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim con As SqlConnection = New SqlConnection(connectionString)
                con.Open()
                Dim SQL_daUp As SqlCommand = New SqlCommand("INSERT INTO INT_LISTAPRECIO VALUES('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "')", con)
                SQL_daUp.ExecuteNonQuery()
                con.Close()
                oRecordSet.MoveNext()
            End While
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
            oRecordSet = Nothing
            GC.Collect()
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Function

    Private Sub Carga_Docs_Click(sender As Object, e As EventArgs) Handles Carga_Docs.Click
        If oCompany.Connected = True Then
            Descuento()
        Else
            System.Runtime.InteropServices.Marshal.ReleaseComObject(oCompany)
            oCompany = Nothing
            GC.Collect()
            If MakeConnectionSAP() Then
                Descuento()
            Else
                MessageBox.Show("Error de Conexion")
            End If
        End If
    End Sub

    '////////////////////////////////////////////////////////////// LIMPIAR TABLAS /////////////////////////////////////////////////////
    Public Sub Delete(tabla As String)
        Dim sql As String
        Try
            Dim cons As SqlConnection = New SqlConnection(connectionString)
            cons.Open()
            Dim SQL_daUp As SqlCommand = New SqlCommand("DELETE FROM " + tabla + "", cons)
            SQL_daUp.ExecuteNonQuery()
            cons.Close()
            MessageBox.Show("Tabla Limpia : " + tabla + "")
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
    Private Sub Button28_Click(sender As Object, e As EventArgs) Handles Button28.Click
        tabla = "INT_CANAL"
        Delete(tabla)
    End Sub

    Private Sub Button27_Click(sender As Object, e As EventArgs) Handles Button27.Click
        tabla = "INT_VENDEDORES"
        Delete(tabla)
    End Sub

    Private Sub Button26_Click(sender As Object, e As EventArgs) Handles Button26.Click
        tabla = "INT_BANCOS"
        Delete(tabla)
    End Sub

    Private Sub Button24_Click(sender As Object, e As EventArgs) Handles Button24.Click
        tabla = "INT_CUENTASXBANCO"
        Delete(tabla)
    End Sub

    Private Sub Button23_Click(sender As Object, e As EventArgs) Handles Button23.Click
        tabla = "INT_CLIENTES_PWST"
        Delete(tabla)
    End Sub

    Private Sub Button22_Click(sender As Object, e As EventArgs) Handles Button22.Click
        tabla = "INT_BODEGASXVENDEDOR"
        Delete(tabla)
    End Sub

    Private Sub Button21_Click(sender As Object, e As EventArgs) Handles Button21.Click
        tabla = "INT_TIPOPRODUCTO"
        Delete(tabla)
    End Sub

    Private Sub Button20_Click(sender As Object, e As EventArgs) Handles Button20.Click
        tabla = "INT_CABECERABONIFICACIONES"
        Delete(tabla)
    End Sub

    Private Sub Button19_Click(sender As Object, e As EventArgs) Handles Button19.Click
        tabla = "INT_FAMILIA"
        Delete(tabla)
    End Sub

    Private Sub Button18_Click(sender As Object, e As EventArgs) Handles Button18.Click
        tabla = "INT_MARCAS"
        Delete(tabla)
    End Sub

    Private Sub Button17_Click(sender As Object, e As EventArgs) Handles Button17.Click
        tabla = "INT_LISTAXCLIENTE"
        Delete(tabla)
    End Sub

    Private Sub Button16_Click(sender As Object, e As EventArgs) Handles Button16.Click
        tabla = "INT_CABECERAFACTURASGP"
        Delete(tabla)
        tabla = "INT_DETALLEFACTURASGP"
        Delete(tabla)
    End Sub

    Private Sub Button15_Click(sender As Object, e As EventArgs) Handles Button15.Click
        tabla = "INT_LISTAPRECIO"
        Delete(tabla)
    End Sub

    Private Sub Button14_Click(sender As Object, e As EventArgs) Handles Button14.Click
        tabla = "INT_INVENTARIOXBODEGAS"
        Delete(tabla)
    End Sub

    'Private Sub selectedRowsButton_Click(
    '    ByVal sender As Object, ByVal e As System.EventArgs) _
    '    Handles DGV.Click

    '    Dim selectedRowCount As Integer =
    '        DGV.Rows.GetRowCount(DataGridViewElementStates.Selected)

    '    If selectedRowCount > 0 Then

    '        Dim sb As New System.Text.StringBuilder()
    '        Dim myArrList As New ArrayList()
    '        Dim i As Integer
    '        For i = 0 To selectedRowCount - 1
    '            'TextBox2.Text = DGV.CurrentRow.Cells.Item(0).Value.ToString + DGV.CurrentRow.Cells.Item(0).Value.ToString
    '            'TextBox2.Text += DGV.CurrentRow.Cells.Item(0).Value.ToString + ","
    '        Next i

    '    End If

    'End Sub


    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click
        Dim query1 As String
        query1 = ""
        Dim query2 As String
        query2 = ""
        Dim i As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        Dim existe As Boolean = DGV.Columns.Cast(Of DataGridViewColumn).Any(Function(x) x.Name = "CHK")
        If existe = False Then
            DGV.Columns.Add(i)
            i.HeaderText = "CHK"
            i.Name = "CHK"
            i.Width = 32
            i.DisplayIndex = 0
        End If
        ListBox1.Items.Clear()
        For Each row As DataGridViewRow In DGV.Rows
            Dim chk As DataGridViewCheckBoxCell = row.Cells("CHK")
            If chk.Value IsNot Nothing AndAlso chk.Value = True Then
                query1 += "'" + DGV.Rows(chk.RowIndex).Cells.Item(4).Value.ToString + "'" + ","
                query2 += "'" + DGV.Rows(chk.RowIndex).Cells.Item(3).Value.ToString + "'" + ","
                ListBox1.Items.Add(DGV.Rows(chk.RowIndex).Cells.Item(3).Value.ToString + "-" + DGV.Rows(chk.RowIndex).Cells.Item(4).Value.ToString)
            End If
        Next
        valrecibo = Mid(query1, 1, Len(query1) - 1)
        valseries = Mid(query2, 1, Len(query2) - 1)
        Dim result As Integer = MessageBox.Show("Desea Realizar los pagos?", "Atencion", MessageBoxButtons.YesNoCancel)
        If result = DialogResult.Cancel Then
            MessageBox.Show("Cancelado")
        ElseIf result = DialogResult.No Then
            MessageBox.Show("No se pagaran")
        ElseIf result = DialogResult.Yes Then
            Recibos(valrecibo, valseries)
        End If
    End Sub

    Public Function CargaGridRecibo()
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("SELECT ID AS 'ID_PWST',EMPRESA,SERIE,NUMERORECIBO as 'NUMRECIBO',FECHA as 'DocDate',CLIENTE as 'CardCode',MONTO as 'CashSum',moneda as 'Moneda',VENDEDOR,TIPODOC,BANCO,CUENTA FROM INT_CABECERACOBRANZAPWST T0 where T0.FECHA = '" + DateTime.Today.AddDays(-1).ToShortDateString + "' and STATUS = '1'", con)
        Dim DT_dat As DataTable = New DataTable()
        SQL_da.Fill(DT_dat)
        Dim i As DataGridViewCheckBoxColumn = New DataGridViewCheckBoxColumn()
        Dim existe As Boolean = DGV.Columns.Cast(Of DataGridViewColumn).Any(Function(x) x.Name = "CHK")
        If existe = False Then
            DGV.Columns.Add(i)
            i.HeaderText = "CHK"
            i.Name = "CHK"
            i.Width = 32
            i.DisplayIndex = 0
        End If
        DGV.DataSource = DT_dat
        con.Close()
    End Function

    Private Sub Button13_Click(sender As Object, e As EventArgs) Handles Button13.Click
        tabla = "INT_PRODUCTOS"
        Delete(tabla)
    End Sub

    Private Sub Button12_Click(sender As Object, e As EventArgs) Handles Button12.Click
        tabla = "INT_LISTAPRECIO"
        Delete(tabla)
    End Sub

    Private Sub Button10_Click(sender As Object, e As EventArgs) Handles Button10.Click
        tabla = "INT_PRECIOSPRODUCTOS"
        Delete(tabla)
    End Sub

    Private Sub Button9_Click(sender As Object, e As EventArgs) Handles Button9.Click
        tabla = "INT_UNIDADES_MEDIDA"
        Delete(tabla)
    End Sub

    Private Sub Button8_Click(sender As Object, e As EventArgs) Handles Button8.Click
        tabla = "INT_UOFM"
        Delete(tabla)
    End Sub

    Private Sub Button3_Click(sender As Object, e As EventArgs) Handles Button3.Click
        Dim msg As MsgBoxResult
        msg = MsgBox("Desea Cerrar la Integracion, ¿Desea salir?", vbYesNo, "Salir de la Integracion")
        If msg = MsgBoxResult.Yes Then
            System.Windows.Forms.Application.Exit()
        Else
            Exit Sub
        End If
    End Sub
End Class

