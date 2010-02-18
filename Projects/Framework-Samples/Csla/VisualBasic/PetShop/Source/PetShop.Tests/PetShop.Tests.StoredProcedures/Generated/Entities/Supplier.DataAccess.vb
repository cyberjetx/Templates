'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
'     Changes to Me file will be lost after each regeneration.
'     To extend the functionality of Me class, please modify the partial class 'Supplier.vb.
'
'     Template: EditableRoot.DataAccess.StoredProcedures.cst
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
Imports Csla.Validation

Public Partial Class Supplier
    <RunLocal()> _
    Protected Shadows Sub DataPortal_Create()
        Dim cancel As Boolean = False
        OnCreating(cancel)
        If (cancel) Then
            Return
        End If

        ValidationRules.CheckRules()

        OnCreated()
    End Sub

    Private Shadows Sub DataPortal_Fetch(ByVal criteria As SupplierCriteria )
        Dim cancel As Boolean = False
        OnFetching(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Supplier_Select]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                command.Parameters.AddWithValue("@p_NameHasValue", criteria.NameHasValue)
				command.Parameters.AddWithValue("@p_Addr1HasValue", criteria.Addr1HasValue)
				command.Parameters.AddWithValue("@p_Addr2HasValue", criteria.Addr2HasValue)
				command.Parameters.AddWithValue("@p_CityHasValue", criteria.CityHasValue)
				command.Parameters.AddWithValue("@p_StateHasValue", criteria.StateHasValue)
				command.Parameters.AddWithValue("@p_ZipHasValue", criteria.ZipHasValue)
				command.Parameters.AddWithValue("@p_PhoneHasValue", criteria.PhoneHasValue)
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Map(reader)
                    Else
                        Throw New Exception(String.Format("The record was not found in 'Supplier' using the following criteria: {0}.", criteria))
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
            Using command As New SqlCommand("[dbo].[CSLA_Supplier_Insert]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_SuppId", SuppId)
				command.Parameters.AddWithValue("@p_Name", Name)
				command.Parameters.AddWithValue("@p_Status", Status)
				command.Parameters.AddWithValue("@p_Addr1", Addr1)
				command.Parameters.AddWithValue("@p_Addr2", Addr2)
				command.Parameters.AddWithValue("@p_City", City)
				command.Parameters.AddWithValue("@p_State", State)
				command.Parameters.AddWithValue("@p_Zip", Zip)
				command.Parameters.AddWithValue("@p_Phone", Phone)

                command.ExecuteNonQuery()
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
            Using command As New SqlCommand("[dbo].[CSLA_Supplier_Update]", connection)
                command.CommandType = CommandType.StoredProcedure
                command.Parameters.AddWithValue("@p_SuppId", SuppId)
				command.Parameters.AddWithValue("@p_Name", Name)
				command.Parameters.AddWithValue("@p_Status", Status)
				command.Parameters.AddWithValue("@p_Addr1", Addr1)
				command.Parameters.AddWithValue("@p_Addr2", Addr2)
				command.Parameters.AddWithValue("@p_City", City)
				command.Parameters.AddWithValue("@p_State", State)
				command.Parameters.AddWithValue("@p_Zip", Zip)
				command.Parameters.AddWithValue("@p_Phone", Phone)

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
    
        DataPortal_Delete(New SupplierCriteria (SuppId))
    
		OnSelfDeleted()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Shadows Sub DataPortal_Delete(ByVal criteria As SupplierCriteria )
        Dim cancel As Boolean = False
        OnDeleting(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand("[dbo].[CSLA_Supplier_Delete]", connection)
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

    Private Sub Map(ByVal reader As SafeDataReader)
        Using(BypassPropertyChecks)
            LoadProperty(_suppIdProperty, reader.GetInt32("SuppId"))
            LoadProperty(_nameProperty, reader.GetString("Name"))
            LoadProperty(_statusProperty, reader.GetString("Status"))
            LoadProperty(_addr1Property, reader.GetString("Addr1"))
            LoadProperty(_addr2Property, reader.GetString("Addr2"))
            LoadProperty(_cityProperty, reader.GetString("City"))
            LoadProperty(_stateProperty, reader.GetString("State"))
            LoadProperty(_zipProperty, reader.GetString("Zip"))
            LoadProperty(_phoneProperty, reader.GetString("Phone"))
        End Using

        MarkOld()
    End Sub
    
    #Region "Data access partial methods"

    Partial Private Sub OnCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnFetching(ByVal criteria As SupplierCriteria, ByRef cancel As Boolean)
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
    Partial Private Sub OnDeleting(ByVal criteria As SupplierCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnDeleted()
    End Sub

    #End Region
End Class