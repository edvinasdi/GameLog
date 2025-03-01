namespace GameLog.Domain.Contracts;

public record GameLog(
    string Title,
    string Comment,
    int Rating
);