namespace Domain.Entities
{
    public class InformacaoNutricional : BaseEntity
    {
        public string Nome { get; set; }
        public decimal QuantidadePorcao { get; set; }
        public decimal ValorDiario { get; set; }
        public Guid ReceitaId { get; set; }
        public virtual Receita Receita { get; set; }
    }
}
