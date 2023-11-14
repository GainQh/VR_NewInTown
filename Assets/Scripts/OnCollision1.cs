using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class OnCollision : MonoBehaviour
{
    private TMP_InputField inputField;
    private void Start()
    {
        // ��ȡTMP_InputField���
        inputField =GetComponent<TMP_InputField>();
    }
    void OnCollisionEnter(Collision other)
    {
        Transform button_transform = other.gameObject.transform.GetChild(0);
        GameObject button = button_transform.gameObject;
        string buttonText = button.GetComponentInChildren<TMP_Text>().text;
        inputField.text = buttonText;
        Destroy(button);
    }
}
