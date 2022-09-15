using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class CookieBannerModel : GdsViewModel
{
    public string? AriaLabel { get; set; }
    public bool Hidden { get; set; }
    public List<MessageModel>? Messages { get; set; }

    public CookieBannerModel()
    {
    }

    public CookieBannerModel(List<MessageModel> messages) : this()
    {
        Messages = messages;
    }

    public CookieBannerModel(params MessageModel[] messages) : this(messages.ToList())
    {
    }

    public class MessageModel : GdsWithContent
    {
        public GdsContent? Heading { get; set; }
        public List<ActionModel>? Actions { get; set; }
        public bool Hidden { get; set; }
        public string? Role { get; set; }

        public MessageModel()
        {
        }

        public MessageModel(GdsContent content) : base(content)
        {
        }

        public class ActionModel : GdsViewModel
        {
            public string? Text { get; set; }
            public string? Type { get; set; }
            public string? Href { get; set; }
            public string? Name { get; set; }
            public string? Value { get; set; }

            public ActionModel()
            {
            }

            public ActionModel(string text) : this()
            {
                Text = text;
            }
        }
    }
}
