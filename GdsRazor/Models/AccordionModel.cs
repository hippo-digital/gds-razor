using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class AccordionModel : GdsViewModel
{
    public int? HeadingLevel { get; set; }

    public List<ItemModel>? Items { get; set; }
    
    // i18n
    public string? HideAllSectionsText { get; set; }
    public string? HideSectionText { get; set; }
    public string? ShowAllSectionsText { get; set; }
    public string? ShowSectionText { get; set; }

    public AccordionModel()
    {
    }

    public AccordionModel(string id, List<ItemModel> items) : base(id)
    {
        Items = items;
    }

    public AccordionModel(string id, params ItemModel[] items) : this(id, items.ToList())
    {
    }

    protected override IEnumerable<KeyValuePair<string, string?>> GetAllAttributes() =>
        MaybePrepend(
            base.GetAllAttributes(),
            new KeyValuePair<string, string?>("data-i18n.hide-all-sections", HideAllSectionsText),
            new KeyValuePair<string, string?>("data-i18n.hide-section", HideSectionText),
            new KeyValuePair<string, string?>("data-i18n.show-all-sections", ShowAllSectionsText), 
            new KeyValuePair<string, string?>("data-i18n.show-section", ShowSectionText)
        );

    public class ItemModel
    {
        public GdsContent? Heading { get; set; }
        public GdsContent? Summary { get; set; }
        public GdsContent? Content { get; set; }
        public bool Expanded { get; set; }

        public ItemModel()
        {
        }

        public ItemModel(GdsContent heading, GdsContent content) : this()
        {
            Heading = heading;
            Content = content;
        }
    }
}
