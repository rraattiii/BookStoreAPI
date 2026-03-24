namespace BookStore.Dtos;

public record UpdateBookDtos(
    string Name,
    string Genre,
    string Author,
    decimal Price,
    DateOnly PublishDate
);
