namespace Hippo.GdsRazor;

public static class Styles
{
    public sealed class Spacing
    {
        public static Spacing S0 => new(0);
        public static Spacing S1 => new(1);
        public static Spacing S2 => new(2);
        public static Spacing S3 => new(3);
        public static Spacing S4 => new(4);
        public static Spacing S5 => new(5);
        public static Spacing S6 => new(6);
        public static Spacing S7 => new(7);
        public static Spacing S8 => new(8);
        public static Spacing S9 => new(9);

        public int Value { get; }

        private Spacing(int value)
        {
            Value = value;
        }
    }

    public sealed class Direction
    {
        public static Direction All => new("");

        public static Direction Top => new("top-");
        public static Direction Right => new("right-");
        public static Direction Bottom => new("bottom-");
        public static Direction Left => new("left-");

        public string Value { get; }

        private Direction(string value)
        {
            Value = value;
        }
    }

    public static string Padding(Spacing spacing, Direction? direction = null, bool staticSpacing = false) => Base("padding", staticSpacing, spacing, direction);
    public static string Margin(Spacing spacing, Direction? direction = null, bool staticSpacing = false) => Base("margin", staticSpacing, spacing, direction);

    private static string Base(string property, bool staticSpacing, Spacing spacing, Direction? direction)
    {
        var staticStr = staticSpacing ? "static-" : "";
        var dir = direction ?? Direction.All;
        return $"govuk-!-{staticStr}{property}-{dir.Value}{spacing.Value}";
    }

    public static class FontSize
    {
        public const string FontSize14 = "govuk-!-font-size-14";
        public const string FontSize16 = "govuk-!-font-size-16";
        public const string FontSize19 = "govuk-!-font-size-19";
        public const string FontSize24 = "govuk-!-font-size-24";
        public const string FontSize27 = "govuk-!-font-size-27";
        public const string FontSize36 = "govuk-!-font-size-36";
        public const string FontSize48 = "govuk-!-font-size-48";
        public const string FontSize80 = "govuk-!-font-size-80";
    }
}
