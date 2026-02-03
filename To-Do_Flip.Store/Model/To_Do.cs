namespace To_Do_Flip.Store.Model;

public class To_Do
{
    public const int MAX_LENGTH = 1000;
    public To_Do(Guid id, string name, string description)
    {
        Id = id;
        Name = name;
        Description = description;
    }

    public Guid Id { get; set; }
    public string Name { get; set; } = string.Empty;
    public string Description { get; set; } = string.Empty;

    public static (To_Do to_Do, string Error) Create(Guid id, string name, string description)
    {
        var error = string.Empty;

        if (string.IsNullOrWhiteSpace(name) || name.Length > MAX_LENGTH)
        {
            error = "Name is too long or can not be empty";
        }

        if (description.Length > MAX_LENGTH)
        {
            error = "Description is too long";
        }
        
        var to_Do = new To_Do(id, name, description);
        return (to_Do, error);
    }
}