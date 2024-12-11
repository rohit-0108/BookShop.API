using AutoMapper;
using BookShop.API.Data;
using BookShop.API.DTOs;
using BookShop.API.Entities;
using BookShop.API.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BookShop.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class BooksController : ControllerBase
    {
        private ApplicationDbContext _context;
        private readonly IUtilityService _utilityService;
        private string containerName = "BookCover";
        private IMapper _mapper;

        public BooksController(ApplicationDbContext context,
            IUtilityService utilityService, string containerName,
            IMapper mapper)
        {
            _context = context;
            _utilityService = utilityService;
            _mapper = mapper;
        }
        [HttpGet]
        public async Task<ActionResult<List<BookDTO>>> Get()
        {
            var books= await _context.Books.Include(x=>x.BookAuthors).ThenInclude(a=>a.Author)
                .Include(y=>y.BookCategories).ThenInclude(b=>b.Category)
                .Include(z=>z.BookShops).ThenInclude(c=>c.Shop)
                .Where(x=>x.IsAvailable==true).ToListAsync();
            var bookDto= _mapper.Map<List<BookDTO>>(books);
            return bookDto;
        }
        [HttpGet("{Id:int}")]
        public async Task<ActionResult<BookDTO>> GetById(int Id)
        {
            var book= await _context.Books.Include(x=>x.BookAuthors).ThenInclude(a=>a.Author)
                .Include(y=>y.BookCategories).ThenInclude(b=>b.Category)
                .Include(z=>z.BookShops).ThenInclude(c=>c.Shop)
                .Where(x=>x.IsAvailable==true && x.Id==Id).FirstOrDefaultAsync();
            
            var bookDto= _mapper.Map<BookDTO>(book);
            return bookDto;
        }
        [HttpPost]
        public async Task<ActionResult<int>> Post([FromForm] BookCreationDTO bookCreationDTO)
        {
            var book= _mapper.Map<Book>(bookCreationDTO);
            if(book.Cover!=null)
            {
                book.Cover=await _utilityService.SaveImage(containerName,bookCreationDTO.Cover);
            }
            await _context.Books.AddAsync(book);
            await _context.SaveChangesAsync();
            return book.Id;
        }
    }
}
