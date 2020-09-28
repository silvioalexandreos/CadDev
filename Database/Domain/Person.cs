using System;
using System.Collections.Generic;
using System.Text;

namespace Database
{
    public abstract class Person
    {
        public Guid Id { get; set; }
        public DateTime DataCadastro { get; set; }
        public bool Status { get; set; }
        public string Nome { get; set; }
        public string Email { get; set; }


    }
}
