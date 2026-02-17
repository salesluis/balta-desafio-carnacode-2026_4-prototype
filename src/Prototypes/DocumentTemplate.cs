using DesignPatternChallenge.Contracts;

namespace DesignPatternChallenge.Prototype;

public class DocumentTemplate : IPrototype<DocumentTemplate>
{
    public string Title { get; set; }
    public string Category { get; set; }
    public List<Section> Sections { get; set; }
    public DocumentStyle Style { get; set; }
    public List<string> RequiredFields { get; set; }
    public Dictionary<string, string> Metadata { get; set; }
    public ApprovalWorkflow Workflow { get; set; }
    public List<string> Tags { get; set; }
    
    public DocumentTemplate()
    {
        Sections = new List<Section>();
        RequiredFields = new List<string>();
        Metadata = new Dictionary<string, string>();
        Tags = new List<string>();
    }
    
    
    public DocumentTemplate ShallowCopy() => (DocumentTemplate)this.MemberwiseClone();

    public DocumentTemplate DeepCopy() => new DocumentTemplate
    {
        Title =  this.Title,
        Category = this.Category,
        Sections = this.Sections.Select(s => s.DeepCopy()).ToList(),
        Style = this.Style.DeepCopy(),
        RequiredFields = new List<string>(this.RequiredFields),
        Metadata = new Dictionary<string, string>(this.Metadata),
        Workflow = this.Workflow.DeepCopy(),
        Tags = new List<string>(this.Tags)
    };
}