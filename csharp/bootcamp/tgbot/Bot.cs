public struct Bot
{
    static string token = string.Empty;
    static string baseUri = string.Empty;
    static HttpClient hc = new HttpClient();
    public static void Start()
    {       
        while (true)
        {
            string url = $"{baseUri}getUpdates";
            JsonParse.Init(hc.GetStringAsync(url).Result);
            List<ModelMsg> msgs = JsonParse.Parse();
            foreach (ModelMsg msg in msgs)
            {
                Data.Add(msg);
                Thread.Sleep(2000);
            }            
        }       
    }
    public static void Init(string publicToken)
    {
        token = publicToken;
        baseUri = $"https://api.telegram.org/bot{token}/";
    }
    public static void SendMessage(string id, string txt)
    {
        string url = $"{baseUri}sendMessage?chat_id={id}&text={txt}";
        var req = hc.GetStringAsync(url).Result;
    }
}