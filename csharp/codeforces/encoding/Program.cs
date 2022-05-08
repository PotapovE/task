// See https://route256.contest.codeforces.com/group/OcTypf5d5d/contest/380037/problem/C

int n = Convert.ToInt32(Console.ReadLine()!);
string[] line = Console.ReadLine()!.Split(' ');
int[] delta = new int[n];
for (int i = 0; i < n; i++) delta[i] = Convert.ToInt32(line[i]);
int[] encoding = new int[n + 1];
for (int j = 1; j < n + 1; j++) 
{
    if (encoding[j - 1] - delta[delta.Length - j] < 0)
    {
        encoding[j] = encoding[j - 1];
        encoding[j - 1] = delta[delta.Length - j];
        if (j != 1) for (int k = 0; k < j - 1; k++) encoding[k] += encoding[j - 1];
    }
    else encoding[j] = encoding[j - 1] - delta[delta.Length - j];
}
for (int k = n; k >= 0; k--) Console.Write($"{encoding[k]} ");