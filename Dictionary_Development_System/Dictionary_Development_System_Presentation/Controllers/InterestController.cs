using Dictionary_Development_System_Business.Interest;
using Dictionary_Development_System_Presentation.Filters;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.RequestModels.Interest;
using Dictionary_Development_System_RequestResponse.ViewModels.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{
  public class InterestController : Controller
  {
    // GET: Interest
    public ActionResult Index()
    {
      return View();
    }
    [AuthenticationFilter]
    public ActionResult GetAllInterests()
    {
      InterestService _interestService = new InterestService();
      List<InterestView> response = new List<InterestView>();
      response=_interestService.GetAllInterests();
      return Json(response);
    }
    [AdminFilter]
    public ActionResult AddInterest(AddInterestRequest request)
    {
      InterestService _interestService = new InterestService();
      BaseResponse response = _interestService.AddInterest(request);
      return Json(response);
    }
  }
}