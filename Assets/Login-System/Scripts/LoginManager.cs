using System;
using System.Collections;
using UnityEngine;
using UnityEngine.Networking;
using TMPro;
using TMPro.EditorUtilities;
using UnityEngine.Serialization;

public class LoginManager : MonoBehaviour
{
    public string uri = "http://localhost/Unitylogin/";

    [SerializeField] private TMP_InputField loginUsername;
    [SerializeField] private TMP_InputField loginPassword;

    [SerializeField] private TMP_InputField registerUsername;
    [SerializeField] private TMP_InputField registerPassword;
    [SerializeField] private TMP_InputField registerEmail;

    private void Start()
    {
        // StartCoroutine(GetData());
        // StartCoroutine(GetUsers());
        //StartCoroutine(RegisterAccount());
    }

    public void UserLogin()
    {
        StartCoroutine(LoginUser());
    }

    public void RegisterUser()
    {
        StartCoroutine(RegisterAccount());
    }

    

    #region Private API Calls

    private IEnumerator GetIndex()
    {
        using (UnityWebRequest req = UnityWebRequest.Get("https://api.dictionaryapi.dev/api/v2/entries/en/hello"))
        {
            //Get back api call
            yield return req.SendWebRequest();
            if (req.result != UnityWebRequest.Result.Success) //failure case
            {
                Debug.Log("Error processing"+ req.error);
            }
            else
            {
                Debug.Log((req.downloadHandler.text));
            }
        }
    }
    
    private IEnumerator GetData()
    {
        using (UnityWebRequest req = UnityWebRequest.Get(uri))
        {
            // Request and wait for the desired page.
            yield return req.SendWebRequest();

            switch (req.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(req.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError( req.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(req.downloadHandler.text);
                    break;

            }
        }
    }

    private IEnumerator GetUsers()
    {using (UnityWebRequest req = UnityWebRequest.Get("http://localhost/Unitylogin/getusers.php"))
        {
            // Request and wait for the desired page.
            yield return req.SendWebRequest();

            switch (req.result)
            {
                case UnityWebRequest.Result.ConnectionError:
                case UnityWebRequest.Result.DataProcessingError:
                    Debug.LogError(req.error);
                    break;
                case UnityWebRequest.Result.ProtocolError:
                    Debug.LogError( req.error);
                    break;
                case UnityWebRequest.Result.Success:
                    Debug.Log(req.downloadHandler.text);
                    break;

            }
        }
    }

    private IEnumerator LoginUser()
    {
        WWWForm form = new WWWForm();
        form.AddField("loginUsername" , loginUsername.text);
        form.AddField("loginPassword" , loginPassword.text);

        using (UnityWebRequest req = UnityWebRequest.Post("http://localhost/Unitylogin/login.php", form))
        {
            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(req.error);
            }
            else  //when result is a success
            {
                Debug.Log(req.downloadHandler.text == "0"
                    ? "Login successful"
                    : "The username or the password doesn't match");
            }
        }
    }

    private IEnumerator RegisterAccount()
    {
        WWWForm form = new WWWForm();
        form.AddField("register_username",registerUsername.text);
        form.AddField("register_password", registerPassword.text);
        form.AddField("register_email",registerEmail.text);
        
        using (UnityWebRequest req = UnityWebRequest.Post("http://localhost/Unitylogin/registerusers.php", form))
        {
            yield return req.SendWebRequest();

            if (req.result == UnityWebRequest.Result.Success)
            {
                Debug.Log(req.downloadHandler.text);
            }
            else
            {
                Debug.Log(("Register Failed "+ req.error));
            }
        }
    }

    #endregion

    #region  Testingregion


    private IEnumerator AddingToDatabase()
    {
        
        WWWForm form = new WWWForm();
        form.AddField("level" , 12);
        form.AddField("score" , 1000000);
        form.AddField("username" , "asd");

        using (UnityWebRequest req = UnityWebRequest.Post("http://localhost/Unitylogin/newtesting.php", form))
        {
            yield return req.SendWebRequest();

            if (req.result != UnityWebRequest.Result.Success)
            {
                Debug.Log(req.error);
            }
            else  //when result is a success
            {
                Debug.Log(req.downloadHandler.text);
            }
        }
    }

    #endregion
}
