using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace SparkSwim.GoodsService.Controllers;

[Authorize(Roles = "Admin", AuthenticationSchemes = "Bearer")]
public class UrlAdminController : BaseController
{
    [HttpGet("writeAbout/{newText}")]
    public async Task<ActionResult<string>> WriteAbout(string newText)
    {
        string fileContents = "null";
        string filePath = @$"{Directory.GetCurrentDirectory()}/about.txt";
        
        try
        {
            using (StreamWriter writer = new StreamWriter(filePath))
            {
                writer.Write(newText);
            }
        }
        catch (IOException e)
        {
            Console.WriteLine("Error while write to file, in UrlAdminController" + e.Message);
        }
        return fileContents;
    }
}