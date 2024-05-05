using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Chest : MonoBehaviour
{
    private GameObject gm;
    void Start()
    {
        gm = GameObject.Find("Game Manager");
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("Player") && Input.GetKeyDown(KeyCode.E))
        {
            gm.GetComponent<GameManager>().OpenChest();
        }
    }
}
