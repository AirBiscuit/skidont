using UnityEngine;
using System.Collections;

public class CameraSway : MonoBehaviour
{
    //This was an unused script that was originally meant to make the camera of the main menu sway around as if it was a camera that someone was holding.
    // However, due to the fact that it was far to jerky when using Linear Interpolation (Lerp) to rotate, I just took it out entirely

    float rotX = 0, rotY = 0, currentRotX, currentRotY;
    int frameDelay = 20;
    // Use this for initialization
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
        if (frameDelay <1)
        {
            frameDelay = 20;
            rotX = Random.Range(-5, 5);
            rotY = Random.Range(-5, 5);
        }
        else frameDelay--;
        
        this.gameObject.transform.rotation = Quaternion.Lerp(this.gameObject.transform.rotation, new Quaternion(rotX / 100, rotY / 100, this.gameObject.transform.rotation.z, this.gameObject.transform.rotation.w), Time.deltaTime);
    }
}
