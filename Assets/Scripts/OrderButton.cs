using UnityEngine;
using UnityEngine.UI;

public class OrderButton : MonoBehaviour
{
    public GameObject prefab;
    public Transform spawnPosition;

    private void Start()
    {
        // 绑定按钮点击事件
        Button button = GetComponent<Button>();
        button.onClick.AddListener(OnClickButton);
    }

    private void OnClickButton()
    {
        // 在指定位置生成预制体
        Instantiate(prefab, spawnPosition.position, Quaternion.identity);
    }
}

