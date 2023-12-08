using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MagazineReload : MonoBehaviour
{
    [SerializeField]
    VRShoot shoot;
    [SerializeField]
    AudioSource reloadAudio;
    [SerializeField]
    Magazine magazine;

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
        if (other.tag == "magazine")
        {
            shoot.rounds = 10;
            other.GetComponent<OVRGrabbable>().enabled = false;
            Destroy(other.gameObject);
            reloadAudio.Play();
            magazine.Invoke("SpawnMagazine", 10);
        }
    }

    private void OnTriggerStay(Collider other)
    {
        ReloadGun(other);
    }
}
