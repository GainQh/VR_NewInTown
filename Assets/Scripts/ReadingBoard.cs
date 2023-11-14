using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;
using System.Collections.Generic;

public class ReadingBoard : MonoBehaviour
{
    public GameObject hintPanel;
    public TextMeshProUGUI boardText;
    public List<string> sayingsLibrary;
    public GameObject boardPanel;
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
        
        if (isPlayerInRange && !isInteracting && device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) && triggerValue)
        {
            isInteracting = true;
            
            if (!isPanelActive)
            {
                // 随机选择一个字符串
                string randomSaying = sayingsLibrary[Random.Range(0, sayingsLibrary.Count)];
                boardText.text = randomSaying;
                
                boardPanel.gameObject.SetActive(true);
                isPanelActive = true;
            }
            else
            {
                boardPanel.gameObject.SetActive(false);
                isPanelActive = false;
            }
        }

        if (isInteracting && (!device.TryGetFeatureValue(CommonUsages.triggerButton, out triggerValue) || !triggerValue))
        {
            isInteracting = false;
        }
    }
}



