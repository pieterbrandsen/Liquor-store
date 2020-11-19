using Microsoft.AspNetCore.Mvc.RazorPages;
using Microsoft.Extensions.Logging;

namespace LiquerStore.Web.Pages
{
    public class IndexModel : PageModel
    {
        // Create a logger interface
        private readonly ILogger<IndexModel> _logger;

        public IndexModel(ILogger<IndexModel> logger)
        {
     
            // Set the logger instance to _logger
            _logger = logger;
        }
    }
}