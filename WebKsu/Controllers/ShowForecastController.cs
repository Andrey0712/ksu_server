using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.StaticFiles;
using static WebKsu.Model.BanerViewModel;
using System.Globalization;
using WebKsu.Constants;
using WebKsu.Data.Entities;
using WebKsu.Data;
using Microsoft.EntityFrameworkCore;
using static WebKsu.Model.RunLineViewModel;
using WebKsu.Model;
using System;
using System.Linq;

namespace WebKsu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class ShowForecastController : ControllerBase
    {
        private readonly ILogger<ShowForecastController> _logger;
        private readonly IMapper _mapper;
        private readonly AppEFContext _context;
        private IHostEnvironment _host;

        public ShowForecastController(ILogger<ShowForecastController> logger, IMapper mapper, AppEFContext context, IHostEnvironment host)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _host = host;
        }



        /// <summary>
        /// Список заявок
        /// </summary>
        /// <returns>Повертає лист</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List show</response>
        /// <response code="400">List show has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  show list right now</response>

        
        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                //Thread.Sleep(2000);
                var model = await _context.Shows
                     .Include(x => x.ClassIdEntity)
                     .Include(x => x.ShowIdEntity)
                     .Include(x => x.SexEntity)
                     .Include(x => x.ValidateShowEntity)
                    .Select(x => _mapper.Map<ShowItemViewModel>(x)).ToListAsync();
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
        /// Список заявок cac
        /// </summary>
        /// <returns>Повертає лист</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List show</response>
        /// <response code="400">List show has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  show list right now</response>
        [HttpGet]
        [Route("lisShowCact")]
        public async Task<IActionResult> lisShowCact()
        {
            try
            {
                //Thread.Sleep(2000);
                var model = await _context.Shows
                     .Include(x => x.ClassIdEntity)
                     .Include(x => x.ShowIdEntity)
                     .Include(x => x.SexEntity)
                     .Include(x => x.ValidateShowEntity)
                     .Where(x=>x.ShowId==1)
                     /*.OrderByDescending(x => x.Breed.ToLower())
                      .ThenByDescending(x => x.ClassId)
                     .ThenByDescending(x => x.SexId)
                     .ThenByDescending(x => x.NameDog.ToLower())*/
                     .OrderBy(x => x.Breed.ToLower())
                      .ThenBy(x => x.ClassId)
                     .ThenBy(x => x.SexId)
                     .ThenBy(x => x.NameDog.ToLower())
                    .Select(x => _mapper.Map<ShowViewModel>(x)).ToListAsync();
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
        /// Список заявок cac
        /// </summary>
        /// <returns>Повертає лист</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List show</response>
        /// <response code="400">List show has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  show list right now</response>
        [HttpGet]
        [Route("lisShowCacib")]
        public async Task<IActionResult> lisShowCacib()
        {
            try
            {
                //Thread.Sleep(2000);
                var model = await _context.Shows
                     .Include(x => x.ClassIdEntity)
                     .Include(x => x.ShowIdEntity)
                     .Include(x => x.SexEntity)
                     .Include(x => x.ValidateShowEntity)
                     .Where(x => x.ShowId == 2)
                     .OrderBy(x=>x.Breed)
                     .ThenBy(x=>x.ClassIdEntity.Id)
                     .ThenBy(x=>x.SexEntity.Id)
                     .ThenBy(x=>x.NameDog)
                    .Select(x => _mapper.Map<ShowViewModel>(x)).ToListAsync();
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
        /// Додати заявку
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає ok</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Add show</response>
        /// <response code="400">Add show has missing/invalid values</response>
        /// <response code="500">Oops! Can't add show right now</response>

        [HttpPost]
        [Route("addShow")]
        /*[Authorize(Roles = Roles.Admin)]*/
        public async Task<IActionResult> Add([FromForm] ShowAddViewModel model)
        {
            try
            {
                /* List<string> fileNames = new List<string>();
                 foreach (var item in model.Images)
                 {
                     string fileName = "";
                     if (item != null)
                     {
                         var ext = Path.GetExtension(item.FileName);
                         fileName = Path.GetRandomFileName() + ext;
                         var filePath = Path.Combine(Directory.GetCurrentDirectory(),
                             "uploads", fileName);
                         using (var stream = System.IO.File.Create(filePath))
                         {
                             item.CopyTo(stream);
                         }
                         fileNames.Add(fileName);
                     }
                 }*/
                var cultureInfo = new CultureInfo("ua-UA");
                var dateTime = DateTime.Now;
                try
                {
                    string date = model.Date;
                    if (date.Length > 12)
                        date = date.Substring(4, date.Length - (date.Length - 12));
                    dateTime = DateTime.SpecifyKind(DateTime.Parse(date, cultureInfo), DateTimeKind.Utc);
                    // var dateTime = DateTime.ParseExact(date, "D", cultureInfo);
                   
                    Console.WriteLine(dateTime);
                }
                catch (FormatException)
                {
                    Console.WriteLine($"Unable to parse '{model.Date}'");
                }
                
                string startFoto1 = String.Empty;
                string startFoto2 = String.Empty;
                string startFoto3 = String.Empty;
                string startFoto4 = String.Empty;
                string startFoto5 = String.Empty;
                string startFoto6 = String.Empty;
                var product = _mapper.Map<ShowEntity>(model);
                product.Date = dateTime;

                if (model.StartPhoto1 != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto1.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    startFoto1 = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto1))
                    {
                        model.StartPhoto1.CopyTo(file);
                    }
                    product.StartPhoto1 = randomFilename;
                }
                if (model.StartPhoto2 != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto2.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    startFoto2 = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto2))
                    {
                        model.StartPhoto2.CopyTo(file);
                    }
                    product.StartPhoto2 = randomFilename;
                }
                if (model.StartPhoto3 != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto3.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    startFoto3 = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto3))
                    {
                        model.StartPhoto3.CopyTo(file);
                    }
                    product.StartPhoto3 = randomFilename;
                }
                if (model.StartPhoto4 != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto4.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    startFoto4 = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto4))
                    {
                        model.StartPhoto4.CopyTo(file);
                    }
                    product.StartPhoto4 = randomFilename;
                }
                if (model.StartPhoto5 != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto5.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    startFoto5 = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto5))
                    {
                        model.StartPhoto5.CopyTo(file);
                    }
                    product.StartPhoto5 = randomFilename;
                }
                if (model.StartPhoto6 != null)
                {
                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto6.FileName);

                    string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                    startFoto6 = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto6))
                    {
                        model.StartPhoto6.CopyTo(file);
                    }
                    product.StartPhoto6 = randomFilename;
                }
                
                _context.Shows.Add(product);
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
        ///Зміна статусу заявки
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає ok</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Change ok</response>
        /// <response code="400">Change has missing/invalid values</response>
        /// <response code="500">Oops! Can't Change right now</response>

        [HttpPost]
        [Route("changeStatus")]
        //[Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> ChangeStatus([FromBody] ShowChangeStatusViewModel model)
        {
            try
            {
                var order = await _context.Shows.SingleOrDefaultAsync(x => x.Id == model.Id);
                order.ValidateShowId = model.StatusId;
                _context.SaveChanges();
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
        /// Редагування заявки
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає message</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Edit show</response>
        /// <response code="400">Edit show has missing/invalid values</response>
        /// <response code="500">Oops! Can't edit show now</response>

        [HttpPost]
        [Route("editShow")]
       /* [Authorize(Roles = Roles.Admin)]*/
        public IActionResult EditShow([FromForm] ShowEditViewModel model)
        {


            if (ModelState.IsValid)
            {
                var item = _context.Shows
                             .FirstOrDefault(x => x.Id == model.Id);
                string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
                string fol = "\\uploads\\";

                item.Id = model.Id;
                if (model.Adress != null)
                {
                    item.Adress = model.Adress;
                }
                if (model.Breed != null)
                {
                    item.Breed = model.Breed;
                }
                if (model.NameDog != null)
                {
                    item.NameDog = model.NameDog;
                }
                if (model.Color != null)
                {
                    item.Color = model.Color;
                }
                if (model.Pedigree != null)
                {
                    item.Pedigree = model.Pedigree;
                }
                if (model.Chip != null)
                {
                    item.Chip = model.Chip;
                }
                if (model.Father != null)
                {
                    item.Father = model.Father;
                }
                if (model.Mather != null)
                {
                    item.Mather = model.Mather;
                }
                if (model.Owner != null)
                {
                    item.Owner = model.Owner;
                }
                if (model.Breeder != null)
                {
                    item.Breeder = model.Breeder;
                }
                if (model.Phone != null)
                {
                    item.Phone = model.Phone;
                }
                if (model.Email != null)
                {
                    item.Email = model.Email;
                }
                if (model.StartPhoto1 != null)
                {
                    var oldImage = item.StartPhoto1;

                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto1.FileName);

                    var startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto1.CopyTo(file);
                    }

                   
                    string contentRootPath = _host.ContentRootPath + fol + oldImage;

                    if (System.IO.File.Exists(contentRootPath))
                    {
                        System.IO.File.Delete(contentRootPath);
                    }
                    item.StartPhoto1 = randomFilename;
                }
                if (model.StartPhoto2 != null)
                {
                    var oldImage = item.StartPhoto2;

                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto2.FileName);

                    var startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto2.CopyTo(file);
                    }

                   
                    string contentRootPath = _host.ContentRootPath + fol + oldImage;

                    if (System.IO.File.Exists(contentRootPath))
                    {
                        System.IO.File.Delete(contentRootPath);
                    }
                    item.StartPhoto2 = randomFilename;
                }
                if (model.StartPhoto3 != null)
                {
                    var oldImage = item.StartPhoto3;

                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto3.FileName);

                    var startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto3.CopyTo(file);
                    }

                   
                    string contentRootPath = _host.ContentRootPath + fol + oldImage;

                    if (System.IO.File.Exists(contentRootPath))
                    {
                        System.IO.File.Delete(contentRootPath);
                    }
                    item.StartPhoto3 = randomFilename;
                }
                if (model.StartPhoto4 != null)
                {
                    var oldImage = item.StartPhoto4;

                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto4.FileName);

                    var startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto4.CopyTo(file);
                    }

                    
                    string contentRootPath = _host.ContentRootPath + fol + oldImage;

                    if (System.IO.File.Exists(contentRootPath))
                    {
                        System.IO.File.Delete(contentRootPath);
                    }
                    item.StartPhoto4 = randomFilename;
                }
                if (model.StartPhoto5 != null)
                {
                    var oldImage = item.StartPhoto5;

                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto5.FileName);

                    var startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto5.CopyTo(file);
                    }

                   
                    string contentRootPath = _host.ContentRootPath + fol + oldImage;

                    if (System.IO.File.Exists(contentRootPath))
                    {
                        System.IO.File.Delete(contentRootPath);
                    }
                    item.StartPhoto5 = randomFilename;
                }
                if (model.StartPhoto6 != null)
                {
                    var oldImage = item.StartPhoto6;

                    string randomFilename = Path.GetRandomFileName() +
                        Path.GetExtension(model.StartPhoto6.FileName);

                    var startFoto = Path.Combine(dirPath, randomFilename);
                    using (var file = System.IO.File.Create(startFoto))
                    {
                        model.StartPhoto6.CopyTo(file);
                    }

                   
                    string contentRootPath = _host.ContentRootPath + fol + oldImage;

                    if (System.IO.File.Exists(contentRootPath))
                    {
                        System.IO.File.Delete(contentRootPath);
                    }
                    item.StartPhoto6 = randomFilename;
                }



                _context.SaveChanges();

            }

            return Ok(new { message = "ok edit" });

        }

        /// <summary>
        /// Видалення заявки
        /// </summary>
        /// <param name="id">Понель із даними</param>
        /// <returns>Повертає повідомлення</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Delete </response>
        /// <response code="400">Delete has missing/invalid values</response>
        /// <response code="500">Oops! Can't delete now</response>

        [HttpPost]
        [Route("delete")]
        //public IActionResult Delete([FromBody] ProductItemViewModel model)
        public IActionResult Delete([FromBody] int id)

        {
            string dirPath = Path.Combine(Directory.GetCurrentDirectory(), "uploads");
            var res = _context.Shows.FirstOrDefault(x => x.Id == id);
            if (res == null)
            {
                return BadRequest(new { message = "Check id!" });
            }

            var oldImage1 = res.StartPhoto1;
            string fol = "\\uploads\\";
            string contentRootPath1 = _host.ContentRootPath + fol + oldImage1;

            if (System.IO.File.Exists(contentRootPath1))
            {
                System.IO.File.Delete(contentRootPath1);
            }
            var oldImage2 = res.StartPhoto2;
            string contentRootPath2 = _host.ContentRootPath + fol + oldImage2;

            if (System.IO.File.Exists(contentRootPath2))
            {
                System.IO.File.Delete(contentRootPath2);
            }
            var oldImage3 = res.StartPhoto3;
               string contentRootPath3 = _host.ContentRootPath + fol + oldImage3;

            if (System.IO.File.Exists(contentRootPath3))
            {
                System.IO.File.Delete(contentRootPath3);
            }
            var oldImage4 = res.StartPhoto4;
                        string contentRootPath4 = _host.ContentRootPath + fol + oldImage4;

            if (System.IO.File.Exists(contentRootPath4))
            {
                System.IO.File.Delete(contentRootPath4);
            }
            var oldImage5 = res.StartPhoto5;
                        string contentRootPath5 = _host.ContentRootPath + fol + oldImage5;

            if (System.IO.File.Exists(contentRootPath5))
            {
                System.IO.File.Delete(contentRootPath5);
            }
            var oldImage6 = res.StartPhoto6;
                       string contentRootPath6 = _host.ContentRootPath + fol + oldImage6;

            if (System.IO.File.Exists(contentRootPath6))
            {
                System.IO.File.Delete(contentRootPath6);
            }
            _context.Shows.Remove(res);
            _context.SaveChanges();
            return Ok(new { message = "Product deleted" });
        }



    }
}

