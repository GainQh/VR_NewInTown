using UnityEngine;
using UnityEngine.UI;
using UnityEngine.XR;
using TMPro;

public class OrderingFood : MonoBehaviour
{
    public GameObject orderPanel;
    public XRNode inputSource = XRNode.RightHand;
    public bool hideHintOnStart = true;
    private bool isPaused = false;
    private Animator staffAnimator;
    private bool isPlayerInRange;
    private bool isInteracting;
    private bool isPanelActive;

    private void Start()
    {   
        staffAnimator = GetComponentInChildren<Animator>();
        if (hideHintOnStart)
            orderPanel.gameObject.SetActive(false);
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = true;
            orderPanel.gameObject.SetActive(true);

            // 设置触发器参数
            staffAnimator.SetTrigger("isOrdering");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            isPlayerInRange = false;
            orderPanel.gameObject.SetActive(false);
        }
    }
}


