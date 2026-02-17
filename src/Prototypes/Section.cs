using DesignPatternChallenge.Contracts;

namespace DesignPatternChallenge.Prototype;

public class Section : IPrototype<Section>
{
    public string Name { get; set; }
    public string Content { get; set; }
    public bool IsEditable { get; set; }
    public List<string> Placeholders { get; set; }

    public Section()
    {
        Placeholders = new List<string>();
    }

    public Section ShallowCopy() => (Section)this.MemberwiseClone();

    public Section DeepCopy() => new Section()
    {
        Name = this.Name,
        Content = this.Content,
        IsEditable = this.IsEditable,
        Placeholders = new List<string>(this.Placeholders)
    };
}