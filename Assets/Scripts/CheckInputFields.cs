using UnityEngine;
using TMPro;

public class CheckInputFields : MonoBehaviour
{
    public TMP_InputField[] inputFields;

    // ��Ҫƥ����ַ���
    public string correctString = "vrnit";

    // ����Ƿ���Ԥ���ַ���ƥ��
    public void CheckInput()
    {
        string inputText = "";
        foreach (TMP_InputField inputField in inputFields)
        {
            inputText += inputField.text;
        }
        if (inputText == correctString)
        {
            Debug.Log("������ȷ");
        }
        else
        {
            Debug.Log("���벻��ȷ");
        }
    }
}