using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

public class CoursesModel: PageModel
{    
    public List<Course> Courses { get; set; }
    public async Task OnGet()
    {
        // CollegeDbContext db = new();
        // Courses = db.Courses.ToList();

         // Consuming REST API with HttpClient
        HttpClient http = new HttpClient();
        Courses = await http.GetFromJsonAsync<List<Course>>("http://localhost:5238/courses");
    }
}
