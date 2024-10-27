using BackendFungi.Contracts;

namespace BackendFungi.Abstractions;

// TODO Этот сервис нужно убрать, а весь его функционал интегрировать в ArticlesService

public interface IFilterArticleService
{
    Task<List<FilterArticleDto>> GetFilterArticlesAsync(GetFilterArticleRequest request,
        CancellationToken ct);
}