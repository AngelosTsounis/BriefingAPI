using ApiAggregator.Contracts.Request;
using FluentValidation;

namespace ApiAggregator.Validators;

public class BriefingRequestValidator : AbstractValidator<BriefingRequest>
{
    public BriefingRequestValidator()
    {
        // Validate Weather
        RuleFor(request => request.City)
            .NotNull()
            .NotEmpty()
            .When(request => !request.Latitude.HasValue || !request.Longitude.HasValue)
            .WithMessage("If City is null or empty, both Lat and Lon must have values.");

        RuleFor(request => request.City)
            .Matches("^[A-Za-z ]+$")
            .WithMessage("City must be a valid name and cannot contain numbers or special characters.")
            .When(request => !string.IsNullOrEmpty(request.City));

        RuleFor(request => request.Latitude)
            .NotNull()
            .When(request => request.Longitude.HasValue)
            .WithMessage("Latitude is required when Longitude is provided.");

        RuleFor(request => request.Longitude)
            .NotNull()
            .When(request => request.Latitude.HasValue)
            .WithMessage("Longitude is required when Latitude is provided.");

        RuleFor(request => request.Latitude)
            .InclusiveBetween(-90, 90)
            .When(request => request.Latitude.HasValue)
            .WithMessage("Latitude must be between -90 and 90 degrees.");

        RuleFor(request => request.Longitude)
            .InclusiveBetween(-180, 180)
            .When(request => request.Longitude.HasValue)
            .WithMessage("Longitude must be between -180 and 180 degrees.");

        // Validate News
        RuleFor(x => x.NewsCount)
            .NotNull()
            .NotEmpty()
            .InclusiveBetween(1, 20)
            .WithMessage("NewsCount must be between 1 and 20.");

        // Validate Jokes 
        RuleFor(x => x.JokeLanguage)
            .NotNull()
            .NotEmpty()
            .WithMessage("Language is required.")
            .Must(lang => lang == "en" || lang == "de")
            .WithMessage("Invalid language specified. Language must be either 'en' (English) or 'de' (German).");

        // Validate Forex 
        RuleFor(x => x.SourceCurrency)
            .NotNull()
            .NotEmpty()
            .WithMessage("Currency is required.")
            .Must(code => ValidCurrencyCodes.Contains(code))
            .WithMessage("Invalid currency code for 'Currency'. Please use a valid 3-letter currency code.");

        RuleFor(x => x.TargetCurrency)
            .NotNull()
            .NotEmpty().WithMessage("Source is required.")
            .Must(code => ValidCurrencyCodes.Contains(code))
            .WithMessage("Invalid currency code for 'Source'. Please use a valid 3-letter currency code.");
    }

    private static readonly List<string> ValidCurrencyCodes = 
        [ 
            "AED", "AFN", "ALL", "AMD", "ANG", "AOA", "ARS", "AUD", "AWG", "AZN",
            "BAM", "BBD", "BDT", "BGN", "BHD", "BIF", "BMD", "BND", "BOB", "BRL",
            "BSD", "BTC", "BTN", "BWP", "BYR", "BZD", "CAD", "CDF", "CHF", "CLF",
            "CLP", "CNY", "COP", "CRC", "CUC", "CUP", "CVE", "CZK", "DJF", "DKK",
            "DOP", "DZD", "EGP", "ERN", "ETB", "EUR", "FJD", "FKP", "GBP", "GEL",
            "GGP", "GHS", "GIP", "GMD", "GNF", "GTQ", "GYD", "HKD", "HNL", "HRK",
            "HTG", "HUF", "IDR", "ILS", "IMP", "INR", "IQD", "IRR", "ISK", "JEP",
            "JMD", "JOD", "JPY", "KES", "KGS", "KHR", "KMF", "KPW", "KRW", "KWD",
            "KYD", "KZT", "LAK", "LBP", "LKR", "LRD", "LSL", "LTL", "LVL", "LYD",
            "MAD", "MDL", "MGA", "MKD", "MMK", "MNT", "MOP", "MRO", "MUR", "MVR",
            "MWK", "MXN", "MYR", "MZN", "NAD", "NGN", "NIO", "NOK", "NPR", "NZD",
            "OMR", "PAB", "PEN", "PGK", "PHP", "PKR", "PLN", "PYG", "QAR", "RON",
            "RSD", "RUB", "RWF", "SAR", "SBD", "SCR", "SDG", "SEK", "SGD", "SHP",
            "SLL", "SOS", "SRD", "STD", "SVC", "SYP", "SZL", "THB", "TJS", "TMT",
            "TND", "TOP", "TRY", "TTD", "TWD", "TZS", "UAH", "UGX", "USD", "UYU",
            "UZS", "VEF", "VND", "VUV", "WST", "XAF", "XAG", "XAU", "XCD", "XDR",
            "XOF", "XPF", "YER", "ZAR", "ZMK", "ZMW", "ZWL"
        ];
}
