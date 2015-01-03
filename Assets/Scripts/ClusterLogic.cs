using UnityEngine;
using System.Collections;

public class ClusterLogic : MonoBehaviour
{

    void Update()
    {
        if (this.transform.childCount == 0)
        {
            GameObject.FindGameObjectWithTag("AlertLeft").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            GameObject.FindGameObjectWithTag("AlertRight").GetComponent<SpriteRenderer>().color = new Color(1, 1, 1, 0);
            Destroy(this.gameObject);
        }
    }
}
