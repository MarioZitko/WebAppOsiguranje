using System.Web.Mvc;
using WebAppOsiguranje.Models;

public class PolicyController : Controller
{
    private PolicyService _policyService;

    public PolicyController()
    {
        _policyService = new PolicyService(System.Configuration.ConfigurationManager.ConnectionStrings["DefaultConnection"].ConnectionString);
    }

    public ActionResult Index()
    {
        var policies = _policyService.GetAllPolicies();
        return View(policies);
    }

    public ActionResult Create()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Policy policy)
    {
        if (ModelState.IsValid)
        {
            _policyService.AddPolicy(policy);
            return RedirectToAction("Index");
        }
        return View(policy);
    }
}
