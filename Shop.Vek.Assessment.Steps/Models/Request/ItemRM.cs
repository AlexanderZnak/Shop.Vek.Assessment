namespace Shop.Vek.Assessment.Steps.Models.Request;

public class ItemRM
{
    public ItemRM(string name)
    {
        Name = name;
    }

    public string Name { get; set; }
}