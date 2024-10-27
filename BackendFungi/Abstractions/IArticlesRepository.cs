using BackendFungi.Models;

namespace BackendFungi.Abstractions;

public interface IArticlesRepository
{
    Task<Guid> CreateArticle(Article article);
    Task<List<Article>> GetAllArticles();
    Task<Guid> GetArticleId(string articleTitle);
    Task<Article> GetArticle(Guid articleId);
    Task<Guid> UpdateArticle(Guid articleId, Article newArticleModel);
    Task<Guid> DeleteArticle(Guid articleId);
}