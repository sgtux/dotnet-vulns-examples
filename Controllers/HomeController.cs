using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace DotnetVulnsExamples.Controllers;

[ApiController]
[Route("[controller]")]
public class HomeController : ControllerBase
{
    [HttpPost]
    public object Get([FromBody] Person person)
    {
        var process = new System.Diagnostics.Process()
        {
            StartInfo = new System.Diagnostics.ProcessStartInfo
            {
                FileName = "/bin/bash",
                Arguments = $"-c \"ping -c1 127.0.0.1\"",
                RedirectStandardOutput = true,
                RedirectStandardError = true,
                UseShellExecute = false,
                CreateNoWindow = true,
            }
        };

        // process.Start();
        // var resultOutput = process.StandardOutput.ReadToEnd();
        // var resultError = process.StandardError.ReadToEnd();
        // process.WaitForExit();

        var data = System.IO.File.ReadAllText("./ping.json");

        var processJson = Newtonsoft.Json.JsonConvert.DeserializeObject(data,
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

        // return Newtonsoft.Json.JsonConvert.SerializeObject(process,
        // new JsonSerializerSettings
        // {
        //     TypeNameHandling = TypeNameHandling.All
        // });


        // var personJson = (Person)Newtonsoft.Json.JsonConvert.DeserializeObject(person,
        //     new JsonSerializerSettings
        //     {
        //         TypeNameHandling = TypeNameHandling.All
        //     });

        // return person;

        return Newtonsoft.Json.JsonConvert.SerializeObject(new Person("Fulano", 45),
            new JsonSerializerSettings
            {
                TypeNameHandling = TypeNameHandling.All
            });

        // Process.
        //             emptyLoan = (Loan)Newtonsoft.Json.JsonConvert.DeserializeObject(fileContent,
        //                 new JsonSerializerSettings
        //                 {
        //                     TypeNameHandling = TypeNameHandling.All
        //                 });
    }
}