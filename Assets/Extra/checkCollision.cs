using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class checkCollision : MonoBehaviour
{
    // Start is called before the first frame update
    Rigidbody rb;
    float rotationSpeed = 1;
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 direction = Camera.main.transform.position - rb.position;
        direction.y = 0;
        rb.rotation = Quaternion.Slerp(rb.rotation, Quaternion.LookRotation(direction), rotationSpeed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.collider);
    }
}
