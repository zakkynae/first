using ConsoleTables;
class Program
{
    private static void FillingAndSortingArrays(FileInfo[] listFiles, out long[] arrayLengthFiles, out DateTime[] arrayDateCreationFile, out string[] arrayExtensionFiles)
    {
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
            table.AddRow(arrayLengthFiles[arrayLengthFiles.Length - 1 - i], arrayExtensionFiles[i], arrayDateCreationFile[i]);
        }
        return table;
    }
    static void Main(string[] args)
    {
        Console.Write("Введите директорию: ");
        var path = String.Format($@"{Console.ReadLine()}");
        var directory = new DirectoryInfo(path);

        string[] arrayExtensionFilesAllDirectories;
        long[] arrayLengthFilesAllDirectories;
        DateTime[] arrayDateCreationFileAllDirectories;
        var listFilesAllDirectories = directory.GetFiles("*.*", SearchOption.AllDirectories);
        FillingAndSortingArrays(listFilesAllDirectories, out arrayLengthFilesAllDirectories, out arrayDateCreationFileAllDirectories, out arrayExtensionFilesAllDirectories);
        var firstTable = GetTable(GetSortedArrayExtension(arrayExtensionFilesAllDirectories), arrayLengthFilesAllDirectories, arrayDateCreationFileAllDirectories);
        Console.WriteLine("Файлы в указанной директории и в подпапках");
        firstTable.Write();

        string[] arrayExtensionFilesDirectory;
        long[] arrayLengthFilesDirectory;
        DateTime[] arrayDateCreationFileDirectory;
        var listFiles = directory.GetFiles();
        FillingAndSortingArrays(listFiles, out arrayLengthFilesDirectory, out arrayDateCreationFileDirectory, out arrayExtensionFilesDirectory);
        Console.WriteLine("Файлы в указанной директории и в подпапках");
        var secondTable = GetTable(GetSortedArrayExtension(arrayExtensionFilesDirectory), arrayLengthFilesDirectory, arrayDateCreationFileDirectory);
        secondTable.Write();

        string[] arrayExtensionFilesDisk;
        long[] arrayLengthFilesDisk;
        DateTime[] arrayDateCreationFileDisk;
        try
        { 
            var directoryDisk = new DirectoryInfo(path.Substring(0, 3));
            var listFilesDisk = directoryDisk.GetFiles("*", SearchOption.AllDirectories);
            FillingAndSortingArrays(listFilesDisk, out arrayLengthFilesDisk, out arrayDateCreationFileDisk, out arrayExtensionFilesDisk);
            var thirdTable = GetTable(GetSortedArrayExtension(arrayExtensionFilesDisk), arrayLengthFilesDisk, arrayDateCreationFileDisk);
            thirdTable.Write();
        }
        catch (UnauthorizedAccessException ex)
        {
            Console.WriteLine(ex.Message);
        }
        Console.ReadKey();
    }
}
