using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZombie : MonoBehaviour
{
    [SerializeField]
    Chase c;

    void OnTriggerEnter(Collider collider)
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



    void OnTriggerStay(Collider collider)
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

    void OnTriggerExit(Collider collider)
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
}
