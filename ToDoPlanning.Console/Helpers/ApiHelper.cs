using System.Xml.Linq;
using Newtonsoft.Json;
using ToDoPlanning.Models.Response.API;
using Task = ToDoPlanning.Models.Response.API.Task;

namespace ToDoPlanning.Console.Helpers;

public class ApiHelper
{
    private readonly HttpClient _httpClient;

    public ApiHelper()
    {
        _httpClient = new HttpClient();
    }

    public async Task<Model> GetDataAsync(string apiURL)
    {
        try
        {
            HttpResponseMessage response = await _httpClient.GetAsync(apiURL);

            string contentType = response.Content.Headers.ContentType?.ToString();

           
            if (response.IsSuccessStatusCode)
            {
                if (contentType == "application/json; charset=UTF-8")
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    Model parsedData = JsonConvert.DeserializeObject<Model>(responseData);
                    return parsedData;
                }
                if (contentType == "application/xml; charset=UTF-8")
                {
                    string responseData = await response.Content.ReadAsStringAsync();
                    
                    XDocument xmlDoc = XDocument.Parse(responseData);

                    Model model = new Model
                    {
                        Tasks = xmlDoc.Descendants("task").Select(t => new Task
                        {
                            Name = (string)t.Element("task_name"),
                            Duration = (int)t.Element("task_duration"),
                            Difficulty = (int)t.Element("task_difficulty")
                        }).ToList()
                    };
                    
                    return model;
                }
               
            }
        }
        catch (Exception e)
        {
            throw e;
        }

        return null;
    }
}