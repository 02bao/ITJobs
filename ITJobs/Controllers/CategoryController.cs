using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController : ControllerBase
{
    // kỹ thuật Dependency Injection
    private readonly ICategoryRepository _categoryRepository;
    private readonly IMapper _mapper;
    // constructor
    public CategoryController(ICategoryRepository categoryRepository, IMapper mapper)
    {
        _categoryRepository = categoryRepository;
        _mapper = mapper;
    }

    [HttpPost("CreateNewCategory")]
    public IActionResult CreateNewCategory(long companyid, Category_Create category)
    {
        bool tmp = _categoryRepository.CreateNewCategory(companyid, category);
        if (tmp)
        {
            return Ok("Create New Category Successfully");
        }
        return BadRequest("Create Failed, Please try again!");
    }

    [HttpGet("GetList")]
    public IActionResult GetList()
    {
        var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetAllCategories());
        return Ok(categories);
    }

    [HttpGet("GetById")]
    public IActionResult GetById(long id)
    {
        var categories = _mapper.Map<CategoryDTO>(_categoryRepository.GetById(id));
        return Ok(categories);
    }

    [HttpGet("GetByCompanyId")]
    public IActionResult GetByCompanyId(long companyid)
    {
        var categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetByCompanyId(companyid));
        return Ok(categories);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] CategoryDTO _DTO)
    {
        var categories = _mapper.Map<Category>(_DTO);
        bool tmp = _categoryRepository.Update(categories);
        if (tmp)
        {
            return Ok("Update Successfully");
        }
        return BadRequest("Update Failed, Please try again!");
    }

    [HttpDelete("Delete")]
    public IActionResult Delete(long id)
    {
        bool tmp = _categoryRepository.Delete(id);
        if (tmp)
        {
            return Ok("Delete Successfully");
        }
        return BadRequest("Delete Failed, Please try again!");
    }
}
