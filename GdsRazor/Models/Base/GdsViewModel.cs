namespace GdsRazor.Models.Base;

public abstract class GdsViewModel : GdsAttributes
{
    public string? Id { get; set; }
    public string? Classes { get; set; }


    protected GdsViewModel(string? id, string? classes = "", Dictionary<string, string?>? attributes = null)
    {
        Id = id;
        Classes = classes;
        Attributes = attributes;
    }

    protected GdsViewModel() : this(null)
    {
    }
}