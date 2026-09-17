using DAL.Helper.Interfaces;
using Dapper;
using Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DAL
{
    public partial class UserRepository : IUserRepository
    {
        private readonly IDatabaseHelper _dbHelper;
        public UserRepository(IDatabaseHelper dbHelper)
        {
            _dbHelper = dbHelper;
        }

        // Implement the correct interface method
        public List<User> GetAllUsers()
        {
            using (var connection = _dbHelper.CreateConnection())
            {
                string sql = "SELECT TOP (1000) * FROM [dbo].[user]";
                var users = connection.Query<User>(sql).ToList();
                return users;
            }
        }
    }
}
