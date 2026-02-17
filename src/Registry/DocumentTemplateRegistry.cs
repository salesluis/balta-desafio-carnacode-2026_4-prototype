
using DesignPatternChallenge.Prototype;

namespace DesignPatternChallenge.Registry;

public class DocumentTemplateRegistry
{
    private readonly Dictionary<string, DocumentTemplate> _prototypes = new();

    public void Register(string key, DocumentTemplate prototype)
        => _prototypes[key] = prototype;
    
    public DocumentTemplate GetDeepCopy(string key)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new ArgumentException($"Template '{key}' não encontrado!");

        return prototype.DeepCopy();
    }
    
    public DocumentTemplate GetShallowCopy(string key)
    {
        if (!_prototypes.TryGetValue(key, out var prototype))
            throw new ArgumentException($"Template '{key}' não encontrado!");

        return prototype.ShallowCopy();
    }
}