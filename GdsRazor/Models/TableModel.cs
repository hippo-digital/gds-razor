using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

/// <summary>
/// Use the table component to make information easier to compare and scan for users.
/// </summary>
public class TableModel : GdsViewModel
{
    /// <summary>
    /// Array of table rows.
    /// </summary>
    public List<RowModel>? Rows { get; set; }

    /// <summary>
    /// Array of table head cells.
    /// </summary>
    public RowModel? Head { get; set; }

    /// <summary>
    /// Caption text
    /// </summary>
    public string? Caption { get; set; }

    /// <summary>
    /// Classes for caption text size.
    /// Classes should correspond to the available typography heading classes.
    /// </summary>
    public string? CaptionClasses { get; set; }

    /// <summary>
    /// If set to true, first cell in table row will be a TH instead of a TD.
    /// </summary>
    public bool FirstCellIsHeader { get; set; }

    public TableModel()
    {
    }

    public TableModel(List<RowModel> rows)
    {
        Rows = rows;
    }

    public TableModel(params RowModel[] rows) : this(rows.ToList())
    {
    }

    public class RowModel : GdsViewModel
    {
        /// <summary>
        /// Array of table cells.
        /// </summary>
        public List<CellModel>? Cells { get; set; }

        public RowModel()
        {
        }

        public RowModel(List<CellModel> cells)
        {
            Cells = cells;
        }

        public RowModel(params CellModel[] cells) : this(cells.ToList())
        {
        }
        
        public static implicit operator RowModel(List<CellModel> s) => new() { Cells = s };
    }

    public class CellModel : GdsWithContent
    {
        /// <summary>
        /// Specify format of a cell.
        /// Currently we only use "numeric".
        /// </summary>
        public string? Format { get; set; }

        /// <summary>
        /// Specify how many columns a cell extends.
        /// </summary>
        public int? Colspan { get; set; }

        /// <summary>
        /// Specify how many rows a cell extends.
        /// </summary>
        public int? Rowspan { get; set; }

        public CellModel()
        {
        }

        public CellModel(GdsContent content) : base(content)
        {
        }

        public static implicit operator CellModel(string s) => new(s);
        public static implicit operator CellModel(HTML h) => new(h);
    }
}
