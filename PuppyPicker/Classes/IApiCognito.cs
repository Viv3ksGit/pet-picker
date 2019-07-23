using System;
using System.Threading.Tasks;
using PuppyPicker.ENUMS;
namespace PuppyPicker.Classes
{

    public class CognitoContext
    {
        public string Error { get; private set; }
        public CognitoContext(CognitoResult res = CognitoResult.Unknown, string error = "")
        {
            Result = res;
            Error = error;
        }
        public CognitoResult Result { get; set; }
    }

    public class SignInContext : CognitoContext
    {
        public SignInContext(CognitoResult res = CognitoResult.Unknown, string error = "") : base(res, error)
        {
        }
        //public CognitoUser User { get; set; }
        public string UserName { get; set; }
        public string UserPassword { get; set; }
        public String IdToken { get; set; }
        public String AccessToken { get; set; }
        public String RefreshToken { get; set; }
        public String SessionId { get; set; }
        public DateTime TokenIssued { get; set; }
        public DateTime Expires { get; set; }
    }

    public interface IApiCognito
    {
        /// <summary>
        /// Sign in using the username and password
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<SignInContext> SignIn(string userName, string password);

        /// <summary>
        /// Refresh the token
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="idToken"></param>
        /// <param name="accessToken"></param>
        /// <param name="refreshToken"></param>
        /// <param name="issued"></param>
        /// <param name="expires"></param>
        /// <returns></returns>
        Task<SignInContext> RefreshToken(string userName, string idToken, string accessToken, String refreshToken, DateTime issued, DateTime expires);
        /// <summary>
        /// Sign a user up
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="password"></param>
        /// <returns></returns>
        Task<CognitoContext> SignUp(string userName, string password);
        /// <summary>
        /// Send a forgot password link to user
        /// </summary>
        /// <param name="userName"></param>
        /// <returns></returns>
        Task<CognitoContext> ForgotPassword(string userName);
        /// <summary>
        /// send reset command to aws
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="code"> aws code sent by email</param>
        /// <param name="newpassword"></param>
        /// <returns></returns>
        Task<CognitoContext> ResetPassword(string userName, string code, string newpassword);
        /// <summary>
        /// Verify the account using a code
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="code"></param>
        /// <returns></returns>
        Task<CognitoContext> VerifyWithCode(string userName, string code);
        /// <summary>
        /// Update the password. 
        /// </summary>
        /// <param name="userName"></param>
        /// <param name="newPassword"></param>
        /// <param name="sessionId"></param>
        /// <returns></returns>
        Task<CognitoContext> UpdatePassword(string userName, string newPassword, string sessionId);
    }

}
