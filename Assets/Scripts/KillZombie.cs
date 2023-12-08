using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KillZombie : MonoBehaviour
{
    [SerializeField]
    Chase c;
    [SerializeField]
    AudioSource zombieEating;

    public void Kill(Collider collider)
    {
        if (collider.gameObject.tag == "bullet")
        {
            //Debug.Log("Colliding with bullet");
            c.Kill();
            this.GetComponent<Collider>().enabled = false;
            Destroy(transform.parent.parent.gameObject, 3);
            PlayerAttributes.instance.ChangeScoreBy(1);
        }
    }


    IEnumerator Damage(Collider collider)
    {
        zombieEating.Play();
        while (collider.gameObject.tag == "player")
        {
            PlayerAttributes.instance.ChangeHealthBy(-1);
            yield return new WaitForSeconds(2);
        }
    }

    void OnTriggerEnter(Collider collider)
    {
        Kill(collider);
        StartCoroutine(Damage(collider));
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
