using CadFuncionario;
using Database;
using System;
using System.Collections.Generic;
using System.Linq;


namespace Business.Report
{
    public class RelatorioFuncionarioBusiness
    {
        public int HorasTrab { get; set; }
        public int LevelID { get; set; }


        public List<Developer> RelatorioDesenvolvedores()
        {
            using (var conexao = new Connection())
            {
                var listaDev = new List<Developer>();
                var desenvolvedores = conexao.Desenvolvedores.ToList();
                var niveis = conexao.Niveis.ToList();

                foreach (var row in conexao.Desenvolvedores.ToList())
                {
                    var nivelDesenvolvedor = niveis.FirstOrDefault(x => x.Id == row.LevelID);


                    var horaDesenvolvedor = nivelDesenvolvedor.VlrHora;
                    var salario = (row.HorasTrab * horaDesenvolvedor);

                    var dev = new Developer();
                    dev.DataCadastro = Convert.ToDateTime(row.DataCadastro);
                    dev.Status = row.Status;
                    dev.Nome = row.Nome;
                    dev.Email = row.Email;
                    dev.HorasTrab = row.HorasTrab;
                    dev.LevelID = row.LevelID;
                    listaDev.Add(dev);
                }
                return listaDev;
            }
        }


        public void Exibir()
        {
            using (var conexao = new Connection())
            {
                Console.Clear();

                var niveis = conexao.Niveis.ToList();
                var desenvolvedores = conexao.Desenvolvedores.ToList();

                foreach (var desen in desenvolvedores)
                {

                    var nivelDesenvolvedor = niveis.FirstOrDefault(x => x.Id == desen.LevelID);

                    if (nivelDesenvolvedor != null)
                    {
                        var horaDesenvolvedor = nivelDesenvolvedor.VlrHora;

                        var salario = (desen.HorasTrab * horaDesenvolvedor);

                        Console.WriteLine($"Status:{desen.Status}, Data Cadastro: " +
                        $"{desen.DataCadastro}, Nome: {desen.Nome}, Email: " +
                        $"{desen.Email}, Nível: {nivelDesenvolvedor.Descricao}, Salario: {salario}");

                    }
                }

                Console.WriteLine("Pressione qualquer tecla para voltar ao menu incial.");
                Console.ReadLine();
            }
        }
    }
}
