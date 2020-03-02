using AutoMapper;
using Temp.DataAccess.Data;
using Temp.Service.ViewModel;

namespace Temp.Service.Mapper
{
    /// <summary>
    /// user mapper
    /// </summary>
    public class UserMapping : Profile
    {
        public UserMapping()
        {
            //view model => entities
            CreateMap<CreateAccViewModel, User>();
            
            //view model => entities
            CreateMap<ChangePassViewModel, User>();

            //createviewmodel => user
            CreateMap<CreateUserViewModel, User>();

            //user => userviewmodel
            CreateMap<User, UserViewModel>();
        }
    }
}