//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'CartList.cs'.
//
//     Template: EditableChildList.Generated.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Collections.Generic;
using Csla;

#endregion

namespace PetShop.Tests.ObjF.ParameterizedSQL
{
    [Serializable]
    [Csla.Server.ObjectFactory(FactoryNames.CartListFactoryName)]
    public partial class CartList : BusinessListBase< CartList, Cart >
    {
        #region Factory Methods 
        
        internal static CartList NewList()
        {
            return DataPortal.CreateChild< CartList >();
        }

        internal static CartList GetByCartId(System.Int32 cartId)
        {
            return DataPortal.FetchChild< CartList >(
                new CartCriteria{CartId = cartId});
        }

        internal static CartList GetByUniqueID(System.Int32 uniqueID)
        {
            return DataPortal.FetchChild< CartList >(
                new CartCriteria{UniqueID = uniqueID});
        }

        internal static CartList GetByIsShoppingCart(System.Boolean isShoppingCart)
        {
            return DataPortal.FetchChild< CartList >(
                new CartCriteria{IsShoppingCart = isShoppingCart});
        }

        internal static CartList GetAll()
        {
            return DataPortal.FetchChild< CartList >(new CartCriteria());
        }

        private CartList()
        {
            AllowNew = true;
            MarkAsChild();
        }
        
        #endregion

        #region Properties
        
        protected override object AddNewCore()
        {
            Cart item = PetShop.Tests.ObjF.ParameterizedSQL.Cart.NewCart();
            Add(item);
            return item;
        }
        
        #endregion

        #region Property overrides

        /// <summary>
        /// Returns true if any children are dirty
        /// </summary>
        public new bool IsDirty
        {
            get
            {
                foreach(Cart item in this.Items)
                {
                    if(item.IsDirty) return true;
                }
                
                return false;
            }
        }

        #endregion


        #region Exists Command

        public static bool Exists(CartCriteria criteria)
        {
            return PetShop.Tests.ObjF.ParameterizedSQL.Cart.Exists(criteria);
        }

        #endregion
    }
}