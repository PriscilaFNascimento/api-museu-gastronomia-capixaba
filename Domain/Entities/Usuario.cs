namespace Domain.Entities
{
    public class Usuario : BaseEntity
    {
        public Usuario()
        {
            ReceitasCriadas = new HashSet<Receita>();
            ReceitasEditadas = new HashSet<Receita>();
            Comentarios = new HashSet<Comentario>();

        }

        public string Nome { get; set; }
        public string Sobrenome { get; set; }
        public string Email { get; set; }
        public DateTime Nascimento { get; set; }
        public string SenhaHash { get; set; }
        public Uri? UriFotoPerfil { get; set; }
        public IEnumerable<Receita> ReceitasCriadas { get; set; }
        public IEnumerable<Receita> ReceitasEditadas { get; set; }
        public IEnumerable<Comentario> Comentarios { get; set; }
    }
}
