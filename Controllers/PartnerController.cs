using System.Linq;
using System;
using System.Web.Mvc;
using WebAppOsiguranje.Models;
using System.Net;

public class PartnerController : Controller
{
    private readonly PartnerService _partnerService;

    public PartnerController()
    {
        _partnerService = new PartnerService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }

    public ActionResult Index()
    {
        var partnersWithPolicyInfo = _partnerService.GetAllPartnersWithPolicyInfo();
        foreach (var partner in partnersWithPolicyInfo)
        {
            partner.IsHighlighted = true;
        }

        var partners = _partnerService.GetAllPartners();

        var allPartners = partnersWithPolicyInfo
            .Concat(partners)
            .OrderByDescending(p => p.CreatedAtUtc)
            .GroupBy(p => p.PartnerId)
            .Select(g => g.First())
            .ToList();

        return View(allPartners);
    }


    public ActionResult GetPartnerDetails(int id)
    {
        var partner = _partnerService.GetPartnerById(id);
        if (partner == null)
        {
            return HttpNotFound();
        }
        return PartialView("_PartnerDetails", partner);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create([Bind(Include = "FirstName,LastName,Address,PartnerNumber,CroatianPIN,CreateByUser,PartnerTypeId,IsForeign,ExternalCode,Gender")] Partner partner)
    {
        string errorMessage = "";
        if (ModelState.IsValid)
        {
            var newPartnerId = _partnerService.AddPartner(partner, out errorMessage);
            if (newPartnerId != 0)
            {
                TempData["NewPartnerId"] = newPartnerId;
                return RedirectToAction("Index");
            }
            else if (!string.IsNullOrEmpty(errorMessage))
            {
                ModelState.AddModelError(string.Empty, errorMessage);
            }
        }
        return View(partner);
    }

    public ActionResult Delete(int? id)
    {
        if (id == null)
        {
            return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
        }
        Partner partner = _partnerService.GetPartnerById(id.Value);
        if (partner == null)
        {
            return HttpNotFound();
        }
        return View(partner);
    }

    [HttpPost, ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public ActionResult DeleteConfirmed(int id)
    {
        bool deleted = _partnerService.DeletePartner(id);
        if (!deleted)
        {
            return RedirectToAction("DeleteFailed");
        }
        return RedirectToAction("Index");
    }

}
