using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
using SantasEmporium.Models;
using SantasEmporium.Services;

namespace SantasEmporium.Pages
{
    public class SantaList : PageModel
{
        [BindProperty]
        public Recipient NewRecipient { get; set; }
        public List<Recipient> recipients = new();
        public void OnGet()
        {
            recipients = RecipientService.GetAll();
        }

        public IActionResult OnPost()
        {
            // If statement is optional
            if (!ModelState.IsValid)
            {
                return Page();
            }
            RecipientService.Add(NewRecipient);
            return RedirectToAction("Get");
        }
    }
}
