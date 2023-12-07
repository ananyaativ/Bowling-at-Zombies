using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Zombie : MonoBehaviour
{   
    public GameObject zombie;
    public PlayerAttributes player;
    public GameObject cube;

    Vector3[] boundary;

    private int spawnMultiplier = 10;

    // Start is called before the first frame update
    void Start()
    {
        Invoke("SpawnZombie", 1);
        boundary = OVRManager.boundary.GetGeometry(OVRBoundary.BoundaryType.PlayArea);
        Debug.Log("Boundary: " + boundary.Length);
    }

    public void SpawnZombie()
    {
        //Vector3 pos = new Vector3(0, 0, -2);
        Vector3 pos = SpawnPoint();

        Vector3 zPos = Camera.main.transform.forward * 5;
        zPos = Quaternion.AngleAxis(Random.Range(-90, 90), Vector3.up) * zPos;
        Instantiate(zombie, pos, Quaternion.identity);
        if (!player.dead)
        {
            Invoke("SpawnZombie", 3);
        }
            
    }

    Vector3 SpawnPoint()
    {
        //for(int i = 0; i < boundary.Length; i++)
        //{
        //    Instantiate(cube, boundary[i], Quaternion.identity);
        //}

        float n = Random.Range(0.0f, 1.0f);
        int wall = Random.Range(0, boundary.Length);

        Vector3 c1 = boundary[wall];
        Vector3 c2 = boundary[(wall + 1) % boundary.Length];

        Vector3 d = c2 - c1;

        Vector3 spawnPoint = c1 + d.normalized * n * d.magnitude;
        return spawnPoint;
    }

}
