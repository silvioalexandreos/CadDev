using CadFuncionario;
using Database;
using System;
using Business;
using Database.Domain.Enum;

namespace Business.Repository
{
    public class FuncaoRepository
    {

        public void SalvarFuncao(Level level)
        {
            var nivel = new Level();

            nivel.Descricao = level.Descricao;
            nivel.VlrHora = level.VlrHora;


            using (var conexao = new Connection())
            {
                conexao.Niveis.Add(level);
                conexao.SaveChanges();
            }
        }
        public void SalvarFuncao(LevelEnum levelEnum, double vlrHora)
        {
            var level = new Level();

            level.Descricao = levelEnum;
            level.VlrHora = vlrHora;


            using (var conexao = new Connection())
            {
                conexao.Niveis.Add(level);
                conexao.SaveChanges();
                Console.WriteLine("Cadastro Salvo com sucesso...");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu incial.");
                Console.ReadLine();
            }
        }
    }
}
