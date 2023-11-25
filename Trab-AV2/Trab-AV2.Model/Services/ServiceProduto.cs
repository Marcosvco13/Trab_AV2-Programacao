using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_AV2.Model.Repositories;

namespace Trab_AV2.Model.Services
{
    public class ServiceProduto
    {
        public RepositoryProduto oRepositoryProduto {  get; set; }
        public RepositorySIMNAO oRepositorySimNao { get; set; }

        public ServiceProduto() 
        {
            oRepositoryProduto = new RepositoryProduto();
            oRepositorySimNao = new RepositorySIMNAO();
        }
    }
}
