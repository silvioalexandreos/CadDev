using Database.Domain.Enum;
using System;

namespace Database
{
    public class Level
    {


        public int Id { get; set; }
        public LevelEnum Descricao { get; set; }
        public double VlrHora { get; set; }



        //public string ValidaCampoDescricao(LevelEnum descricao)
        //{
        //    if (string.IsNullOrEmpty(descricao)) throw new Exception("Preencha o campo descrição corretamente.");

        //    return descricao;
        //}

        //public double ValidaCampoVlrHoras(double vlrHora)
        //{
        //    if (vlrHora < 0) throw new Exception("Digite um valor positivo.");

        //    return vlrHora;
        //}
    }
    
}