using UnityEngine;
using TMPro;

public class CheckInputFields : MonoBehaviour
{
    public TMP_InputField[] inputFields;

    // 需要匹配的字符串
    public string correctString = "vrnit";

    // 检查是否与预设字符串匹配
    public void CheckInput()
    {
        string inputText = "";
        foreach (TMP_InputField inputField in inputFields)
        {
            inputText += inputField.text;
        }
        if (inputText == correctString)
        {
            Debug.Log("输入正确");
        }
        else
        {
            Debug.Log("输入不正确");
        }
    }
}