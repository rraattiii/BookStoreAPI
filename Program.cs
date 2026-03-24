using BookStore.Dtos;
using BookStore.EndPoints;

var builder = WebApplication.CreateBuilder(args);
var app = builder.Build();


app.MapBooksEndpoints();
app.Run();
