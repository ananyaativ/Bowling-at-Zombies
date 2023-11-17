using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    float rotationSpeed = 1;
    Animator anim;
    Boolean dead = false;
    PlayerAttributes manager;
    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
        manager = GameObject.Find("PlayerAttributes").GetComponent<PlayerAttributes>();
    }

    void OnTriggerEnter(Collider collider)
    {
        if (collider.gameObject.tag == "sphere")
        {   
            anim.SetTrigger("hit");
            dead = true;
            this.GetComponent<Collider>().enabled = false;
            Destroy(this.gameObject,5);
            Debug.Log(manager);
            manager.ChangeScoreBy(1);
        }

        if(collider.gameObject.tag == "player")
        {
            manager.ChangeHealthBy(-1);

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
