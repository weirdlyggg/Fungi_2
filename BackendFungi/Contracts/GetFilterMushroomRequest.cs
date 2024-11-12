namespace BackendFungi.Contracts;

public record GetFilterMushroomRequest(
    string? PartOfName,
    bool? RedBook,
    string? Eatable,
    bool? HasStem,
    int? StemSizeFrom,
    int? StemSizeTo,
    string? StemType,
    string? StemColor
);
