using System;
using System.Collections.Generic;
using System.Linq;
using AutoMapper;
using Microsoft.EntityFrameworkCore;
using Temp.Common.Infrastructure;
using Temp.DataAccess.Data;
using Temp.Service.BaseService;
using Temp.Service.ViewModel;

namespace Temp.Service.Service
{
    /// <summary>
    /// user service class
    /// </summary>
    public class UserService : IUserService
    {
        private readonly IUnitofWork _unitofWork;
        private readonly IMapper _mapper;
        
        /// <summary>
        /// userservice constructor
        /// </summary>
        public UserService(IUnitofWork unitofWork, IMapper mapper)
        {
            _unitofWork = unitofWork;
            _mapper = mapper;
        }

        public IEnumerable<UserViewModel> GetAll()
        {
            var users = _unitofWork.UserBaseService.GetAll();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }

        /// <summary>
        /// get all user
        /// </summary>
        /// <returns></returns>
        public IEnumerable<UserViewModel> GetAllIncluding()
        {
            var users = _unitofWork.UserBaseService.ObjectContext.Include(s => s.Role).ToList();
            return _mapper.Map<IEnumerable<User>, IEnumerable<UserViewModel>>(users);
        }
        
        /// <summary>
        /// create or edit user
        /// </summary>
        /// <param name="userDto"></param>
        /// <exception cref="NotImplementedException"></exception>
        public void Save(CreateUserViewModel userDto)
        {
            if (userDto.Id <= 0)
            {
                var user = _mapper.Map<CreateUserViewModel, User>(userDto);
                user.CreateDate = DateTime.Now;
                user.ExpiredDate = DateTime.Now;
                user.Type = (int) UserType.None;
                _unitofWork.UserBaseService.Add(user);
                _unitofWork.Save();
            }
        }
        
        /// <summary>
        /// delete user
        /// </summary>
        /// <exception cref="NotImplementedException"></exception>
        public void Delete(int id)
        {
            var user =  _unitofWork.UserBaseService.GetById(id);
            _unitofWork.UserBaseService.Delete(user);
            _unitofWork.Save();
        }
        
        /// <summary>
        /// approve request expired for user
        /// </summary>
        /// <param name="user"></param>
        public void ApproveRequestExpired(User user)
        {
            user.Type = (int) UserType.None;
            user.ExpiredDate = DateTime.Now.AddDays(30);
            _unitofWork.Save();
        }
        
        /// <summary>
        /// reject request expired for user
        /// </summary>
        /// <param name="user"></param>
        public void RejectRequestExpired(User user)
        {
            user.Type = (int) UserType.None;
            _unitofWork.Save();
        }
        
        /// <summary>
        /// get user by id
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public User GetById(int id)
        {
            var user = _unitofWork.UserBaseService.GetById(id);
            return user;
        }
    }
}