using Temp.DataAccess.Data;
using Temp.Service.ViewModel;

namespace Temp.Service.Service
{
    /// <summary>
    /// Account service interface
    /// </summary>
    public interface IAccountService
    {
        /// <summary>
        /// login
        /// </summary>
        /// <param name="logInDto"></param>
        /// <returns></returns>
        User LogIn(LogInViewModel logInDto);
        
        /// <summary>
        /// regiter account
        /// </summary>
        /// <param name="accDto"></param>
        void CreateAccount(CreateAccViewModel accDto);
        
        /// <summary>
        /// check exist account
        /// </summary>
        /// <param name="accDto"></param>
        /// <returns></returns>
        bool CheckAccount(CreateAccViewModel accDto);
        
        /// <summary>
        /// change passowrd account
        /// </summary>
        /// <param name="passDto"></param>
        /// <returns></returns>
        bool ChangePass(ChangePassViewModel passDto);
        
        /// <summary>
        /// check password
        /// </summary>
        /// <param name="passDto"></param>
        /// <returns></returns>
        bool CheckPass(ChangePassViewModel passDto);
        
        /// <summary>
        /// get account by name
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        User GetAccount(string name);
        
        /// <summary>
        /// user request expired date
        /// </summary>
        void RequestExpired(User user);
        
    }
}