using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartButton : MonoBehaviour
{
    public PlayerAttributes player;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.name == "RightHandAnchor" || other.name == "LeftHandAnchor")
        {
            Debug.Log("Button!");
            player.RestartGame();
        }
    }
}
