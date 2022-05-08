// See https://api.telegram.org/bot<token>/getUpdates
// https://api.telegram.org/bot<token>/sendMessage?chat_id=1852284449&text=How%20are%20u?

using Newtonsoft.Json.Linq;

string url = "https://api.telegram.org/bot<token>/getUpdates";
HttpClient hc = new HttpClient();
string res = hc.GetStringAsync(url).Result;
JObject resultReq = JObject.Parse(res);
JToken result = resultReq["result"]!;

foreach (var item in result)
{
    string fName = item["message"]!["from"]!["first_name"]!.ToString();
    string text = item["message"]!["text"]!.ToString();
    Console.WriteLine($"{fName}: {text}");
}