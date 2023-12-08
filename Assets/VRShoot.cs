using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VRShoot : MonoBehaviour
{
    public SimpleShoot simpleShoot;
    public int rounds = 10;

    [SerializeField]
    AudioSource bulletAudio;
    [SerializeField]
    AudioSource emptyAudio;

    private OVRGrabbable grabbable;

    // Start is called before the first frame update
    void Start()
    {
        grabbable = GetComponent<OVRGrabbable>();
    }

    // Update is called once per frame
    void Update()
    {
        if (OVRInput.GetActiveController() == OVRInput.Controller.Touch)
        {
            Debug.Log("Shoot grabber: " + grabbable.isGrabbed);
            if (grabbable.isGrabbed)
            {
                OVRGrabber grabber = grabbable.grabbedBy;
                if (grabber.GetController() == OVRInput.Controller.RTouch && OVRInput.GetDown(OVRInput.Button.SecondaryIndexTrigger))
                {
                    Shoot(grabber.GetController());
                } else if (grabber.GetController() == OVRInput.Controller.LTouch && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
                {
                    Shoot(grabber.GetController());
                }
            }
        } else
        {
            if (grabbable.isGrabbed && OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger))
            {
                OVRGrabber grabber = grabbable.grabbedBy;
                Shoot(grabber.GetController());
            }
        }
        
    }

    void Shoot(OVRInput.Controller controller)
    {
        if (rounds > 0)
        {
            rounds -= 1;
            Debug.Log("Shooting");
            simpleShoot.StartShoot();
            bulletAudio.Play();
            StartCoroutine(Vibrate(controller));
        }
        else
        {
            emptyAudio.Play();
        }
    }

    IEnumerator Vibrate(OVRInput.Controller controller)
    {
        OVRInput.SetControllerVibration(2.0f, 0.5f, controller);
        yield return new WaitForSeconds(0.5f);
        OVRInput.SetControllerVibration(0.0f, 0.0f, controller);
    }
}
