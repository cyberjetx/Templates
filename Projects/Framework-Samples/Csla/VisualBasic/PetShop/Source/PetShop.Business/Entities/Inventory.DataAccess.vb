'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
'     Changes to Me file will be lost after each regeneration.
'     To extend the functionality of Me class, please modify the partial class 'Inventory.vb.
'
'     Template: EditableRoot.DataAccess.ParameterizedSQL.cst
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

Public Partial Class Inventory
    <RunLocal()> _
    Protected Shadows Sub DataPortal_Create()
        ValidationRules.CheckRules()
    End Sub

    Private Shadows Sub DataPortal_Fetch(ByVal criteria As InventoryCriteria)
        Dim cancel As Boolean = False
        OnFetching(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Dim commandText As String = String.Format("SELECT [ItemId], [Qty] FROM [dbo].[Inventory] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then
                        Map(reader)
                    Else
                        Throw New Exception(String.Format("The record was not found in 'Inventory' using the following criteria: {0}.", criteria))
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

        Const commandText As String = "INSERT INTO [dbo].[Inventory] ([ItemId], [Qty]) VALUES (@p_ItemId, @p_Qty)"
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddWithValue("@p_ItemId", ItemId)
				command.Parameters.AddWithValue("@p_Qty", Qty)

                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    If reader.Read() Then

                    End If
                End Using
            End Using
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

        Const commandText As String = "UPDATE [dbo].[Inventory]  SET [ItemId] = @p_ItemId, [Qty] = @p_Qty WHERE [ItemId] = @p_ItemId"
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
                command.Parameters.AddWithValue("@p_ItemId", ItemId)
				command.Parameters.AddWithValue("@p_Qty", Qty)

                Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                    'RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    If reader.RecordsAffected = 0 Then
                        Throw New DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.")
                    End If
                End Using
            End Using
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
    
        DataPortal_Delete(New InventoryCriteria(ItemId))
    
		OnSelfDeleted()
    End Sub

    <Transactional(TransactionalTypes.TransactionScope)> _
    Protected Shadows Sub DataPortal_Delete(ByVal criteria As InventoryCriteria)
        Dim cancel As Boolean = False
        OnDeleting(criteria, cancel)
        If (cancel) Then
            Return
        End If

        Dim commandText As String = String.Format("DELETE FROM [dbo].[Inventory] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag))
        Using connection As New SqlConnection(ADOHelper.ConnectionString)
            connection.Open()
            Using command As New SqlCommand(commandText, connection)
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
            LoadProperty(_itemIdProperty, reader.GetString("ItemId"))
            LoadProperty(_qtyProperty, reader.GetInt32("Qty"))
        End Using

        MarkOld()
    End Sub
    
    #Region "Data access partial methods"

    Partial Private Sub OnCreating(ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnCreated()
    End Sub
    Partial Private Sub OnFetching(ByVal criteria As InventoryCriteria, ByRef cancel As Boolean)
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
    Partial Private Sub OnDeleting(ByVal criteria As InventoryCriteria, ByRef cancel As Boolean)
    End Sub
    Partial Private Sub OnDeleted()
    End Sub

    #End Region
End Class