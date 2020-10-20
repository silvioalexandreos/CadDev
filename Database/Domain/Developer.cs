using CadFuncionario;
using Database.Domain.Enum;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;

namespace Database
{
    public class Developer : Person
    {
        public double HorasTrab { get; set; }
        public int LevelID { get; set; }

        public Developer()
        {
            DataCadastro = DateTime.Now;
            Status = true;
        }
     
        public string ValidaCampoNome(string nome)
        {
            if (string.IsNullOrEmpty(nome)) throw new Exception("Preencha o campo nome corretamente.");

            return nome;
        }

        public int ValidarCampoNivel(int nivel)
        {
            if (nivel < 1 && nivel > 3) throw new Exception("Digite um nível valido.");

            return nivel;
        }

        public double ValidarCamposQtdHoras(double qtdHoras)
        {
            if (qtdHoras < 0) throw new Exception("Quantidade de horas não pode ser negativa.");

            return qtdHoras;
        }

        public string ValidarCampoEmail(string email)
        {
            int emailIndice = email.IndexOf("@");

            if (emailIndice < 0) throw new Exception("Email inválido.");

            return email;
        }
    }
}