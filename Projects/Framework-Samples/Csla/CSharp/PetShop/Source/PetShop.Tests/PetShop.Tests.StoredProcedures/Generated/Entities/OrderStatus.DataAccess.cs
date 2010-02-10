//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CodeSmith: v5.2.1, CSLA Templates: v1.5.0.0, CSLA Framework: v3.8.0.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'OrderStatus.cs'.
//
//     Template: EditableChild.DataAccess.StoredProcedures.cst
//     Template website: http://code.google.com/p/codesmith/
// </autogenerated>
//------------------------------------------------------------------------------
#region Using declarations

using System;
using System.Data;
using System.Data.SqlClient;

using Csla;
using Csla.Data;

#endregion

namespace PetShop.Tests.StoredProcedures
{
    public partial class OrderStatus
    {
        protected override void Child_Create()
        {
            bool cancel = false;
            OnChildCreating(ref cancel);
            if (cancel) return;

            ValidationRules.CheckRules();

            OnChildCreated();
        }

        private void Child_Fetch(OrderStatusCriteria criteria)
        {
            bool cancel = false;
            OnChildFetching(criteria, ref cancel);
            if (cancel) return;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Select]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                            Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'OrderStatus' using the following criteria: {0}.", criteria));
                    }
                }
            }

            OnChildFetched();
        }

        private void Child_Insert(Order order, SqlConnection connection)
        {
            bool cancel = false;
            OnChildInserting(ref cancel);
            if (cancel) return;

			if(connection.State != ConnectionState.Open) connection.Open();
            using(SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Insert]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_OrderId", order.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", LineNum);
					command.Parameters.AddWithValue("@p_Timestamp", Timestamp);
					command.Parameters.AddWithValue("@p_Status", Status);

                command.ExecuteNonQuery();
            }

            OnChildInserted();
        }

        private void Child_Update(Order order, SqlConnection connection)
        {
            bool cancel = false;
            OnChildUpdating(ref cancel);
            if (cancel) return;

			if(connection.State != ConnectionState.Open) connection.Open();
            using(SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Update]", connection))
            {
                command.CommandType = CommandType.StoredProcedure;
                command.Parameters.AddWithValue("@p_OrderId", order.OrderId);
					command.Parameters.AddWithValue("@p_LineNum", LineNum);
					command.Parameters.AddWithValue("@p_Timestamp", Timestamp);
					command.Parameters.AddWithValue("@p_Status", Status);

                //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                int result = command.ExecuteNonQuery();
                if (result == 0)
                    throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
            }

            OnChildUpdated();
        }

        private void Child_DeleteSelf()
        {
            bool cancel = false;
            OnChildSelfDeleting(ref cancel);
            if (cancel) return;
            
            DataPortal_Delete(new OrderStatusCriteria (OrderId, LineNum));
        
			OnChildSelfDeleted();
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(OrderStatusCriteria criteria)
        {
            bool cancel = false;
            OnDeleting(criteria, ref cancel);
            if (cancel) return;

            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand("[dbo].[CSLA_OrderStatus_Delete]", connection))
                {
                    command.CommandType = CommandType.StoredProcedure;
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    
                    //result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }

            OnDeleted();
        }

        private void Map(SafeDataReader reader)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_orderIdProperty, reader.GetInt32("OrderId"));
                LoadProperty(_lineNumProperty, reader.GetInt32("LineNum"));
                LoadProperty(_timestampProperty, reader.GetDateTime("Timestamp"));
                LoadProperty(_statusProperty, reader.GetString("Status"));
            }

            MarkAsChild();
            MarkOld();
        }

        #region Child data access partial methods

        partial void OnChildCreating(ref bool cancel);
        partial void OnChildCreated();
        partial void OnChildFetching(OrderStatusCriteria criteria, ref bool cancel);
        partial void OnChildFetched();
        partial void OnChildInserting(ref bool cancel);
        partial void OnChildInserted();
        partial void OnChildUpdating(ref bool cancel);
        partial void OnChildUpdated();
        partial void OnChildSelfDeleting(ref bool cancel);
        partial void OnChildSelfDeleted();
        partial void OnDeleting(OrderStatusCriteria criteria, ref bool cancel);
        partial void OnDeleted();

        #endregion
    }
}