
Imports System.Xml
Imports System.Data.SqlClient
Imports System.Windows.Forms
Imports System.IO
Imports System.Threading
Imports System.Globalization

Public Class Form1
    Public Shared SQL_Conexion As SqlConnection = New SqlConnection()

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
    Private Sub Button1_Click(sender As Object, e As EventArgs) Handles Button1.Click
        Dim docistm As String
        Dim SQL_da As SqlDataAdapter = New SqlDataAdapter("SELECT T0.ID_PWST AS ID_PWST,T0.EMPRESA AS EMPRESA,T0.SERIE AS SERIE,T0.NUMEROPEDIDO AS NUMPEDIDO,T0.FECHAPEDIDO AS 'DocDate',T0.FECHAENTREGA AS 'DocDueDate',T0.MONTO AS 'DocTotal',T0.OBSERVACIONES AS 'Comments',T0.TIPODOC AS TIPODOC,T0.CLIENTE AS 'CardCode',T0.VENDEDOR AS 'SlpCode',T0.STATUS AS DOCSTATUS,T0.BODEGA AS BODEGA FROM INT_CABECERAPEDIDOSPWST T0 where T0.FECHAPEDIDO = '" + MonthCalendar1.SelectionStart.ToShortDateString + "'", Connection.ObtenerConexion())
        Dim DT_dat As DataTable = New DataTable()
        SQL_da.Fill(DT_dat)
        DGV.DataSource = DT_dat
        SQL_Conexion.Close()
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

                Dim SQL_daDET As SqlDataAdapter = New SqlDataAdapter("select T0.ARTICULO,1 as 'UNIDADES',T0.PRECIOVENTA from INT_DETALLEPEDIDOSPWST T0 WHERE T0.NUMEROPEDIDO = '" + row("NUMPEDIDO").ToString() + "'", Connection.ObtenerConexion())
                Dim DT_datDET As DataTable = New DataTable()
                SQL_daDET.Fill(DT_datDET)
                DGVD.DataSource = DT_datDET
                SQL_Conexion.Close()

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
                    Dim SQL_daUp As SqlCommand = New SqlCommand("UPDATE INT_CABECERAPEDIDOSPWST SET SAP = 1 WHERE NUMEROPEDIDO = '" + row("NUMPEDIDO").ToString() + "'", Connection.ObtenerConexion())
                    SQL_daUp.ExecuteNonQuery()
                    SQL_Conexion.Close()
                End If


            End If
        Next
    End Sub

    Private Sub Button2_Click(sender As Object, e As EventArgs) Handles Button2.Click

    End Sub
End Class
