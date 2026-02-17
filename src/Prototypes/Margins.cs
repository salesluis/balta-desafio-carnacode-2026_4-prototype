using System.Runtime.CompilerServices;
using DesignPatternChallenge.Contracts;

namespace DesignPatternChallenge.Prototypes;

public class Margins : IPrototype<Margins>
{
    public int Top { get; set; }
    public int Bottom { get; set; }
    public int Left { get; set; }
    public int Right { get; set; }

    public Margins ShallowCopy() => (Margins)this.MemberwiseClone();

    public Margins DeepCopy() => new Margins
    {
        Top = this.Top,
        Bottom = this.Bottom,
        Left = this.Left,
        Right = this.Right
    };
}