using BLL.Concrete;
using Entities;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ViewModels;
using WepAPI.Filters;

namespace WepAPI.Controllers
{
    [EnableCors("MyPolicy")]
    [Route("api/[controller]")]
    [ApiController]
    //[AuthActionFilter]
    public class CategoriesController : ControllerBase
    {
        private CategoryManager _categoryManager;

        public CategoriesController(CategoryManager categoryManager)
        {
            _categoryManager = categoryManager;
        }

        [HttpGet("listele")]
        public IActionResult Get()
        {
            if (!_categoryManager.GetAll().Any())
            {
                return BadRequest("hata");
            }
            return Ok(_categoryManager.GetAll());
        }

        //[HttpPost("Ekle")]
        //public IActionResult Post(CategoryViewModel viewModel)
        //{

        //    var result = _categoryManager.Add(viewModel);
        //    if (result < 1)
        //    {
        //        return BadRequest("Kategori eklerken hata oluştu!");
        //    }
        //    return Created("", "Başarılı");
        //}
        [HttpPost("Ekle")]
        public IActionResult Post([FromBody] CategoryViewModel viewModel)
        {
            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);
            }

            var result = _categoryManager.Add(viewModel);
            if (result < 1)
            {
                return BadRequest("Kategori eklerken hata oluştu!");
            }

            return CreatedAtAction(nameof(Post), new { id = result }, "Başarılı");
        }

        [HttpPut("Guncelle")]
        public IActionResult Put(int id,CategoryViewModel viewModel) 
        {
            var guncellenecekKategori = _categoryManager.GetById(id);
            if (guncellenecekKategori is null)
            {
                return BadRequest("Guncellenecek kategori bulunamadı");
            }
            guncellenecekKategori.Name = viewModel.Name;
            guncellenecekKategori.Products = viewModel.Products;
            var result = _categoryManager.Update(viewModel);
            if (result < 1)
            {
                return BadRequest("Kategori güncellenirken hata oluştu!");
            }
            return Ok(guncellenecekKategori);
        }

        [HttpDelete("Sil")]
        public IActionResult Delete(int id)
        {
            var kategori = _categoryManager.GetById(id);
            if (kategori is null)
            {
                return BadRequest("Silinecek kategori bulunamadı");
            }
           var result = _categoryManager.Delete(kategori);
            if (result < 1)
            {
                return BadRequest("Kategori silinirken hata oluştu!");
            }
            return Ok(kategori);
        }

        [HttpGet("Bul")]
        public IActionResult Get(int id)
        {
            var aranankategori = _categoryManager.GetById(id);
            if (aranankategori is null)
            {
                return BadRequest("Hata kategori bulunamadı");
            }

            return Ok(aranankategori);
        }
    }
}
