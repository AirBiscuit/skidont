using UnityEngine;
using System.Collections;

public class LimbControl : MonoBehaviour
{
    //Specific key is set in the editor based on which limb this script is attached to
    public KeyCode key;
    public float multiplier = 1;

    private Vector2 oldPos;
    private Vector2 velocity;

    // Update is called once per frame
    void Update()
    {
        CalculateMouseMovement();
        if (Input.GetKey(key))
        {
            this.rigidbody2D.AddForce(velocity * multiplier);
        }
    }
    void CalculateMouseMovement()
    {
        velocity = new Vector2(Input.mousePosition.x - oldPos.x, Input.mousePosition.y - oldPos.y);
        oldPos = Input.mousePosition;
    }
}
