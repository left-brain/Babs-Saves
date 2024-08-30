using UnityEngine;
using System.IO;

public class SaveManager : MonoBehaviour
{
    private string savePath;

    private void Awake()
    {
        savePath = Application.persistentDataPath + "/saveData.json";
    }

    public void Save(ISaveable data)
    {
        string json = data.ToJson();
        File.WriteAllText(savePath, json);
    }

    public void Load(ISaveable data)
    {
        if (File.Exists(savePath))
        {
            string json = File.ReadAllText(savePath);
            data.PopulateFromJson(json);
        }
        else
        {
            Debug.LogWarning("Save file not found.");
        }
    }
}
