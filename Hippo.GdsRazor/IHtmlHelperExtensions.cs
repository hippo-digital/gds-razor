using Hippo.GdsRazor.Models;
using Hippo.GdsRazor.Models.Content;
using Microsoft.AspNetCore.Html;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Hippo.GdsRazor;

public static class HtmlHelperExtensions {
    public static Task<IHtmlContent> GdsAccordion(this IHtmlHelper html, AccordionModel model) =>
        html.PartialAsync("GdsAccordion", model);
    public static Task<IHtmlContent> GdsBackLink(this IHtmlHelper html, BackLinkModel model) =>
        html.PartialAsync("GdsBackLink", model);
    public static Task<IHtmlContent> GdsBreadcrumbs(this IHtmlHelper html, BreadcrumbsModel model) =>
        html.PartialAsync("GdsBreadcrumbs", model);
    public static Task<IHtmlContent> GdsButtonGroup(this IHtmlHelper html, ButtonGroupModel model) =>
        html.PartialAsync("GdsButtonGroup", model);
    public static Task<IHtmlContent> GdsButton(this IHtmlHelper html, ButtonModel model) =>
        html.PartialAsync("GdsButton", model);
    public static Task<IHtmlContent> GdsCharacterCount(this IHtmlHelper html, CharacterCountModel model) =>
        html.PartialAsync("GdsCharacterCount", model);
    public static Task<IHtmlContent> GdsCheckboxes(this IHtmlHelper html, CheckboxesModel model) =>
        html.PartialAsync("GdsCheckboxes", model);
    public static Task<IHtmlContent> GdsCookieBanner(this IHtmlHelper html, CookieBannerModel model) =>
        html.PartialAsync("GdsCookieBanner", model);
    public static Task<IHtmlContent> GdsDateInput(this IHtmlHelper html, DateInputModel model) =>
        html.PartialAsync("GdsDateInput", model);
    public static Task<IHtmlContent> GdsDetails(this IHtmlHelper html, DetailsModel model) =>
        html.PartialAsync("GdsDetails", model);
    public static Task<IHtmlContent> GdsErrorMessage(this IHtmlHelper html, ErrorMessageModel model) =>
        html.PartialAsync("GdsErrorMessage", model);
    public static Task<IHtmlContent> GdsErrorSummary(this IHtmlHelper html, ErrorSummaryModel model) =>
        html.PartialAsync("GdsErrorSummary", model);
    public static Task<IHtmlContent> GdsFieldset(this IHtmlHelper html, FieldsetModel model) =>
        html.PartialAsync("GdsFieldset", model);
    public static Task<IHtmlContent> GdsFileUpload(this IHtmlHelper html, FileUploadModel model) =>
        html.PartialAsync("GdsFileUpload", model);
    public static Task<IHtmlContent> GdsFooter(this IHtmlHelper html, FooterModel model) =>
        html.PartialAsync("GdsFooter", model);
    public static Task<IHtmlContent> GdsHeader(this IHtmlHelper html, HeaderModel model) =>
        html.PartialAsync("GdsHeader", model);
    public static Task<IHtmlContent> GdsHeading(this IHtmlHelper html, HeadingModel model) =>
        html.PartialAsync("GdsHeading", model);
    public static Task<IHtmlContent> GdsHint(this IHtmlHelper html, HintModel model) =>
        html.PartialAsync("GdsHint", model);
    public static Task<IHtmlContent> GdsInput(this IHtmlHelper html, InputModel model) =>
        html.PartialAsync("GdsInput", model);
    public static Task<IHtmlContent> GdsInsetText(this IHtmlHelper html, InsetTextModel model) =>
        html.PartialAsync("GdsInsetText", model);
    public static Task<IHtmlContent> GdsLabel(this IHtmlHelper html, LabelModel model) =>
        html.PartialAsync("GdsLabel", model);
    public static Task<IHtmlContent> GdsLink(this IHtmlHelper html, LinkModel model) =>
        html.PartialAsync("GdsLink", model);
    public static Task<IHtmlContent> GdsNotificationBanner(this IHtmlHelper html, NotificationBannerModel model) =>
        html.PartialAsync("GdsNotificationBanner", model);
    public static Task<IHtmlContent> GdsPagination(this IHtmlHelper html, PaginationModel model) =>
        html.PartialAsync("GdsPagination", model);
    public static Task<IHtmlContent> GdsPanel(this IHtmlHelper html, PanelModel model) =>
        html.PartialAsync("GdsPanel", model);
    public static Task<IHtmlContent> GdsPhaseBanner(this IHtmlHelper html, PhaseBannerModel model) =>
        html.PartialAsync("GdsPhaseBanner", model);
    public static Task<IHtmlContent> GdsRadios(this IHtmlHelper html, RadiosModel model) =>
        html.PartialAsync("GdsRadios", model);
    public static Task<IHtmlContent> GdsSelect(this IHtmlHelper html, SelectModel model) =>
        html.PartialAsync("GdsSelect", model);
    public static Task<IHtmlContent> GdsSkipLink(this IHtmlHelper html, SkipLinkModel model) =>
        html.PartialAsync("GdsSkipLink", model);
    public static Task<IHtmlContent> GdsSummaryList(this IHtmlHelper html, SummaryListModel model) =>
        html.PartialAsync("GdsSummaryList", model);
    public static Task<IHtmlContent> GdsTable(this IHtmlHelper html, TableModel model) =>
        html.PartialAsync("GdsTable", model);
    public static Task<IHtmlContent> GdsTabs(this IHtmlHelper html, TabsModel model) =>
        html.PartialAsync("GdsTabs", model);
    public static Task<IHtmlContent> GdsTag(this IHtmlHelper html, TagModel model) =>
        html.PartialAsync("GdsTag", model);
    public static Task<IHtmlContent> GdsTextarea(this IHtmlHelper html, TextareaModel model) =>
        html.PartialAsync("GdsTextarea", model);
    public static Task<IHtmlContent> GdsWarningText(this IHtmlHelper html, WarningTextModel model) =>
        html.PartialAsync("GdsWarningText", model);
    public static Task<IHtmlContent> GdsContent(this IHtmlHelper html, GdsContent? model) =>
        html.PartialAsync("GdsContent", model);

    // Errors
    public static ErrorMessageModel? ErrorMessageModel(this IHtmlHelper html, string name)
    {
        var modelState = html.ViewData.ModelState[name];
        return modelState == null || !modelState.Errors.Any() ? null : new ErrorMessageModel((HTML) (_ => html.ValidationMessage(name)));
    }
}
