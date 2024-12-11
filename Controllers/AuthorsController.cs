using AutoMapper;
using BookShop.API.Data;
using BookShop.API.DTOs;
using BookShop.API.Entities;
using BookShop.API.Extensions;
using BookShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthorsController : ControllerBase
    {
        private readonly ApplicationDbContext _context;
        private readonly IMapper _mapper;
        private readonly IUtilityService _utilityService;
        private readonly string containerName = "AuthorImage";

        public AuthorsController(ApplicationDbContext context,
            IMapper mapper, IUtilityService utilityService)
        {
            _context = context;
            _mapper = mapper;
            _utilityService = utilityService;
        }
        [HttpGet]
        public async Task<ActionResult<List<AuthorDTO>>> Get([FromQuery] PaginationDTo paginationDTo)
        {
            var querable = _context.Authors.AsQueryable();
            await HttpContext.SetResponseHeader(querable);
            var author = await querable.OrderBy(x => x.Name).ToPaging(paginationDTo).ToListAsync();
            return _mapper.Map<List<AuthorDTO>>(author);
        }
        [HttpPost("searchByName")]
        public async Task<ActionResult<List<AuthorBookDto>>> SearchbyName([FromBody]string name)
        {
            if(string.IsNullOrEmpty(name))
            {
                return new List<AuthorBookDto>();

            }
            return await _context.Authors.Where(x=>x.Name.Contains(name))
                .OrderBy(x=>x.Name).Select(x=>new AuthorBookDto { Id=x.Id, Name=x.Name,Picture=x.Picture })
                .Take(10).ToListAsync();
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<AuthorDTO>> Get(int Id)
        {
            var author= await _context.Authors.FirstOrDefaultAsync(x=>x.Id==Id);
            if(author==null)
            {
                return NotFound();
            }
            return _mapper.Map<AuthorDTO>(author);
        }
        [HttpPost]
        public async Task<ActionResult> Post([FromForm] AuthorCreationDto authorCreationDto)
        {
            var author= _mapper.Map<Author>(authorCreationDto);
            if(authorCreationDto.Picture!=null)
            {
                author.Picture = await _utilityService.SaveImage(containerName,authorCreationDto.Picture);
            }
            _context.Authors.Add(author);
            _context.SaveChanges();
            return NoContent();
        }
        [HttpPut("{Id:int}")]
        public async Task<ActionResult> Put(int Id, [FromForm] AuthorCreationDto authorCreationDto)
        {
            var author=await _context.Authors.FirstOrDefaultAsync(x=>x.Id == Id);
            if(author==null)
            {
                return NotFound();
            }
            author = _mapper.Map(authorCreationDto,author);
            if(authorCreationDto.Picture!= null)
            {
                author.Picture= await _utilityService.EditImage(containerName, authorCreationDto.Picture,author.Picture);
            }
            await _context.SaveChangesAsync();
            return NoContent();

        }
        [HttpDelete("{Id:int}")]
        public async Task<ActionResult> Delete(int Id)
        {
            var author = await _context.Authors.FirstOrDefaultAsync(x => x.Id == Id);
            if (author == null)
            {
                return NotFound();
            }
            await _utilityService.DeleteImage(containerName, author.Picture);
            _context.Remove(author);
            await _context.SaveChangesAsync();
         return NoContent();
        }

            
    }
}
