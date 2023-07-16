using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Receita : BaseEntity
    {
        public string Nome { get; set; }
        public Uri UriImagem { get; set; }
        public string Ingredientes { get; set; }
        public string ModoPreparo { get; set; }
        public string Historia { get; set; }
        public string Porcao { get; set; }
        public int PorcoesReceita { get; set; }
        public virtual Usuario Criador { get; set; }
        public virtual Guid CriadorId { get; set; }
        public virtual Usuario Editor { get; set; }
        public virtual Guid EditorId { get; set; }
    }
}
