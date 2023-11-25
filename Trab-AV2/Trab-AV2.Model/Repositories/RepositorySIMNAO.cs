using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_AV2.Model.Models;

namespace Trab_AV2.Model.Repositories
{
    public class RepositorySIMNAO : RepositoryBase<SimNao>
    {
        public RepositorySIMNAO(bool saveChanges = true) : base(saveChanges) 
        { 
        }
    }
}
