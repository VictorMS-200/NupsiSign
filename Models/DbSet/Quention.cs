namespace NupsiSign.Models.DbSet;

public class Question
{
    public string title { get; set; }
    public bool date { get; set; }
    public List<string> options { get; set; }

    public Question()
    {
        
    }

    public Question(string title, bool date, List<string> options)
    {
        this.title = title;
        this.date = date;
        this.options = options;
    }
    public Question(string title, bool method)
    {
        this.title = title;
        this.date = method;
    }

    public Question(string title, List<string> options)
    {
        this.title = title;
        this.options = options;
    }

    public Question(string title)
    {
        this.title = title;
    }
}