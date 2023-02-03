namespace WebApplication1.MVC.Model
{
    public class Fornecedor
    {
        //Nome, CNPJ, Telefone e E-mail.

        public int Id { get; set; }
        public string Nome { get; set; }
        public string CNPJ { get; set; }
        public string Telefone  { get; set; }
        public string Email { get; set; }
        public IEnumerable<Endereco> Endereco { get; set; }
    }
}
