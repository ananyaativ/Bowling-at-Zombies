using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    Rigidbody rb;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        StartCoroutine(Predict());
    }

    private void FixedUpdate()
    {
        StartCoroutine(Predict());
    }

    IEnumerator Predict()
    {
        Vector3 prediction = transform.position + rb.velocity * Time.fixedDeltaTime;

        RaycastHit hit;
        int layerMask =~ LayerMask.GetMask("Bullet");
        Debug.DrawLine(transform.position, prediction);

        if (Physics.Linecast(transform.position, prediction, out hit, layerMask))
        {
            Debug.Log("Predicting");
            transform.position = hit.point;
            rb.collisionDetectionMode = CollisionDetectionMode.ContinuousSpeculative;
            rb.isKinematic = true;
            yield return 0;
            OnTriggerEnterFixed(hit.collider);
        }
    }

    void OnTriggerEnterFixed(Collider other)
    {
        if (other.CompareTag("zombie"))
        {
            Destroy(gameObject);
            other.gameObject.GetComponent<KillZombie>().Kill(this.GetComponent<Collider>());
        }
    }
}
