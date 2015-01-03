using UnityEngine;
using System.Collections;

public class Snowball : MonoBehaviour
{
    private Vector2 target;
    private Vector2 direction;
    public float Speed = 5;

    public float duration = 1, start = 0;

    void Start()
    {
        if (this.transform.parent != null) //Used to decide whether or not the snowball is a single or part of a cluster
        {
            //Part of a wave
            target = new Vector2(GameObject.FindGameObjectWithTag("Body").transform.position.x, GameObject.FindGameObjectWithTag("Body").transform.position.y);
            direction = new Vector2(target.x - transform.position.x, target.y - transform.position.y);
            rigidbody2D.velocity = direction.normalized * Speed;
        }
        else
        {
            //A single, large snowball
            this.rigidbody2D.mass = 5;
            if (transform.position.x < 0)
                direction = new Vector2(1, 0);
            else direction = new Vector2(-1, 0);

            //The increased speed is needed due to the higher mass.
            rigidbody2D.velocity = direction * Speed * 15;
        }
        
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Limb" || other.gameObject.tag == "Body")
        {
            //Make the alerts disappear by setting their alpha to 0
            GameObject.FindGameObjectWithTag("AlertLeft").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            GameObject.FindGameObjectWithTag("AlertRight").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            Destroy(this.gameObject);
        }
        
    }

    //Unused particle system toggle, unused either because the particles themselves were messy or because it didn't work, I forget which.

    //void showParticles(float start, float duration)
    //{
    //    this.particleSystem.enableEmission = true;
        
    //}
}
