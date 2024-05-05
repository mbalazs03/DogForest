using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private TMPro.TextMeshProUGUI gameOverText, healthText;
    private int health = 10;
    private bool keyVisible = false;
    private bool hasKey = false;
    public GameObject potionPrefab;
    public GameObject key;
    public GameObject openChest;
    public GameObject closeChest;

    private void Start()
    {
        Debug.Log("HP: " + health);
        StartCoroutine(ReduceHealth());
        healthText.SetText("HP: " +  health);
        SpawnPotion();
        key.SetActive(false);
        openChest.SetActive(false);
    }

    IEnumerator ReduceHealth()
    {
        while (health > 0)
        {
            yield return new WaitForSeconds(2);
            health--;
            healthText.SetText("HP: " + health);
        }
        GameOver(false);
    }

    IEnumerator ShowKey()
    {
        if (!hasKey)
        {
            key.SetActive(true);
            keyVisible = true;

            yield return new WaitForSeconds(3f);

            key.SetActive(false);
            keyVisible = false;
        }
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.R) && !keyVisible)
        {
            StartCoroutine(ShowKey());
        }
    }

    void SpawnPotion()
    {
        Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 1, Random.Range(-25, 25));
        Instantiate(potionPrefab, randomPosition, Quaternion.identity);
    }

    public void PotionPickedUp()
    { 
        if (health > 0)
        {
            health += 5;
        }
        SpawnPotion();
    }

    public void KeyPickedUp()
    {
        hasKey = true;
    }

    public void OpenChest()
    {
        if (hasKey)
        {
            closeChest.SetActive(false);
            openChest.SetActive(true);
            Debug.Log("You Won!");
            GameOver(true);
        }
    }

    public void GameOver(bool isWin)
    {
        GameObject.FindObjectOfType<PlayerController>().enabled = false;
        gameOverText.gameObject.SetActive(true);
        if (!isWin)
        {
            gameOverText.SetText("Game Over");
        }
        else
        {
            gameOverText.SetText("You Won!");
        }
        Time.timeScale = 0;
    }
}

