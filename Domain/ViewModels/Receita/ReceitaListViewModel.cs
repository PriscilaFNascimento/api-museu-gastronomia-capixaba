namespace Domain.ViewModels
{
    public class ReceitaListViewModel
    {
        public Guid Id { get; set; }
        public string Nome { get; set; }
        public string Historia { get; set; }
        public Uri? UriImagem { get; set; }
    }
}
