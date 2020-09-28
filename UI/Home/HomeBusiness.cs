using Business;
using CadFuncionario.Controller;
using System;
using UI;

namespace CadFuncionario.UI
{
    public class HomeBusiness
    {
        public HomeBusiness()
        {

        }

        public void MenuSelecao()
        {
            FuncaoView funcao = new FuncaoView();
            FuncionarioView funcionario = new FuncionarioView();
            RelatorioFuncionarioBusiness relatorioFuncionario = new RelatorioFuncionarioBusiness();


            try
            {
                var selecao = Convert.ToInt32(Console.ReadLine());

                switch (selecao)
                {
                    case 1:
                        Console.Clear();
                        funcao.CadFuncao();
                        break;
                    case 2:
                        Console.Clear();
                        funcionario.CadFuncionario();
                        break;
                    case 3:
                        Console.Clear();
                        relatorioFuncionario.Exibir();
                        break;
                    case 4:
                        Console.Clear();
                        Environment.Exit(0);
                        break;
                    default:
                        Console.WriteLine("Opção invalida.");
                        break;
                }
            }

            catch (FormatException)
            {
                Console.WriteLine("O campo deve ser preenchido com valor numérico.");
                Console.ReadLine();
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                Console.ReadLine();
            }

        }
    }
}
