namespace GameLog.Public.Host.Contracts;

public record GameLogDto(
    string Title,
    string Comment,
    int Rating
);