namespace Desafio_React.EndPoints.Cliente
{
    public record ClienteResponse(
       string nome,
       string dataCad,
       string contatoTipo,
       string contatoText,
       string enderecoCep,
       string enderecoLogra,
       string enderecocidade,
       string endereconumero,
       string enderecocomplemento);
}