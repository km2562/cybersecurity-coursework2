using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http.Headers;
using System.Net.Http.Json;
using System.Reflection;
using System.Text;
using System.Text.Json.Serialization;
using static ConsoleApp1.PaymentHar;

HelperFunctions help = new HelperFunctions();

string path = @".\outputHAR3.csv";

if (!File.Exists(path))
{
    // Create a file to write to.
    string[] createText = { "" };
    File.WriteAllLines(path, createText, Encoding.UTF8);
}

string readText = File.ReadAllText(@".\www.tkmaxx.com.har");

PaymentHar? fullHAR = JsonConvert.DeserializeObject<PaymentHar>(readText);

var entries = fullHAR.log.entries;

List<OutputFile> newFile = new List<OutputFile>();

foreach (var entry in entries)
{


    var outputFile = new OutputFile();

    outputFile.Timestamp = entry.startedDateTime;
    outputFile.RequestUrl = entry.request.url;
    outputFile.Method = entry.request.method;
    outputFile.ResponseStatus = entry.response.status;
    outputFile.ResponseStatusText = entry.response.statusText;

    newFile.Add(outputFile);

}



using (var writer = new StringWriter())
{
    var csvBuilder = new StringBuilder();

    // Write header
    PropertyInfo[] properties = typeof(OutputFile).GetProperties();
    string header = string.Join(",", properties.Select(p => p.Name));
    csvBuilder.AppendLine(header);

    // Write data
    foreach (var data in newFile)
    {
        string csvLine = string.Join(",", properties.Select(p => help.EscapeCsvField(p.GetValue(data)?.ToString())));
        csvBuilder.AppendLine(csvLine);
    }

    string asString = csvBuilder.ToString();

    File.AppendAllText(path, asString);


}

Console.WriteLine("breakpoint");


