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
            StartCoroutine(Vibrate(OVRInput.Controller.RTouch));
            StartCoroutine(Vibrate(OVRInput.Controller.LTouch));
            player.RestartGame();
        }
    }

    IEnumerator Vibrate(OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(2.0f, 0.5f, controller);
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(0.0f, 0.0f, controller);
    }
}
