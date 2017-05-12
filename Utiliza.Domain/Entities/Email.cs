namespace Utiliza.Domain.Entities
{
    public class Email
    {
        public string EmailId { get; set; }
        public string EmailExtenso { get; set; }
        public virtual string ClienteId { get; set; }

    }
}
