using System.ComponentModel.DataAnnotations;

namespace Equinox.Application.ViewModels
{
    public class AlunoContatoViewModel
    {
        [Key]
        public int id_cliente  { get; set; }
        public int id_tipo_contato  { get; set; }
        public int id_contato  { get; set; }
        public string ds_contato { get; set; }
        public virtual AlunoViewModel Cliente { get; private set; }
    }
}
