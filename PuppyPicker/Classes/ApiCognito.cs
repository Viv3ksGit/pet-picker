
/*
Install those NuGet packages one by one on each platform

AWSSDK.CognitoIdentityProvider
AWSSDK.Core
AWSSDK.SecurityToken
AWSSDK.Extensions.CognitoAuthentication

*/



using System;
//using SyBrass.Tools.Diagnostics;
using Amazon;
using Amazon.CognitoIdentityProvider;
using Amazon.CognitoIdentityProvider.Model;
using Amazon.Extensions.CognitoAuthentication;
using Amazon.Runtime;
using System.Threading.Tasks;
using PuppyPicker.ENUMS;
using System.Diagnostics;
using Xamarin.Forms;

namespace PuppyPicker.Classes
{
    public class ApiCognito : IApiCognito
    {
        private readonly AmazonCognitoIdentityProviderClient awsProvider;
        private readonly CognitoUserPool UserPool;
        public ApiCognito()
        {
            awsProvider = new AmazonCognitoIdentityProviderClient(new AnonymousAWSCredentials(), RegionEndpoint.CACentral1);
            UserPool = new CognitoUserPool(Keys.AWS_PoolID, Keys.AWS_UsersPool_ClientID, awsProvider);
        }

        public async Task<CognitoContext> SignUp(string userName, string password)
        {
            try
            {
                SignUpResponse result = await awsProvider.SignUpAsync(new SignUpRequest
                {
                    ClientId = Keys.AWS_UsersPool_ClientID,
                    Password = password,
                    Username = userName
                });

                Debug.WriteLine($"From {this.GetType().Name}, Sign Up Succeeded");
                return new CognitoContext(CognitoResult.SignupOk);
                //ProceedToCodeValidation();
            }
            catch (UsernameExistsException)
            {
                Debug.WriteLine($"From {this.GetType().Name}, UsernameExistsException");
                return new CognitoContext(CognitoResult.UserNameAlreadyUsed);
            }
            catch (InvalidPasswordException)
            {
                Debug.WriteLine($"From {this.GetType().Name}, InvalidPasswordException");
                return new CognitoContext(CognitoResult.PasswordRequirementsFailed);
            }
            catch (Exception e)
            {
                //Sign Up failed, reason below
                Debug.WriteLine($"Exception in: {this.GetType().Name} error:{e.Message}");
                return new CognitoContext(CognitoResult.Unknown, e.Message);

            }

        }

        public async Task<SignInContext> SignIn(string userName, string password)
        {
            try
            {
                CognitoUser user = new CognitoUser(userName, Keys.AWS_UsersPool_ClientID, UserPool, awsProvider);
                AuthFlowResponse context = await user.StartWithSrpAuthAsync(new InitiateSrpAuthRequest()
                {
                    Password = password
                }).ConfigureAwait(false);

                // TODO handle other challenges
                if (context.ChallengeName == ChallengeNameType.NEW_PASSWORD_REQUIRED)
                {
                    Debug.WriteLine($"Login Challenge Required");
                    return new SignInContext(CognitoResult.PasswordChangeRequred)
                    {
                        //User = user,
                        SessionId = context.SessionID
                    };
                }

                else
                {
                    
                    Debug.WriteLine($"From:{this.GetType().Name},Login Success ======> ");
                    Debug.WriteLine($"username:{userName}");
                    Debug.WriteLine($"password:{password}");
                    Debug.WriteLine($"ID Token:{context.AuthenticationResult?.IdToken}");
                    Debug.WriteLine($"Refresh Token:{context.AuthenticationResult?.RefreshToken}");
                    Debug.WriteLine($"Access Token:{context.AuthenticationResult?.AccessToken}");
                    Debug.WriteLine($"TokenIssued:{user.SessionTokens.IssuedTime}");
                    Debug.WriteLine($"Expires:{user.SessionTokens.ExpirationTime}");
                    Debug.WriteLine($"SessionId:{context.SessionID}");

                    var _sessionData = new SignInContext(CognitoResult.Ok)
                    {
                        //User = user,
                        UserName = userName,
                        UserPassword = password,
                        IdToken = context.AuthenticationResult?.IdToken,
                        RefreshToken = context.AuthenticationResult?.RefreshToken,
                        AccessToken = context.AuthenticationResult?.AccessToken,
                        TokenIssued = user.SessionTokens.IssuedTime,
                        Expires = user.SessionTokens.ExpirationTime,
                        SessionId = context.SessionID
                    };

                    var myApp = Application.Current as App;
                    myApp.SetSessionData(_sessionData);

                    return _sessionData;
                }
            }
            catch (UserNotConfirmedException)
            {
                return new SignInContext(CognitoResult.NotConfirmed);
            }
            catch (NotAuthorizedException)
            {
                return new SignInContext(CognitoResult.InvalidPassword);
            }
            catch (UserNotFoundException)
            {
                return new SignInContext(CognitoResult.UserNotFound);
            }
            catch (Exception e)
            {
                return new SignInContext(CognitoResult.Unknown, e.Message);
            }

        }

        public async Task<SignInContext> RefreshToken(string userName, string idToken, string accessToken, String refreshToken, DateTime issued, DateTime expires)
        {
            Debug.WriteLine("ApiCognito: ========== Called to refresh session =========");
            try
            {
                Debug.WriteLine($"//sending user:{userName}, refresh token:{refreshToken},{expires}");

                CognitoUser user = new CognitoUser("", Keys.AWS_UsersPool_ClientID, UserPool, awsProvider);
                user.SessionTokens = new CognitoUserSession(
                    idToken,
                    accessToken,
                    refreshToken,
                    issued,
                    expires
                    //DateTime.Now.AddHours(1)//this will add one more our to the session
                    );

                AuthFlowResponse context = await user.StartWithRefreshTokenAuthAsync(new InitiateRefreshTokenAuthRequest
                {
                    AuthFlowType = AuthFlowType.REFRESH_TOKEN_AUTH
                })
                .ConfigureAwait(false);
                Debug.WriteLine("//connection went through");


                // TODO handle other challenges
                return new SignInContext(CognitoResult.Ok)
                {
                    //User = user,
                    IdToken = context.AuthenticationResult?.IdToken,
                    RefreshToken = context.AuthenticationResult?.RefreshToken,
                    AccessToken = context.AuthenticationResult?.AccessToken,
                    TokenIssued = user.SessionTokens.IssuedTime,
                    Expires = user.SessionTokens.ExpirationTime
                };
            }
            /*
            catch (NotAuthorizedException)
            {
                Debug.WriteLine("//returning NotAuthorizedException");

                return new SignInContext(CognitoResult.NotAuthorized);
            }*/
            catch (Exception e)
            {
                Debug.WriteLine($"RefreshToken() threw an exception {e}");
            }
            Debug.WriteLine($"returning unknown");

            return new SignInContext(CognitoResult.Unknown);
        }


        public async Task<CognitoContext> VerifyWithCode(string userName, string activationCode)
        {
            try
            {
                var result = await awsProvider.ConfirmSignUpAsync(new ConfirmSignUpRequest
                {
                    ClientId = Keys.AWS_UsersPool_ClientID,
                    Username = userName,
                    ConfirmationCode = activationCode
                });
                Debug.WriteLine("User verified success, navigate to sign in page");
                return new CognitoContext(CognitoResult.Ok);
            }
            catch (Exception e)
            {
                Debug.WriteLine($"VerifyWithCode() threw an exception {e}");
                return new CognitoContext(CognitoResult.Unknown, e.Message);

            }
        }

        //Step 1 in resetting a password
        //Sending a reset request to send a verification code
        public async Task<CognitoContext> ForgotPassword(string userName)
        {
            try
            {
                CognitoUser user = new CognitoUser(userName, Keys.AWS_UsersPool_ClientID, UserPool, awsProvider);
                await user.ForgotPasswordAsync();
                return new CognitoContext(CognitoResult.Ok);

            }
            catch (Exception e)
            {
                return new CognitoContext(CognitoResult.Unknown, e.Message);
            }
            //in case forgot password
        }

        //Step 2 in resetting a password
        //Sending new password along with code and all user data
        public async Task<CognitoContext> ResetPassword(string userName, string code, string newpassword)
        {
            try
            {
                CognitoUser user = new CognitoUser(userName, Keys.AWS_UsersPool_ClientID, UserPool, awsProvider);
                await user.ConfirmForgotPasswordAsync(code, newpassword);
                return new CognitoContext(CognitoResult.Ok);
            }
            catch (Exception e)
            {
                return new CognitoContext(CognitoResult.Unknown, e.Message);
            }

        }

        public async Task<CognitoContext> UpdatePassword(string userName, string newPassword, string sessionId)
        {
            try
            {

                CognitoUser user = new CognitoUser(userName, Keys.AWS_UsersPool_ClientID, UserPool, awsProvider);
                var res = await user.RespondToNewPasswordRequiredAsync(new RespondToNewPasswordRequiredRequest
                {
                    SessionID = sessionId,
                    NewPassword = newPassword
                });

                return new CognitoContext(CognitoResult.Ok);
            }
            catch (Exception e)
            {
                Console.WriteLine($"UpdatePassword() threw an exception {e}");
            }
            return new CognitoContext(CognitoResult.Unknown);
        }



    }
}
