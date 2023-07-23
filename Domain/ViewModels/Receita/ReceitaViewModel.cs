namespace Domain.ViewModels
{
    public class ReceitaViewModel : BaseViewModel
    {
        public string Nome { get; set; }
        public Uri? UriImagem { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string Historia { get; set; }
        public string Porcao { get; set; }
        public int PorcoesReceita { get; set; }
        public string NomeCriador { get; set; }
        public virtual Guid CriadorId { get; set; }
        public string NomeEditor { get; set; }
        public virtual Guid EditorId { get; set; }
    }
}
