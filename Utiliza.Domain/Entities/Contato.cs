namespace Utiliza.Domain.Entities
{
    public class Contato
    {
        public string ContaoId { get; set; }
        public string NomeContato { get; set; }
        public string Cargo { get; set; }
        public int Ordem { get; set; }
        public virtual string ClienteId { get; set; }
    }
}
