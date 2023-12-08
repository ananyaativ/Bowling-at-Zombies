using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Magazine : MonoBehaviour
{
    public GameObject magazine;
    public PlayerAttributes player;
    public Transform playerPos;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnMagazine", 10);
    }

    public void SpawnMagazine()
    {
        Vector3 pos = playerPos.position + new Vector3(0, -0.25f, 0.25f);

        Instantiate(magazine, pos, Quaternion.identity);
    }
}
