using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Comentario : BaseEntity
    {
        public string Conteudo { get; set; }
        public virtual Usuario Comentarista { get; set; }
        public virtual Receita ReceitaId { get; set; }
    }
}
