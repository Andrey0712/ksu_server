using AutoMapper;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using System.Globalization;
using WebKsu.Data;
using static WebKsu.Model.BanerViewModel;
using WebKsu.Data.Entities;
using Microsoft.EntityFrameworkCore;

namespace WebKsu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class BanerForecastController : ControllerBase
    {
       /* private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };*/

        private readonly ILogger<BanerForecastController> _logger;
        private readonly IMapper _mapper;
        private readonly AppEFContext _context;

        public BanerForecastController(ILogger<BanerForecastController> logger, IMapper mapper, AppEFContext context)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
        }

       // [HttpGet(Name = "GetWeatherForecast")]

        /// <summary>
        /// �������
        /// </summary>
        /// <returns>������� ����</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">������� ��� ������</response>
        /// <response code="400">Has missing/invalid values</response>
        /// <response code="500">Oops! Can't get list right now</response>
        /// 
        [HttpGet]
        [Route("details_for_payment")]
        public IActionResult DounloudFile()
        {
            string contentType = "";
            string file = Directory.GetCurrentDirectory() +
                "/dataRahunok/details_for_payment.pdf";
            new FileExtensionContentTypeProvider()
                .TryGetContentType(file, out contentType);

            return new PhysicalFileResult(file, contentType);
        }

        /// <summary>
        /// ������ ������
        /// </summary>
        /// <returns>������� ����</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List products</response>
        /// <response code="400">List products has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  products list right now</response>

        [HttpGet]
        [Route("listBaners")]
        public async Task<IActionResult> List()
        {
            try
            {
                Thread.Sleep(2000);
                var model = await _context.Baner
                                 .Select(x => _mapper.Map<BanerItemViewModel>(x)).ToListAsync();
                return Ok(model);
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    invalid = ex.Message
                });
            }
        }

        /// <summary>
        /// ������� �� ID
        /// </summary>
        /// <param name="id">������ �� ������</param>
        /// <returns>������� ������ �� id</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Get product</response>
        /// <response code="400">Get product has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  product  right now</response>

        [HttpGet]
        [Route("get/{id}")]
        public IActionResult GetData(int id)
        {
            var cultureInfo = new CultureInfo("ua-UA");
            var product = _context.Baner.FirstOrDefault(x => x.Id == id);
            BanerViewModelImages model = new BanerViewModelImages
            {
                Id = product.Id,
                Name = product.Name,
                Description = product.Description,
                StartPhoto = product.StartPhoto,
                DateCreate = product.DateCreated.ToString("dd.MM.yyyy HH:mm:ss"),

            };
            return Ok(model);
        }

        /// <summary>
        /// ��������� ��������
        /// </summary>
        /// <param name="id">������ �� ������</param>
        /// <returns>������� �����������</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Delete product</response>
        /// <response code="400">Delete product has missing/invalid values</response>
        /// <response code="500">Oops! Can't delete product now</response>

        [HttpPost]
        [Route("deleteBaner")]
        //public IActionResult Delete([FromBody] ProductItemViewModel model)
        public IActionResult Delete([FromBody] int id)

        {

            var res = _context.Baner.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                return BadRequest(new { message = "Check id!" });
            }

            _context.Baner.Remove(res);
            _context.SaveChanges();
            return Ok(new { message = "Product deleted" });
        }

        /// <summary>
        /// ������ �����
        /// </summary>
        /// <param name="model">������ �� ������</param>
        /// <returns>������� ok</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Add product</response>
        /// <response code="400">Add product has missing/invalid values</response>
        /// <response code="500">Oops! Can't add product right now</response>

        [HttpPost]
        [Route("addBaner")]
        public async Task<IActionResult> Add([FromForm] BanerAddViewModel model)
        {
            try
            {

                string startFoto = String.Empty;
                var product = _mapper.Map<BanerEntity>(model);

                if (model.StartPhoto != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto.CopyTo(file);
                    }
                    product.StartPhoto = randomFilename;
                }
                _context.Baner.Add(product);
                await _context.SaveChangesAsync();

                /*foreach (var img in fileNames)
                {
                    ProductImageEntity productImage = new ProductImageEntity()
                    {
                        Name = img,
                        ProductId = product.Id
                    };
                    _context.ProductImages.Add(productImage);
                    _context.SaveChanges();
                }*/
                return Ok();
            }
            catch (Exception ex)
            {
                return BadRequest(new
                {
                    invalid = ex.Message
                });
            }
        }

        /// <summary>
        /// ����������� ������
        /// </summary>
        /// <param name="model">������ �� ������</param>
        /// <returns>������� message</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Edit product</response>
        /// <response code="400">Edit product has missing/invalid values</response>
        /// <response code="500">Oops! Can't edit product now</response>

        [HttpPost]
        [Route("editBaner")]
        public IActionResult Edit([FromForm] BanerToEdit model)
        {


            if (ModelState.IsValid)
            {
                var itemProd = _context.Baner
                             .FirstOrDefault(x => x.Id == model.Id);
                string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");

                itemProd.Id = model.Id;
                if (model.Name != null)
                {
                    itemProd.Name = model.Name;
                }
                if (model.Description != null)
                {
                    itemProd.Description = model.Description;
                }

                if (model.StartPhoto != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto.FileName);

                    var startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto.CopyTo(file);
                    }
                    itemProd.StartPhoto = randomFilename;
                }

                /* //��������� ���� �����
                 if (model.deletedImages != null)
                 {
                     foreach (var delProduct in model.deletedImages)
                     {
                         var delProductImage = itemProd.ProductImages.SingleOrDefault(x => delProduct.Contains(x.Name));
                         string imgPath = Path.Combine(dirPath, delProductImage.Name);
                         if (System.IO.File.Exists(imgPath))
                         {
                             System.IO.File.Delete(imgPath);
                         }
                         _context.ProductImages.Remove(delProductImage);
                     }
                 }
                 //������ ��� �����
                 if (model.Images != null)
                 {
                     foreach (var newImages in model.Images)
                     {
                         string ext = Path.GetExtension(newImages.FileName);
                         string fileName = Path.GetRandomFileName() + ext;

                         string filePath = Path.Combine(dirPath, fileName);
                         using (var stream = System.IO.File.Create(filePath))
                         {
                             newImages.CopyTo(stream);
                         }

                         _context.ProductImages.Add(new Data.Entities.ProductImageEntity
                         {
                             Name = fileName,
                             ProductId = itemProd.Id
                         });
                     }
                 }*/

                _context.SaveChanges();

            }
            //return Ok(model);
            return Ok(new { message = "ok edit" });

        }

        /* public IEnumerable<WeatherForecast> Get()
         {
             return Enumerable.Range(1, 5).Select(index => new WeatherForecast
             {
                 Date = DateTime.Now.AddDays(index),
                 TemperatureC = Random.Shared.Next(-20, 55),
                 Summary = Summaries[Random.Shared.Next(Summaries.Length)]
             })
             .ToArray();
         }*/
    }
}
