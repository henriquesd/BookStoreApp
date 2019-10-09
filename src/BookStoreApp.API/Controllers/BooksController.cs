using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace BookStoreApp.API.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    public class BooksController : MainController
    {
        
    }
}