using Hippo.GdsRazor.Models.Base;
using Hippo.GdsRazor.Models.Content;

namespace Hippo.GdsRazor.Models;

/// <summary>
/// Allow users to accept or reject cookies which are not essential to making your service work.
/// </summary>
public class CookieBannerModel : GdsViewModel
{
    /// <summary>
    /// The text for the aria-label which labels the cookie banner region.
    /// This region applies to all messages that the cookie banner includes.
    /// For example, the cookie message and the confirmation message.
    /// </summary>
    public string? AriaLabel { get; set; }

    /// <summary>
    /// If you set this option to true, the whole cookie banner is hidden, including all messages within the banner.
    /// You can use hidden for client-side implementations where the cookie banner HTML is present, but hidden until the cookie banner is shown using JavaScript.
    /// </summary>
    public bool Hidden { get; set; }

    /// <summary>
    /// The different messages you can pass into the cookie banner.
    /// For example, the cookie message and the confirmation message.
    /// </summary>
    public IEnumerable<MessageModel>? Messages { get; set; }

    public CookieBannerModel()
    {
    }

    public CookieBannerModel(IEnumerable<MessageModel> messages) : this()
    {
        Messages = messages;
    }

    public CookieBannerModel(params MessageModel[] messages) : this(messages.ToList())
    {
    }

    public class MessageModel : GdsWithContent
    {
        /// <summary>
        /// The heading content that displays in the message.
        /// </summary>
        public GdsContent? Heading { get; set; }

        /// <summary>
        /// The buttons and links that you want to display in the message.
        /// Actions defaults to button unless you set href, which renders the action as a link.
        /// </summary>
        public List<ActionModel>? Actions { get; set; }

        /// <summary>
        /// If you set it to true, the message is hidden.
        /// You can use hidden for client-side implementations where the confirmation message HTML is present, but hidden on the page.
        /// </summary>
        public bool Hidden { get; set; }

        /// <summary>
        /// Set role to alert on confirmation messages to allow assistive tech to automatically read the message.
        /// You will also need to move focus to the confirmation message using JavaScript you have written yourself.
        /// </summary>
        public string? Role { get; set; }

        public MessageModel()
        {
        }

        public MessageModel(GdsContent content) : base(content)
        {
        }

        public class ActionModel : GdsViewModel
        {
            /// <summary>
            /// The button or link text.
            /// </summary>
            public string? Text { get; set; }

            /// <summary>
            /// The type of button.
            /// You can set button or submit.
            /// Set button and href to render a link styled as a button.
            /// If you set href, it overrides submit.
            /// </summary>
            public string? Type { get; set; }

            /// <summary>
            /// The href for a link.
            /// Set button and href to render a link styled as a button.
            /// </summary>
            public string? Href { get; set; }

            /// <summary>
            /// The name attribute for the button.
            /// Does not apply if you set href, which makes a link.
            /// </summary>
            public string? Name { get; set; }

            /// <summary>
            /// The value attribute for the button.
            /// Does not apply if you set href, which makes a link.
            /// </summary>
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
