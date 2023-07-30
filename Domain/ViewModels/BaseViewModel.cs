using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.ViewModels
{
    public class BaseViewModel
    {
        public Guid Id { get; set; }
        public DateTimeOffset Registro { get; set; }
        public DateTimeOffset Atualizacao { get; set; }
        public DateTime? Desativacao { get; set; }
    }
}
