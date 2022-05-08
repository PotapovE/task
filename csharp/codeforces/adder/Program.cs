// https://route256.contest.codeforces.com/group/OcTypf5d5d/contest/380037/problem/A

int n = Convert.ToInt32(Console.ReadLine())!;
for (int i = 0; i < n; i++)
{
    string[] s = Console.ReadLine()!.Split(' ');
    Console.WriteLine(Convert.ToInt32(s[0]) + Convert.ToInt32(s[1]));
}