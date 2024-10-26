namespace BackendFungi.YuraFolder.Models;

// TODO можно написать дто наподобие GetFilterArticleRequest.cs

public class MushroomsModel
{
    public bool? Redbook { get; set; }
    public string? Eatable { get; set; }
    public bool? HasStem { get; set; }
    public int? StemSizeFrom { get; set; }
    public int? StemSizeTo { get; set; }
    public string? StemType { get; set; }
    public string? StemColor { get; set; }
}