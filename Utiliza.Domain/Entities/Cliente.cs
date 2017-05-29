//using GeoCoordinatePortable;
using System;
using System.Collections.Generic;

namespace Utiliza.Domain.Entities
{
    public class Cliente
    {
        public string ClienteId { get; set; }
        public int Codigo { get; set; }
        public string RazaoSocial { get; set; }
        public string NomeFantasia { get; set; }
        public string Endereco { get; set; }
        public string Bairro { get; set; }
        public string Cep { get; set; }
        public string Cidade { get; set; }
        public string Estado { get; set; }
        public string TipoDePessoa { get; set; }
        public string CnpjCpf { get; set; }
        public DateTime DataContrato { get; set; }
        public DateTime DataExpiracao { get; set; }
        public string Site { get; set; }
        //public GeoCoordinate Localizacao { get; set; }
        public virtual List<Telefone> Telefones { get; set; }
        public virtual List<Email> Emails { get; set; }
        public virtual List<Contato> Contatos { get; set; }
        public string Logo { get; set; }
    }

}
