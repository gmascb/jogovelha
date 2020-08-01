using System;
using System.ComponentModel.DataAnnotations;

/* 
vstest.console.exe --settings:C:\Users\Guilherme\Documents\workspace\jogovelha\Tests\Test.RunSettings.xml C:\Users\Guilherme\Documents\workspace\jogovelha\bin\Debug\netcoreapp3.1\jogovelha.dll 
 */

namespace jogovelha.Models
{
    public class Position
    {
        [Key]
        public int Id { get; set; }
        
        public string Matrix { get; set; }

        public Position()
        {
            this.Matrix = "02,12,22|01,11,21|00,10,20"; 
        }

        public void SetMatrix(int x, int y, string Player)
        {
            this.Matrix = this.Matrix.Replace(x.ToString() + y.ToString(), Player);
        }

        public string[,] BuildMatrix()
        {
            string[] lines = this.Matrix.Split("|");
            string[,] result = new string[3,3];

            for (int ln = 0; ln < 3; ln++)
            {
                string[] columns = lines[ln].Split(",");

                result[ln,2] = columns[0];
                result[ln,1] = columns[1];
                result[ln,0] = columns[2];

            }

            return result;
        }

        public string MatrixDrawTrue()
        {
            var Matrix = "";
            Matrix +=  "O,X,O";
            Matrix += "|X,O,X|";
            Matrix +=  "O,X,O";

            return Matrix;
        }

        public string MatrixDrawFalse()
        {
            var Matrix = "";

            Matrix += "02,X,22";
            Matrix +="|O,11,X|";
            Matrix += "00,O,20";
          
            return Matrix;
        }

    }
}