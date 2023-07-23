namespace Domain.ViewModels
{
    public class InserirReceitaViewModel
    {
        public string Nome { get; set; }
        public Uri? UriImagem { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string Historia { get; set; }
        public string Porcao { get; set; }
        public int PorcoesReceita { get; set; }
        public List<InformacaoNutricionalViewModel> InformacoesNutricionais { get; set; }
    }
}
