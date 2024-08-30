public interface ISaveable
{
    void PopulateFromJson(string json);
    string ToJson();
}

