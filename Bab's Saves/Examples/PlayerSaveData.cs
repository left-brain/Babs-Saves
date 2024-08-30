using UnityEngine;

[System.Serializable]
public class PlayerSaveData : ISaveable
{
    // These variables are the onces that get saved
    public int playerHealth;
    public Vector3 playerPosition;

    public void PopulateFromJson(string json)
    {
        // Convert JSON string back to PlayerSaveData object
        JsonUtility.FromJsonOverwrite(json, this);
    }

    public string ToJson()
    {
        // Convert PlayerSaveData object to JSON string
        return JsonUtility.ToJson(this);
    }
}
