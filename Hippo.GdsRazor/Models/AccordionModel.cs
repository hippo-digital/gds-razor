using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// The accordion component lets users show and hide sections of related content on a page.
/// </summary>
public class AccordionModel : GdsViewModel
{
    /// <summary>
    /// Heading level, from 1 to 6.
    /// </summary>
    public int? HeadingLevel { get; set; }

    /// <summary>
    /// An array of sections within the accordion.
    /// </summary>
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
        /// <summary>
        /// The title of each section.
        /// </summary>
        public GdsContent? Heading { get; set; }

        /// <summary>
        /// The content for the summary line.
        /// The summary line is inside the HTML &lt;button&gt; element, so you can only add phrasing content to it.
        /// </summary>
        public GdsContent? Summary { get; set; }

        /// <summary>
        /// The content of each section, which is hidden when the section is closed.
        /// </summary>
        public GdsContent? Content { get; set; }

        /// <summary>
        /// Sets whether the section should be expanded when the page loads for the first time.
        /// </summary>
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
