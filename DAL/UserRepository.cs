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
            try
            {
                using (var connection = _dbHelper.CreateConnection())
                {
                    string sql = "SELECT TOP (1000) * FROM [dbo].[user]";
                    var users = connection.Query<User>(sql).ToList();
                    return users;
                }
            } catch (Exception ex) 
            {
                throw ex;
            }
        }
        public bool Create(User thongtin)
        {
            try
            {
                using (var connection = _dbHelper.CreateConnection())
                {
                    string sql = @"INSERT INTO [dbo].[user] 
                                 ([user_id], [hoten], [ngaysinh], [diachi], [gioitinh], [email], [taikhoan], [matkhau], [role], [image_url])
                                 VALUES 
                                 (@User_Id, @Hoten, @Ngaysinh, @Diachi, @Gioitinh, @Email, @Taikhoan, @Matkhau, @Role, @Image_Url)";
                    int rowsAffected = connection.Execute(sql, thongtin);
                    return rowsAffected > 0;
                }
                //return true;
            } catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
