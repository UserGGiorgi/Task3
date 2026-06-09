using System.Numerics;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();

app.MapGet("/abesdzegiorgi_gmail_com", (string? x, string? y) =>
{
    if (string.IsNullOrWhiteSpace(x) || string.IsNullOrWhiteSpace(y))
        return Results.Text("NaN");

    if (!BigInteger.TryParse(x.Trim(), out BigInteger a) ||
        !BigInteger.TryParse(y.Trim(), out BigInteger b))
        return Results.Text("NaN");

    if (a <= 0 || b <= 0)
        return Results.Text("NaN");

    BigInteger Gcd(BigInteger m, BigInteger n)
    {
        while (n != 0)
        {
            (m, n) = (n, m % n);
        }
        return m;
    }

    BigInteger gcd = Gcd(a, b);
    BigInteger lcm = (a / gcd) * b;
    return Results.Text(lcm.ToString());
});

app.Run();