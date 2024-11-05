using System.Linq.Expressions;
using BackendFungi.Abstractions;
using BackendFungi.Contracts;
using BackendFungi.Database.Context;
using BackendFungi.Models;
using Microsoft.EntityFrameworkCore;

namespace BackendFungi.Services;

public class ArticlesService : IArticlesService {
    private readonly IArticlesRepository _articlesRepository;
    private readonly FungiDbContext _context;


    public ArticlesService(IArticlesRepository articlesRepository, FungiDbContext context) {
        _articlesRepository = articlesRepository;
        _context = context;
    }

    // Returns an article model based on the article title
    public async Task<Article> GetArticleAsync(string articleTitle, CancellationToken ct) {
        try {
            var articleId = await _articlesRepository.GetArticleId(articleTitle);

            var article = await _articlesRepository.GetArticle(articleId);

            return article;
        }
        catch (Exception e) {
            throw new Exception($"Unable to get article \"{articleTitle}\": \"{e.Message}\"");
        }
    }

    // Returns a list of all article models
    public async Task<List<Article>> GetAllArticlesAsync(CancellationToken ct) {
        try {
            var articles = await _articlesRepository.GetAllArticles();

            return articles;
        }
        catch (Exception e) {
            throw new Exception($"Unable to get articles: \"{e.Message}\"");
        }
    }

    public async Task<List<FilterArticleDto>> GetFilteredArticlesAsync(GetFilterArticleRequest request,
        CancellationToken ct) {
        var filterArticleQuery = _context.Articles
            .Where(a => string.IsNullOrEmpty(request.Search) || a.Title.ToLower().Contains(request.Search.ToLower()));

        filterArticleQuery = request.SortBy?.ToLower() switch {
            "id" => request.SortOrder == "desc"
                ? filterArticleQuery.OrderByDescending(article => article.Id)
                : filterArticleQuery.OrderBy(article => article.Id),

            "title" => request.SortOrder == "desc"
                ? filterArticleQuery.OrderByDescending(article => article.Title)
                : filterArticleQuery.OrderBy(article => article.Title),

            _ => request.SortOrder == "desc"
                ? filterArticleQuery.OrderByDescending(article => article.PublishDate)
                : filterArticleQuery.OrderBy(article => article.PublishDate)
        };

        return await filterArticleQuery
            .Select(a => new FilterArticleDto(a.Id, a.Title, a.PublishDate))
            .ToListAsync(ct);
    }


    // Creates an article and paragraphs for it in the database,
    // returns the id of the created article
    public async Task<Guid> CreateArticleAsync(Article article, CancellationToken ct) {
        try {
            await _articlesRepository.GetArticleId(article.Title);
            throw new Exception($"Article \"{article.Title}\" has already existed");
        }
        catch (Exception e) {
            if (e.Message == $"Article \"{article.Title}\" has already existed") {
                throw new Exception($"Unable to create article \"{article.Title}\": \"{e.Message}\"");
            }

            try {
                var createdArticleId = await _articlesRepository.CreateArticle(article);

                return createdArticleId;
            }
            catch (Exception ex) {
                throw new Exception($"Unable to create article \"{article.Title}\": \"{ex.Message}\"");
            }
        }
    }

    // Changes the article parameters to new ones, returns the id of the changed article
    public async Task<Guid> UpdateArticleAsync(string articleTitle, Article newArticleModel, CancellationToken ct) {
        try {
            var existedArticleId = await _articlesRepository.GetArticleId(articleTitle);

            var updatedArticleId = await _articlesRepository
                .UpdateArticle(existedArticleId, newArticleModel);

            return updatedArticleId;
        }
        catch (Exception e) {
            throw new Exception($"Unable to update article \"{articleTitle}\": \"{e.Message}\"");
        }
    }

    // Deletes an article and returns its id
    public async Task<Guid> DeleteArticleAsync(string articleTitle, CancellationToken ct) {
        try {
            var articleId = await _articlesRepository.GetArticleId(articleTitle);

            var deletedArticleId = await _articlesRepository.DeleteArticle(articleId);

            return deletedArticleId;
        }
        catch (Exception e) {
            throw new Exception($"Unable to delete article \"{articleTitle}\": \"{e.Message}\"");
        }
    }
}