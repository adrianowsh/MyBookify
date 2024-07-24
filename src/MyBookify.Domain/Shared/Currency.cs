﻿namespace MyBookify.Domain.Shared;
public sealed record Currency
{
    public string Code { get; init; }

    internal static readonly Currency None = new("");
    public static readonly Currency Usd = new("USD");
    public static readonly Currency Eur = new("EUR");
    public static readonly Currency Brl = new("BRL");

    private Currency(string code) => Code = code;


    public static Currency FromCode(string code)
    {
        return All.FirstOrDefault(c => c.Code == code) ??
               throw new ApplicationException("The currency code is invalid");
    }

    public static readonly IReadOnlyCollection<Currency> All =
    [
        Usd,
        Eur,
        Brl
    ];
}
