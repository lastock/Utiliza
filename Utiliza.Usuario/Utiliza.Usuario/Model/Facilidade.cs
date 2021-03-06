﻿using SQLite;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Utiliza.Usuario.Model
{
    [Table("facilidade")]
    public class Facilidade
    {
        [PrimaryKey]
        public int IdFacilidade { get; set; }
        [NotNull]
        public int IdFornecedor { get; set; }
        [NotNull]
        public string IconFacilidade { get; set; }
        [NotNull,MaxLength(50)]
        public string DescricaoFacilidade { get; set; }

    }
}
