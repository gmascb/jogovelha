using System;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using jogovelha.Models;
using jogovelha.Data;


namespace jogovelha.Service
{
    public class GameService
    {   
        public DataContext  DataContext
        {
            get { return _dtCxt; }
            set { _dtCxt = value; }
        } private DataContext _dtCxt;
        
        public MovementDto MovementDto
        {
            get { return _mvDto; }
            set { _mvDto = value; }
        } private MovementDto _mvDto;
        
        public ResultDto ResultDTO
        {
            get { 
                    if (_resultDto == null)
                    {
                        _resultDto = new ResultDto();
                    }

                    return _resultDto; 
                }
            set { _resultDto = value; }
        } private ResultDto _resultDto;

        public GameService(DataContext DataContext)
        {  
            this.DataContext = DataContext;
            this.MovementDto = new MovementDto();
        }        

        public GameService(DataContext DataContext, MovementDto MovementDto)
        {
            this.DataContext = DataContext;
            this.MovementDto = MovementDto;
        }

        private void setResultDtoMovement()
        {
            ResultDTO.msg = "Movement registred";
            ResultDTO.winner = String.Empty;
        }

        private void setResultDtoDraw()
        {
            ResultDTO.msg = "Game Finished!";
            ResultDTO.winner = "Draw";
        }

        private void setResultDtoWinner(string winner)
        {
            ResultDTO.msg = "Game Finished!";
            ResultDTO.winner = winner;
        }

        private void setResultDtoWrongPlayer()
        {
            ResultDTO.msg = "It is not the player's turn";
            ResultDTO.winner = String.Empty;
        }

        private void setResultDtoGameNotFound()
        {
            ResultDTO.msg = "Game not found.";
            ResultDTO.winner = String.Empty;
        }

        public async Task<Game> StartGame()
        {
            Game Game = new Game();
            Position Position = new Position();
            
            Game.Position = Position;
            
            DataContext.Game.Add(Game);
            DataContext.Game.Include(p => p.Position);

            await DataContext.SaveChangesAsync();

            return Game;
        }

        public async Task<ResultDto> MakeMovement()
        {
            var Game = await DataContext.Game.Include(x => x.Position).FirstOrDefaultAsync(x => x.Id == MovementDto.id);

            if (Game == null)
            {
                setResultDtoGameNotFound();
                return ResultDTO;
            }

            if (!Game.ValidNextPlayer(MovementDto.player))
            {
                setResultDtoWrongPlayer();
                return ResultDTO;
            }

            Game.Position.SetMatrix(MovementDto.position.x, MovementDto.position.y, MovementDto.player);
            Game.ChangePlayer();

            if (Game.IsGameDraw(Game.Position.BuildMatrix()))
            {
                setResultDtoDraw();
                return ResultDTO;
            }

            Game.FindWinner(Game.Position.BuildMatrix());

            if (!String.IsNullOrEmpty(Game.Winner))
            {
                setResultDtoWinner(Game.Winner);
            }
            else
            {
                setResultDtoMovement();
            }

            DataContext.SaveChanges();

            return ResultDTO;
        }
    }
}