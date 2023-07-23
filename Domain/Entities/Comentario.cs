namespace Domain.Entities
{
    public class Comentario : BaseEntity
    {
        public string Conteudo { get; set; }
        public Guid ComentaristaId { get; set; }
        public virtual Usuario Comentarista { get; set; }
        public Guid ReceitaId { get; set; }
        public virtual Receita Receita { get; set; }
    }
}
