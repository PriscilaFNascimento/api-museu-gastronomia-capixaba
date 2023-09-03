using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Receita : BaseEntity
    {
        public Receita()
        {
            InformacoesNutricionais = new HashSet<InformacaoNutricional>();
            Comentarios = new HashSet<Comentario>();
        }

        public string Nome { get; set; }
        public Uri? UriImagem { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string Historia { get; set; }
        public decimal Porcao { get; set; }
        public EnumTamanhoPorcao UnidadeMedidaPorcao { get; set; }
        public int PorcoesReceita { get; set; }
        public decimal Rendimento { get; set; }
        public EnumRendimentoReceita UnidadeMedidaRendimento { get; set; }
        public decimal TempoPreparo { get; set; }
        public EnumTempoPreparo UnidadeTempoPreparo { get; set; }
        public virtual Usuario Criador { get; set; }
        public virtual Guid CriadorId { get; set; }
        public virtual Usuario UltimoEditor { get; set; }
        public virtual Guid UltimoEditorId { get; set; }
        public IEnumerable<InformacaoNutricional> InformacoesNutricionais { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }

    }
}
