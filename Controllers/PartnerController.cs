using System.Web.Mvc;
using WebAppOsiguranje.Models;

public class PartnerController : Controller
{
    private readonly PartnerService _partnerService;

    public PartnerController()
    {
        _partnerService = new PartnerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }

    public ActionResult Index()
    {
        var partners = _partnerService.GetAllPartners();
        return View(partners);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Partner partner)
    {
        if (ModelState.IsValid)
        {
            _partnerService.AddPartner(partner);
            TempData["NewPartnerId"] = partner.PartnerId;
            return RedirectToAction("Index");
        }
        return View(partner);
    }
}
