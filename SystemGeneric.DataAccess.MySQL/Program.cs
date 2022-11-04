using System;
using System.Collections.Generic;
using System.Data;

namespace SystemGeneric.DataAccess.MySQL
{
    class Program
    {
         static IGenericRepository repository = new GenericRepository("server=localhost;port=3306;database=mySQLdb;uid=root;password=MySQL@123456;");
        static void Main(string[] args)
        {
            Console.WriteLine("Hello MySQL World!");

            //get User details
            //Stored Procedure
            //Dapper.DefaultTypeMap.MatchNamesWithUnderscores = true;
            GenericParameter genericParameter = new GenericParameter
            {
                SqlCommand = "INSERT INTO usertable2 (email, password, create_time) VALUES (@email, @password, @create_time);",
                ExecuteType = System.Data.CommandType.Text
            };
            genericParameter.InputParameters.Add("@email", "myemail", DbType.String, ParameterDirection.Input);
            genericParameter.InputParameters.Add("@password", "myPass", DbType.String, ParameterDirection.Input);
            genericParameter.InputParameters.Add("@create_time", DateTime.Now, DbType.DateTime, ParameterDirection.Input);

            dynamic dynamicValue = repository.ExecuteScalar<dynamic>(genericParameter);

            genericParameter = new GenericParameter
            {
                SqlCommand = "Select * from UserTable2;",
                ExecuteType = CommandType.Text
            };

            IEnumerable<UserTable> userInfo = repository.ExecuteQueryList<UserTable>(genericParameter);
            foreach(var user in userInfo)
            {
                Console.WriteLine($"Created Date : {user.Create_Time}, Modified Date : {user.Create_Time}.");
            }
            //DateTime.SpecifyKind((DateTime)value, DateTimeKind.Utc);
            Console.ReadLine();
        }

    }

    public class UserTable
    {
        public int UserName { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime? Create_Time { get; set; }
    }
}
