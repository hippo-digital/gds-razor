namespace Hippo.GdsRazor.Models.Base;

public abstract class GdsViewModel : GdsAttributes
{
    /// <summary>
    /// Set the id of the element
    /// </summary>
    public string? Id { get; set; }

    /// <summary>
    /// Classes to add to the element
    /// </summary>
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