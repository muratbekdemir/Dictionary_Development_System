using Dictionary_Development_System_Data;
using Dictionary_Development_System_RequestResponse;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.ViewModels.Interest;
using System;
using System.Collections.Generic;
using System.Linq;
using Dictionary_Development_System_RequestResponse.RequestModels.Interest;

namespace Dictionary_Development_System_Business.Interest
{
  public class InterestService
  {
    public List<InterestView> GetAllInterests()
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<InterestView> response = new List<InterestView>();
          var entity = dbContext.Interest.ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              if (item.Id != 0)
              {
                InterestView obj = new InterestView();
                obj.Id = item.Id;
                obj.Name = item.Name;
                obj.CreatedDate = Convert.ToString(item.CreatedDate);
                obj.UpdatedDate = Convert.ToString(item.UpdatedDate);
                response.Add(obj);
              }
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
    public int GetUserInterestID(int UserId)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          InterestView response = new InterestView();
          var entity = dbContext.User.FirstOrDefault(x => x.Id == UserId);
          if (entity != null)
          {
            response.Id = entity.InterestId;
          }
          return response.Id;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public int GetSameInterestDevelopersCount(int UserId)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          var user = dbContext.User.FirstOrDefault(x => x.Id == UserId);

          return dbContext.User
                          .Where(x => x.InterestId == user.InterestId && x.Role==(int)Role.Senior)
                          .ToList().Count;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse AddInterest(AddInterestRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          Dictionary_Development_System_Data.Interest temp = new Dictionary_Development_System_Data.Interest();
          temp.Name = request.InterestName;
          temp.CreatedDate = DateTime.Now;
          temp.UpdatedDate = DateTime.Now;

          dbContext.Interest.Add(temp);
          dbContext.SaveChanges();

          BaseResponse response = new BaseResponse
          {
            IsSucceed = true,
            Message = "Yeni İlgi Alanı Eklendi"
          };
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
