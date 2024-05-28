var builder = WebApplication.CreateBuilder(args);
builder.Services.AddDbContext<CollegeDbContext>();
var app = builder.Build();

app.MapGet("/", () => "Hello World!");
app.MapGet("/courses", (CollegeDbContext db) =>db.Courses.ToList());
app.MapGet("/courses/{id:int}", (int id,CollegeDbContext db) =>db.Courses.Find(id));
app.MapGet("/sessions", (CollegeDbContext db) =>db.Sessions.ToList());
app.MapGet("/sessions/{id:int}", (int id,CollegeDbContext db) =>db.Sessions.Find(id));

app.MapPost("/courses", (Course course, CollegeDbContext db)=>
{
    db.Courses.Add(course);
    db.SaveChanges();
});
app.MapPut("/courses/{id}", (int id, Course course, CollegeDbContext db)=>
{
    db.Courses.Update(course);
    db.SaveChanges();
});
app.MapDelete("/courses/{id}", (int id, CollegeDbContext db)=>
{
    var course = db.Courses.Find(id);
    db.Courses.Remove(course);
    db.SaveChanges();
});

app.MapPost("/sessions", (Session session, CollegeDbContext db) =>
{
    db.Sessions.Add(session);
    db.SaveChanges();
});
app.MapPut("/sessions/{id}", (int id, Session session, CollegeDbContext db)=>
{
    db.Sessions.Update(session);
    db.SaveChanges();
});
app.MapDelete("/sessions/{id}", (int id, CollegeDbContext db)=>
{
    var session = db.Sessions.Find(id);
    db.Sessions.Remove(session);
    db.SaveChanges();
});

app.Run();
