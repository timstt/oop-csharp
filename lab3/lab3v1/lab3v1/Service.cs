using System;
using System.IO;

public class Service
{
    private string _outputFormat;
    private string _filePath;
    private string _dataToProcess;

    public Service(string format, string path)
    {
        _outputFormat = format;
        _filePath = path;
    }

    public void SaveAndPrint(string message)
    {
        _dataToProcess = message;

        string result = _outputFormat + ": " + _dataToProcess;

        Console.WriteLine(result);
        File.AppendAllText(_filePath, result + Environment.NewLine);
    }

    public string ReadFromConsole()
    {
        return Console.ReadLine();
    }

    public string ReadFromFile()
    {
        if (File.Exists(_filePath))
        {
            return File.ReadAllText(_filePath);
        }
        return "Файл не знайдено.";
    }

    public void ClearFile()
    {
        File.WriteAllText(_filePath, string.Empty);
    }
}