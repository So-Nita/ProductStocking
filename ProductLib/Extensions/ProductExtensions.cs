using AutoMapper;
using Microsoft.IdentityModel.Tokens;
using ProductLib.Models;
using ProductLib.Repository;

namespace ProductLib.Extensions;

public class ProductExtensions
{
    private readonly Repository<Product> _context;
    private readonly IMapper _mapper;   
    public ProductExtensions(Repository<Product> context, IMapper mapper)
    {
        _context = context;
        _mapper = mapper;
    }
    
    public List<Product> ReadAllProduct()
    {
        return _context.GetAll()!.ToList();
    }
    public Product CreateProduct(ProductCreateReq req)
    {
        if (req.Code.IsNullOrEmpty()) throw new ArgumentException("Code is required");
        if (req.Category.CompareTo == null) throw new ArgumentException("Code is required");
        var data = new Product()
        {
            Id = Guid.NewGuid().ToString(),
            Code = req.Code,
            Name = req.Name,
            Category = req.Category,
            Created = DateTime.Now,
            LastUpdated = null
        };
        try
        {
            _context.Add(data);
            _context.SaveChanges();
        }
        catch { throw new Exception(); }
        return data;
    }
    public Product UpdateProduct(ProductUpdateReq product)
    {
        var existPro = _context.GetById(product.Id);
        if (existPro == null) throw new ArgumentException("Product doesn't existing.");
        
        existPro.Code = product.Code!;
        existPro.Name = product.Name;
        existPro.Category = product.Category ?? default;
        existPro.LastUpdated = DateTime.Now;
        try
        {
            _context.Update(existPro);
            _context.SaveChanges();
        }
        catch { throw new ArgumentException("Cannot update product."); }
        return existPro;
    }
    public bool DeleteProduct(String id)
    {
        var existPro = _context.GetById(id);
        if (existPro == null) throw new ArgumentException("Product doesn't existing.");
        try
        {
            _context.Delete(existPro);
            _context.SaveChanges();
        }
        catch
        {
            throw new ArgumentException("Cannot delete product.");
        }
        return true;
    }
    
}
