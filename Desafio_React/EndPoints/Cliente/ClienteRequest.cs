namespace Desafio_React.EndPoints.Cliente
{
    public record ClienteRequest (int id, string nome,
        string contTipo, string contTexto
        ,string Endcep,string Endnumero);
    
}
