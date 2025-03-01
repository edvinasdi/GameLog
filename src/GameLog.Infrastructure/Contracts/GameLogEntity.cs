namespace GameLog.Infrastructure.Contracts;

public record GameLogEntity(
    string Title,
    string Comment,
    int Rating
);