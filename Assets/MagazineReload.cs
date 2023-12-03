using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineReload : MonoBehaviour
{
    [SerializeField]
    VRShoot shoot;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void ReloadGun(Collider other)
    {
        Debug.Log("Detecting reload");
        if (other.tag == "magazine")
        {
            shoot.rounds = 6;
            Destroy(other.gameObject);
            Debug.Log("Reloading magazine");
            //TODO: add sound
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        ReloadGun(other);
    }

    private void OnTriggerStay(Collider other)
    {
        ReloadGun(other);
    }

    private void OnTriggerExit(Collider other)
    {
        ReloadGun(other);
    }
}
