using UnityEngine;
using System.Collections;

public class LimbColission : MonoBehaviour
{
    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Floor")
        {
            GameObject.FindGameObjectWithTag("GameController").GetComponent<GameController>().SetGameOver();
        }
        
    }
}
