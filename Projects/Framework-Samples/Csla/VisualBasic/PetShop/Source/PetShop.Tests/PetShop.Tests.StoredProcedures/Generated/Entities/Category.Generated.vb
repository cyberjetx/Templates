'------------------------------------------------------------------------------
' <autogenerated>
'     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
'     Changes to this file will be lost after each regeneration.
'     To extend the functionality of this class, please modify the partial class 'Category.vb.
'
'     Template path: EditableRoot.Generated.cst
'     Template website: http://code.google.com/p/codesmith/
' </autogenerated>
'------------------------------------------------------------------------------
Option Explicit On
Option Strict On

Imports System

Imports Csla
Imports Csla.Data
Imports Csla.Validation

<Serializable()> _
Public Partial Class Category 
    Inherits BusinessBase(Of Category)

    #Region "Contructor(s)"

    Private Sub New()
        ' require use of factory method 
    End Sub

    Private Sub New(ByVal categoryId As System.String)
        Using(BypassPropertyChecks)
           LoadProperty(_categoryIdProperty, categoryId)
        End Using
    End Sub

    Friend Sub New(Byval reader As SafeDataReader)
        Map(reader)
    End Sub

    #End Region
    #Region "Validation Rules"

    Protected Overrides Sub AddBusinessRules()

        If AddBusinessValidationRules() Then Exit Sub

        ValidationRules.AddRule(AddressOf CommonRules.StringRequired, _categoryIdProperty)
        ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_categoryIdProperty, 10))
        ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_nameProperty, 80))
        ValidationRules.AddRule(AddressOf CommonRules.StringMaxLength, New CommonRules.MaxLengthRuleArgs(_descnProperty, 255))
    End Sub

    #End Region

    #Region "Properties"

    
    Private Shared ReadOnly _categoryIdProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.CategoryId)
		<System.ComponentModel.DataObjectField(true, false)> _
    Public Property CategoryId() As System.String
        Get 
            Return GetProperty(_categoryIdProperty)
        End Get
        Set (ByVal value As System.String)
            SetProperty(_categoryIdProperty, value)
        End Set
    End Property
    
    
    Private Shared ReadOnly _nameProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.Name)
    Public Property Name() As System.String
        Get 
            Return GetProperty(_nameProperty)
        End Get
        Set (ByVal value As System.String)
            SetProperty(_nameProperty, value)
        End Set
    End Property
    
    
    Private Shared ReadOnly _descnProperty As PropertyInfo(Of System.String) = RegisterProperty(Of System.String)(Function(p As Category) p.Descn)
    Public Property Descn() As System.String
        Get 
            Return GetProperty(_descnProperty)
        End Get
        Set (ByVal value As System.String)
            SetProperty(_descnProperty, value)
        End Set
    End Property
    
    'OneToMany
    Private Shared ReadOnly _productsProperty As PropertyInfo(Of ProductList) = RegisterProperty(Of ProductList)(Function(p As Category) p.Products, Csla.RelationshipTypes.Child)
Public ReadOnly Property Products() As ProductList 
        Get
            If Not (FieldManager.FieldExists(_productsProperty)) Then
                Dim criteria As New PetShop.Tests.StoredProcedures.ProductCriteria()
                criteria.CategoryId = CategoryId
                
                If (Me.IsNew Or Not PetShop.Tests.StoredProcedures.ProductList.Exists(criteria)) Then
                    LoadProperty(_productsProperty, PetShop.Tests.StoredProcedures.ProductList.NewList())
                Else
                    LoadProperty(_productsProperty, PetShop.Tests.StoredProcedures.ProductList.GetByCategoryId(CategoryId))
                End If
            End If
            
            Return GetProperty(_productsProperty) 
        End Get
    End Property
    
    #End Region


    #Region "Factory Methods"

    Public Shared Function NewCategory() As Category 
        Return DataPortal.Create(Of Category)()
    End Function

    Public Shared Function GetByCategoryId(ByVal categoryId As System.String) As Category 
        Dim criteria As New CategoryCriteria()
		criteria.CategoryId = categoryId
		
        Return DataPortal.Fetch(Of Category)(criteria)
    End Function

    Public Shared Sub DeleteCategory(ByVal categoryId As System.String)
        DataPortal.Delete(New CategoryCriteria(categoryId))
    End Sub

    #End Region

    #Region "Exists Command"

    Public Shared Function Exists(ByVal criteria As CategoryCriteria) As Boolean
        Return ExistsCommand.Execute(criteria)
    End Function

    #End Region

End Class
