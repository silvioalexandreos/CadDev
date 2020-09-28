using System;
using System.Security.Cryptography;
using Business.Report;
using Business.Repository;
using Database;
using Database.Domain.Enum;

namespace UI
{
    public class FuncaoView
    {

        FuncaoRepository funcaoRepository = new FuncaoRepository();

        public void CadFuncao()
        {
            Console.WriteLine("####################### Cadastro de Função #######################");

            Console.WriteLine(" 1 - Junior | 2 - Pleno | 3 - Sênior ");
            Console.Write("Níveis: ");
            

            int level = Convert.ToInt32(Console.ReadLine());

            switch (level)
            {
                case 1:
                    level = (int)LevelEnum.Junior;
                    break;
                case 2:
                    level = (int)LevelEnum.Pleno;
                    break;
                case 3:
                    level = (int)LevelEnum.Senior;
                    break;
                default:
                    throw new Exception("Valor digitado é inválido.");
            }

            LevelEnum level1 = (LevelEnum)level;

            Console.Write("Valor hora: ");
            var vlrHora = Convert.ToDouble(Console.ReadLine());

            funcaoRepository.SalvarFuncao(level1, vlrHora);

        }
    }
}