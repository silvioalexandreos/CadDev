using CadFuncionario;
using Database;
using Database.Domain.Enum;
using System;
using System.Collections.Generic;

namespace Business.Repository
{
    public class FuncionarioRepository
    {
        public void SalvarFuncionario(Developer developer)
        {
            var dev = new Developer();

            dev.ValidaCampoNome(developer.Nome);
            dev.Nome = developer.Nome;

            dev.ValidarCampoEmail(developer.Email);
            dev.Email = developer.Email;

            dev.LevelID = developer.LevelID;

            dev.ValidarCamposQtdHoras(developer.HorasTrab);
            dev.HorasTrab = developer.HorasTrab;

            using (var conexao = new Connection())
            {
                conexao.Desenvolvedores.Add(dev);
                conexao.SaveChanges();
            }
        }

        public void SalvarFuncionario(string nome, string email, int levelID, double qtdHoras)
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