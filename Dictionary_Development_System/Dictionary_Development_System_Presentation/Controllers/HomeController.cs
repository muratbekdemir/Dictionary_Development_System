using Dictionary_Development_System_Presentation.Filters;
using Dictionary_Development_System_Presentation.Principal;
using Dictionary_Development_System_RequestResponse.ResponseModels.Account;
using Dictionary_Development_System_RequestResponse.ViewModels.Account;
using System.Collections.Generic;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{

  public class HomeController : BaseController
  {
    public ActionResult BaseInformation()
    {
      UserResponse response = new UserResponse();
      if (CustomPrincipal.SessionAuthentication())
      {
        response.UserView = new UserView();
        response.UserView.Email = base.UserEmail;
        response.UserView.Name = base.UserName;
        response.UserView.Surname = base.UserSurname;
        response.UserView.RoleName = base.RoleName;
      }

      return PartialView("~/Views/Shared/_BaseInformation.cshtml", response);
    }

    public ActionResult Index()
    {
      return View();
    }

    #region Sidebar İşlemleri

    public ActionResult Sidebar()
    {
      List<SidebarModel> response = new List<SidebarModel>();
      if (base.RoleName == Role.User.ToString())
        response = UserSidebar();
      if (base.RoleName == Role.Developer.ToString())
        response = DeveloperSidebar();
      if (base.RoleName == Role.Admin.ToString())
        response = AdminSidebar();
      if (base.RoleName == Role.Senior.ToString())
        response = SeniorSidebar();

      return PartialView("~/Views/Shared/PartialLayout/_Sidebar.cshtml", response);
    }

    private List<SidebarModel> UserSidebar()
    {
      return new List<SidebarModel>
      {
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Word/GetMyReported" , AValue = "Bildirdiklerim", IClass = "fa icon-notebook"}
      };
    }
    private List<SidebarModel> DeveloperSidebar()
    {
      return new List<SidebarModel>
      {
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Word/GetMyReported" , AValue = "Bildirdiklerim", IClass = "fa icon-notebook"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Developer/GetDeveloperTasks" , AValue = "Görevler", IClass = "fa fa-tasks"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Developer/GetDeveloperSend/", AValue = "Gönderilenler", IClass = "fa fa-thumbs-up"}
      };
    }

    private List<SidebarModel> AdminSidebar()
    {
      return new List<SidebarModel>
      {
          new SidebarModel{ SpanClass= "nav-item", SpanValue = "", AClass = "nav-link", AHref = "/Word/GetMyReported", AValue = "Bildirdiklerim", IClass = "fa icon-notebook" },
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Admin/GetReportedWords" , AValue = "Rapor Edilenler", IClass = "icon-puzzle"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Admin/GetAssignedTasks" , AValue = "Görevlendirelenler", IClass = "icon-star"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Admin/GetPendingWords" , AValue = "Beklemede", IClass = "icon-speedometer"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Admin/GetVotingTasks" , AValue = "Oylamada", IClass = "icon-pie-chart"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass="nav-link",AHref="/Admin/GetUsers", AValue="Yönetim",IClass="icon-eye"}
      };
    }

    private List<SidebarModel> SeniorSidebar()
    {
      return new List<SidebarModel>
      {
          new SidebarModel{ SpanClass= "nav-item", SpanValue = "", AClass = "nav-link", AHref = "/Word/GetMyReported", AValue = "Bildirdiklerim", IClass = "fa icon-notebook" },
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Developer/GetDeveloperTasks" , AValue = "Görevler", IClass = "fa fa-tasks"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Developer/GetDeveloperSend/" , AValue = "Gönderilenler", IClass = "fa fa-thumbs-up"},
          new SidebarModel{ SpanClass="nav-item", SpanValue="", AClass = "nav-link", AHref = "/Developer/GetRatingWords" , AValue = "Oylamadıklarım", IClass = "icon-directions"}
      };
    }

    public class SidebarModel
    {
      public string AClass { get; set; } // <a class="..."> </a>
      public string AHref { get; set; } // <a href="..."> </a>
      public string AValue { get; set; } // <a> ... </a>
      public string IClass { get; set; } // <i class="..." >
      public string SpanClass { get; set; } // <span class="..."> 
      public string SpanValue { get; set; } // <span>...</span>
    }
    #endregion
  }
}