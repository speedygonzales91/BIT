using BIT_DataAccess.Data;
using BIT_Models;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace BIT_Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class FilesController : ControllerBase
    {
        private readonly ApplicationDbContext _db;

        public FilesController(ApplicationDbContext db)
        {
            this._db = db;
        }


        [HttpPost]
        public async Task<IActionResult> UploadFile()
        {
            try
            {
                if (Request.HasFormContentType)
                {
                    var form = Request.Form;
                    var files = new List<BIT_DataAccess.Data.File>();
                    foreach (var file in form.Files)
                    {
                        var name = $"{file.Name}.{file.ContentType}";
                        var fileToAdd = new BIT_DataAccess.Data.File
                        {
                            Name = file.FileName,
                            FileType = file.ContentType,
                            CreatedOn = DateTime.Now,
                            CreatedBy = "Admin"
                        };

                        var memoryStream = new MemoryStream();
                        await file.OpenReadStream().CopyToAsync(memoryStream);
                        fileToAdd.DataFiles = memoryStream.ToArray();

                        files.Add(fileToAdd);
                    }


                    await _db.Files.AddRangeAsync(files);
                    await _db.SaveChangesAsync();

                    return Ok(files);

                }
                return BadRequest(new ErrorModel
                {
                    ErrorMessage = "File is missing"
                });
            }
            catch (Exception)
            {

                return null;
            }
        }
    }
}
