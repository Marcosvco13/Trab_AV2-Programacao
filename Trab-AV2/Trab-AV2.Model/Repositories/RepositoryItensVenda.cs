using Trab_AV2.Model.Interfaces;
using Trab_AV2.Model.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_AV2.Model.Models;
using Trab_AV2.Model.Repositories;

namespace Trab_AV2.Model.Repositories
{
    public class RepositoryItensVenda : RepositoryBase<ItensVenda>
    {
        public RepositoryItensVenda(bool saveChanges = true) : base(saveChanges)
        {

        }

        public Task AtualizarItensAsync(List<ItensVenda> itensVendas)
        {
            throw new NotImplementedException();
        }
    }
}