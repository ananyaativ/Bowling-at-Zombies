using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZombie : MonoBehaviour
{
    [SerializeField]
    Chase c;

    public void Kill(Collider collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            Debug.Log("Colliding with bullet");
            c.Kill();
            this.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject, 3);
            PlayerAttributes.instance.ChangeScoreBy(1);
        }
        else if (collider.gameObject.tag == "player")
        {
            PlayerAttributes.instance.ChangeHealthBy(-1);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Kill(collider);
    }

    void OnTriggerStay(Collider collider)
    {
        Kill(collider);
    }

    void OnTriggerExit(Collider collider)
    {
        Kill(collider);
    }
}
