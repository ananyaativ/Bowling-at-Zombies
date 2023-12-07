using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public GameObject magazine;
    public PlayerAttributes player;
    public bool spawn = true;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnMagazine", 10);
    }

    void SpawnMagazine()
    {
        //if (spawn)
        //{
            //Vector3 pos = new Vector3(0, 0, -2);
            Vector3 pos = new Vector3(0, 1, 0);

            Instantiate(magazine, pos, Quaternion.identity);
        Debug.Log("Spawning magazine");
        //}
    }
}
