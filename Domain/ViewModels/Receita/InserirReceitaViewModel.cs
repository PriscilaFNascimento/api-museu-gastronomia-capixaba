using Domain.Enums;

namespace Domain.ViewModels
{
    public class InserirReceitaViewModel
    {
        public string Nome { get; set; }
        public Uri? UriImagem { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string Historia { get; set; }
        public int PorcoesReceita { get; set; }
        public decimal Porcao { get; set; }
        public EnumTamanhoPorcao UnidadeMedidaPorcao { get; set; }
        public decimal Rendimento { get; set; }
        public EnumRendimentoReceita UnidadeMedidaRendimento { get; set; }
        public decimal TempoPreparo { get; set; }
        public EnumTempoPreparo UnidadeTempoPreparo { get; set; }
        public List<InformacaoNutricionalViewModel> InformacoesNutricionais { get; set; }
    }
}
