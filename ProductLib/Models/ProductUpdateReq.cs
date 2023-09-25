using System;
namespace ProductLib.Models
{
	public class ProductUpdateReq
	{
        public string Id { get; set; } = default!;
        public string? Code { get; set; } = default!;
        public string? Name { get; set; } = default;
        public Category? Category { get; set; } =default!;
    }
}

