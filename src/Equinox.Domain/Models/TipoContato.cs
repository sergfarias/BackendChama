using Equinox.Domain.Core.Models;

namespace Equinox.Domain.Models
{
    public class TipoContato : Enumeration<TipoContato>
    {

        public static readonly TipoContato Telefone = new TipoContato(1, "Telefone");
        public static readonly TipoContato Celular = new TipoContato(2, "Celular");
        public static readonly TipoContato Email = new TipoContato(3, "E-mail");

        protected TipoContato(int id, string nome)
            :base(id,nome)
        { }

    }
}