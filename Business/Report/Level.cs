using CadFuncionario;
using Database;
using Database.Domain.Enum;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;

namespace Business.Report
{
    public class Level
    {
        public int Id { get; set; }
        public LevelEnum Descricao { get; set; }
        public double VlrHora { get; set; }

        public List<Level> Lista()
        {
            var lista = new List<Level>();
            var paginaDB = new Connection();

            foreach (var row in paginaDB.Niveis.ToList())
            {
                var pagina = new Level();
                pagina.Id = Convert.ToInt32(row.Id);
                pagina.Descricao = row.Descricao;
                pagina.VlrHora = Convert.ToInt32(row.VlrHora);

                lista.Add(pagina);
            }
            return lista;
        }

    }
}
