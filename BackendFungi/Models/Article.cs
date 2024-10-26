using BackendFungi.Contracts;

namespace BackendFungi.Models;

public class Article
{
    public const int MaxTitleLength = 255;

    private Article(Guid id, string title, DateTime? publishDate, List<Paragraph> paragraphs)
    {
        Id = id;
        Title = title;
        PublishDate = publishDate;
        Paragraphs = paragraphs;
    }

    public Guid Id { get; }
    public string Title { get; }
    public DateTime? PublishDate { get; }
    public List<Paragraph> Paragraphs { get; }

    private static string ArticleBasicChecks(string title, DateTime? publishDate, 
        List<ParagraphDto>? paragraphsDto = null, List<Paragraph>? paragraphs = null)
    {
        if (paragraphsDto is null && paragraphs is null)
        {
            throw new ArgumentException("At least one type of paragraph list is required");
        }
        
        var error = string.Empty;

        if (string.IsNullOrEmpty(title) || title.Length > MaxTitleLength)
        {
            error = $"Title can't be longer than {MaxTitleLength} characters or empty";
        }
        else if (publishDate > DateTime.Now)
        {
            error = "Publish date can't be from the future";
        }
        else if ((paragraphsDto is not null && paragraphsDto.Count == 0) ||
                 (paragraphs is not null && paragraphs.Count == 0))
        {
            error = "The article must contain paragraphs";
        }

        return error;
    }

    public static (Article Article, string Error)
        Create(Guid id, string title, DateTime? publishDate, List<ParagraphDto> paragraphs)
    {
        var error = ArticleBasicChecks(title, publishDate, paragraphsDto: paragraphs);
        
        var universalPublishDate = publishDate?.ToUniversalTime() ?? DateTime.Now.ToUniversalTime();
        
        var paragraphList = new List<Paragraph>();
        for (var i = 0; i < paragraphs.Count; i++)
        {
            var (p, e) = Paragraph.Create(Guid.NewGuid(), id, paragraphs[i].ParagraphText, i);

            if (!string.IsNullOrEmpty(e))
            {
                if (string.IsNullOrEmpty(error))
                {
                    error = $"One of the paragraphs caused an error \"{e}\"";
                }
            }
            
            paragraphList.Add(p);
        }

        var article = new Article(id, title, universalPublishDate, paragraphList);

        return (article, error);
    }
    
    public static (Article Article, string Error)
        Create(Guid id, string title, DateTime? publishDate, List<Paragraph> paragraphs)
    {
        var error = ArticleBasicChecks(title, publishDate, paragraphs: paragraphs);
        
        var universalPublishDate = publishDate?.ToUniversalTime() ?? DateTime.Now.ToUniversalTime();

        var article = new Article(id, title, universalPublishDate, paragraphs);

        return (article, error);
    }
}