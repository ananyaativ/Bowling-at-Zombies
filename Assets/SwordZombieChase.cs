using Oculus.Interaction.Body.Input;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordZombieChase : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    bool isCollided;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
       
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.main.transform.position - rb.position;
        direction.y = 0;
        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(direction), 1 * Time.deltaTime);
        if(isCollided)
            rb.velocity = transform.forward*2;
    }
    private void OnCollisionEnter(Collision collision)
    {
        //debug.log("collided with: " + collision.collider);
        isCollided = true;

    }
}
