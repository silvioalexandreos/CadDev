using System;
using System.Collections.Generic;
using System.Text;

namespace Business.Repository.Interface
{
    public interface IRepository
    {
        public void Salvar();
        public void Adicionar();
        public void Atualizar();
        public void Remover();
    }
}
