﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v2.0.1.1766, CSLA Framework: v3.8.2.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'OrderStatusList.vb.
'
'     Template: EditableRootList.DataAccess.StoredProcedures.cst
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

Namespace PetShop.Tests.StoredProcedures
    Public Partial Class OrderStatusList
    
        <RunLocal()> _
        Protected Overrides Sub DataPortal_Create()
        End Sub
    
        Private Shadows Sub DataPortal_Fetch(ByVal criteria As OrderStatusCriteria)
            Dim cancel As Boolean = False
            OnFetching(criteria, cancel)
            If (cancel) Then
                Return
            End If
    
            RaiseListChangedEvents = False
    
            ' Fetch Child objects.
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Using command As New SqlCommand("[dbo].[CSLA_OrderStatus_Select]", connection)
                    command.CommandType = CommandType.StoredProcedure
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag))
                    
                    Using reader As SafeDataReader = New SafeDataReader(command.ExecuteReader())
                        If reader.Read() Then
                            Do
                                Me.Add(New OrderStatus(reader))
                            Loop While reader.Read()
                        End If
                    End Using
                End Using
            End Using
    
            RaiseListChangedEvents = True
    
            OnFetched()
        End Sub
    
        Protected Overrides Sub DataPortal_Update()
            Dim cancel As Boolean = False
            OnUpdating(cancel)
            If (cancel) Then
                Return
            End If
    
            RaiseListChangedEvents = False
    
            ' Create a new connection.
            Using connection As New SqlConnection(ADOHelper.ConnectionString)
                connection.Open()
                Child_Update(connection)
            End Using
    
            RaiseListChangedEvents = True
    
            OnUpdated()
        End Sub
    End Class
End Namespace
