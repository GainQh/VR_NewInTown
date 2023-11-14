using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;

public class ReadingArticle : MonoBehaviour
{
    public GameObject hintPanel;
    public GameObject articlePanel;
    public XRNode inputSource = XRNode.RightHand;
    public bool hideHintOnStart = true;
    private bool isPaused = false;

    private bool isPlayerInRange;
    private bool isInteracting;
    private bool isPanelActive;

    private void Start()
    {
        if (hideHintOnStart)
            hintPanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            hintPanel.gameObject.SetActive(true);
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            hintPanel.gameObject.SetActive(false);
        }
    }

    private void Update()
    {
        InputDevice device = InputDevices.GetDeviceAtXRNode(inputSource);
        bool triggerValue;
        bool primaryValue;
        bool secondaryValue;
        
        if (isPlayerInRange && !isInteracting && device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            isInteracting = true;
            
            if (!isPanelActive)
            {
                articlePanel.gameObject.SetActive(true);
                isPanelActive = true;
            }
            else
            {
                articlePanel.gameObject.SetActive(false);
                isPanelActive = false;
            }
        }

        if (isInteracting && (!device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) || !triggerValue))
        {
            isInteracting = false;
        }
    }
}


