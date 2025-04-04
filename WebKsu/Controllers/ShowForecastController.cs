﻿using AutoMapper;
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

        /// <summary>
        /// Список продуктів
        /// </summary>
        /// <returns>Повертає лист</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List products</response>
        /// <response code="400">List products has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  products list right now</response>

        [HttpGet]
        [Route("list")]
        public async Task<IActionResult> List()
        {
            try
            {
                Thread.Sleep(2000);
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



        /* /// <summary>
         /// Видалення
         /// </summary>
         /// <param name="id">Понель із даними</param>
         /// <returns>Повертає повідомлення</returns>
         /// <remarks>Awesomeness!</remarks>
         /// <response code="200">Delete run lines</response>
         /// <response code="400">Delete run lines has missing/invalid values</response>
         /// <response code="500">Oops! Can't delete run lines now</response>

         [HttpPost]
         [Route("deleteRunlines")]
         *//*[Authorize(Roles = Roles.Admin)]*//*
         //public IActionResult Delete([FromBody] ProductItemViewModel model)
         public IActionResult Delete([FromBody] int id)

         {

             var res = _context.RunLine.FirstOrDefault(x => x.Id == id);
             if (res == null)
             {
                 return BadRequest(new { message = "Check id!" });
             }

             _context.RunLine.Remove(res);
             _context.SaveChanges();
             return Ok(new { message = "Runlines deleted" });
         }*/

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

                string startFoto1 = String.Empty;
                string startFoto2 = String.Empty;
                string startFoto3 = String.Empty;
                string startFoto4 = String.Empty;
                string startFoto5 = String.Empty;
                string startFoto6 = String.Empty;
                var product = _mapper.Map<ShowEntity>(model);

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
                    using (var file = System.IO.File.Create(startFoto5))
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
        /// Редагування заявки
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає message</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Edit show</response>
        /// <response code="400">Edit show has missing/invalid values</response>
        /// <response code="500">Oops! Can't edit show now</response>

        [HttpPost]
        [Route("editRunLine")]
       /* [Authorize(Roles = Roles.Admin)]*/
        public IActionResult Edit([FromForm] RunLineToEdit model)
        {


            if (ModelState.IsValid)
            {
                var itemProd = _context.RunLine
                             .FirstOrDefault(x => x.Id == model.Id);
                
                itemProd.Id = model.Id;
               
                if (model.Description != null)
                {
                    itemProd.Description = model.Description;
                }
                                
                _context.SaveChanges();
                            }

            return Ok(new { message = "ok edit" });

        }




    }
}

