using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    float rotationSpeed = 1;
    Animator anim;
    Boolean dead = false;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "sphere")
        {   
            anim.SetTrigger("hit");
            dead = true;
            this.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject,5);
            PlayerAttributes.instance.ChangeScoreBy(1);
        }
        else if (collider.gameObject.tag == "player")
        {
            PlayerAttributes.instance.ChangeHealthBy(-1);
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (dead) return;
        Vector3 direction = Camera.main.transform.position - this.transform.position;
        direction.y = 0;
        this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }
}
