using System.Collections.Generic;
using Temp.DataAccess.Data;
using Temp.Service.ViewModel;

namespace Temp.Service.Service
{
    /// <summary>
    /// interface of user service
    /// </summary>
    public interface IUserService
    {
        /// <summary>
        /// get all list user
        /// </summary>
        /// <returns></returns>
        IEnumerable<UserViewModel> GetAll();

        IEnumerable<UserViewModel> GetAllIncluding();
        
        /// <summary>
        /// create or edit user
        /// </summary>
        /// <param name="userDto"></param>
        void Save(CreateUserViewModel userDto);
        
        /// <summary>
        /// delete user
        /// </summary>
        void Delete(int id);
        
        /// <summary>
        /// approve request expired for user
        /// </summary>
        /// <param name="user"></param>
        void ApproveRequestExpired(User user);
        
        /// <summary>
        /// reject request expired for user
        /// </summary>
        /// <param name="user"></param>
        void RejectRequestExpired(User user);
        
        /// <summary>
        /// get account by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        User GetById(int id);
    }
}