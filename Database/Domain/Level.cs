using Database.Domain.Enum;
using System;

namespace Database
{
    public class Level
    {


        public int Id { get; set; }
        public LevelEnum Descricao { get; set; }
        public double VlrHora { get; set; }


        public double ValidaCampoVlrHoras(double vlrHora)
        {
            if (vlrHora < 0) throw new Exception("Digite um valor positivo.");

            return vlrHora;
        }
    }

}