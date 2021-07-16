namespace DomainLayer.Models.CommonModels.Enums
{
    public class TipoTituloModel : ITipoTituloModel
    {
        public int TipoId { get; set; }
        public string TipoTitulo { get; set; }

        public TipoTituloModel(int tipoId)
        {
            TipoId = tipoId;
        }

        public TipoTituloModel(string tipoTitulo)
        {
            TipoTitulo = tipoTitulo;
        }

        public TipoTituloModel()
        {

        }

        public override string ToString()
        {
            return $"{TipoId}";

        }
    }
}
