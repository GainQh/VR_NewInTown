using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Text.RegularExpressions;
using System.Threading;
using UnityEngine.XR;

public class DoorInteractor : MonoBehaviour
{

    public float gazeTime = 6f;
    private float timer;
    private bool isGazedAt;
    public XRNode inputSource = XRNode.RightHand;

    public GameObject InteractiveItem1;
    public AudioSource audioSource;

    private bool isTriggered;
     private InputDevice device;
    private bool triggerValue;

    // Use this for initialization
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
        timer = 0f;
        isTriggered = false;
    }

    // Update is called once per frame
    void Update()
    {
        device = InputDevices.GetDeviceAtXRNode(inputSource);
        isTriggered = GazedValue();
        if (isTriggered)
        {
            timer += Time.deltaTime;

            if (timer >= gazeTime && device.TryGetFeatureValue(UnityEngine.XR.CommonUsages.triggerButton, out triggerValue))
            {
                audioSource.Play();
                timer = 0f;
            }
        }
        else
        {
            timer = 0f;
        }
    }
    private bool GazedValue()
    {
        Transform camera = Camera.main.transform;
        Ray ray;
        RaycastHit hit;
        GameObject hitObject;
        ray = new Ray(camera.position, camera.forward);
        if (Physics.Raycast(ray, out hit))
        {
            hitObject = hit.collider.gameObject;
            if (hitObject == InteractiveItem1)
            {
                return true;
            }
        }
        return false;
    }
}
