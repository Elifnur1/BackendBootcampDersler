using System;

namespace EFCore.Shared.Dtos;

public class CategoryCreateDto
{
    public string? Name { get; set; }
    public bool IsDeleted { get; set; }
    public string? Description { get; set; }
}
