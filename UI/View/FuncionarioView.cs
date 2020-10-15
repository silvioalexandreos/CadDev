
using Business;
using Business.Repository;
using CadFuncionario.View;
using Database.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Text.RegularExpressions;
using static System.Net.Mime.MediaTypeNames;

namespace CadFuncionario.Controller
{
    
    public class FuncionarioView
    {
     
        public void CadFuncionario()
        {
            FuncionarioRepository funcionarioRepository = new FuncionarioRepository();
            

            Console.Clear();
            Console.WriteLine("####################### Cadastro de Funcionário #######################");

            Console.Write("Nome: ");
            var nome = Console.ReadLine();
            
            Console.Write("Email: ");
            var email = Console.ReadLine();

            Console.WriteLine(" 1 - Junior | 2 - Pleno | 3 - Sênior ");
            Console.Write("Digite o ID da Função: ");

            string levelTemp = Console.ReadLine();
            int level = int.Parse(levelTemp);

            Console.Write("Quantas horas trabalho no mês: ");
            var qtdHoras = Convert.ToInt32(Console.ReadLine());

            funcionarioRepository.SalvarFuncionario(nome, email, level, qtdHoras);
        }
    }
}
