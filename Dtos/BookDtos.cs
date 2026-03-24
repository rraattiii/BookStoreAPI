namespace BookStore.Dtos;
//A Dto is a contract between the client and the server since it represents
//a shared agreement about how data will be transferred and used.
public record BookDtos(
    int Id,
    string Name,
    string Author,
    string Genre,
    decimal Price,
    DateOnly PublishDate
);
