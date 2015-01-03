using UnityEngine;
using System.Collections;

public class GameJoltAPIManager : MonoBehaviour
{
    public int gameID = PRIVATE;
    public string privateKey = GETYOUROWNPLEASE;
    public string userName;
    public string userToken;
    public bool IsLoggedIn = false;
    private GJUser CurrentUser;

    void Awake()
    {
        DontDestroyOnLoad(gameObject);
        GJAPI.Init(gameID, privateKey, true, 1);
#if UNITY_EDITOR
        OnGetFromWeb(FillYourOwnName, FillYourOwnKey);
#else
        GJAPIHelper.Users.GetFromWeb(OnGetFromWeb);
#endif
        //GJAPIHelper.Users.DownloadUserAvatar
        if (IsLoggedIn)
        {

        }
    }

    void OnEnable()
    {
        GJAPI.Users.VerifyCallback += OnVerifyUser;

    }

    void OnDisable()
    {
        GJAPI.Users.VerifyCallback -= OnVerifyUser;
    }
    void OnGetFromWeb(string name, string token)
    {
        Debug.Log(name + "@" + token);
        userName = name;
        userToken = token;
        GJAPI.Users.Verify(userName, userToken);
    }

    void OnVerifyUser(bool success)
    {
        if (success)
        {
            IsLoggedIn = true;
            Debug.Log("User " + userName + " verified and logged in.");
            CurrentUser = new GJUser(userName, userToken);

        }
    }
}