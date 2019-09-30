namespace TypeFaster.GameServices.Contracts
{
    public interface ISententceEvaluationService
    {
        bool CheckIfInputIsASliceOfSentence(string input, int sentence_id);
    }
}
