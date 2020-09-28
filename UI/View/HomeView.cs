using CadFuncionario.Controller;
using CadFuncionario.UI;
using System;
using System.Collections.Generic;
using System.Text;

namespace CadFuncionario.View
{
    static class HomeView
    {
        public static void Menu()
        {
            do
            {

                Console.Clear();

                Console.WriteLine("###### Escolha a opção desejada #####");
                Console.WriteLine(" 1 - Cadastro de Função: ");
                Console.WriteLine(" 2 - Cadastro de Funcionário: ");
                Console.WriteLine(" 3 - Listar Funcionarios ");
                Console.WriteLine(" 4 - Fechar");

                Console.Write("Qual a opção desejada: ");

                HomeBusiness homeController = new HomeBusiness();
                homeController.MenuSelecao();

            } while (true);
        }
    }
}

