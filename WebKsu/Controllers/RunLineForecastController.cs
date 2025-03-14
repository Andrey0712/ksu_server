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

namespace WebKsu.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class RunLineForecastController : ControllerBase
    {
        private readonly ILogger<RunLineForecastController> _logger;
        private readonly IMapper _mapper;
        private readonly AppEFContext _context;
        private IHostEnvironment _host;

        public RunLineForecastController(ILogger<RunLineForecastController> logger, IMapper mapper, AppEFContext context, IHostEnvironment host)
        {
            _logger = logger;
            _mapper = mapper;
            _context = context;
            _host = host;
        }



        /// <summary>
        /// Список run lines
        /// </summary>
        /// <returns>Повертає лист</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">List run lines</response>
        /// <response code="400">List run lines has missing/invalid values</response>
        /// <response code="500">Oops! Can't get  products list right now</response>

        [HttpGet]
        [Route("listRunlines")]
        public async Task<IActionResult> List()
        {
            try
            {
                Thread.Sleep(2000);
                var model = await _context.RunLine
                                 .Select(x => _mapper.Map<RunLineItemViewModel>(x)).ToListAsync();
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
        [Authorize(Roles = Roles.Admin)]
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
        }

        /// <summary>
        /// Додати Runlines
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає ok</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Add Runlines</response>
        /// <response code="400">Add Runlines has missing/invalid values</response>
        /// <response code="500">Oops! Can't add Runlines right now</response>

        [HttpPost]
        [Route("addRunlines")]
        [Authorize(Roles = Roles.Admin)]
        public async Task<IActionResult> Add([FromForm] RunLineAddViewModel model)
        {
            try
            {

               
                var product = _mapper.Map<RunLineEntity>(model);

              
                _context.RunLine.Add(product);
                await _context.SaveChangesAsync();


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
        /// Редагування Runlines
        /// </summary>
        /// <param name="model">Понель із даними</param>
        /// <returns>Повертає message</returns>
        /// <remarks>Awesomeness!</remarks>
        /// <response code="200">Edit Runlines</response>
        /// <response code="400">Edit Runlines has missing/invalid values</response>
        /// <response code="500">Oops! Can't edit Runlines now</response>

        [HttpPost]
        [Route("editRunLine")]
        [Authorize(Roles = Roles.Admin)]
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

