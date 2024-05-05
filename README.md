# Dog Forest

A simple game developed in Unity with C# whitin an university project.

### Note:

The C# scripts are located in Assets>Assets>Scripts

## Description

In this game, the player controls a dog in an enchanted forest. The goal is to guide the dog out of the forest by opening a chest.

### Details:

- **Health Display:** The dog's health is prominently displayed on the interface, starting at "HP: 10". As time progresses, the dog gradually loses health; every 2 seconds, its health decreases by one. The UI continuously updates to reflect the current health status.
- **Game Over Condition:** If the dog's health drops to 0, the game ends. This is visually indicated on the interface, and further movement by the player is disabled to signify the end of the game.
- **Potion Collection:** Throughout the forest, potions are scattered for the player to collect. Each potion collected increases the dog's health by 5 points. Additionally, upon picking up a potion, a new one spawns randomly within the game area to maintain gameplay dynamics.
- **Key Visibility Mechanism:** The key required to open the chest is initially invisible due to a curse. However, by pressing the R key, the player can reveal the key's location for 3 seconds before it disappears again.
- **Chest Opening:** Upon successfully locating and picking up the key with the dog, reaching the chest allows the player to open it. The "Chest open" object replaces the "Chest closed" object, simulating the chest's opening. A victory message is displayed on the interface to indicate that the game has been won.

# Game Manager

The `GameManager` script controls various aspects of the Dog Forest game, including health management, potion spawning, key visibility, chest interaction, and game over conditions.

## Functionalities:

- **Health Management:** The script manages the dog's health throughout the game. It initializes the health value, reduces it gradually over time, and updates the health UI accordingly. If the health reaches zero, the game ends.
- **Potion Spawning:** Potions are spawned at random positions within the game area. Upon picking up a potion, the dog's health increases by 5, and a new potion spawns to maintain gameplay.
- **Key Visibility:** The script handles the visibility of the key required to open the chest. By pressing the R key, the player can temporarily reveal the key's location.
- **Chest Interaction:** When the player picks up the key and reaches the chest, the script allows them to open it. Upon opening the chest, the game is won, and the appropriate message is displayed.
- **Game Over Condition:** If the dog's health drops to zero or the player opens the chest without the key, the game ends. The script disables player controls, displays the game over message, and freezes the game.

## Code Sample:

```csharp
using System.Collections;
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

    private IEnumerator ReduceHealth()
    {
        // Gradually reduces the dog's health over time.
        while (health > 0)
        {
            yield return new WaitForSeconds(2);
            health--;
            healthText.SetText("HP: " + health);
        }
        GameOver(false);
    }

    private IEnumerator ShowKey()
    {
        // Temporarily reveals the key's location for 3 seconds when the R key is pressed.
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
        // Checks for the R key press to show the key temporarily.
        if (Input.GetKeyDown(KeyCode.R) && !keyVisible)
        {
            StartCoroutine(ShowKey());
        }
    }

    private void SpawnPotion()
    {
        // Spawns a potion at a random position within the game area.
        Vector3 randomPosition = new Vector3(Random.Range(-25, 25), 1, Random.Range(-25, 25));
        Instantiate(potionPrefab, randomPosition, Quaternion.identity);
    }

    public void PotionPickedUp()
    {
        // Increases the dog's health by 5 upon picking up a potion and spawns a new potion.
        if (health > 0)
        {
            health += 5;
        }
        SpawnPotion();
    }

    public void KeyPickedUp()
    {
        // Sets the flag indicating that the key has been picked up.
        hasKey = true;
    }

    public void OpenChest()
    {
        // Opens the chest if the player has the key, displays victory message, and ends the game.
        if (hasKey)
        {
            closeChest.SetActive(false);
            openChest.SetActive(true);
            Debug.Log("You Won!");
            GameOver(true);
        }
    }

    private void GameOver(bool isWin)
    {
        // Ends the game and displays the appropriate message.
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
```

## Notes:
- Ensure that all required GameObjects and UI elements are correctly assigned in the Unity Editor for proper functionality.

# Player Controller

The `PlayerController` script handles player movement and jumping in the Dog Forest game.

## Functionalities:

- **Movement:** Allows the player to move horizontally and vertically using the arrow keys or the WASD keys.
- **Rotation:** Rotates the player character smoothly towards the direction of movement.
- **Jumping:** Enables the player to jump by pressing the spacebar key. The player can perform a jump once every specified duration.
- **Animation:** Controls the player character's animation states based on movement and jumping actions.

# PickUp

The `PickUp` script handles the interaction between the player and pickable items in the Dog Forest game.

## Functionalities:

- **Trigger Detection:** Detects when the player collides with pickable items.
- **Interaction:** Triggers an action in the GameManager script when the player picks up an item.

## Code Sample:

```csharp
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
        gm.GetComponent<GameManager>().PotionPickedUp();
        Destroy(gameObject);
    }
}
```

# KeyPickUp

The `KeyPickUp` script handles the interaction between the player and the key in the Dog Forest game.

## Functionalities:

- **Trigger Detection:** Detects when the player collides with the key.
- **Interaction:** Triggers an action in the GameManager script when the player picks up the key.

## Code Sample:

```csharp
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
        gm.GetComponent<GameManager>().KeyPickedUp();
        gameObject.SetActive(false);
    }
}
```

# Chest

The `Chest` script handles the interaction between the player and the chest in the Dog Forest game.

## Functionalities:

- **Trigger Detection:** Detects when the player stays within the trigger area of the chest.
- **Interaction:** Allows the player to open the chest by pressing the E key.

## Code Sample:

```csharp
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
```

