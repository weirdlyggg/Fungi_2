namespace BackendFungi.Contracts;

// TODO возможно чтобы не плодить типы данных функция может просто возвращать список Dto и этот тип данных можно удалить за ненадобностью
public record GetFilterArticleResponse(List<FilterArticleDto> FilterArticleDtos);