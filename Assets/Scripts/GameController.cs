using UnityEngine;
using System.Collections;

public class GameController : MonoBehaviour
{
    public enum GameState
    {
        MainMenu,
        Paused,
        Starting,
        Playing,
        GameOver
    }

    private GameState gameState;
    public GameObject snowballCluster;
    public GameObject LargeSnowball;
    public GUIStyle Style;
    public GUIStyle timerStyle;

    private bool rightSpawn;

    private float countdown = 2;


    void Start()
    {
        Time.timeScale = 1;
        gameState = GameState.Playing;
    }

    void Update()
    {
        if (countdown <= 0)
        {
            countdown = Random.Range(3, 7);
            PrepareSpawning();
        }
        countdown -= Time.deltaTime;
    }

    public void SetGameOver()
    {
        Time.timeScale = 0;
        GameObject.FindGameObjectWithTag("MainCamera").GetComponent<SongSwitch>().ChangeSong();
        float finalTime = Time.timeSinceLevelLoad;
        float leaderBoardFriendlyScore = finalTime - (finalTime % 1);
        uint leaderBoardScore = (uint)leaderBoardFriendlyScore;
        gameState = GameState.GameOver;

        //Gamejolt bits

        if (GameObject.FindGameObjectWithTag("API").GetComponent<GameJoltAPIManager>().IsLoggedIn)
        {
            GJAPI.Scores.Add(finalTime.ToString(), leaderBoardScore);
        }
    }

    void SpawnSnowballLarge(bool right)
    {
        if (right)
        {
            Instantiate(LargeSnowball, new Vector3(40, -9, 0), this.transform.rotation);
        }
        else Instantiate(LargeSnowball, new Vector3(-40, -9, 0), this.transform.rotation);

    }
    void SpawnSnowballWave(bool right)
    {
        if (right)
        {
            Instantiate(snowballCluster, new Vector3(40, 6, 0), this.transform.rotation);
        }
        else Instantiate(snowballCluster, new Vector3(-40, 6, 0), this.transform.rotation);
    }

    void PrepareSpawning()
    {
        int side = Random.Range(0, 2);
        if (side < 1)
            rightSpawn = true;
        else rightSpawn = false;

        StartCoroutine("FadeIn");
        StartCoroutine("SpawnDelay");
    }

    //Legacy UI, this build of the game was made before 4.6 came out.
    void OnGUI()
    {
        switch (gameState)
        {
            case GameState.Playing:
                {
                    GUILayout.BeginArea(new Rect(0, 0, Screen.width, Screen.height));

                    GUILayout.Label(string.Format("Time {0:f3}", Time.timeSinceLevelLoad), timerStyle);

                    GUILayout.EndArea();
                    break;
                }

            case GameState.GameOver:
                {
                    GUILayout.BeginArea(new Rect(0, 300, Screen.width, Screen.height));

                    GUILayout.Label("Your time: " + Time.timeSinceLevelLoad, Style);
                    GUILayout.Label("-", Style);

                    if (GUILayout.Button("Try Again", Style))
                        Application.LoadLevel(Application.loadedLevel);
                    if (GUILayout.Button("Main menu", Style))
                        Application.LoadLevel(1);
                    GUILayout.EndArea();
                    break;
                }
        }
    }

    //Co-routine to make the alerts on the side of the screen fade in
    IEnumerator FadeIn()
    {
        SpriteRenderer spriteColour;
        if (rightSpawn)
        {
            spriteColour = GameObject.FindGameObjectWithTag("AlertRight").GetComponent<SpriteRenderer>();
        }
        else spriteColour = GameObject.FindGameObjectWithTag("AlertLeft").GetComponent<SpriteRenderer>();

        for (int i = 0; i < 60; i++)
        {
            spriteColour.color = new Color(1, 1, 1, Mathf.Lerp(spriteColour.color.a, 1, 2 * Time.deltaTime));
            yield return null;
        }

    }

    //An unused coroutine to make the alerts fade back out, ditched in favour of letting the snowballs' collision take care of the change
    IEnumerator FadeOut()
    {
        SpriteRenderer spriteColour;
        if (rightSpawn)
        {
            spriteColour = GameObject.FindGameObjectWithTag("AlertRight").GetComponent<SpriteRenderer>();
        }
        else spriteColour = GameObject.FindGameObjectWithTag("AlertLeft").GetComponent<SpriteRenderer>();
        for (float f = 1f; f >= 0; f -= 0.1f)
        {
            Color c = spriteColour.color;
            c.a = f;
            spriteColour.color = c;
            yield return null;
        }
    }
    //D
    IEnumerator SpawnDelay()
    {
        yield return new WaitForSeconds(2);
        int check = Random.Range(0, 2);
        if (check < 1)
        {
            SpawnSnowballLarge(rightSpawn);
        }
        else SpawnSnowballWave(rightSpawn);

    }
}
