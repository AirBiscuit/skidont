using UnityEngine;
using System.Collections;

public class SkateSound : MonoBehaviour
{
    private float vel;

    void OnCollisionStay2D()
    {
        //Determines whether or not to play the ice sound effect, and sets it's volume based on how fast the skate is moving along the ice
        if (!this.gameObject.audio.isPlaying)
        {
            this.gameObject.audio.Play();
        }

        vel = this.rigidbody2D.velocity.x;
        if (vel < 0)
            vel *= -1;

        vel /= 10;

        this.gameObject.audio.volume = vel;
    }

    void OnCollisionExit2D()
    {
        if (this.gameObject.audio.isPlaying)
        {
            this.gameObject.audio.Stop();
        }
    }
}
