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
            }
            catch (Exception ex)
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
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Update(User thongtin)
        {
            try
            {
                using (var connection = _dbHelper.CreateConnection())
                {
                    string sql = @"UPDATE [dbo].[user] 
                                 SET [hoten] = @Hoten, 
                                     [ngaysinh] = @Ngaysinh, 
                                     [diachi] = @Diachi, 
                                     [gioitinh] = @Gioitinh, 
                                     [email] = @Email, 
                                     [taikhoan] = @Taikhoan, 
                                     [matkhau] = @Matkhau, 
                                     [role] = @Role, 
                                     [image_url] = @Image_Url
                                 WHERE [user_id] = @User_Id";
                    int rowsAffected = connection.Execute(sql, thongtin);
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        public bool Delete(string user_Id)
        {
            try
            {
                using (var connection = _dbHelper.CreateConnection())
                {
                    string sql = @"DELETE FROM [dbo].[user] WHERE [user_id] = @User_Id";
                    int rowsAffected = connection.Execute(sql, new { User_Id = user_Id });
                    return rowsAffected > 0;
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}
