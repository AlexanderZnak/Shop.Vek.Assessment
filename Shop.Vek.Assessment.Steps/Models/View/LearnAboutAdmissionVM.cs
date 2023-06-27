namespace Shop.Vek.Assessment.Steps.Models.View;

public class LearnAboutAdmissionVM
{
    public LearnAboutAdmissionVM(string dialogContent)
    {
        DialogContent = dialogContent;
    }

    public string DialogContent { get; set; }
}