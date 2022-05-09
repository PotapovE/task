string token = File.ReadAllText(@"D:\programming\Test\token");
string url = $"https://api.telegram.org/bot{token}/getUpdates";
HttpClient hc = new HttpClient();
string json = hc.GetStringAsync(url).Result;
JsonParse.Init(json);
List<ModelMsg> msgs = JsonParse.Parse();
foreach (var item in msgs)
{
    Console.WriteLine(ModelMsg.ToString(item));
}