using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LogingInApp.Classes
{
    public static class DataAdapters
    {
        public static SqlDataAdapter EmployeeAdapter(SqlConnection connection)
        {
            SqlDataAdapter adapter = new SqlDataAdapter();

            SqlCommand selectCommand = new SqlCommand("SELECT * FROM Employee", connection);
            adapter.SelectCommand = selectCommand;

            SqlCommand insertCommand = new SqlCommand("INSERT INTO Employee (FirstName, LastName, Gender) " +
                "VALUES (@FirstName, @LastName, @Gender", connection);
            insertCommand.Parameters.Add("@FirstName", SqlDbType.NVarChar, 100, "FirstName");
            insertCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 100, "LastName");
            insertCommand.Parameters.Add("@Gender", SqlDbType.NChar, 1, "Gender");
            adapter.InsertCommand = insertCommand;

            SqlCommand updateCommand = new SqlCommand("UPDATE dbo.Employee SET LastName=@LastName WHERE Id=@EmployeeId", connection);
            updateCommand.Parameters.Add("@LastName", SqlDbType.NVarChar, 100, "LastName");
            SqlParameter updateId = updateCommand.Parameters.Add("@EmployeeId", SqlDbType.Int, 100, "Id");
            updateId.SourceVersion = DataRowVersion.Original;
            adapter.UpdateCommand = updateCommand;

            SqlCommand deleteCommand = new SqlCommand("DELETE FROM Employee WHERE Id=@EmployeeId", connection);
            SqlParameter deletedId = deleteCommand.Parameters.Add("@EmployeeId", SqlDbType.Int, 100, "EmployeeId");
            deletedId.SourceVersion = DataRowVersion.Original;
            adapter.DeleteCommand = deleteCommand;

            return adapter;



        }
        
    }
}
