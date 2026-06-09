var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/lcm", (string x, string y) =>
{
    if (!long.TryParse(x, out long a) || !long.TryParse(y, out long b) || a <= 0 || b <= 0)
        return "NaN";

    return LCM(a, b).ToString();
});

app.Run();

long GCD(long a, long b)
{
    while (b != 0)
    {
        long t = b;
        b = a % b;
        a = t;
    }
    return a;
}

long LCM(long a, long b)
{
    return (a / GCD(a, b)) * b;
}