using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_AV2.Model.Models;

namespace Trab_AV2.Model.Repositories
{
    public class RepositoryVwEstoque : RepositoryBase<VwEstoque>
    {
        public RepositoryVwEstoque(bool saveChanges = true) : base(saveChanges) 
        {
        }

        public VwEstoque SelecionarEstoqueProduto(int id)
        {
            return _context.VwEstoques.FirstOrDefault(x => x.Id == id)!;
        }
    }
}
