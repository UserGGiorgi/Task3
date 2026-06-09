var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/abesdzegiorgi_gmail_com", (string x, string y) =>
{
    if (!long.TryParse(x, out long a) ||
        !long.TryParse(y, out long b) ||
        a <= 0 || b <= 0)
    {
        return Results.Text("NaN");
    }

    long Gcd(long m, long n)
    {
        while (n != 0)
        {
            (m, n) = (n, m % n);
        }
        return m;
    }

    long lcm = (a / Gcd(a, b)) * b;

    return Results.Text(lcm.ToString());
});

app.Run();