namespace MyBookify.Domain.Users;

public sealed class Role
{
    public static readonly Role Registered = new(1, "Registered");

    private readonly List<Permission> _permissions = [];

    public Role(int id, string name)
    {
        Id = id;
        Name = name;
    }


    public Role(int id, string name, Permission permission)
    {
        Id = id;
        Name = name;
        _permissions.Add(permission);
    }


    public int Id { get; init; }

    public string Name { get; init; }

    public ICollection<User> Users { get; init; } = [];
    public ICollection<Permission> Permissions { get; init; } = [];
}

