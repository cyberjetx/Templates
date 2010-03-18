//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Category.cs'.
//
//     Template: EditableChild.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;

using Csla;
using Csla.Data;
using Csla.Validation;

#endregion

namespace PetShop.Tests.Collections.EditableChild
{
    [Serializable]
    public partial class Category : BusinessBase< Category >
    {
        #region Contructor(s)

        private Category()
        {
            MarkAsChild();
        }

        internal Category(System.String categoryId)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_categoryIdProperty, categoryId);
            }

            MarkAsChild();
        }
        
        internal Category(SafeDataReader reader)
        {
            Map(reader);

            MarkAsChild();
        }
        #endregion

        #region Validation Rules

        protected override void AddBusinessRules()
        {
            if(AddBusinessValidationRules())
                return;

            ValidationRules.AddRule(CommonRules.StringRequired, _categoryIdProperty);
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_categoryIdProperty, 10));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_nameProperty, 80));
            ValidationRules.AddRule(CommonRules.StringMaxLength, new CommonRules.MaxLengthRuleArgs(_descriptionProperty, 255));
        }

        #endregion

        #region Properties

        private static readonly PropertyInfo< System.String > _categoryIdProperty = RegisterProperty< System.String >(p => p.CategoryId);
		[System.ComponentModel.DataObjectField(true, false)]
        public System.String CategoryId
        {
            get { return GetProperty(_categoryIdProperty); }
            set{ SetProperty(_categoryIdProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _nameProperty = RegisterProperty< System.String >(p => p.Name);
        public System.String Name
        {
            get { return GetProperty(_nameProperty); }
            set{ SetProperty(_nameProperty, value); }
        }

        private static readonly PropertyInfo< System.String > _descriptionProperty = RegisterProperty< System.String >(p => p.Description);
        public System.String Description
        {
            get { return GetProperty(_descriptionProperty); }
            set{ SetProperty(_descriptionProperty, value); }
        }


        ////AssociatedOneToMany
        //private static readonly PropertyInfo< ProductList > _productsProperty = RegisterProperty<ProductList>(p => p.Products, Csla.RelationshipTypes.Child);
        //public ProductList Products
        //{
        //    get
        //    {
        //        if(!FieldManager.FieldExists(_productsProperty))
        //        {
        //            if(IsNew || !PetShop.Tests.Collections.EditableChild.ProductList.Exists(new PetShop.Tests.Collections.EditableChild.ProductCriteria {CategoryId = CategoryId}))
        //                LoadProperty(_productsProperty, PetShop.Tests.Collections.EditableChild.ProductList.NewList());
        //            else
        //                LoadProperty(_productsProperty, PetShop.Tests.Collections.EditableChild.ProductList.GetByCategoryId(CategoryId));
        //        }

        //        return GetProperty(_productsProperty);
        //    }
        //}

        #endregion

        #region Factory Methods 

        internal static Category NewCategory()
        {
            return DataPortal.CreateChild< Category >();
        }

        internal static Category GetByCategoryId(System.String categoryId)
        {
            return DataPortal.FetchChild< Category >(
                new CategoryCriteria {CategoryId = categoryId});
        }

        #endregion

        #region Exists Command

        public static bool Exists(CategoryCriteria criteria)
        {
            return ExistsCommand.Execute(criteria);
        }

        #endregion


    }
}