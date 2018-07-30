using Dictionary_Development_System_Presentation.Filters;
using SessionLayer;
using System.Web.Mvc;

namespace Dictionary_Development_System_Presentation.Controllers
{

  public class BaseController : Controller
  {
    #region Properties
    public int UserID { get { return SessionManager.Instance().GetValue<int>("UserID"); } }
    public string UserEmail { get { return SessionManager.Instance().GetValue<string>("UserEmail"); } }
    public string UserName { get { return SessionManager.Instance().GetValue<string>("UserName"); } }
    public string UserSurname { get { return SessionManager.Instance().GetValue<string>("UserSurname"); } }
    public string RoleName { get { return SessionManager.Instance().GetValue<string>("RoleName"); } }
    #endregion
  }
}