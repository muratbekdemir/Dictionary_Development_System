using Dictionary_Development_System_Business.Account;
using Dictionary_Development_System_Business.Word;
using Dictionary_Development_System_Presentation.Filters;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.RequestModels.Account;
using Dictionary_Development_System_RequestResponse.RequestModels.Word;
using Dictionary_Development_System_RequestResponse.ResponseModels.Account;
using Dictionary_Development_System_RequestResponse.ResponseModels.Word;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{
  [AuthenticationFilter]
  [AdminFilter]
  public class AdminController : BaseController
  {
    // GET: Admin
    public ActionResult Index()
    {
      return View();
    }
    public ActionResult GetReportedWords()
    {
      WordService _service = new WordService();
      List<GetReportedWordResponse> response = new List<GetReportedWordResponse>();
      response = _service.GetReportedWords();

      return View(response);
    }
    public ActionResult AssignWordToDeveloper(AssignWordToDeveloperRequest request)
    {
      BaseResponse response = new BaseResponse();
      WordService _wordService = new WordService();
      response = _wordService.AssignWordToDeveloper(request);

      return Json(response);
    }
    public ActionResult RejectWord(AssignWordToDeveloperRequest request)
    {
      BaseResponse response = new BaseResponse();
      WordService _wordService = new WordService();
      response = _wordService.WordRejectedByAdmin(request);

      return Json(response);
    }
    public ActionResult GetAssignedTasks()
    {
      WordService _service = new WordService();
      List<GetAssignedTasksResponse> response = new List<GetAssignedTasksResponse>();
      response = _service.GetAssignedTasks();

      return View(response);      
    }
    public ActionResult GetPendingWords()
    {
      WordService _service = new WordService();
      List<GetPendingWordsResponse> response = new List<GetPendingWordsResponse>();
      response = _service.GetPendingWords();

      return View(response);
    }
    public ActionResult SendTaskToVoting(SendTaskFromAdminRequest request)
    {
      BaseResponse response = new BaseResponse();
      WordService _service = new WordService();
      response = _service.SendTaskToVoting(request);

      return Json(response);
    }
    public ActionResult DenyTask(SendTaskFromAdminRequest request)
    {
      BaseResponse response = new BaseResponse();
      WordService _service = new WordService();
      response = _service.DenyTask(request);

      return Json(response);
    }
    public ActionResult GetVotingTasks()
    {
      WordService _service = new WordService();
      List<GetVotingTasksResponse> response = new List<GetVotingTasksResponse>();
      response = _service.GetVotingTasks();

      return View(response);
    }
    public ActionResult GetUsers()
    {
      Account_Service _acoountService = new Account_Service();
      List<GetUserResponse> response = new List<GetUserResponse>();
      response = _acoountService.GetUsers();

      return View(response);
    }
    public ActionResult AddEditUser(AddUserRequest request)
    {
      Account_Service _accountService = new Account_Service();
      BaseResponse response = _accountService.AddEditUser(request);
      return Json(response);
    }
  }
}