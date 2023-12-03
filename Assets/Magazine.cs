using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public GameObject magazine;
    public PlayerAttributes player;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnMagazine", 10);
    }

    void SpawnMagazine()
    {
        //Vector3 pos = new Vector3(0, 0, -2);
        Vector3 pos = new Vector3(0, 1, 0);

        Instantiate(magazine, pos, Quaternion.identity);
        // TODO: spawn new magazine only after previous one is used
        //if (!player.dead)
        //    Invoke("SpawnMagazine", 10);
    }
}
