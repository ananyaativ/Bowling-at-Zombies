using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chase : MonoBehaviour
{
    float rotationSpeed = 1;
    Animator anim;
    bool dead = false;

    // Start is called before the first frame update
    void Start()
    {
        anim = this.GetComponent<Animator>();
    }

    public void Kill()
    {
        anim.SetTrigger("hit");
        dead = true;
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
