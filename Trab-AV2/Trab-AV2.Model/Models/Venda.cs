﻿// <auto-generated> This file has been auto generated by EF Core Power Tools. </auto-generated>
#nullable disable
using System;
using System.Collections.Generic;

namespace Trab_AV2.Model.Models;

public partial class Venda
{
    public int Id { get; set; }

    public int IdProduto { get; set; }

    public string IdUser { get; set; }

    public DateTime? DataVenda { get; set; }

    public decimal? ValorVenda { get; set; }

    public virtual ICollection<ItensVenda> ItensVenda { get; set; } = new List<ItensVenda>();
}