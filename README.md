# Dog Forest

A simple game developed in Unity with C#.

## Description

In this game, the player controls a dog in an enchanted forest. The goal is to guide the dog out of the forest by opening a chest.

### Details:

- **Health Display:** The dog's health is prominently displayed on the interface, starting at "HP: 10". As time progresses, the dog gradually loses health; every 2 seconds, its health decreases by one. The UI continuously updates to reflect the current health status.
- **Game Over Condition:** If the dog's health drops to 0, the game ends. This is visually indicated on the interface, and further movement by the player is disabled to signify the end of the game.
- **Potion Collection:** Throughout the forest, potions are scattered for the player to collect. Each potion collected increases the dog's health by 5 points. Additionally, upon picking up a potion, a new one spawns randomly within the game area to maintain gameplay dynamics.
- **Key Visibility Mechanism:** The key required to open the chest is initially invisible due to a curse. However, by pressing the R key, the player can reveal the key's location for 3 seconds before it disappears again.
- **Chest Opening:** Upon successfully locating and picking up the key with the dog, reaching the chest allows the player to open it. The "Chest open" object replaces the "Chest closed" object, simulating the chest's opening. A victory message is displayed on the interface to indicate that the game has been won.

# Dog Forest Game Manager

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
    // Define variables and references here

    private void Start()
    {
        // Initialize variables and start coroutines
    }

    private IEnumerator ReduceHealth()
    {
        // Coroutine to gradually reduce health over time
    }

    private IEnumerator ShowKey()
    {
        // Coroutine to temporarily reveal the key's location
    }

    private void Update()
    {
        // Update method to handle key visibility
    }

    // Define other methods for potion spawning, key pickup, chest interaction, and game over
}
