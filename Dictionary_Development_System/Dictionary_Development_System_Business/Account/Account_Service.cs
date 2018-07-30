using Dictionary_Development_System_Data;
using Dictionary_Development_System_RequestResponse;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.RequestModels.Account;
using Dictionary_Development_System_RequestResponse.ResponseModels.Account;
using Dictionary_Development_System_RequestResponse.ViewModels.Account;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Dictionary_Development_System_Business.Account
{
  public class Account_Service
  {
    public LoginResponse Login(LoginRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          LoginResponse response = new LoginResponse();
          User user = dbContext.User.FirstOrDefault(x => x.Email == request.Email && x.Password == request.Password);
          if (user != null)
          {
            response.UserView = new UserView()
            {
              Email = user.Email,
              Id = user.Id,
              Name = user.Name,
              RoleName = ReturnRole(user.Role),
              Surname = user.Surname
            };
          }
          else
          {
            response.IsSucceed = false;
            response.Message = $"Bu {request.Email}'e ait herhangi bir kullanıcı bulunmamaktadır! ";
          }
          return response;
        }

      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    private string ReturnRole(int roleID)
    {
      string response = string.Empty;
      switch (roleID)
      {
        case 1:
          response = Role.User.ToString(); break;
        case 2:
          response = Role.Developer.ToString(); break;
        case 3:
          response = Role.Admin.ToString(); break;
        case 4:
          response = Role.Senior.ToString(); break;
        default:
          response = Role.User.ToString(); break;
      }
      return response;
    }
    public List<GetUserResponse> GetUsers()
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<GetUserResponse> response = new List<GetUserResponse>();
          var entity = dbContext.User.ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              GetUserResponse temp = new GetUserResponse();
              temp.UserId = item.Id;
              temp.UserName = item.Name;
              temp.UserSurname = item.Surname;
              temp.Email = item.Email;
              temp.InterestName = item.Interest.Name;
              temp.InterestId = item.Interest.Id;
              temp.RoleId = item.Role;
              temp.Password = item.Password;
              switch (temp.RoleId)
              {
                case 1:
                  temp.RoleName = "Kullanıcı";
                  break;
                case 2:
                  temp.RoleName = "Geliştirici";
                  break;
                case 4:
                  temp.RoleName = "Kurul Üyesi";
                  break;
                default:
                  temp.RoleName = "TANIMLANAMADI";
                  break;
              }
              temp.CreatedDate = Convert.ToString(item.CreatedDaate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);

              response.Add(temp);
            }
          }
          response.Remove(response.FirstOrDefault(x => x.RoleId == (int)Role.Admin));   /*admin listede görüntülenmemeli*/

          response.Reverse();
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse AddEditUser(AddUserRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          BaseResponse response = new BaseResponse();
          if (request.Id == 0)
          {
            User temp = new User();

            temp.Name = request.Name;
            temp.Surname = request.Surname;
            temp.Email = request.Email;
            temp.Password = request.Password;
            temp.InterestId = request.InterestId;
            temp.Role = request.Role;
            temp.CreatedDaate = DateTime.Now;
            temp.UpdatedDate = DateTime.Now;

            dbContext.User.Add(temp);
            dbContext.SaveChanges();

            
            response.Message = "Kullanıcı Eklendi";
            response.IsSucceed = true;
          }
          else
          {
            var entity = dbContext.User.FirstOrDefault(x => x.Id == request.Id);

            if (entity != null)
            {
              entity.Name = request.Name;
              entity.Surname = request.Surname;
              entity.Email = request.Email;
              entity.Password = request.Password;
              entity.InterestId = request.InterestId;
              entity.Role = request.Role;
              entity.UpdatedDate = DateTime.Now;

              dbContext.SaveChanges();

              response.Message = "Kullanıcı Güncellendi";
              response.IsSucceed = true;
            }
            else
            {
              response.Message = "KULLANICI BULUNAMADI";
              response.IsSucceed = false;
            }

          }
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }


    }


  }
}
