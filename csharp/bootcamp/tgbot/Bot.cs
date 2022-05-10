public struct Bot
{
    static string token = string.Empty;
    static string baseUri = string.Empty;
    static HttpClient hc = new HttpClient();
    public static void BotThread()
    {
        while (true)
        {
            string url = $"{baseUri}getUpdates";
            JsonParse.Init(hc.GetStringAsync(url).Result);
            List<ModelMsg> msgs = JsonParse.Parse();
            foreach (ModelMsg msg in msgs)
            {
                if(!Data.Read().ContainsKey(msg.Id))
                {
                    SendMessage(msg.Id, "Hi");
                }
                else
                {
                    SendMessage(msg.Id, "How a u?");
                }
                Data.Add(msg);
                Thread.Sleep(2000);
            }    
            //Data.Save();       
        }       
    }
    public static void Start()
    {       
        Thread t = new Thread(new ThreadStart(BotThread));
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