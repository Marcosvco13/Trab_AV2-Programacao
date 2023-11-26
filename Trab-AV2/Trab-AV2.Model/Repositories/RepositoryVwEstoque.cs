using Microsoft.EntityFrameworkCore;
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
    public class RepositoryVwEstoque : RepositoryBase<VwEstoque>
    {
        public RepositoryVwEstoque(bool saveChanges = true) : base(saveChanges)
        {
        }

        public VwEstoque SelecionaEstoqueProduo(int codProduto)
        {
            return _context.VwEstoque.FirstOrDefault(x => x.Procodigo == codProduto);
        }

    }
}
