
namespace User.Infrastructure.Constants
{
    public static class JwtAuthConstants
    {
        public const string ISSUER  = "InmoSys";
        public const string AUDIENCE = "InmoSysClients";      
        public const int TOKEN_EXPIRATION_MINUTES = 60;
        public const string JWT_MODULE = "User";
        public const int NUMBER_OF_ITERATION = 100000;
    }
}
