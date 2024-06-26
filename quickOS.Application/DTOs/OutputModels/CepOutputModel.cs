namespace quickOS.Application.DTOs.OutputModels;

public class CepOutputModel
{
    public string Cep { get; private set; }
    public string Logradouro { get; private set; }
    public string Complemento { get; private set; }
    public string Bairro { get; private set; }
    public string Localidade { get; private set; }
    public string UF { get; private set; }

    public CepOutputModel(string cep, string logradouro, string complemento, string bairro, string localidade, string uf)
    {
        Cep = cep;
        Logradouro = logradouro;
        Complemento = complemento;
        Bairro = bairro;
        Localidade = localidade;
        UF = uf;
    }
}
