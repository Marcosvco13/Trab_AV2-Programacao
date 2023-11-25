using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_AV2.Model.Models;

namespace Trab_AV2.Model.Repositories
{
    public class RepositoryVenda : RepositoryBase<Venda>
    {
        public RepositoryVenda(bool saveChanges = true) : base(saveChanges) 
        { 
        }
    }
}
