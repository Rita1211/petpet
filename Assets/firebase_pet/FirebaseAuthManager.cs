using System.Collections;
using UnityEngine;
using UnityEngine.UI;
using Firebase;
using Firebase.Auth;
using TMPro;

public class FirebaseAuthManager : MonoBehaviour
{
    [Header("Firebase")]
    public DependencyStatus dependencyStatus;
    public FirebaseAuth auth;
    public FirebaseUser user;
    
    [Space]
    [Header("Login")]
    public TMP_InputField emailLoginField;
    public TMP_InputField passwordLoginField;
    
    
    [Space]
    [Header("Registration")]
    public TMP_InputField usernameRegisterField;
    public TMP_InputField emailRegisterField;
    public TMP_InputField passwordRegisterField;
    public TMP_InputField confirmPasswordRegisterField;
   

   private void Awake()
    {
        FirebaseApp.CheckAndFixDependenciesAsync().ContinueWith(task =>
        {
            dependencyStatus = task.Result;

            if(dependencyStatus == DependencyStatus.Available)
            {
                InitializeFirebase();
            }
            else
            {
                Debug.LogError("Could not resolve all Firebase dependencies:" + dependencyStatus);
            }

        });


    }

     void InitializeFirebase()
    {
        auth = FirebaseAuth.DefaultInstance;

       auth.StateChanged += AuthStateChanged;
       AuthStateChanged(this, null);

    }

    void AuthStateChanged(object sender, System.EventArgs eventArgs)
    {
        if(auth.CurrentUser != user)
        {
            bool signedIn = user != auth.CurrentUser && auth.CurrentUser != null;

            if(!signedIn && user != null)
            {
                Debug.Log("Signed out " + user.UserId);
            }
             
            user = auth.CurrentUser;

            if(signedIn)
            {
                Debug.Log("Signed in " + user.UserId);
            }
        }
    }

    public void Login()
    {
        StartCoroutine(LoginAsync(emailLoginField.text, passwordLoginField.text));
    }

    private IEnumerator LoginAsync(string email, string password)
    {
        var loginTask = auth.SignInWithEmailAndPasswordAsync(email, password);

        yield return new WaitUntil(() => loginTask.IsCompleted);


        if(loginTask.Exception != null)
        {
            Debug.LogError(loginTask.Exception);

            FirebaseException firebaseException = loginTask.Exception.GetBaseException() as FirebaseException;
            AuthError authError = (AuthError)firebaseException.ErrorCode;

            string failedMessage = "Login Failed! Because ";

            switch(authError)
            {
                case AuthError.InvalidEmail:
                    failedMessage += "Email is invalid";
                    break;

                case AuthError.WrongPassword:
                    failedMessage += "Wrong Password";
                    break;

                case AuthError.MissingEmail:
                    failedMessage += "Email is missing";
                    break;

                case AuthError.MissingPassword:
                    failedMessage += "Password is missing";
                    break;               

                default:
                    failedMessage += "Login Failed";
                    break;

            }
            
            Debug.Log(failedMessage);
        }
        else
        {
            user = loginTask.Result.User;

            Debug.LogFormat("{0} You Are Successfully Logged In ", user.DisplayName);

            UnityEngine.SceneManagement.SceneManager.LoadScene("ready");
            
        }
    }

    public void Register()
    {
        StartCoroutine(RegisterAsync(usernameRegisterField.text, emailRegisterField.text, passwordRegisterField.text, confirmPasswordRegisterField.text));
    }

    private IEnumerator RegisterAsync(string name, string email, string password, string confirmPassword)
    {
        if(name == "")
        {
            Debug.LogError("User Name is empty");

        }
        else if(email == "")
        {
            Debug.LogError("email field is empty");
        }
        else if(passwordRegisterField.text != confirmPasswordRegisterField.text)
        {
            Debug.LogError("Password does not match");

        }
        else
        {
            var registerTask = auth.CreateUserWithEmailAndPasswordAsync(email, password);

            yield return new WaitUntil(() => registerTask.IsCompleted);

            if(registerTask.Exception != null)
            {
                Debug.LogError(registerTask.Exception);

                FirebaseException firebaseException = registerTask.Exception.GetBaseException() as FirebaseException;
                AuthError authError = (AuthError)firebaseException.ErrorCode;

                string failedMessage = "Register Failed! Because ";
                switch(authError)
                {
                    case AuthError.InvalidEmail:
                        failedMessage += "Email is invalid";
                        break;

                    case AuthError.WrongPassword:
                        failedMessage += "Wrong Password";
                        break;      

                    case AuthError.MissingEmail:
                        failedMessage += "Email is missing";
                        break;
                    
                    case AuthError.MissingPassword:
                        failedMessage += "Password is missing";
                        break;

                    default:
                        failedMessage = "Registration Failed";
                        break;

                }

                Debug.Log(failedMessage);
            }
            else
            {
                user = registerTask.Result.User;

                UserProfile userProfile = new UserProfile { DisplayName = name};

                var updateProfileTask = user.UpdateUserProfileAsync(userProfile);

                yield return new WaitUntil(() => updateProfileTask.IsCompleted);

                if(updateProfileTask.Exception != null)
                {

                    user.DeleteAsync();

                    Debug.LogError(updateProfileTask.Exception);

                    FirebaseException firebaseException = updateProfileTask.Exception.GetBaseException() as FirebaseException;
                    AuthError authError = (AuthError)firebaseException.ErrorCode;


                    string failedMessage = "Profile update Failed! Because ";
                    switch(authError)
                    {
                        case AuthError.InvalidEmail:
                            failedMessage += "Email is invalid";
                            break;

                        case AuthError.WrongPassword:
                            failedMessage += "Wrong Password";
                            break;

                        case AuthError.MissingEmail:
                            failedMessage += "Email is missing";
                            break;

                        case AuthError.MissingPassword:
                            failedMessage += "Password is missing";
                            break;
                         
                        default:
                            failedMessage = "profile update Failed";
                            break;
                    }

                    Debug.Log(failedMessage);
                }
                else
                {
                    Debug.Log("Registration Sucessful Welcome " + user.DisplayName);
                    UIManager.Instance.OpenLoginPanel();
                }


                
            }
        }
    }

}
