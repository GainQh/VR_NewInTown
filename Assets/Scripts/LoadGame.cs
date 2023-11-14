using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LoadGame : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject panel1;
    public GameObject panel2;
    public void SwitchPanel()
    {
        panel1.SetActive(false);
        panel2.SetActive(true);
    }

}
