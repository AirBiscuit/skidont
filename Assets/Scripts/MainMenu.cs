using UnityEngine;
using System.Collections;

public class MainMenu : MonoBehaviour
{
    public GUIStyle ButtonStyle;
    public GUIStyle TextStyle;
    private GameObject GameJoltController;
    private GameObject camera;
    private bool showControls;

    void Start()
    {
        Time.timeScale = 1;
        GameJoltController = GameObject.FindGameObjectWithTag("API");
        camera = GameObject.FindGameObjectWithTag("MainCamera");
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            Application.Quit();
        }

        //Swings the camera around to show a sprite with all the controls
        if (showControls)
        {
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, new Quaternion(0, 180, camera.transform.rotation.z, camera.transform.rotation.w),  1);
        }
        else
        {
            camera.transform.rotation = Quaternion.Slerp(camera.transform.rotation, new Quaternion(0, 0, camera.transform.rotation.z, camera.transform.rotation.w), 100);
        }
    }

    //Legacy GUI, needs to be updated to 4.6's UI system
    void OnGUI()
    {
        GUILayout.BeginArea(new Rect(0, Screen.width/4, Screen.width, Screen.height));
        if (!showControls)
        {
            if (GUILayout.Button("Play", ButtonStyle))
                Application.LoadLevel(2);
            if (GameJoltController.GetComponent<GameJoltAPIManager>().IsLoggedIn)
            {
                if (GUILayout.Button("Leaderboards", ButtonStyle))
                {
                    GJAPIHelper.Scores.ShowLeaderboards();
                }
            }

            if (GUILayout.Button("Controls", ButtonStyle))
                showControls = true;
        }
        else
        {
            if (GUILayout.Button("Return", ButtonStyle))
                showControls = false;
        }

        GUILayout.EndArea();
        GUI.Label(new Rect(0, Screen.height, 200, 50), "@PelagicReactor @iAirBiscuit", TextStyle);
    }

    void OnApplicationQuit()
    {
        PlayerPrefs.Save();
    }
}
