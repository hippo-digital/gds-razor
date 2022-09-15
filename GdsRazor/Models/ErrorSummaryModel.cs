using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class ErrorSummaryModel : GdsViewModel
{
    public GdsContent? Title { get; set; }
    public GdsContent? Description { get; set; }
    public List<ErrorModel>? ErrorList { get; set; }
    public bool DisableAutoFocus { get; set; }
    
    public ErrorSummaryModel()
    {
    }

    public ErrorSummaryModel(GdsContent title, List<ErrorModel> errorList) : this()
    {
        Title = title;
        ErrorList = errorList;
    }

    public ErrorSummaryModel(GdsContent title, params ErrorModel[] errorList) : this(title, errorList.ToList())
    {
    }

    public class ErrorModel : GdsWithHref
    {
        public ErrorModel()
        {
        }

        public ErrorModel(GdsContent content) : base(content)
        {
        }

        public static implicit operator ErrorModel(string s) => new(s);
        public static implicit operator ErrorModel((string, string) t) => new(t.Item2) { Href = t.Item1 };
    }
}
