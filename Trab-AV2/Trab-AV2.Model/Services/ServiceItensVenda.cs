using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_AV2.Model.Repositories;

namespace Trab_AV2.Model.Services
{
    public class ServiceItensVenda
    {
        public RepositoryItensVenda oRepositoryItensVenda { get; set; }

        public ServiceItensVenda() { 
        
            oRepositoryItensVenda = new RepositoryItensVenda();
        }
    }
}
