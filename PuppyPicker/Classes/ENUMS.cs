using System;
using System.Reflection;
using Xamarin.Forms;

namespace PuppyPicker.ENUMS
{

    public enum ServerReplyStatus
    {
        Success,
        Fail,
        UserNameAlreadyUsed,
        PasswordRequirementsFailed,
        NotConfirmed,
        InvalidPassword,
        UserNotFound,
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


    class EnumPicker : Picker
    {
        public static readonly BindableProperty EnumTypeProperty =
            BindableProperty.Create(nameof(EnumType), typeof(Type), typeof(EnumPicker),
                propertyChanged: (bindable, oldValue, newValue) =>
                {
                    EnumPicker picker = (EnumPicker)bindable;

                    if (oldValue != null)
                    {
                        picker.ItemsSource = null;
                    }
                    if (newValue != null)
                    {
                        if (!((Type)newValue).GetTypeInfo().IsEnum)
                            throw new ArgumentException("EnumPicker: EnumType property must be enumeration type");

                        picker.ItemsSource = Enum.GetValues((Type)newValue);
                    }
                });

        public Type EnumType
        {
            set => SetValue(EnumTypeProperty, value);
            get => (Type)GetValue(EnumTypeProperty);
        }
    }
}
