using GdsRazor.Models.Base;
using GdsRazor.Models.Content;

namespace GdsRazor.Models;

public class TableModel : GdsViewModel
{
    public List<RowModel>? Rows { get; set; }
    public RowModel? Head { get; set; }
    public string? Caption { get; set; }
    public string? CaptionClasses { get; set; }
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
        public string? Format { get; set; }
        public int? Colspan { get; set; }
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
