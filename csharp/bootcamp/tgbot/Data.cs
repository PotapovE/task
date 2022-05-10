using Newtonsoft.Json;
public struct Data
{
    static Dictionary<string, List<ModelMsg>> db = new();
    public static void Add(ModelMsg model)
    {
        var id = model.Id;
        if(db.ContainsKey(id))
        {
            db[id].Add(model);
        }
        else
        {
            db.Add(id, new List<ModelMsg>(new ModelMsg[] {model}));
        }
    }
    public static Dictionary<string, List<ModelMsg>> Read()
    {
        return db;
    }
    public static string GetString()
    {
        string data = string.Empty;
        foreach (var item in db)
        {
            data += $"{item.Key} [{string.Join(' ', item.Value)}]\n";
        }
        return data;
    }
    public static void Save()
    {
        File.WriteAllText("data.json", JsonConvert.SerializeObject(db));
    }
    public static void Load()
    {
        
    }
}