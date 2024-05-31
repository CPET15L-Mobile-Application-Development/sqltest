using System;
using System.Collections.Generic;
using System.Text;
using SQLite;
using System.Threading.Tasks;
using sqltest.Model;


namespace sqltest
{
    public class SQLiteHelper
    {
        private readonly SQLiteAsyncConnection db;

        public SQLiteHelper(string dbPath)
        {
            db = new SQLiteAsyncConnection(dbPath);
            db.CreateTableAsync<EmployeeModel>();
        }

        public Task<int> CreateEmployee (EmployeeModel employee)
        {
            return db.InsertAsync(employee);

        }

        public Task<List<EmployeeModel>> ReadEmployees()
        {
            return db.Table<EmployeeModel>().ToListAsync();
        }
        public Task<int> UpdateEmployee(EmployeeModel employee)
        {
            return db.UpdateAsync(employee);
        }

        public Task<int> DeleteEmployee (EmployeeModel employee)
        {
            return db.DeleteAsync(employee);
        }

        public Task<List<EmployeeModel>> Search(string search) 
        {
            return db.Table<EmployeeModel>().Where(p => p.Name.StartsWith(search)).ToListAsync();
            
        }
    }
}
