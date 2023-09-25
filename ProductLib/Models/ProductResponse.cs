namespace ProductLib;
public class ProductResponse
{
    public string? Id {get;set;}=default;
    public string Code {get;set;}=default!;
    public string? Name {get;set;}=default;
    public Category? Category {get;set;} = default;
}