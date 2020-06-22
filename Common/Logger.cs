using System;
using System.IO;

public class Logger
{
    private static string LogFilePath = @"C:\Users\Benwi\Desktop\Repos\Automation\Logs.txt";

    public static void LogResult(string name, bool success, string addText) 
    {
        var logMessage = DateTime.Now.ToString("g") + $" {name}: ";
        logMessage += success ? $"✔   point total: {addText}" : $"❌   message: {addText}";
        logMessage += "\n";
        File.AppendAllText(LogFilePath, logMessage);
    }
}