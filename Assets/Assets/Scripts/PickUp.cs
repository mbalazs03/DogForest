using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUp : MonoBehaviour
{
    private GameObject gm;
    void Start()
    {
        gm = GameObject.Find("Game Manager");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("potion");
        gm.GetComponent<GameManager>().PotionPickedUp();
        Destroy(this.gameObject);
    }
}
