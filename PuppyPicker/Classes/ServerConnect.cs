using System.Diagnostics;
using System.Threading.Tasks;
using PuppyPicker.Models;
using PuppyPicker.ENUMS;
using Plugin.Toast;
using PuppyPicker.BaseClasses;

namespace PuppyPicker.Classes
{
    public class ServerConnect : BaseVM
    {
        public IApiCognito AuthApi => new ApiCognito();

        public ServerConnect()
        {
            ;
        }

        async public Task<ServerReplyStatus> Connect(UserAuthInfoObject _connectInfo)
        {

            var responseCognito = new CognitoContext();
            var funcReply = ServerReplyStatus.Unknown;
            var connectType = _connectInfo.AuthType;
            string user;
            string pass;

            switch (connectType)
            {
                case AuthType.SignUp:
                    user = _connectInfo.Email.Trim().ToLower();
                    pass = _connectInfo.Password.Trim();
                    responseCognito = await AuthApi.SignUp(user, pass);

                    switch (responseCognito.Result)
                    {
                        case CognitoResult.SignupOk:
                            Debug.WriteLine("Sign up ok");
                            //responseJson = "{\"error\":\"false\",\"message\":\"User_Created\"}";
                            funcReply = ServerReplyStatus.Success;
                            break;
                        case CognitoResult.PasswordRequirementsFailed:
                            Debug.WriteLine("Password requirment failed");
                            await MyApp.MainPage.DisplayAlert("", "Password requirments not fullfilled", "OK");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Pass_Req_Failed\"}";
                            funcReply = ServerReplyStatus.Success;
                            break;
                        case CognitoResult.UserNameAlreadyUsed:

                            Debug.WriteLine("Email exists");
                            await MyApp.MainPage.DisplayAlert("", "Email exists", "OK");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Email_Exist\"}";
                            funcReply = ServerReplyStatus.Success;
                            break;
                        default:
                            Debug.WriteLine($"strange error: {responseCognito.Error}");
                            await MyApp.MainPage.DisplayAlert("Sign up Failed", "Try again", "OK");
                            //responseJson = "{\"error\":\"true\",\"message\":\"" + responseCognito.Error + "\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                    }

                    break;





                case AuthType.SignIn:
                    user = _connectInfo.Email.Trim().ToLower();
                    pass = _connectInfo.Password.Trim();
                    responseCognito = await AuthApi.SignIn(user, pass);
                    Debug.WriteLine($" Reply from aws Auth: {responseCognito.Result} ");
                    switch (responseCognito.Result)
                    {
                        case CognitoResult.Ok:
                            //responseJson = "{\"error\":\"false\",\"message\":\"--\"}";
                            Debug.WriteLine($"From:{this.GetType().Name},Login success");
                           
                            funcReply = ServerReplyStatus.Success;
                            //MyApp.Session.PopulateSession(responseCognito as SignInContext);
                            break;
                        case CognitoResult.NotConfirmed:
                            Debug.WriteLine($"From:{this.GetType().Name},Email not confirmed");
                            await MyApp.MainPage.DisplayAlert("", "Email not confirmed", "OK");
                            //CrossToastPopUp.Current.ShowToastError("Please confirm your email to login");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Email_Not_Activated\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                        case CognitoResult.InvalidPassword:
                            Debug.WriteLine($"From:{this.GetType().Name},Invalid Password");
                            await MyApp.MainPage.DisplayAlert("", "Invalid Password", "OK");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Password_Mismatch\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                        case CognitoResult.UserNotFound:
                            Debug.WriteLine($"From:{this.GetType().Name},Email not found");
                            await MyApp.MainPage.DisplayAlert("", "Email not found", "OK");
                            //responseJson = "{\"error\":\"true\",\"message\":\"Email_Not_Exist\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                        default:
                            Debug.WriteLine($"strange error: {responseCognito.Error}");
                            await MyApp.MainPage.DisplayAlert("Sign in Failed", "Try again", "OK");
                            //responseJson = "{\"error\":\"true\",\"message\":\"" + responseCognito.Error + "\"}";
                            funcReply = ServerReplyStatus.Fail;
                            break;
                    }
                    break;
            }

            return funcReply;
        }
    }
}
