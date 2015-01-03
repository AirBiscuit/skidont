using UnityEngine;
using System.Collections;

public class CloudMovement : MonoBehaviour
{


    public float maxPosition;
    private float amount;
    public float multiplier = 1f;
    // Use this for initialization
    void Start()
    {
        amount = transform.position.z;
    }

    // Update is called once per frame
    void Update()
    {
        transform.Translate(amount * multiplier * Time.deltaTime, 0, 0);
        if (transform.position.x > maxPosition)
        {
            transform.Translate(1.75f * -maxPosition, 0, 0);
        }
        else if (transform.position.x < -maxPosition)
        {
            transform.Translate(1.75f * maxPosition,0,0);
        }
    }
}
