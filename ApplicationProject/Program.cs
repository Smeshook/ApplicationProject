// See https://aka.ms/new-console-template for more information
using System;
using System.Collections.Concurrent;
using System.IO;

public static class Application
{
    static void Main(string[] args)
    {
        Console.WriteLine("Enter path to book");
        string pathToBook = Console.ReadLine();
        string pathToUniqueWords = @".\uniqueWords.txt";

        StreamReader bookLines = new StreamReader (pathToBook);

        //string allLines = bookLines.ReadLine().ToLower();
        var specialWords = new Dictionary<string, int>();
        string[] textWords;

        char[] charsToTrim = {' ', '.', ',', '-', '\n', '\"', '(', ')', ':', ';', '[', ']', '\t', '!', '?',
                                                     '0','1','2','3','4','5','6','7','8','9'};
        string[] notUnique = {"я", "мы","он","она","они","оно","ты","вы","нее","у","в","него","ее","его","мне","чтобы","себя", "тебя",
                              "не", "с","к","все","за","это","от","по","так","то","из","бы","ему","ей","была","будто","быть", "тут", "уж",
                              "о","и","или","в","на","под","над","а","но","как","что", "сноска", "же", "этот","ним","ваше", "свое", "даже", "всё",
                              "было","были","был","еще","для","когда","вот","ни","ну","до","нет", "да", "этого", "про", "эти","этих","кто",
                              "того","вас","тем","себе","ли","вам","чем","которые","во","свою","перед", "сам", "мой", "меня", "чтоб", "если", 
                              "их","только","уже","очень","всех","при","со","чтото","своего","им","без", "ней", "там", "го", "т","г","м", "ж"};


        while (true)
        {
            string allLines = bookLines.ReadLine();
            if (allLines == null)
                break;
            else
                allLines = allLines.ToLower();

            textWords = allLines.Split(' ');

            foreach (string word in textWords)
            {
                if (specialWords.ContainsKey(word))
                    specialWords[word]++;
                else
                    specialWords[word] = 1;
            }

        }
            bookLines.Close();

        StreamWriter uniqeWords = new StreamWriter(pathToUniqueWords);
        
        specialWords.Remove("");
        
        foreach (string word in notUnique)
            specialWords.Remove(word);

        foreach (var word in specialWords.OrderByDescending(x => x.Value))
            uniqeWords.WriteLine($"{word.Key}\t {word.Value}");

        uniqeWords.Close();
    }
}