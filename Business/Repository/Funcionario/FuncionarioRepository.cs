using CadFuncionario;
using Database;
using Database.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Business.Repository
{
    public class FuncionarioRepository
    {

        public void SalvarFuncionario(string nome, string email, int levelID, int qtdHoras)
        {
            var dev = new Developer();

            dev.ValidaCampoNome(nome);
            dev.Nome = nome;

            dev.ValidarCampoEmail(email);
            dev.Email = email;

            dev.LevelID = levelID;

            dev.ValidarCamposQtdHoras(qtdHoras);
            dev.HorasTrab = qtdHoras;

            using (var conexao = new Connection())
            {
                conexao.Desenvolvedores.Add(dev);
                conexao.SaveChanges();
                Console.WriteLine("Cadastro Salvo com sucesso...");
                Console.WriteLine("Pressione qualquer tecla para voltar ao menu incial.");
                Console.ReadLine();
            }
        }

        public void SalvarFuncionario()
        {
            throw new NotImplementedException();
        }
    }
}                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                                        