string token = File.ReadAllText(@"D:\programming\Test\token");
Bot.Init(token);
Bot.Start();
Console.ReadLine();