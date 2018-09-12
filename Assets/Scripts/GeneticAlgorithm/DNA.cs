public class DNA
{
    public string phrase = "";

    public DNA()
    {
        phrase = PhraseHelper.GetRandomPhrase(Config.nLettersPerPhrase);
    }
}