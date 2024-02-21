using System.Linq;
using System.Web.Mvc;
using WebAppOsiguranje.Models;

public class PolicyController : Controller
{
    private PolicyService _policyService;
    private PartnerService _partnerService;

    public PolicyController()
    {
        _policyService = new PolicyService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString); 
        _partnerService = new PartnerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);

    }

    public ActionResult Index()
    {
        var policies = _policyService.GetAllPolicies();
        return View(policies);
    }

    public ActionResult Create()
    {
        ViewBag.Partners = _partnerService.GetAllPartners()
                                         .Select(p => new SelectListItem
                                         {
                                             Value = p.PartnerId.ToString(),
                                             Text = $"{p.PartnerId} {p.FirstName} {p.LastName}"
                                         }).ToList();
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Policy policy)
    {
        if (ModelState.IsValid)
        {
            _policyService.AddPolicy(policy);
            return RedirectToAction("../Partner/Index");
        }
        ViewBag.Partners = _partnerService.GetAllPartners().Select(p => new SelectListItem
                                         {
                                             Value = p.PartnerId.ToString(),
                                             Text = $"{p.PartnerId} {p.FirstName} {p.LastName}"
                                         }).ToList();
        return View(policy);
    }
}
