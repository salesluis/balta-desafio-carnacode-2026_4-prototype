namespace DesignPatternChallenge.Contracts;

public interface IPrototype<T>
{
    T ShallowCopy();
    T DeepCopy();
}