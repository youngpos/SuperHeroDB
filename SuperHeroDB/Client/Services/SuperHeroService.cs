using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Json;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public class SuperHeroService : ISuperHeroService
    {
        private readonly HttpClient _httpClient;

        // 생성자
        public SuperHeroService(HttpClient httpClient)
        {
            _httpClient = httpClient;
        }

        public List<SuperHero> Heroes { get; set; } = new List<SuperHero>();
        public List<Comic> Comics { get; set; } = new List<Comic>();

        public event Action OnChange;



        // 자료 최초 생성
        public async Task<List<SuperHero>> CreateSuperHero(SuperHero hero)
        {
            var result = await _httpClient.PostAsJsonAsync<SuperHero>($"api/superhero", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            OnChange.Invoke();
            return Heroes;

        }

        public async Task<List<SuperHero>> DeleteSuperHero(int id)
        {
            var result = await _httpClient.DeleteAsync($"api/superhero/{id}");
            Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            OnChange.Invoke();
            return Heroes;

        }

        public async Task GetComics()
        {
            Comics =  await _httpClient.GetFromJsonAsync<List<Comic>>("api/superhero/comics");
        }


        // 단일 조회
        public async Task<SuperHero> GetSuperHero(int id)
        {
            return await _httpClient.GetFromJsonAsync<SuperHero>($"api/superhero/{id}");
        }

        // 전체 조회
        public async Task<List<SuperHero>> GetSuperHeroes()
        {
            Heroes =  await _httpClient.GetFromJsonAsync<List<SuperHero>>("api/superhero");
            return Heroes;
        }

        public async Task<List<SuperHero>> UpdateSuperHero(SuperHero hero, int id)
        {
            var result = await _httpClient.PutAsJsonAsync($"api/superhero/{id}", hero);
            Heroes = await result.Content.ReadFromJsonAsync<List<SuperHero>>();
            OnChange.Invoke();
            return Heroes;

        }
    }
}
