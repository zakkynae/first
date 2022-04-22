﻿using ConsoleTables;
class Program
{
    private static void GetArraysData(DirectoryInfo directory, out long[] arrayLengthFiles, out DateTime[] arrayDateCreationFile, out string[] arrayExtensionFiles)
    {
        var listFiles = directory.GetFiles();
        arrayLengthFiles = new long[listFiles.Length];
        arrayDateCreationFile = new DateTime[listFiles.Length];
        arrayExtensionFiles = new string[listFiles.Length];
        for (int i = 0; i < listFiles.Length; i++)
        {
            arrayLengthFiles[i] = listFiles[i].Length;
            arrayDateCreationFile[i] = listFiles[i].CreationTime;
            arrayExtensionFiles[i] = listFiles[i].Extension;
        }
        Array.Sort(arrayLengthFiles);
        Array.Sort(arrayDateCreationFile);
    }
    private static string[] GetSortedArrayExtension(string[] arrayExtensionFiles)
    {
        var amountExtensionFiles = new Dictionary<string, int>();
        foreach (var extension in arrayExtensionFiles)
        {
            if (!amountExtensionFiles.ContainsKey(extension)) amountExtensionFiles[extension] = 0;
            amountExtensionFiles[extension]++;
        }
        amountExtensionFiles = amountExtensionFiles.OrderByDescending(pair => pair.Value).ToDictionary(pair => pair.Key, pair => pair.Value);

        return amountExtensionFiles.Keys.ToArray();
    }
    private static ConsoleTable GetTable(string[] arrayExtensionFiles, long[] arrayLengthFiles, DateTime[] arrayDateCreationFile)
    {
        var table = new ConsoleTable("The largest files", "The most popular extensions", "The oldest files");
        for (int i = 0; i < 3; i++)
        {
            table.AddRow(arrayLengthFiles[i], arrayExtensionFiles[i], arrayDateCreationFile[i]);
        }
        return table;
    }
    static void Main(string[] args)
    {
        Console.Write("Введите директорию: ");
        var path = String.Format($@"{Console.ReadLine()}");
        var directory = new DirectoryInfo(path);
        string[] arrayExtensionFiles;
        long[] arrayLengthFiles;
        DateTime[] arrayDateCreationFile;

        GetArraysData(directory, out arrayLengthFiles, out arrayDateCreationFile, out arrayExtensionFiles);
        GetSortedArrayExtension(arrayExtensionFiles);
        var table = GetTable(arrayExtensionFiles, arrayLengthFiles, arrayDateCreationFile);
        table.Write();
    }
}