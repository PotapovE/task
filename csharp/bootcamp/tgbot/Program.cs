string token = File.ReadAllText(@"D:\programming\Test\token");



Bot.Init(token);
// Bot.SendMessage("1987135332", "как мороженко?");
Bot.Start();