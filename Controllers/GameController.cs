using System;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using jogovelha.Service;
using jogovelha.Models;
using jogovelha.Data;

namespace jogovelha.Controllers
{
    [ApiController]
    [Route("")]
    public class GameController : ControllerBase
    {
        [HttpPost]
        [Route("game")]
        public Task<Game> StartGame([FromServices] DataContext context)
        {
            GameService service = new GameService(context);
            var result =  service.StartGame();
            return result;
        }
        
        [HttpPost]
        [Route("game/movement")]
        public Task<ResultDto> MakeMove([FromServices] DataContext context, [FromBody] MovementDto Mov)
        {
            GameService service = new GameService(context, Mov);
            var result = service.MakeMovement(); 
            return result;
        }


        [HttpGet]
        [Route("")]
        public String Get()
        {
            return "Let the Game Begins!";
        }
    }
}
