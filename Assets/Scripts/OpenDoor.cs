using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenDoor : MonoBehaviour
{
    // Start is called before the first frame update
    //public GameObject DoorL;
    //public GameObject DoorR;
    private Animator Gate;

    void Start()
    {
        Gate = GetComponent<Animator>( );
    }

    // Update is called once per frame
    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gate.SetBool("Open", true);
            Gate.SetBool("Close", false);
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            Gate.SetBool("Close", true);
            Gate.SetBool("Open", false);
        }
    }
}
