public class ProductBase
{
    public string Name { get; set; }
    public string Description { get; set; }
    public string Category { get; set; }
    public decimal Price { get; set; }
    public int Stock { get; set; }
}

public class Product : ProductBase
{
    public Guid Id { get; set; }
}

public class CreateProductDto : ProductBase
{
}
