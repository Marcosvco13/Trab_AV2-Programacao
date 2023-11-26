using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Trab_AV2.Model.Interfaces;
using Trab_AV2.Model.Repositories;

namespace Trab_AV2.Model.Services
{
    public class ServiceVenda
    {
        public RepositoryVenda oRepositoryVenda {  get; set; }
        public RepositoryProduto oRepositoryProduto { get; set; }
        public RepositoryItensVenda oRepositoryItensVenda { get; set; }
        public RepositoryVwEstoque oRepositoryVwEstoque { get; set; }


        public ServiceVenda() 
        {
            oRepositoryVenda = new RepositoryVenda();
            oRepositoryProduto = new RepositoryProduto();
            oRepositoryItensVenda = new RepositoryItensVenda();
            oRepositoryVwEstoque = new RepositoryVwEstoque();

        }
    }
}
