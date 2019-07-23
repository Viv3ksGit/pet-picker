using System;
namespace PuppyPicker.ENUMS { 

    public enum ServerReplyStatus
    {
        Success,
        Fail,
        Unknown
    }
    public enum AuthType
    {
        SignUp,
        SignIn,
        ForgotPassword,
        ResetPass,
        RefreshSession
    }
    public enum CognitoResult
    {
        Unknown,
        Ok,
        PasswordChangeRequred,
        SignupOk,
        NotAuthorized,
        Error,
        UserNotFound,
        UserNameAlreadyUsed,
        PasswordRequirementsFailed,
        NotConfirmed,
        InvalidPassword
    }
    public enum SessionStatus
    {
        LoggedOut,
        LoggedInWithActiveSession,
        LoggedInWithExpiredSession
    }

    public enum ServerAction
    {
        UserProfileUpdate,
        DeviceConnect,
        DeviceDelete,
        LoadControllers,
        LoadMacros,
        RecordMacro,
        UpdateMacro,
        DeleteMacro,
        UpdateConfig,
        LoadConfig,
        AddBundle,
        LoadBundle,
        DeleteBundle,
        NullVal
    }

}
