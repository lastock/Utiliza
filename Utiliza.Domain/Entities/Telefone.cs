namespace Utiliza.Domain.Entities
{
    public class Telefone
    {
        public string TelefoneId { get; set; }
        public string TipoTelefone { get; set; }
        public string Operadora { get; set; }
        public int Ordem { get; set; }
        public string CodPais { get; set; }
        public string Ddd { get; set; }
        public string NumeroTelefone { get; set; }
        public virtual string ClienteId { get; set; }

    }
}
