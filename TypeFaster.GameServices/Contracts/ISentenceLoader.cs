using TypeFaster.Domain.Entities;

namespace TypeFaster.GameServices.Contracts
{
    public interface ISentenceLoader
    {
        Sentence GetNextRandomSentence();
    }
}
