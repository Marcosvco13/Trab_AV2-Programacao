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

        public async Task AlterarAsync(Venda venda, List<ItensVenda> itens)
        {
            _context.Entry(venda).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
            await _context.SaveChangesAsync();
            var listaItensExistentes = _context.ItensVenda.Where(x => x.ItvCodigoVenda == venda.Id).ToList();
            if (listaItensExistentes.Count > 0)
            {
                _context.RemoveRange(listaItensExistentes);
            }

            if (itens.Count > 0)
            {
                foreach (var item in itens)
                {
                    item.ItvCodigoVenda = venda.Id;
                }
                _context.AddRange(itens);
            }
            await _context.SaveChangesAsync();
        }
    }
}
