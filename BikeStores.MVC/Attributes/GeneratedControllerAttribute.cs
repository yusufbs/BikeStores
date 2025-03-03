namespace BikeStores.MVC.Attributes;

[AttributeUsage(AttributeTargets.Class, AllowMultiple = false)]
public class GeneratedControllerAttribute : Attribute
{
    public GeneratedControllerAttribute(Type type)
    {
        EntityType = type;
    }

    public Type EntityType { get; }
}
