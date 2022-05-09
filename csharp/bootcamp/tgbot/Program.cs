string token = File.ReadAllText(@"D:\programming\Test\token");
string url = $"https://api.telegram.org/bot{token}/getUpdates";
HttpClient hc = new HttpClient();
string json = hc.GetStringAsync(url).Result;
JsonParse.Init(json);