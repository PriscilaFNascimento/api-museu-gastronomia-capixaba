using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class BaseEntity
    {
        public Guid Id { get; set; } = Guid.NewGuid();
        public DateTime Registro { get; set; } = DateTime.Now;
        public DateTime Atualizacao { get; set; } = DateTime.Now;
        public DateTime? Desativacao { get; set; }
    }
}
