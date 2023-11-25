using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Trab_AV2.Model.Models;

public partial class VwEstoque
{
    public string ProDescricao { get; set; }
    public int Procodigo { get; set; }
    public decimal? Quantidade { get; set; }
    public decimal Valorvenda { get; set; }
}

