namespace BackendFungi.Contracts;

public record GetFilterMushroomRequest(
    string? PartOfName,
    bool? Redbook,
    string? Eatable,
    bool? HasStem,
    int? StemSizeFrom,
    int? StemSizeTo,
    string? StemType,
    string? StemColor
);
