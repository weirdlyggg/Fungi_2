using BackendFungi.Models;

namespace BackendFungi.Abstractions;

public interface IArticlesService
{
    Task<Article> GetArticleAsync(string articleTitle, CancellationToken ct);
    Task<List<Article>> GetAllArticlesAsync(CancellationToken ct);
    
    // TODO Нужно как-то интегрировать фильтрацию статей в этот интерфейс и сервис
    // Task<List<Article>> GetFilteredArticlesAsync(Какие-то параметры, CancellationToken ct);
    
    Task<Guid> CreateArticleAsync(Article article, CancellationToken ct);
    Task<Guid> UpdateArticleAsync(string articleTitle, Article newArticleModel, CancellationToken ct);
    Task<Guid> DeleteArticleAsync(string articleTitle, CancellationToken ct);
}