namespace Temp.Common.Infrastructure
{
    /// <summary>
    /// Define all Constants
    /// </summary>
    public class Constants
    {
        public const string JwtIssuer = "Jwt:Issuer";
        public const string JwtKey = "Jwt:Key";

        public const string CommaString = ",";
        public const char Colon = ':';
        public const string PageTitle = "Title";
        public const string Gender = "Gender";
        public const string DateServerFormat = "DateServerFormat";
        public const string DateClientFortmat = "DateClientFortmat";
        public const string Controller = "controller";
        public const string Action = "action";
        public const string AppName = "Xem";
        public const string CacheBuster = "CacheBuster";
        public const string Alphabet = "abcdefghijklmnopqrstuvwxyz";
        public const string Ok = "OK";
        public const string UploadDir = "Upload";
        public const string SessionKey = "VshopSession";
        public const string AppSession = ".Vshop.Session";
        public const string FormatName = "{0} {1} {2}";

        /// <summary>
        /// basic authentication
        /// </summary>
        public class BasicAuth
        {
            public const string AuthenticationUsername = "Authentication:Username";
            public const string AuthenticationPassword = "Authentication:Password";
            public const string Authorization = "Authorization";
            public const string BasicAuthorization = "Basic Authorization";
            public const string StringType = "string";
            public const string Header = "header";
            public const string Basic = "Basic";
            public const string BasicHeader = "Basic ";
            public const string Iso88591 = "iso-8859-1";
        }    
        
        /// <summary>
        /// class define all route in system
        /// </summary>
        public class Route
        {
            public const string ErrorPage = "/error/systemerror";
            public const string NotFound = "/error/pagenotfound";
            public const string AccessDenied = "/error/notpermission";
            public const string ApiRoute = "/api";
        }

        /// <summary>
        /// Config for swagger
        /// </summary>
        public class Swagger
        {
            public const string Header = "header";
            public const string V1 = "v1";
            public const string CorsPolicy = "CorsPolicy";
        }

        /// <summary>
        /// Define key for appsetting config 
        /// </summary>
        public class Settings
        {
            public const string DefaultCulture = "Cultures:Default";
            public const string OptionCulture = "Cultures:Option";
            public const string PageSize = "Pagination:PageSize";
            public const string LoginExpiredTime = "Login:ExpiredTime";
            public const string ErrorMessage = "ErrorMessage";
            public const string ConnectionString = "ConnectionString";
            public const string DefaultConnection = "DefaultConnection";
            public const string ResourcesDir = "Resources";
            public const string VshopDataAccess = "Vshop.VshopDataAccess";
            public const string EncryptKey = "Encryptor:Key";
            public const string MaxTimezoneTimeHour = "23";
            public const string MaxTimezoneTimeMinute = "59";
            public const double MaxTimezoneTimeHourMinute = 23.99;
            public const string ExpiredSessionTime = "ExpiredSessionTime";
            public const string DefaultUsernameAdmin = "admin";
            public const string DefaultUsernameUser = "user";
            public const string DefaultPassword = "123qwe";
            public const string DefaultCategoryName = "AAA";
        }

        /// <summary>
        /// Config for logger system
        /// </summary>
        public class Logger
        {
            public const string LogFile = "Logging:LogDir";
            public const string Logging = "Logging";
        }      

        /// <summary>
        /// claim name
        /// </summary>
        public class ClaimName
        {
            public const string UserCode = "UserCode";
            public const string UserName = "UserName";
            public const string AccountId = "AccountId";
            public const string Role = "Role";
        }            

        /// <summary>
        /// const role
        /// </summary>
        public class Role
        {
            public const string Admin = "Admin";
            public const string User = "User";
        }

        /// <summary>
        /// db init default
        /// </summary>
        public class DbInit
        {
            public const string DfAdmin = "Admin";
            public const string DfUser = "User";
            public const string DfCate = "AAA";
            public const string DfPassword = "123qwe";

        }
    }
}
