using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReturnGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel1;
    public GameObject panel2;

    public void SwitchPanel()
    {
        panel2.SetActive(false);
        panel1.SetActive(true);
    }
}
