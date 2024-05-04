
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Versioning.Models;

namespace Versioning.Controllers
{
    [ApiVersion("1.0")]
    //[Route("api/[controller]")]
    [Route("v{v:apiVersion}/doctors")]
    [ApiController]
    public class DoctorV1Controller : ControllerBase
    {

        private readonly DoccureContext _context;
        public DoctorV1Controller(DoccureContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }

        
        
        [HttpGet]
       
        public async Task<IActionResult> GetAllDoctors([FromQuery]SpecializationQueryParameters queryParams)
        {


            if (queryParams.Size < 1)
            {
                return BadRequest("Size parameter must be at least 1.");
            }


            if (queryParams.Page < 0)
            {
                return BadRequest("Page parameter must not be negative.");
            }



            IQueryable<Doctor> Doctors = _context.Doctors;
       

         
            if (!string.IsNullOrEmpty(queryParams.Name))
            {
                Doctors = Doctors.Where(x => x.Name.ToLower().Contains(queryParams.Name.ToLower()));

            }

            if (!string.IsNullOrEmpty(queryParams.SortBy))
            {

                if (typeof(Doctor).GetProperty(queryParams.SortBy) != null)
                {
                    Doctors = Doctors.OrderByCustom(
                        queryParams.SortBy,
                        queryParams.SortOrder);
                }
            }
            var totalDoctors = await Doctors.CountAsync();
            var skipAmount = queryParams.Page <= 1 ? 0 : queryParams.Size * (queryParams.Page - 1);

            var items = await Doctors

         .Skip(skipAmount)
         .Take(queryParams.Size)
         .ToArrayAsync();


            var response = new PagedResponse<Doctor>
            {
                Data = items,
                PageNumber = queryParams.Page,
                PageSize = queryParams.Size,
                TotalRecords = totalDoctors,
                TotalPages = (int)Math.Ceiling((double)totalDoctors / queryParams.Size)
            };
            return Ok(response);
        }

        public class PagedResponse<T>
        {
            public IEnumerable<T> Data { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalRecords { get; set; }
            public int TotalPages { get; set; }
        }

        [HttpGet]
        [Route("GetItemById/{id}")]
        public async Task<IActionResult> GetItem(int id)
        {

            // var item = await _inventoryContext.Items.FindAsync(id);
            var item = await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return Ok("Item not found.");
            }
            return Ok(item);

        }



    }



    /// Version 2

    [ApiVersion("2.0")]
    //[Route("api/[controller]")]
    [Route("v{v:apiVersion}/doctors")]
    [ApiController]
    public class DoctorV2Controller : ControllerBase
    {

        private readonly DoccureContext _context;
        public DoctorV2Controller(DoccureContext context)
        {
            _context = context;

            _context.Database.EnsureCreated();
        }



        [HttpGet]

        public async Task<IActionResult> GetAllDoctors([FromQuery] SpecializationQueryParameters queryParams)
        {


            if (queryParams.Size < 1)
            {
                return BadRequest("Size parameter must be at least 1.");
            }


            if (queryParams.Page < 0)
            {
                return BadRequest("Page parameter must not be negative.");
            }



            IQueryable<Doctor> Doctors = _context.Doctors.Where(x=>x.IsAvailable==true);



            if (!string.IsNullOrEmpty(queryParams.Name))
            {
                Doctors = Doctors.Where(x => x.Name.ToLower().Contains(queryParams.Name.ToLower()));

            }

            if (!string.IsNullOrEmpty(queryParams.SortBy))
            {

                if (typeof(Doctor).GetProperty(queryParams.SortBy) != null)
                {
                    Doctors = Doctors.OrderByCustom(
                        queryParams.SortBy,
                        queryParams.SortOrder);
                }
            }
            var totalDoctors = await Doctors.CountAsync();
            var skipAmount = queryParams.Page <= 1 ? 0 : queryParams.Size * (queryParams.Page - 1);

            var items = await Doctors

         .Skip(skipAmount)
         .Take(queryParams.Size)
         .ToArrayAsync();


            var response = new PagedResponse<Doctor>
            {
                Data = items,
                PageNumber = queryParams.Page,
                PageSize = queryParams.Size,
                TotalRecords = totalDoctors,
                TotalPages = (int)Math.Ceiling((double)totalDoctors / queryParams.Size)
            };
            return Ok(response);
        }

        public class PagedResponse<T>
        {
            public IEnumerable<T> Data { get; set; }
            public int PageNumber { get; set; }
            public int PageSize { get; set; }
            public int TotalRecords { get; set; }
            public int TotalPages { get; set; }
        }

        [HttpGet]
        [Route("GetItemById/{id}")]
        public async Task<IActionResult> GetItem(int id)
        {

            // var item = await _inventoryContext.Items.FindAsync(id);
            var item = await _context.Doctors.AsNoTracking().FirstOrDefaultAsync(x => x.Id == id);
            if (item == null)
            {
                return Ok("Item not found.");
            }
            return Ok(item);

        }



    }

}