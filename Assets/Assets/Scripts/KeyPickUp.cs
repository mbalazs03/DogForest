using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyPickUp : MonoBehaviour
{
    private GameObject gm;
    void Start()
    {
        gm = GameObject.Find("Game Manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("key");
        gm.GetComponent<GameManager>().KeyPickedUp();
        this.gameObject.SetActive(false);
    }
}
