using System;
using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;

namespace jogovelha.Models
{
    public class Game
    {
        [Key]
        public Guid Id
        {
            get { return _id; }
            set { _id = value; }
        } private Guid _id;

        [JsonIgnore]
        public Position Position
        {
            get { return _position; }
            set { _position = value; }
        } private Position _position;
    
        public string NextPlayer
        {
            get { return _nextPlayer; }
            set { _nextPlayer = value; }
        } private string _nextPlayer;

        [JsonIgnore]
        public string Winner
        {
            get { return _winner; }
            set { _winner = value; }
        } private string _winner;

        public Game()
        {
            this.Id = Guid.NewGuid();
            this.NextPlayer =  DateTime.Now.Millisecond % 2 == 0 ? "X" : "O";
            this.Winner = String.Empty;
        }

        public void ChangePlayer()
        {
            this.NextPlayer = this.NextPlayer == "X" ? "O" : "X";
        }

        private static bool IsEqual(string c1, string c2, string c3) {
            return c1.Equals(c2) && c2.Equals(c3);
        }

        public string FindWinner(string[,] Matrix) {
            
            Winner = IsEqual(Matrix[0,0], Matrix[1,0], Matrix[2,0]) ? Matrix[0,0] : Winner;
            Winner = IsEqual(Matrix[0,1], Matrix[1,1], Matrix[2,1]) ? Matrix[0,1] : Winner;
            Winner = IsEqual(Matrix[0,2], Matrix[1,2], Matrix[2,2]) ? Matrix[0,2] : Winner;
            Winner = IsEqual(Matrix[0,0], Matrix[0,1], Matrix[0,2]) ? Matrix[0,0] : Winner;
            Winner = IsEqual(Matrix[1,0], Matrix[1,1], Matrix[1,2]) ? Matrix[1,0] : Winner;
            Winner = IsEqual(Matrix[2,0], Matrix[2,1], Matrix[2,2]) ? Matrix[2,0] : Winner;
            Winner = IsEqual(Matrix[0,0], Matrix[1,1], Matrix[2,2]) ? Matrix[0,0] : Winner;
            Winner = IsEqual(Matrix[0,2], Matrix[1,1], Matrix[2,0]) ? Matrix[0,2] : Winner;
        
            return Winner;
        }

        public bool IsGameDraw(string[,] Matrix) 
        {
            bool Draw = false;

            for(int ln = 0; ln < 3; ln++) 
            {
                for(int cl = 0; cl < 3; cl++) 
                {
                    if (!Matrix[ln,cl].Equals("X") && !Matrix[ln,cl].Equals("O"))
                    {
                        Draw |= true;
                    }
                }
            }

            if (!Draw)
            {
                Winner = "Draw";
            }

            return !Draw;
        }
        
        public bool ValidNextPlayer(string Player){
            return this.NextPlayer.Equals(Player);
        }

    }
}