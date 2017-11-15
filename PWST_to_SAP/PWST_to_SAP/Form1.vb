
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Imports System.Globalization

Public Class Form1
    Public Shared SQL_Conexion As SqlConnection = New SqlConnection()
    Dim connectionString As String = "Data Source=127.0.0.1;" + "Initial Catalog=istmaniaPWST;" + "User id=sa;" + "Password=12345;"
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
        Try
            Connected = -1

            oCompany = New SAPbobsCOM.Company
            oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_MSSQL2012
            oCompany.DbUserName = "sa"
            oCompany.DbPassword = "12345"
            oCompany.Server = "DESKTOP-G67F328"
            oCompany.CompanyDB = "FYA"
            oCompany.UserName = "manager"
            oCompany.Password = "alegria"
            oCompany.LicenseServer = "DESKTOP-G67F328:30000"
            oCompany.UseTrusted = False
            Connected = oCompany.Connect()

            'oCompany = New SAPbobsCOM.Company
            'oCompany.DbUserName = "USERSAP"
            'oCompany.DbPassword = "$Sap2017"
            'oCompany.Server = "192.168.1.51:30015"
            'oCompany.CompanyDB = "DEMONUEVA"
            'oCompany.UserName = "manager"
            'oCompany.Password = "12345"
            'oCompany.LicenseServer = "192.168.1.51:40000"
            'oCompany.DbServerType = SAPbobsCOM.BoDataServerTypes.dst_HANADB
            'oCompany.UseTrusted = False
            'Connected = oCompany.Connect()

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
#Region "Pedidos Recibidos"
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim docistm As String
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("SELECT T0.ID_PWST AS ID_PWST,T0.EMPRESA AS EMPRESA,T0.SERIE AS SERIE,T0.NUMEROPEDIDO AS NUMPEDIDO,T0.FECHAPEDIDO AS 'DocDate',T0.FECHAENTREGA AS 'DocDueDate',T0.MONTO AS 'DocTotal',T0.OBSERVACIONES AS 'Comments',T0.TIPODOC AS TIPODOC,T0.CLIENTE AS 'CardCode',T0.VENDEDOR AS 'SlpCode',T0.STATUS AS DOCSTATUS,T0.BODEGA AS BODEGA FROM INT_CABECERAPEDIDOSPWST T0 where T0.FECHAPEDIDO = '" + MonthCalendar1.SelectionStart.ToShortDateString + "'", con)
        Dim DT_dat As DataTable = New DataTable()
        SQL_da.Fill(DT_dat)
        con.Close()
        For Each row As DataRow In DT_dat.Rows

            Dim oReturn As Integer = -1
            Dim oError As Integer = 0
            Dim errMsg As String = ""
            Dim sql As String
            If MakeConnectionSAP() Then
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


            End If
        Next
    End Sub
#End Region
#Region "Pagos Recibidos"
    Private Sub Button_Cobros_Click(sender As Object, e As EventArgs) Handles Button_Cobros.Click
        Dim con As SqlConnection = New SqlConnection(connectionString)
        con.Open()
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("SELECT ID AS 'ID_PWST',EMPRESA,SERIE,NUMERORECIBO as 'NUMRECIBO',FECHA as 'DocDate',CLIENTE as 'CardCode',MONTO as 'CashSum',moneda as 'Moneda',VENDEDOR,TIPODOC,BANCO,CUENTA FROM INT_CABECERACOBRANZAPWST T0 where T0.FECHA = '" + MonthCalendar1.SelectionStart.ToShortDateString + "'", con)
        Dim DT_dat As DataTable = New DataTable()
        SQL_da.Fill(DT_dat)
        con.Close()
        For Each row As DataRow In DT_dat.Rows

            Dim oReturn As Integer = -1
            Dim oError As Integer = 0
            Dim errMsg As String = ""
            Dim sql As String
            If MakeConnectionSAP() Then
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

                'sql = ("select top 1 " & Chr(34) & "DocEntry" & Chr(34) & " from oinv where " & Chr(34) & "DocNum" & Chr(34) & " = " + xnDetLines.SelectSingleNode("docnum").InnerText)
                'Dim oRecordSet As SAPbobsCOM.Recordset
                '    oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
                '    oRecordSet.DoQuery(sql)
                '    If oRecordSet.RecordCount > 0 Then
                '        oPayment.Invoices.DocEntry = oRecordSet.Fields.Item(0).Value
                '    End If
                'oPayment.Invoices.InvoiceType = "13"
                'oPayment.Invoices.SumApplied = ""
                'oPayment.Invoices.Add()
                'System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
                'oRecordSet = Nothing
                '    GC.Collect()

                oReturn = oPayment.Add()
                If oReturn <> 0 Then
                    oCompany.GetLastError(oError, errMsg)
                    MsgBox(errMsg)
                Else
                    Dim cons As SqlConnection = New SqlConnection(connectionString)
                    cons.Open()
                    Dim SQL_daUp As SqlCommand = New SqlCommand("UPDATE INT_CABECERACOBRANZAPWST SET SAP = 1 WHERE NUMERORECIBO = '" + row("NUMRECIBO").ToString() + "'", cons)
                    SQL_daUp.ExecuteNonQuery()
                    cons.Close()
                End If


            End If
        Next
    End Sub
#End Region
    Private Sub MonthCalendar1_DateChanged(sender As Object, e As DateRangeEventArgs) Handles MonthCalendar1.DateChanged
        TextBox1.Text = MonthCalendar1.SelectionStart.ToShortDateString()
    End Sub

    Private Sub Vendedores_Click(sender As Object, e As EventArgs) Handles Vendedores.Click
        Dim sql As String
        Dim splcode As String
        Dim splname As String
        sql = ("select SlpCode, SlpName from OSLP")
        MakeConnectionSAP()
        Dim oRecordSet As SAPbobsCOM.Recordset
        oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
        oRecordSet.DoQuery(Sql)
        While oRecordSet.EoF = False
            Dim con As SqlConnection = New SqlConnection(connectionString)
            con.Open()
            Dim SQL_daUp As SqlCommand = New SqlCommand("insert into INT_CANAL values ('" + oRecordSet.Fields.Item(0).Value.ToString + "','" + oRecordSet.Fields.Item(1).Value.ToString + "',' ')", con)
            SQL_daUp.ExecuteNonQuery()
            con.Close()
            oRecordSet.MoveNext()
        End While
        System.Runtime.InteropServices.Marshal.ReleaseComObject(oRecordSet)
        oRecordSet = Nothing
        GC.Collect()
    End Sub

    Private Sub Clientes_Click(sender As Object, e As EventArgs) Handles Clientes.Click
        Dim sql As String
        Dim splcode As String
        Dim splname As String
        Try

            sql = ("select O.CardCode,O.CardName,o.VatIdUnCmp,isnull( (select top 1 T1.Address from crd1 T1 where T1.AdresType = 'B' and t1.CardCode = o.CardCode),' ') as 'Fiscal', isnull( (select top 1 T1.Address from crd1 T1 where T1.AdresType = 'S' and t1.CardCode = o.CardCode),' ') as 'Entrega',o.Phone1,o.Phone2,' ' as 'Registro', O.CardName,' ' as 'CatFiscal',O.U_CANAL,o.Country,o.State1,o.County,' ' as 'Territorio',' ' as 'Empresa',' ' as 'estatus',o.IndustryC,o.Discount,' ' as 'exencion',' ' as 'limitecredito',' ' as 'status' from ocrd O inner join CRD1 C on O.CardCode = C.CardCode group by o.CardCode, o.VatIdUnCmp,o.cardname, o.Phone1,o.Phone2,O.CardName,o.Country,o.State1,o.County,o.IndustryC,o.Discount,O.U_CANAL")
            MakeConnectionSAP()
            Dim oRecordSet As SAPbobsCOM.Recordset
            oRecordSet = oCompany.GetBusinessObject(SAPbobsCOM.BoObjectTypes.BoRecordset)
            oRecordSet.DoQuery(sql)
            While oRecordSet.EoF = False
                Dim connectionString As String = "Data Source=127.0.0.1;" + "Initial Catalog=istmaniaPWST;" + "User id=sa;" + "Password=12345;"
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
        Catch ex As Exception
            MessageBox.Show(ex.Message)
        End Try
    End Sub
End Class

