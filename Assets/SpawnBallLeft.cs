using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnBallLeft : MonoBehaviour
{
    public GameObject prefab;
    public float spawnSpeed = 5;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
        {
            GameObject spawnBall = Instantiate(prefab, transform.position, Quaternion.identity);
            Rigidbody spawnedBallRB = spawnBall.GetComponent<Rigidbody>();
            spawnedBallRB.velocity = transform.forward * spawnSpeed;
            Destroy(spawnBall, 10);
        }
    }
}
