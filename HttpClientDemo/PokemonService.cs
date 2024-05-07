namespace HttpClientDemo;

public class PokemonService
{
    private readonly HttpClient _client;
    public PokemonService(HttpClient client)
    {
        _client = client;
    }
    public async Task<Pokemon?> GetPokemonAsync(string name)
    {
        var pokemon = await _client.GetFromJsonAsync<Pokemon?>($"pokemon/{name}");
        return pokemon;
    }
}

public class Pokemon
{
    public int Id { get; set; }
    public required string Name { get; set; }
    public double Weight { get; set; }
}
