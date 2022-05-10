using Newtonsoft.Json.Linq;
public struct JsonParse
{
    static string json = string.Empty;
    public static void Init (string jsonString)
    {
        json = jsonString;
    }
    public static List<ModelMsg> Parse ()
    {
        List<ModelMsg> msg = new();
        JObject resultReq = JObject.Parse(json);
        JToken result = resultReq["result"]!;
        ModelMsg mMsg = new();
        foreach (var item in result)
        {
            mMsg.FirstName = item["message"]!["from"]!["first_name"]!.ToString();
            mMsg.MsgText = item["message"]!["text"]!.ToString();
            mMsg.Id = item["message"]!["from"]!["id"]!.ToString();
            mMsg.UpdateId = item["update_id"]!.ToString();
            msg.Add(mMsg);
        }
        return msg;
    }
}