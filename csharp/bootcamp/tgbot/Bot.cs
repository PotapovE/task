public struct Bot
{
    static string token;
    static string baseUri;
    static HttpClient hc = new HttpClient();
    // string url = $"https://api.telegram.org/bot{token}/getUpdates";
    // string json = hc.GetStringAsync(url).Result;
    // JsonParse.Init(json);

    public static void Start()
    {
        
        while (true)
        {
            string url = $"{baseUri}getUpdates";
            JsonParse.Init(hc.GetStringAsync(url).Result);
            var r = JsonParse.Parse();
            foreach (var item in r)
            {
                Console.WriteLine(ModelMsg.ToString(item));
                // SendMessage(item.Id, item.MsgText); // ломается из-зи картинки.
            }
            Thread.Sleep(2000);
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