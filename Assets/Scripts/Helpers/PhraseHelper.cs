using System;

public static class PhraseHelper
{
    private static Random rand;

    public static void Init()
    {
        rand = new Random();
    }

    public static string GetRandomPhrase(int nLettersPerPhrase)
    {
        string phrase = "";

        for (int i = 0; i < nLettersPerPhrase; i++)
        {
            phrase += GetRandomLetter();
        }

        return phrase;
    }

    public static char GetRandomLetter()
    {
        string characterList = "abcdefghijklmnopqrstuvwxyz ";
        int position = rand.Next(0, characterList.Length);
        return characterList[position];
    }
}