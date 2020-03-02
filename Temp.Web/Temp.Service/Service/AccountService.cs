using System;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Temp.Common.Infrastructure;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.ViewModel;
using Role = Temp.Common.Infrastructure.Role;

namespace Temp.Service.Service
{
    /// <summary>
    /// Account service
    /// </summary>
    public class AccountService : IAccountService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;

        public AccountService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }
        
        /// <summary>
        /// login
        /// </summary>
        /// <param name="login"></param>
        /// <returns></returns>
        public User LogIn(LogInViewModel login)
        {
            var account =
                _unitofWork.UserBaseService.ObjectContext.Include(s => s.Role)
                    .FirstOrDefault(s => s.Username == login.Username && s.Password == login.Password);
            return account;
        }
        
        /// <summary>
        /// register
        /// </summary>
        /// <param name="accModel"></param>
        public void CreateAccount(CreateAccViewModel accModel)
        {
            accModel.RoleId = (int)Role.User;
            accModel.CreateDate = DateTime.Now;
            accModel.ExpiredDate = DateTime.Now;
            accModel.Type = (int)UserType.None;
            var user = _mapper.Map<CreateAccViewModel, User>(accModel);
            _unitofWork.UserBaseService.Add(user);
            _unitofWork.Save();
        }
        
        /// <summary>
        /// check account
        /// </summary>
        /// <param name="accModel"></param>
        /// <returns></returns>
        public bool CheckAccount(CreateAccViewModel accModel)
        {
            var isExist = _unitofWork.UserBaseService.ObjectContext.Any(s => s.Username.Equals(accModel.Username));
            if (!isExist)
            {
                return true;
            }            
            return false;               
        }
        
        /// <summary>
        /// change password
        /// </summary>
        /// <param name="passModel"></param>
        /// <returns></returns>
        public bool ChangePass(ChangePassViewModel passModel)
        {
            var user = _unitofWork.UserBaseService.ObjectContext.Include(s => s.Role)
                .FirstOrDefault(s => s.Username == passModel.UserName);
            
            if (user == null) return false;
            var userUpdate = new User
            {
                Username = user.Username,
                Id = user.Id,
                Password = passModel.Password,
                RoleId = user.Id
            };
            _unitofWork.UserBaseService.Update(userUpdate);
            _unitofWork.Save();
            return true;
        }
        
        /// <summary>
        /// check password
        /// </summary>
        /// <param name="passModel"></param>
        /// <returns></returns>
        public bool CheckPass(ChangePassViewModel passModel)
        {
            var user = _unitofWork.UserBaseService.Get(s => s.Username == passModel.UserName);
            if (user != null && user.Password != passModel.CurrentPass)
            {
                return false;
            }

            return true;
        }
        
        /// <summary>
        /// get account by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public User GetAccount(string name)
        {
            return _unitofWork.UserBaseService.ObjectContext.FirstOrDefault(s => s.Username == name);
        }
        
        /// <summary>
        /// request expired date
        /// </summary>
        /// <param name="user"></param>
        public void RequestExpired(User user)
        {
            user.Type = (int)UserType.Processing;
            _unitofWork.Save();
        }
    }
}