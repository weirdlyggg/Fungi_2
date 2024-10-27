namespace BackendFungi.Contracts;

public record MushroomDto(
    string Name,
    string? SynonymousName,
    bool RedBook,
    string Eatable,
    bool HasStem,
    int? StemSizeFrom,
    int? StemSizeTo,
    string? StemType,
    string? StemColor,
    string? Description,
    List<DoppelgangerDto> Doppelgangers
);