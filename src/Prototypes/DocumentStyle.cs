using DesignPatternChallenge.Contracts;
using DesignPatternChallenge.Prototypes;

namespace DesignPatternChallenge.Prototype;

public class DocumentStyle : IPrototype<DocumentStyle>
{
    public string FontFamily { get; set; }
    public int FontSize { get; set; }
    public string HeaderColor { get; set; }
    public string LogoUrl { get; set; }
    public Margins PageMargins { get; set; }
    
    public DocumentStyle ShallowCopy() => (DocumentStyle)this.MemberwiseClone();

    public DocumentStyle DeepCopy() => new DocumentStyle
    {
        FontFamily = this.FontFamily,
        FontSize = this.FontSize,
        HeaderColor = this.HeaderColor,
        LogoUrl = this.LogoUrl,
        PageMargins = new Margins
        {
            Bottom = this.PageMargins.Bottom,
            Left = this.PageMargins.Left,
            Right = this.PageMargins.Right,
            Top = this.PageMargins.Top
        },
    };
}