'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Order.vb.
'
'     Template: SwitchableObject.DataAccess.StoredProcedures.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System
Imports System.Data
Imports System.Data.SqlClient

Imports Csla
Imports Csla.Data

Public Partial Class Order

    #Region "Root Data Access"

    <RunLocal()> _
    Protected Overrides Sub DataPortal_Create()
        ValidationRules.CheckRules()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Private Shadows Sub DataPortal_Fetch(ByVal criteria As OrderCriteria)
        Dim cancel As Boolean = False
        OnFetching(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Order_Select]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Map(reader)
                    Else
                        Throw New Exception(String.Format("The record was not found in 'Orders' using the following criteria: {0}.", criteria))
                    End If
                End Using
            End Using
        End Using

        OnFetched()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Overrides Sub DataPortal_Insert()
        Dim cancel As Boolean = False
        OnInserting(cancel)
        If (cancel) Then
            Return
        End If

        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Order_Insert]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OrderId", OrderId)
					command.Parameters("@p_OrderId").Direction = ParameterDirection.Output
				command.Parameters.AddWithValue("@p_UserId", UserId)
				command.Parameters.AddWithValue("@p_OrderDate", OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ShipAddr2)
				command.Parameters.AddWithValue("@p_ShipCity", ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", BillAddr2)
				command.Parameters.AddWithValue("@p_BillCity", BillCity)
				command.Parameters.AddWithValue("@p_BillState", BillState)
				command.Parameters.AddWithValue("@p_BillZip", BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Locale)

                command.ExecuteNonQuery()
                Using (BypassPropertyChecks)
                    LoadProperty(_orderIdProperty, command.Parameters("@p_OrderId").Value)
                End Using
            End Using

			FieldManager.UpdateChildren(Me, connection)
        End Using

        OnInserted()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Overrides Sub DataPortal_Update()
        Dim cancel As Boolean = False
        OnUpdating(cancel)
        If (cancel) Then
            Return
        End If

        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Order_Update]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_OrderId", OrderId)
				command.Parameters.AddWithValue("@p_UserId", UserId)
				command.Parameters.AddWithValue("@p_OrderDate", OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ShipAddr2)
				command.Parameters.AddWithValue("@p_ShipCity", ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", BillAddr2)
				command.Parameters.AddWithValue("@p_BillCity", BillCity)
				command.Parameters.AddWithValue("@p_BillState", BillState)
				command.Parameters.AddWithValue("@p_BillZip", BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Locale)

                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
            End Using

			FieldManager.UpdateChildren(Me, connection)
        End Using

        OnUpdated()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Overrides Sub DataPortal_DeleteSelf()
        Dim cancel As Boolean = False
        OnSelfDeleting(cancel)
        If (cancel) Then
            Return
        End If
    
        DataPortal_Delete(New OrderCriteria(OrderId))
    
		OnSelfDeleted()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Shadows Sub DataPortal_Delete(ByVal criteria As OrderCriteria)
        Dim cancel As Boolean = False
        OnDeleting(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Order_Delete]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                
                'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                Dim result As Integer = command.ExecuteNonQuery()
                If (result = 0) Then
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                End If
            End Using
        End Using

        OnDeleted()
    End Sub

    #End Region

    #Region "Child Data Access"

    <RunLocal()> _
    Protected Overrides Sub Child_Create()
        Dim cancel As Boolean = False
        OnChildCreating(cancel)
        If (cancel) Then
            Return
        End If

        ValidationRules.CheckRules()

        OnChildCreated()
    End Sub
    
    Private Sub Child_Fetch(ByVal criteria As OrderCriteria)
        Dim cancel As Boolean = False
        OnChildFetching(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Order_Select]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Map(reader)
                    Else
                        Throw New Exception(String.Format("The record was not found in 'Orders' using the following criteria: {0}.", criteria))
                    End If
                End Using
            End Using
        End Using

        OnChildFetched()
        MarkAsChild()
    End Sub

    Private Sub Child_Insert(ByVal connection As SqlConnection)
        Dim cancel As Boolean = False
        OnChildInserting(cancel)
        If (cancel) Then
            Return
        End If

        If connection.State <> ConnectionState.Open Then connection.Open()
        Using command As New SqlCommand("[dbo].[CSLA_Order_Insert]", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@p_OrderId", OrderId)
					command.Parameters("@p_OrderId").Direction = ParameterDirection.Output
				command.Parameters.AddWithValue("@p_UserId", UserId)
				command.Parameters.AddWithValue("@p_OrderDate", OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ShipAddr2)
				command.Parameters.AddWithValue("@p_ShipCity", ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", BillAddr2)
				command.Parameters.AddWithValue("@p_BillCity", BillCity)
				command.Parameters.AddWithValue("@p_BillState", BillState)
				command.Parameters.AddWithValue("@p_BillZip", BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Locale)

            command.ExecuteNonQuery()
            LoadProperty(_orderIdProperty, command.Parameters("@p_OrderId").Value)
        End Using

        OnChildInserted()
    End Sub

    Private Sub Child_Update(ByVal connection As SqlConnection)
        Dim cancel As Boolean = False
        OnChildUpdating(cancel)
        If (cancel) Then
            Return
        End If

        If connection.State <> ConnectionState.Open Then connection.Open()
        Using command As New SqlCommand("[dbo].[CSLA_Order_Update]", connection)
            command.CommandType = CommandType.StoredProcedure
            command.Parameters.AddWithValue("@p_OrderId", OrderId)
				command.Parameters.AddWithValue("@p_UserId", UserId)
				command.Parameters.AddWithValue("@p_OrderDate", OrderDate)
				command.Parameters.AddWithValue("@p_ShipAddr1", ShipAddr1)
				command.Parameters.AddWithValue("@p_ShipAddr2", ShipAddr2)
				command.Parameters.AddWithValue("@p_ShipCity", ShipCity)
				command.Parameters.AddWithValue("@p_ShipState", ShipState)
				command.Parameters.AddWithValue("@p_ShipZip", ShipZip)
				command.Parameters.AddWithValue("@p_ShipCountry", ShipCountry)
				command.Parameters.AddWithValue("@p_BillAddr1", BillAddr1)
				command.Parameters.AddWithValue("@p_BillAddr2", BillAddr2)
				command.Parameters.AddWithValue("@p_BillCity", BillCity)
				command.Parameters.AddWithValue("@p_BillState", BillState)
				command.Parameters.AddWithValue("@p_BillZip", BillZip)
				command.Parameters.AddWithValue("@p_BillCountry", BillCountry)
				command.Parameters.AddWithValue("@p_Courier", Courier)
				command.Parameters.AddWithValue("@p_TotalPrice", TotalPrice)
				command.Parameters.AddWithValue("@p_BillToFirstName", BillToFirstName)
				command.Parameters.AddWithValue("@p_BillToLastName", BillToLastName)
				command.Parameters.AddWithValue("@p_ShipToFirstName", ShipToFirstName)
				command.Parameters.AddWithValue("@p_ShipToLastName", ShipToLastName)
				command.Parameters.AddWithValue("@p_AuthorizationNumber", AuthorizationNumber)
				command.Parameters.AddWithValue("@p_Locale", Locale)

            'result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
            Dim result As Integer = command.ExecuteNonQuery()
            If (result = 0) Then
                throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
            End If
        End Using

        OnChildUpdated()
    End Sub

    Private Sub Child_DeleteSelf()
		Dim cancel As Boolean = False
        OnChildSelfDeleting(cancel)
        If (cancel) Then
            Return
        End If
    
        DataPortal_Delete(New OrderCriteria(OrderId))
    
		OnChildSelfDeleted()
    End Sub

    #End Region

    Private Sub Map(ByVal reader As SafeDataReader)
        Using(BypassPropertyChecks)
            LoadProperty(_orderIdProperty, reader.GetInt32("OrderId"))
            LoadProperty(_userIdProperty, reader.GetString("UserId"))
            LoadProperty(_orderDateProperty, reader.GetDateTime("OrderDate"))
            LoadProperty(_shipAddr1Property, reader.GetString("ShipAddr1"))
            LoadProperty(_shipAddr2Property, reader.GetString("ShipAddr2"))
            LoadProperty(_shipCityProperty, reader.GetString("ShipCity"))
            LoadProperty(_shipStateProperty, reader.GetString("ShipState"))
            LoadProperty(_shipZipProperty, reader.GetString("ShipZip"))
            LoadProperty(_shipCountryProperty, reader.GetString("ShipCountry"))
            LoadProperty(_billAddr1Property, reader.GetString("BillAddr1"))
            LoadProperty(_billAddr2Property, reader.GetString("BillAddr2"))
            LoadProperty(_billCityProperty, reader.GetString("BillCity"))
            LoadProperty(_billStateProperty, reader.GetString("BillState"))
            LoadProperty(_billZipProperty, reader.GetString("BillZip"))
            LoadProperty(_billCountryProperty, reader.GetString("BillCountry"))
            LoadProperty(_courierProperty, reader.GetString("Courier"))
            LoadProperty(_totalPriceProperty, reader.GetDecimal("TotalPrice"))
            LoadProperty(_billToFirstNameProperty, reader.GetString("BillToFirstName"))
            LoadProperty(_billToLastNameProperty, reader.GetString("BillToLastName"))
            LoadProperty(_shipToFirstNameProperty, reader.GetString("ShipToFirstName"))
            LoadProperty(_shipToLastNameProperty, reader.GetString("ShipToLastName"))
            LoadProperty(_authorizationNumberProperty, reader.GetInt32("AuthorizationNumber"))
            LoadProperty(_localeProperty, reader.GetString("Locale"))
        End Using

        MarkOld()
    End Sub
    
    #Region "Data access partial methods"

    Partial Private Sub OnCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnFetching(ByVal criteria As OrderCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnFetched()
    End Sub
    Partial Private Sub OnInserting(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnInserted()
    End Sub
    Partial Private Sub OnUpdating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnUpdated()
    End Sub
    Partial Private Sub OnSelfDeleting(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnSelfDeleted()
    End Sub
    Partial Private Sub OnDeleting(ByVal criteria As OrderCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnDeleted()
    End Sub

    #End Region

    #Region "Child data access partial methods"

    Partial Private Sub OnChildCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildCreated()
    End Sub
    Partial Private Sub OnChildFetching(ByVal criteria As OrderCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildFetched()
    End Sub
    Partial Private Sub OnChildInserting(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildInserted()
    End Sub
    Partial Private Sub OnChildUpdating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildUpdated()
    End Sub
    Partial Private Sub OnChildSelfDeleting(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnChildSelfDeleted()
    End Sub

    #End Region

End Class