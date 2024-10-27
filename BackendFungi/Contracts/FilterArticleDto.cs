namespace BackendFungi.Contracts;

// TODO Этот тип по сути является ArticleDto для общих случаев, поэтому можно его заменить и убрать за ненадобностью

public record FilterArticleDto(Guid Id, string Title, DateTime? PublishDate);