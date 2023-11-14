using UnityEngine;
using System.Collections.Generic;

public class SentenceLibrary : MonoBehaviour
{
    public List<string> sentenceLibrary1;
    public List<string> sentenceLibrary2;
    public List<string> sentenceLibrary3;
    public List<string> sentenceLibrary4;
    public List<AudioClip> audioLibrary1;
    public List<AudioClip> audioLibrary2;
    public List<AudioClip> audioLibrary3;
    public List<AudioClip> audioLibrary4;

    public KeyValuePair<List<string>, List<AudioClip>> GenerateRandomSentences()
    {
        List<string> randomSentences = new List<string>();
        List<AudioClip> randomAudios = new List<AudioClip>();

        KeyValuePair<string, int> randomSentence1 = GetRandomSentenceFromLibrary(sentenceLibrary1);
        string sentence1 = randomSentence1.Key;
        int index1 = randomSentence1.Value;

        //KeyValuePair<string, int> randomSentence2 = GetRandomSentenceFromLibrary(sentenceLibrary2);
        //string sentence2 = randomSentence2.Key;
        //int index2 = randomSentence2.Value;

        //KeyValuePair<string, int> randomSentence3 = GetRandomSentenceFromLibrary(sentenceLibrary3);
        //string sentence3 = randomSentence3.Key;
        //int index3 = randomSentence3.Value;

        KeyValuePair<string, int> randomSentence4 = GetRandomSentenceFromLibrary(sentenceLibrary4);
        string sentence4 = randomSentence4.Key;
        int index4 = randomSentence4.Value;

        randomSentences.Add(sentence1);
        randomSentences.Add(sentenceLibrary2[index1]);
        randomSentences.Add(sentenceLibrary3[index1]);
        randomSentences.Add(sentence4);
        randomAudios.Add(audioLibrary1[index1]);
        randomAudios.Add(audioLibrary2[index1]);
        randomAudios.Add(audioLibrary3[index1]);
        randomAudios.Add(audioLibrary4[index4]);
        return new KeyValuePair<List<string>, List<AudioClip>>(randomSentences, randomAudios);
    }

    private KeyValuePair<string, int> GetRandomSentenceFromLibrary(List<string> sentenceLibrary)
    {
        int randomIndex = Random.Range(0, sentenceLibrary.Count);
        string sentence = sentenceLibrary[randomIndex];
        return new KeyValuePair<string, int>(sentence, randomIndex);
    }   

}



