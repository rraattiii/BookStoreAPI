namespace BookStore.Dtos;

public record CreateBookDtos(
    string Name,
    string Genre,
    string Author,
    decimal Price,
    DateOnly PublishDate
);
