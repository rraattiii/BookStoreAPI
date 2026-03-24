using System;
using BookStore.Dtos;

namespace BookStore.EndPoints;

public static class BooksEndpoints
{
    const string GetBookEndpointName = "GetBook";
    private static readonly List<BookDtos> books = [
    new (
        1, 
        "The Great Gatsby", 
        "F. Scott Fitzgerald", 
        "Novel",
        10.99M, 
        new DateOnly(1925, 4, 10)),
    new (
        2, 
        "To Kill a Mockingbird", 
        "Harper Lee", 
        "Novel",
        8.99M, 
        new DateOnly(1960, 7, 11)),
    new (
        3, 
        "1984", 
        "George Orwell", 
        "Dystopian",
        9.99M, 
        new DateOnly(1949, 6, 8)),
    new (
        4, 
        "Pride and Prejudice", 
        "Jane Austen", 
        "Romance",
        7.99M, 
        new DateOnly(1813, 1, 28)),
    new (
        5, 
        "The Hobbit", 
        "J.R.R. Tolkien", 
        "Fantasy",
        12.99M, 
        new DateOnly(1937, 9, 21))
];

    public static void MapBooksEndpoints(this WebApplication app)
    {
        app.MapGet("/books", () => books);



// GET /books/{id}
app.MapGet("/books/{id}", (int id) => 
{
    var book = books.Find(book => book.Id == id);

    return book is null ? Results.NotFound() : Results.Ok(book);
})
    .WithName(GetBookEndpointName);

//POST /books

app.MapPost("/books", (CreateBookDtos newBook)=>
{
    BookDtos book = new (
        books.Count + 1,
        newBook.Name,
        newBook.Genre,
        newBook.Author,
        newBook.Price,
        newBook.PublishDate
    );

    books.Add(book);
    return Results.CreatedAtRoute(GetBookEndpointName, new { id = book.Id }, book);
});

// PUT /books/{id}
app.MapPut("/books/{id}", (int id, UpdateBookDtos updatedBook) =>
{
    var index = books.FindIndex(book => book.Id == id);

    if (index == -1)
    {
        return Results.NotFound();
    }
    books[index] = new BookDtos(
        id,
        updatedBook.Name,
        updatedBook.Author,
        updatedBook.Genre,
        updatedBook.Price,
        updatedBook.PublishDate
    );

    return Results.NoContent();
});

//Delete /books/{id}
app.MapDelete("/books/{id}", (int id) => 
{
    books.RemoveAll(book => book.Id == id);

    return Results.NoContent();
});

    }
}
