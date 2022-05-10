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
}