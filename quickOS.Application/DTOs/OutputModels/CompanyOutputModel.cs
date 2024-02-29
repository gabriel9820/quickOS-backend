namespace quickOS.Application.DTOs.OutputModels;

public class CompanyOutputModel
{
    public string Name { get; private set; }

    public CompanyOutputModel(string name)
    {
        Name = name;
    }
}
