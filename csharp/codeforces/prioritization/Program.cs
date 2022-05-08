// https://route256.contest.codeforces.com/group/OcTypf5d5d/contest/380037/problem/B

int count = Convert.ToInt32(Console.ReadLine())!;
for (int i = 0; i < count; i++)
{
    int n = Convert.ToInt32(Console.ReadLine()!);
    string[] s = Console.ReadLine()!.Split(' ');
    int[] num = new int [s.Length];
    int[] priority = new int [n];
    int priorityNum = 1;
    for (int j = 0; j < s.Length; j++)
    {
        num[j] = Convert.ToInt32(s[j]);
    }
    int max = num[0];
    foreach (var item in num)
    {
        if (item > max) max = item;
    }
    for (int z = 0; z < n; z++)
    {
        for (int k = 0; k < n; k++)
        {
            if (num[k] == max || num[k] == max - 1) priority[k] = priorityNum;
        }
        int temp = 0;
        foreach (var item in num)
        {
            if (item < (max - 1) && item > temp) temp = item;
        }
        if (max == temp) break;
        max = temp;
        priorityNum ++;
    }
    System.Console.WriteLine(string.Join(' ', priority));
}