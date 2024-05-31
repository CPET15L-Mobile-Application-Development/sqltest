using System;
using System.Collections.Generic;
using System.Text;
using SQLite;


namespace sqltest.Model
{
     public class EmployeeModel
    {
        [PrimaryKey, AutoIncrement]
        public int Id { get; set; }
        [MaxLength(50)]

        public string Name { get; set; }    
        public string Address { get; set; }
    }
}
