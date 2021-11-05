using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SuperHeroDB.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace SuperHeroDB.Server.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SuperHeroController : ControllerBase
    {
        static List<Comic> comics = new List<Comic>
        {
            new Comic { Id=1, Name = "Marval"  },
            new Comic { Id=2, Name = "DC"}
        };

        static List<SuperHero> heroes = new List<SuperHero>
        {
            new SuperHero {Id = 1, FirstName = "김", LastName = "영목",HeroName="young",Comic=comics[0]},
            new SuperHero {Id = 2, FirstName = "홍", LastName = "길동",HeroName="슈퍼맨",Comic=comics[1]},
            new SuperHero {Id = 3, FirstName = "성", LastName = "춘향",HeroName="슈퍼우먼",Comic=comics[1]}
        };

        [HttpGet("comics")]
        public async Task<IActionResult> GetComics()
        {
            return Ok(comics);
        }

        [HttpGet]
        public async Task<IActionResult> GetSuperHeros()
        {
            //test
            return Ok(heroes);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetSIngleSuperHero(int id)
        {
            var hero = heroes.FirstOrDefault(h => h.Id == id);
            if (hero == null)
                return NotFound("해당 자료가 없습니다...!");
            return Ok(hero);
        }

        [HttpPost]
        public async Task<IActionResult> CreateSuperHero(SuperHero hero)
        {
            hero.Id = heroes.Max(h => h.Id + 1);
            heroes.Add(hero);
            return Ok(heroes);
        }

        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateSuperHero(SuperHero hero,int id)
        {
            var dbHero = heroes.FirstOrDefault(h => h.Id == id);
            if (dbHero == null)
                return NotFound("해당 자료가 없습니다...!");

            var index = heroes.IndexOf(dbHero);
            heroes[index] = hero;
            //dbHero = hero;

            return Ok(heroes);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteSuperHero(int id)
        {
            var dbHero = heroes.FirstOrDefault(h => h.Id == id);
            if (dbHero == null)
                return NotFound("해당 자료가 없습니다...!");

            heroes.Remove(dbHero);
            return Ok(heroes);
        }

    }
}
