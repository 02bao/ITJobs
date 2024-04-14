using AutoMapper;
using ITJobs.DTO;
using ITJobs.Interface;
using ITJobs.Models;
using Microsoft.AspNetCore.Mvc;

namespace ITJobs.Controllers;

[ApiController]
[Route("api/[controller]")]
public class CategoryController(
    ICategoryRepository _categoryRepository, 
    IMapper _mapper) : ControllerBase
{
    [HttpPost("CreateNewCategory")]
    public IActionResult CreateNewCategory(long companyid, Category_Create category)
    {
        bool IsSuccess = _categoryRepository.CreateNewCategory(companyid, category);
        return IsSuccess ? Ok() : BadRequest();
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
        CategoryDTO categories = _mapper.Map<CategoryDTO>(_categoryRepository.GetById(id));
        return Ok(categories);
    }

    [HttpGet("GetByCompanyId")]
    public IActionResult GetByCompanyId(long companyid)
    {
        List<CategoryDTO> categories = _mapper.Map<List<CategoryDTO>>(_categoryRepository.GetByCompanyId(companyid));
        return Ok(categories);
    }

    [HttpPut("Update")]
    public IActionResult Update([FromBody] CategoryDTO _DTO)
    {
        Category categories = _mapper.Map<Category>(_DTO);
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
        bool IsSuccess = _categoryRepository.Delete(id);
        return IsSuccess ? Ok() : BadRequest();
    }
}
