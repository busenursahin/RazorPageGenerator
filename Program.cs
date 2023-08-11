using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using RazorPageGenerator;

public class Program
{
    private static async Task Main(string[] args)
    {
        /*   var catClientService = new CatClientService();
          var cats = await catClientService.GetAll("https://api.thecatapi.com/v1/images/search");
   */

        //https://api.thecatapi.com/v1/images/search
        /*    string endPoint = args[0];
           string ns = args[1];
           string typeName = args[2];
    */

        string endPoint = "https://api.thecatapi.com/v1/images/search";
        string ns = "Cat.Web.Models";
        string typeName = "Cat";

        HttpClientHelper clientHelper = new HttpClientHelper();
        string jsonString = await clientHelper.GetJson(endPoint);


        JArray jArray = JArray.Parse(jsonString);
        JObject jsonObject = jArray.Children<JObject>().First();
        //JObject.Parse

        string savePath = Path.Combine(Constants.TargetFolder, "RazorPageGenerator");

        using (StreamWriter streamWriter = new StreamWriter(Path.Combine(savePath, $"{typeName}.cs")))
        {
            streamWriter.WriteLine($"using System;");
            streamWriter.WriteLine($"using System.Linq;");
            streamWriter.WriteLine();
            streamWriter.WriteLine($"namespace {ns};");
            streamWriter.WriteLine();
            streamWriter.WriteLine($"public class {typeName}");
            streamWriter.WriteLine("{");

            var propertyBuilder = new PropertyBuilder();
            foreach (var property in jsonObject.Properties())
            {
                var prop = propertyBuilder.GetProperty(property);
                streamWriter.WriteLine(prop);
            }

            streamWriter.WriteLine("}"); ;
        }


        using (StreamWriter streamWriter = new StreamWriter(Path.Combine(savePath, $"{typeName}ClientService.cs")))
        {
            streamWriter.WriteLine($"using System;");
            streamWriter.WriteLine($"using System.Linq;");
            streamWriter.WriteLine($"using {ns}.Services;");
            streamWriter.WriteLine();
            streamWriter.WriteLine($"namespace {ns};");
            streamWriter.WriteLine();
            streamWriter.WriteLine($"public class {typeName}ClientService : ClientService<{typeName}>");
            streamWriter.WriteLine("{");
            streamWriter.WriteLine("}"); ;

        }





        // http of from file get 
        // FileReadHelper fileReadHelper = new FileReadHelper();
        // await fileReadHelper.GetResponse("Pizza", "/Users/bnd/Desktop/build-in-public/RazorPageGenerator/Pizza.json");

        Console.Read();

        // json deserialize - jobject

        // typeof value --> type

        // property name : type --> class 

        // aspnet-code-generator

    }
}