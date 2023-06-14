namespace Desafio_React.Domain.Client
{
    public class Contato
    {
        public int Id { get; private set; }
        public string Tipo { get; private set; }
        public string Texto { get; private set; }

        public Contato()
        {
            
        }

        public Contato(int id, string tipo, string texto)
        {
            Id = id;
            Tipo = tipo;
            Texto = texto;
        }

        public void EditarContato(string tipo,string texto)
        {
            Tipo = tipo;
            Texto = texto;

        }
    }
}
