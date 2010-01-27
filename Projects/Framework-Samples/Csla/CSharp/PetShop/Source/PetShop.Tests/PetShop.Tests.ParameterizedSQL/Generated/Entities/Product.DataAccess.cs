//------------------------------------------------------------------------------
// <autogenerated>
//     This code was generated using CSLA 3.8.X CodeSmith Templates.
//     Changes to this file will be lost after each regeneration.
//     To extend the functionality of this class, please modify the partial class 'Product.cs'.
//
//     Template: SwitchableObject.DataAccess.ParameterizedSQL.cst
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

namespace PetShop.Tests.ParameterizedSQL
{
    public partial class Product
    {
        #region Root Data Access

        [RunLocal]
        protected override void DataPortal_Create()
        {
            ValidationRules.CheckRules();
        }

        private void DataPortal_Fetch(ProductCriteria criteria)
        {
            string commandText = string.Format("SELECT [ProductId], [CategoryId], [Name], [Descn], [Image] FROM [dbo].[Product] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if (reader.Read())
							Map(reader);
						else
							throw new Exception(String.Format("The record was not found in 'Product' using the following criteria: {0}.", criteria));
                    }
                }
            }
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Insert()
        {
            const string commandText = "INSERT INTO [dbo].[Product] ([ProductId], [CategoryId], [Name], [Descn], [Image]) VALUES (@p_ProductId, @p_CategoryId, @p_Name, @p_Descn, @p_Image)";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
					command.Parameters.AddWithValue("@p_ProductId", ProductId);
					command.Parameters.AddWithValue("@p_CategoryId", CategoryId);
					command.Parameters.AddWithValue("@p_Name", Name);
					command.Parameters.AddWithValue("@p_Descn", Descn);
					command.Parameters.AddWithValue("@p_Image", Image);
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                        }
                    }
                }
            }

            FieldManager.UpdateChildren(this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_Update()
        {
            const string commandText = "UPDATE [dbo].[Product]  SET [ProductId] = @p_ProductId, [CategoryId] = @p_CategoryId, [Name] = @p_Name, [Descn] = @p_Descn, [Image] = @p_Image WHERE [ProductId] = @p_ProductId";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
					command.Parameters.AddWithValue("@p_ProductId", ProductId);
					command.Parameters.AddWithValue("@p_CategoryId", CategoryId);
					command.Parameters.AddWithValue("@p_Name", Name);
					command.Parameters.AddWithValue("@p_Descn", Descn);
					command.Parameters.AddWithValue("@p_Image", Image);

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        //RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        if(reader.RecordsAffected == 0)
                            throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                    }
                }
            }

            FieldManager.UpdateChildren(this);
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected override void DataPortal_DeleteSelf()
        {
            DataPortal_Delete(new ProductCriteria(ProductId));
        }

        [Transactional(TransactionalTypes.TransactionScope)]
        protected void DataPortal_Delete(ProductCriteria criteria)
        {
            string commandText = string.Format("DELETE FROM [dbo].[Product] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
					
					//result: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                    int result = command.ExecuteNonQuery();
                    if (result == 0)
                        throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");
                }
            }
        }

        #endregion

        #region Child Data Access

        protected override void Child_Create()
        {
            // TODO: load default values
            // omit this override if you have no defaults to set
            //base.Child_Create();
        }

        private void Child_Fetch(ProductCriteria criteria)
        {
            string commandText = string.Format("SELECT [ProductId], [CategoryId], [Name], [Descn], [Image] FROM [dbo].[Product] {0}", ADOHelper.BuildWhereStatement(criteria.StateBag));
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using (SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddRange(ADOHelper.SqlParameters(criteria.StateBag));
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                            Map(reader);
                        else
                            throw new Exception(string.Format("The record was not found in 'Product' using the following criteria: {0}.", criteria));
                    }
                }
            }

            MarkAsChild();
        }

        private void Child_Insert(Category category)
        {
            const string commandText = "INSERT INTO [dbo].[Product] ([ProductId], [CategoryId], [Name], [Descn], [Image]) VALUES (@p_ProductId, @p_CategoryId, @p_Name, @p_Descn, @p_Image)";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
                    command.Parameters.AddWithValue("@p_ProductId", ProductId);
					command.Parameters.AddWithValue("@p_CategoryId", category.CategoryId);
					command.Parameters.AddWithValue("@p_Name", Name);
					command.Parameters.AddWithValue("@p_Descn", Descn);
					command.Parameters.AddWithValue("@p_Image", Image);
                    
                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        if(reader.Read())
                        {
                        }
                    }
                }
            }
        }

        private void Child_Update(Category category)
        {
            const string commandText = "UPDATE [dbo].[Product]  SET [ProductId] = @p_ProductId, [CategoryId] = @p_CategoryId, [Name] = @p_Name, [Descn] = @p_Descn, [Image] = @p_Image WHERE [ProductId] = @p_ProductId";
            using (SqlConnection connection = new SqlConnection(ADOHelper.ConnectionString))
            {
                connection.Open();
                using(SqlCommand command = new SqlCommand(commandText, connection))
                {
					command.Parameters.AddWithValue("@p_ProductId", ProductId);
					command.Parameters.AddWithValue("@p_CategoryId", category.CategoryId);
					command.Parameters.AddWithValue("@p_Name", Name);
					command.Parameters.AddWithValue("@p_Descn", Descn);
					command.Parameters.AddWithValue("@p_Image", Image);

                    using(var reader = new SafeDataReader(command.ExecuteReader()))
                    {
                        //RecordsAffected: The number of rows changed, inserted, or deleted. -1 for select statements; 0 if no rows were affected, or the statement failed. 
                        if(reader.RecordsAffected == 0)
                            throw new DBConcurrencyException("The entity is out of date on the client. Please update the entity and try again. This could also be thrown if the sql statement failed to execute.");

                    }
                }
            }
        }

        private void Child_DeleteSelf()
        {
            DataPortal_Delete(new ProductCriteria(ProductId));
        }

        #endregion

        private void Map(SafeDataReader reader)
        {
            using(BypassPropertyChecks)
            {
                LoadProperty(_productIdProperty, reader.GetString("ProductId"));
                LoadProperty(_categoryIdProperty, reader.GetString("CategoryId"));
                LoadProperty(_nameProperty, reader.GetString("Name"));
                LoadProperty(_descnProperty, reader.GetString("Descn"));
                LoadProperty(_imageProperty, reader.GetString("Image"));
            }

            MarkOld();
        }
    }
}