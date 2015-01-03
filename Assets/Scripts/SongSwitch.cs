using UnityEngine;
using System.Collections;

public class SongSwitch : MonoBehaviour
{

    public AudioClip bgm;
    public AudioClip gameovermusic;

    void Start()
    {
        this.audio.clip = bgm;
    }

    // Update is called once per frame
    void Update()
    {

    }
    public void ChangeSong()
    {
        Debug.Log("Song stopped");
        this.audio.Stop();
        float time = this.audio.time;
        this.audio.clip = gameovermusic;
        this.audio.Play();
        this.audio.time = time;

    }
}
