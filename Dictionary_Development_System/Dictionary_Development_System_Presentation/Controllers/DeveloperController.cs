using Dictionary_Development_System_Business.Interest;
using Dictionary_Development_System_Business.Word;
using Dictionary_Development_System_Presentation.Filters;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.RequestModels.Word;
using Dictionary_Development_System_RequestResponse.ResponseModels.Word;
using Dictionary_Development_System_RequestResponse.ViewModels.Developer;
using Dictionary_Development_System_RequestResponse.ViewModels.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{
  [AuthenticationFilter]
  [DeveloperFilter]
  public class DeveloperController : BaseController
  {
    // GET: Developer
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult GetDeveloperTasks()
    {
      var developerId = base.UserID;
      WordService _wordService = new WordService();
      List<GetDeveloperTasksResponse> response = _wordService.GetDeveloperTask(developerId);

      return View(response);
    }
    public ActionResult SendResearchView(int Id)
    {
      SendResearchViewModel Model = new SendResearchViewModel();
      Model.WordId = Id;
      return View(Model);
    }
    [HttpPost, ValidateInput(false)]
    public ActionResult SendTaskToAdmin(SendTaskToAdminRequest request)
    {
      WordService _wordService = new WordService();
      request.DeveloperId = base.UserID;

      BaseResponse response = _wordService.SendTaskToAdmin(request);
      
      return Json(response);
    }
    [SeniorFilter]
    public ActionResult GetRatingWords()
    {
      GetRatingWordsRequest request = new GetRatingWordsRequest();
      request.UserId = base.UserID;
      InterestService _interestService = new InterestService();
      request.InterestId = _interestService.GetUserInterestID(request.UserId);
      WordService _wordService = new WordService();
      List<WordView> response = _wordService.GetRatingWords(request);

      return View(response);
    }
   
    public ActionResult GetDeveloperSend(SendTaskFromAdminRequest request)
    {
      WordService _wordService = new WordService();
      request.UserId = base.UserID;
      List<GetVotingTasksResponse> response = new List<GetVotingTasksResponse>();
      response = _wordService.GetDeveloperSend(request);

      return View(response);
    }
    [SeniorFilter]
    public ActionResult AcceptanceVote(SendTaskFromAdminRequest request)
    {
      WordService _wordService = new WordService();
      BaseResponse response = new BaseResponse();
      request.UserId = base.UserID;
      response = _wordService.AcceptanceVote(request);
      _wordService.VotingIsEnded(request);
      
      return Json(response);
    }
    [SeniorFilter]
    public ActionResult RejectionVote(SendTaskFromAdminRequest request)
    {
      WordService _wordService = new WordService();
      BaseResponse response = new BaseResponse();
      request.UserId = base.UserID;
      response = _wordService.RejectionVote(request);
      _wordService.VotingIsEnded(request);

      return Json(response);
    }
  }
}