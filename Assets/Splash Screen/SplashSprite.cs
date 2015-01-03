using UnityEngine;
using System.Collections;

public class SplashSprite : MonoBehaviour
{
    SpriteRenderer sprite;
    private float Duration;
    void Start()
    {
        sprite = this.GetComponent<SpriteRenderer>();
        Duration = Time.time + audio.clip.length;
    }

    void Update()
    {
        if (Time.time < 1)
        {
            sprite.color = new Color(1, 1, 1, Mathf.Lerp(0, 1, Time.time));
        }
        else if (Time.time > 4)
        {
            sprite.color = new Color(1, 1, 1, Mathf.Lerp(1, 0, Time.time - 4));
            if (Duration < Time.time)
            {
                Application.LoadLevel(1);
            }

        }

    }
}
