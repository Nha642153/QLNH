using QuanlyNhahang_API.Model;
using System.Collections.Generic;

namespace QuanlyNhahang_API.Service
{
    interface IUserService
    {
        List<User> GetUsers(string Username);
        void SaveOrUpdate(User user);
        void Delete(int id);
    }
}
