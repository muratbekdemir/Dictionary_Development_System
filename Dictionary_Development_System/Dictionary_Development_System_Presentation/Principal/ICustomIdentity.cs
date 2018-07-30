using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Principal;
using System.Web;

namespace Dictionary_Development_System_Presentation.Principal
{
  public interface ICustomIdentity : IIdentity
  { 
    int UserId { get; set; } // Giriş Yapan Kullanıcı ID
    string UserEmail { get; set; } // Giriş Yapan Kullanıcı Email
    string UserName { get; set; }
    string UserSurname { get; set; }
    string RoleName { get; set; }
    bool IsAuthenticated { get; set; }//giriş yapıp yapmadığını, yani authenticate olup olmadığını sorgular
  }
}