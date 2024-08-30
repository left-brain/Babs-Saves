using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerSaveData playerData; // Reference to the save data

    private void Start()
    {
        // Initialize or load playerData
        playerData = new PlayerSaveData();
        LoadPlayerData(); // Load saved data when the game starts
    }

    private void Update()
    {
        // Example: Modify player health and position
        if (Input.GetKeyDown(KeyCode.Space))
        {
            playerData.playerHealth -= 10;
            playerData.playerPosition += Vector3.right * 2f;
            SavePlayerData(); // Save data when player presses Space key

            // Move the player GameObject to the updated player position
            transform.position = playerData.playerPosition;
        }
    }

    private void SavePlayerData()
    {
        // Save playerData using SaveManager
        SaveManager saveManager = FindObjectOfType<SaveManager>();
        if (saveManager != null)
        {
            saveManager.Save(playerData);
            Debug.Log("Player data saved.");
        }
        else
        {
            Debug.LogWarning("SaveManager not found in the scene.");
        }
    }

    private void LoadPlayerData()
    {
        // Load playerData using SaveManager
        SaveManager saveManager = FindObjectOfType<SaveManager>();
        if (saveManager != null)
        {
            saveManager.Load(playerData);
            Debug.Log("Player data loaded.");

            // Move the player GameObject to the loaded player position
            transform.position = playerData.playerPosition;
        }
        else
        {
            Debug.LogWarning("SaveManager not found in the scene.");
        }
    }
}
