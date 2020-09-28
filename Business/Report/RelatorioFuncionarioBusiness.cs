using CadFuncionario;
using Database;
using System;
using System.Linq;


namespace Business
{
    public class RelatorioFuncionarioBusiness
    {
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
