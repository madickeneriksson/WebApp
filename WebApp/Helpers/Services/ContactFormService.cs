using WebApp.Contexts;
using WebApp.Models.Entities;
using WebApp.ViewModels;

namespace WebApp.Helpers.Services
{
    public class ContactFormService
    {
        private readonly IdentityContext _context;

        public ContactFormService(IdentityContext context)
        {
            _context = context;
        }

        public async Task<bool> CreateAsync(ContactformViewModel contactformViewModel)
        {
            try
            {
                ContacFormEntity contactFormEntity = contactformViewModel;
               


                _context.ContactForm.Add(contactFormEntity);
                await _context.SaveChangesAsync();
                return true;
            }
            catch
            {
                return false;
            }

        }
    }
}
