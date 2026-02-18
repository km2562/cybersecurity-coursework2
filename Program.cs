using HARAnalyser;
using Newtonsoft.Json;
using System.Reflection;
using System.Text;

Console.WriteLine("HAR Analyser");

// This is a bespoke app written to convert the HAR file from JSON and to extract key data items to csv
// It has a second purpose to search for strings within the webpages. 
// This app relies on the HAR and webfiles being added to a folder on the C drive named "HAR"
// The HAR file is hardcoded as "www.tkmaxx.com.har"
// The webpage is hardcoded as "Payment powered by Worldpay - TK Maxx UK_files"

HelperFunctions help = new HelperFunctions();

// Read the HAR file and deserialise 
string readText = File.ReadAllText(@"C:\\HAR\www.tkmaxx.com.har");
PaymentHar fullHAR = JsonConvert.DeserializeObject<PaymentHar>(readText);
var entries = fullHAR.log.entries;

bool repeat = true;

while (repeat)
{
    Console.WriteLine("Choose a function");
    Console.WriteLine("[1] Extract URL details from HAR to file");
    Console.WriteLine("[2] Search in files");
    Console.WriteLine("[3] Exit");

    var input = Console.ReadLine();

    if (input == "1")
    {

        string path = @"C:\\HAR\outputHAR.csv";

        if (!File.Exists(path))
        {
            // Create a file to write to.
            string[] createText = { "" };
            File.WriteAllLines(path, createText, Encoding.UTF8);
        }

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

    }

    else if (input == "2")
    {

        Console.Write("Search term: ");
        string searchTerm = Console.ReadLine();
        int count = 0;

        string[] fileList = Directory.GetFiles(@"C:\\HAR\Payment powered by Worldpay - TK Maxx UK_files");

        foreach (var file in fileList)
        {
            string contents = File.ReadAllText(file);

            if (contents.Contains(searchTerm, StringComparison.CurrentCultureIgnoreCase))
            {
                Console.WriteLine(file);
                Console.WriteLine(" ");
                count++;
            }
        }

        if (count == 0)
        {
            Console.WriteLine("No instances found");
            Console.WriteLine(" ");
        }
    }

    else if (input == "3")
    {
        repeat = false;
    }
    else
    {
        Console.WriteLine("Input not recognised, try again");
    }
}
