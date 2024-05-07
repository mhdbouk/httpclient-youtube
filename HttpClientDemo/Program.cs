using HttpClientDemo;
using Microsoft.AspNetCore.Mvc;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddTransient<PokemonService>();

builder.Services.AddHttpClient<PokemonService>(client =>
{
    client.BaseAddress = new Uri("https://pokeapi.co/api/v2/");
});

var app = builder.Build();

app.MapGet("/pokemon/{name}",
    async ([FromServices] PokemonService service, string name) =>
    {
        var pokemon = await service.GetPokemonAsync(name);
        return pokemon is null ? Results.NotFound() : Results.Ok(pokemon);
    });

app.Run();
