using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{   public GameObject zombie;
    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnZombie", 1);
    }

    void SpawnZombie()
    {
        Vector3 zPos = Camera.main.transform.forward *10;
        zPos.y = 0;
        Instantiate(zombie, zPos, Quaternion.identity);
        Invoke("SpawnZombie", Random.Range(1, 5));
    }
    // Update is called once per frame
    void Update()
    {
        
    }
}
