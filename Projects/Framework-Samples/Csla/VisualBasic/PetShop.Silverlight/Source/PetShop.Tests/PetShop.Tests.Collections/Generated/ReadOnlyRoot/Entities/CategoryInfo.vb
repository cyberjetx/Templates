﻿'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.2, CSLA Templates: v2.0.1.1766, CSLA Framework: v3.8.2.
'       Changes to this template will not be lost.
'
'     Template: ReadOnlyRoot.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Security
Imports Csla.Validation

Namespace PetShop.Tests.Collections.ReadOnlyRoot
    Public Partial Class CategoryInfo
        #Region "Authorization Rules"
    
    
        Protected Overrides Sub AddAuthorizationRules()
            ''More information on these rules can be found here (http://www.devx.com/codemag/Article/40663/1763/page/2).
    
            'Dim canWrite As String() = { "AdminUser", "RegularUser" }
            'Dim canRead As String() = { "AdminUser", "RegularUser", "ReadOnlyUser" }
            'Dim admin As String() = { "AdminUser" }
    
            'AuthorizationRules.AllowCreate(GetType(CategoryInfo), admin)
            'AuthorizationRules.AllowDelete(GetType(CategoryInfo), admin)
            'AuthorizationRules.AllowEdit(GetType(CategoryInfo), canWrite)
            'AuthorizationRules.AllowGet(GetType(CategoryInfo), canRead)
    
            ''CategoryId
            'AuthorizationRules.AllowWrite(_categoryIdProperty, canWrite)
            'AuthorizationRules.AllowRead(_categoryIdProperty, canRead)
    
            ''Name
            'AuthorizationRules.AllowWrite(_nameProperty, canWrite)
            'AuthorizationRules.AllowRead(_nameProperty, canRead)
    
            ''Description
            'AuthorizationRules.AllowWrite(_descriptionProperty, canWrite)
            'AuthorizationRules.AllowRead(_descriptionProperty, canRead)
    
    ' NOTE: Many-To-Many support coming soon.
        End Sub
    
        #End Region
    End Class
End Namespace