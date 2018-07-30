using Dictionary_Development_System_Business.Interest;
using Dictionary_Development_System_Business.Word;
using Dictionary_Development_System_Presentation.Filters;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.RequestModels.Word;
using Dictionary_Development_System_RequestResponse.ResponseModels.Word;
using Dictionary_Development_System_RequestResponse.ViewModels.Word;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{
  public class WordController : BaseController
  {
    WordService word_Service = new WordService();
    public ActionResult Index()
    {
      return View();
    }

    [HttpPost]
    public ActionResult Search(SearchWordRequest request)
    {
      SearchResponse response = new SearchResponse();

      response = word_Service.SearchWord(request);

      if (response.IsSucceed)
      {
        return View(response);
      }
      else
      {
        NotFoundResponse result = new NotFoundResponse();
        InterestService interest_Service = new InterestService();
        result.Interests = interest_Service.GetAllInterests();
        result.Word = request.Word;
        return PartialView("_NotFoundPage", result);
      }
    }
    
    [AuthenticationFilter]
    public ActionResult Report(ReportRequest request)
    {
      BaseResponse response = new BaseResponse();
      request.UserId = base.UserID;
      response=word_Service.ReportWord(request);
      return Json(response);
    }

    [AuthenticationFilter]/*leftsidebarda gösterilemelidir her kullanıcı için*/
    public ActionResult GetMyReported(SendTaskFromAdminRequest request)
    {
      request.UserId = base.UserID;
      WordService _wordService = new WordService();
      List<WordView> response = _wordService.GetMyReported(request);

      return View(response);
    }
  }
}