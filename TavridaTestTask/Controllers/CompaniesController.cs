using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics;
using TavridaTestTask.Models;
using TavridaTestTask.Models.ViewModels;

namespace TavridaTestTask.Controllers
{
    public class CompaniesController : Controller
    {
        private readonly ILogger<CompaniesController> _logger;
        private readonly TestTaskContext _context;

        public CompaniesController(ILogger<CompaniesController> logger, TestTaskContext context)
        {
            _logger = logger;
            _context = context;
        }

        public async Task<IActionResult> CompanyBranches()
        {
            var CompaniesBranches = from cb in _context.CompaniesBranches
                                    join c in _context.Companies on cb.CompanyId equals c.Id
                                    select new CompanyBranchViewModel()
                                    {
                                        CompanyBranchName = cb.Name,
                                        CompanyName = c.Name,
                                        CompanyGroup = c.BinarySign,
                                        RelatedBranches = !c.BinarySign ?
                                            string.Join(", ", _context.CompaniesBranches.Where(x => x.CompanyId == c.Id).Select(x => x.Name)) :
                                            string.Join(", ", _context.CompaniesBranches.Select(x => x.Name))
                                    };
            return CompaniesBranches != null ?
                          View(await CompaniesBranches.ToListAsync()) :
                          Problem("Entity set 'CompaniesBranches'  is null.");
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}