using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Client.Services
{
    public interface ISuperHeroService
    {
        event Action OnChange;

        // Hero 전체 자료
        Task<List<SuperHero>> GetSuperHeroes();
        
        List<SuperHero> Heroes { get; set; }

        // Comic 전체 자료
        List<Comic> Comics { get; set; }

        // Comic 전체 조회
        Task GetComics();

        // Hero 단일 조회
        Task<SuperHero> GetSuperHero(int id);

        // Hero 저장
        Task<List<SuperHero>> CreateSuperHero(SuperHero hero);

        // 수정
        Task<List<SuperHero>> UpdateSuperHero(SuperHero hero,int id);

        // 삭제
        Task<List<SuperHero>> DeleteSuperHero(int id);
    }
}
