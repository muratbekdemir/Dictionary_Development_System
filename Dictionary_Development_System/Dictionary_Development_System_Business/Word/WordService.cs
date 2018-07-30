using Dictionary_Development_System_Business.Interest;
using Dictionary_Development_System_Data;
using Dictionary_Development_System_RequestResponse;
using Dictionary_Development_System_RequestResponse.Models.ResponseModels;
using Dictionary_Development_System_RequestResponse.RequestModels.Word;
using Dictionary_Development_System_RequestResponse.ResponseModels.Developer;
using Dictionary_Development_System_RequestResponse.ResponseModels.Word;
using Dictionary_Development_System_RequestResponse.ViewModels.Word;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;

namespace Dictionary_Development_System_Business.Word
{
  public class WordService
  {
    public SearchResponse SearchWord(SearchWordRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          SearchResponse response = new SearchResponse();
          var entity = dbContext.Dictionary.FirstOrDefault(x => x.Word == request.Word);

          if (entity != null)
          {
            response = new SearchResponse()
            {
              Word = entity.Word,
              Content = entity.Content,
              DeveloperId = entity.DeveloperId,
              InterestId = entity.InterestId,
              CreatedDate = Convert.ToString(entity.CreatedDate),
              UpdatedDate = Convert.ToString(entity.UpdatedDate)
            };
          }
          else
          {
            response.IsSucceed = false;
            response.Message = $"{request.Word} kelimesi sözlükte bulunamadı!";
          }
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse ReportWord(ReportRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          BaseResponse response = new BaseResponse();
          TempWord data = new TempWord();
          data.Word = request.Word;
          data.Status = 1;
          data.InterestId = request.InterestId;
          data.CreatedDate = DateTime.Now;
          data.UpdatedDate = DateTime.Now;
          data.AcceptanceVote = 0;
          data.RejectionVote = 0;
          data.UserId = request.UserId;
          dbContext.TempWord.Add(data);

          response.IsSucceed = true;
          response.Message = "Bildiriminiz için teşekkür ederiz.";
          dbContext.SaveChanges();

          return response;
        }
      }
      catch (Exception ex)
      {

        throw ex;
      }

    }
    public List<GetReportedWordResponse> GetReportedWords()
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<GetReportedWordResponse> response = new List<GetReportedWordResponse>();

          var entity = dbContext.TempWord.Where(x => x.Status == 1).ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              GetReportedWordResponse temp = new GetReportedWordResponse();
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);
              temp.WordId = item.Id;
              temp.Id = item.Id;
              temp.Word = item.Word;

              var i = dbContext.User.FirstOrDefault(x => x.Id == item.UserId);
              if (i != null) { temp.UserName = i.Name; temp.UserSurname = i.Surname; } else temp.UserName = "ADMIN";
              var developers = dbContext.User.Where(x => (x.Role == 2 || x.Role == 4) && (x.InterestId == item.InterestId)).ToList();//Senior
              if (developers != null)
                foreach (var element in developers)
                {
                  InterestsDevelopersResponse IDR = new InterestsDevelopersResponse();
                  IDR.Id = element.Id;
                  IDR.Name = element.Name;
                  IDR.Surname = element.Surname;
                  temp.Developers.Add(IDR);
                }
              var interest = dbContext.Interest.FirstOrDefault(x => x.Id == item.InterestId);
              if (interest != null)
              {
                temp.Interest.InerestId = interest.Id;
                temp.Interest.InterestName = interest.Name;
              }
              response.Add(temp);
            }
          }
          response.Reverse();
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse AssignWordToDeveloper(AssignWordToDeveloperRequest request)
    {
      try
      {
        BaseResponse response = new BaseResponse();
        using (DDS_Context dbContext = new DDS_Context())
        {
          TempWord wordEntity = new TempWord();
          wordEntity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.WordId);
          if (wordEntity == null)
          {
            response.IsSucceed = false;
            response.Message = "Bir Hata Oluştu, Görevlendirme Yapılamadı.";
          }
          else
          {
            wordEntity.DeveloperId = request.DeveloperId;
            wordEntity.Status = 2;  /*Status=OnDeveloper*/
            wordEntity.UpdatedDate = DateTime.Now;

            dbContext.SaveChanges();

            response.IsSucceed = true;
            response.Message = "Geliştirici Görevlendirildi.";
          }
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse WordRejectedByAdmin(AssignWordToDeveloperRequest request)
    {
      try
      {
        BaseResponse response = new BaseResponse();
        using (DDS_Context dbContext = new DDS_Context())
        {
          TempWord wordEntity = new TempWord();
          wordEntity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.WordId);
          if (wordEntity == null)
          {
            response.IsSucceed = false;
            response.Message = "Bir Hata Oluştu, Reddetme Başarısız.";
          }
          else
          {
            wordEntity.Status = 5;  /*Status=AdminRejected*/
            wordEntity.UpdatedDate = DateTime.Now;

            dbContext.SaveChanges();

            response.IsSucceed = true;
            response.Message = "Kelime Reddedildi.";
          }
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }
    public List<GetDeveloperTasksResponse> GetDeveloperTask(int developerId)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<GetDeveloperTasksResponse> response = new List<GetDeveloperTasksResponse>();

          var entity = dbContext.TempWord.Where(x => x.Status == 2 && x.DeveloperId == developerId).ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              GetDeveloperTasksResponse temp = new GetDeveloperTasksResponse();

              temp.Id = item.Id;
              temp.Word = item.Word;
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);

              response.Add(temp);
            }
          }
          response.Reverse();
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse SendTaskToAdmin(SendTaskToAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          var entity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.WordId);
          entity.Content = request.Content; /*ckeditor==word content*/
          entity.Status = 3;  /*status = WaitAdminConfirmation*/
          entity.UpdatedDate = DateTime.Now;

          dbContext.SaveChanges();

          BaseResponse response = new BaseResponse();
          response.IsSucceed = true;
          response.Message = "Araştırmanız Onaylanmak İçin Yöneticiye Gönderildi.";
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public List<GetAssignedTasksResponse> GetAssignedTasks()
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<GetAssignedTasksResponse> response = new List<GetAssignedTasksResponse>();

          var entity = dbContext.TempWord.Where(x => x.Status == 2).ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              GetAssignedTasksResponse temp = new GetAssignedTasksResponse();
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);
              temp.WordId = item.Id;
              temp.Word = item.Word;
              var userEntity = dbContext.User.FirstOrDefault(x => x.Id == item.UserId);
              if (userEntity != null) { temp.UserName = userEntity.Name; temp.UserSurname = userEntity.Surname; }
              else { temp.UserName = "UNDEFINED"; }

              var developerEntity = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
              if (developerEntity != null) { temp.DeveloperName = developerEntity.Name; temp.DeveloperSurname = developerEntity.Surname; }
              else { temp.DeveloperName = "UNDEFINED"; temp.DeveloperSurname = "UNDEFINED"; }

              var interest = dbContext.Interest.FirstOrDefault(x => x.Id == item.InterestId);
              if (interest != null)
              {
                temp.Interest.InerestId = interest.Id;
                temp.Interest.InterestName = interest.Name;
              }
              response.Add(temp);
            }
          }
          response.Reverse();
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public List<GetPendingWordsResponse> GetPendingWords()
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<GetPendingWordsResponse> response = new List<GetPendingWordsResponse>();

          var entity = dbContext.TempWord.Where(x => x.Status == 3).ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              GetPendingWordsResponse temp = new GetPendingWordsResponse();
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);
              temp.WordId = item.Id;
              temp.Word = item.Word;
              var userEntity = dbContext.User.FirstOrDefault(x => x.Id == item.UserId);
              if (userEntity != null) { temp.UserName = userEntity.Name; temp.UserSurname = userEntity.Surname; }
              else { temp.UserName = "UNDEFINED"; }

              var developerEntity = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
              if (developerEntity != null) { temp.DeveloperName = developerEntity.Name; temp.DeveloperSurname = developerEntity.Surname; }
              else { temp.DeveloperName = "UNDEFINED"; temp.DeveloperSurname = "UNDEFINED"; }

              var interest = dbContext.Interest.FirstOrDefault(x => x.Id == item.InterestId);
              if (interest != null)
              {
                temp.Interest.InerestId = interest.Id;
                temp.Interest.InterestName = interest.Name;
              }
              temp.Content = item.Content;
              response.Add(temp);
            }
          }
          response.Reverse();
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse SendTaskToVoting(SendTaskFromAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          var entity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id);
          entity.Status = 4;  /*status = inVote*/
          entity.UpdatedDate = DateTime.Now;

          dbContext.SaveChanges();

          BaseResponse response = new BaseResponse();
          response.IsSucceed = true;
          response.Message = "Araştırma Sonucu Oylanmak Üzere Gönderildi";
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }
    public BaseResponse DenyTask(SendTaskFromAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          var entity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id);
          entity.Status = 5;  /*status = inVote*/
          entity.UpdatedDate = DateTime.Now;

          dbContext.SaveChanges();

          BaseResponse response = new BaseResponse();
          response.IsSucceed = true;
          response.Message = "Araştırma Sonucu Reddedildi";
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }
    public List<WordView> GetRatingWords(GetRatingWordsRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<WordView> response = new List<WordView>();

          var entity = dbContext.TempWord.Where(x => x.Status == 4 && x.InterestId == request.InterestId).ToList();
          var result = entity;

          if (result != null)
          {
            /*daha önce oy kullandığının kontrolü*/
            var isVoted = dbContext.Votes.Where(x => x.DeveloperId == request.UserId).ToList();
            var deleteItems = new List<TempWord>();
            foreach (var voted in isVoted)
            {
              foreach (var item in result)
              {
                if (item.Id == voted.WordId)
                {
                  deleteItems.Add(item);
                }
              }
            }
            if (deleteItems != null)
            {
              foreach (var item in deleteItems)
              {
                result.Remove(item);
              }
            }
            ///////////////////////////////////////
            if (result.Count != 0)
            {
              foreach (var item in result)
              {
                WordView temp = new WordView();
                temp.CreatedDate = Convert.ToString(item.CreatedDate);
                temp.UpdatedDate = Convert.ToString(item.UpdatedDate);
                temp.WordId = item.Id;
                temp.Word = item.Word;
                var userEntity = dbContext.User.FirstOrDefault(x => x.Id == item.UserId);
                if (userEntity != null) { temp.UserName = userEntity.Name; temp.UserSurname = userEntity.Surname; }
                else { temp.UserName = "UNDEFINED"; temp.UserSurname = "UNDEFINED"; }

                var developerEntity = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
                if (developerEntity != null) { temp.DeveloperName = developerEntity.Name; temp.DeveloperSurname = developerEntity.Surname; }
                else { temp.DeveloperName = "UNDEFINED"; temp.DeveloperSurname = "UNDEFINED"; }

                var interest = dbContext.Interest.FirstOrDefault(x => x.Id == item.InterestId);
                if (interest != null)
                {
                  temp.Interest.InerestId = interest.Id;
                  temp.Interest.InterestName = interest.Name;
                }
                temp.Content = item.Content;
                response.Add(temp);
              }
            }
          }
          response.Reverse();
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public List<GetVotingTasksResponse> GetVotingTasks()
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<GetVotingTasksResponse> response = new List<GetVotingTasksResponse>();

          var entity = dbContext.TempWord.Where(x => x.Status == 4).ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              GetVotingTasksResponse temp = new GetVotingTasksResponse();
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);
              temp.WordId = item.Id;
              temp.Word = item.Word;
              var userEntity = dbContext.User.FirstOrDefault(x => x.Id == item.UserId);
              if (userEntity != null) { temp.UserName = userEntity.Name; temp.UserSurname = userEntity.Surname; }
              else { temp.UserName = "UNDEFINED"; temp.UserSurname = "UNDEFINED"; }

              var developerEntity = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
              if (developerEntity != null) { temp.DeveloperName = developerEntity.Name; temp.DeveloperSurname = developerEntity.Surname; }
              else { temp.DeveloperName = "UNDEFINED"; temp.DeveloperSurname = "UNDEFINED"; }

              var interest = dbContext.Interest.FirstOrDefault(x => x.Id == item.InterestId);
              if (interest != null)
              {
                temp.Interest.InerestId = interest.Id;
                temp.Interest.InterestName = interest.Name;
              }
              temp.Content = item.Content;
              temp.AcceptanceVote = item.AcceptanceVote;
              temp.RejectionVote = item.RejectionVote;
              response.Add(temp);
            }
          }
          response.Reverse();

          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public List<GetVotingTasksResponse> GetDeveloperSend(SendTaskFromAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<GetVotingTasksResponse> response = new List<GetVotingTasksResponse>();

          var entity = dbContext.TempWord.Where(x => x.Status > 2 && x.DeveloperId == request.UserId).ToList();

          if (entity != null)
          {
            foreach (var item in entity)
            {
              GetVotingTasksResponse temp = new GetVotingTasksResponse();
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);
              temp.WordId = item.Id;
              temp.Word = item.Word;
              var userEntity = dbContext.User.FirstOrDefault(x => x.Id == item.UserId);
              if (userEntity != null) { temp.UserName = userEntity.Name; temp.UserSurname = userEntity.Surname; }
              else { temp.UserName = "UNDEFINED"; temp.UserSurname = "UNDEFINED"; }

              var developerEntity = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
              if (developerEntity != null) { temp.DeveloperName = developerEntity.Name; temp.DeveloperSurname = developerEntity.Surname; }
              else { temp.DeveloperName = "UNDEFINED"; temp.DeveloperSurname = "UNDEFINED"; }

              var interest = dbContext.Interest.FirstOrDefault(x => x.Id == item.InterestId);
              if (interest != null)
              {
                temp.Interest.InerestId = interest.Id;
                temp.Interest.InterestName = interest.Name;
              }
              temp.Content = item.Content;
              temp.AcceptanceVote = item.AcceptanceVote;
              temp.RejectionVote = item.RejectionVote;

              switch (item.Status)
              {
                case 3:
                  temp.Status = "Admin Onayı Bekliyor";
                  break;
                case 4:
                  temp.Status = "Oylanıyor";
                  break;
                case 5:
                  temp.Status = "Admin Tarafından Reddedildi";
                  break;
                default:
                  temp.Status = "TANIMLANAMADI";
                  break;
              }

              response.Add(temp);
            }
          }

          var dictionary = dbContext.Dictionary.Where(x => x.DeveloperId == request.UserId).ToList();

          if (dictionary != null)
          {
            foreach (var item in dictionary)
            {
              GetVotingTasksResponse temp = new GetVotingTasksResponse();
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.UpdatedDate = Convert.ToString(item.UpdatedDate);
              temp.WordId = item.Id;
              temp.Word = item.Word;

              var developerEntity = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
              if (developerEntity != null) { temp.DeveloperName = developerEntity.Name; temp.DeveloperSurname = developerEntity.Surname; }
              else { temp.DeveloperName = "UNDEFINED"; temp.DeveloperSurname = "UNDEFINED"; }

              var interest = dbContext.Interest.FirstOrDefault(x => x.Id == item.InterestId);
              if (interest != null)
              {
                temp.Interest.InerestId = interest.Id;
                temp.Interest.InterestName = interest.Name;
              }
              temp.Content = item.Content;
              temp.Status = "Sözlüğe Eklendi";
              response.Add(temp);
              }
            }
          response.OrderBy(x=>x.UpdatedDate);

          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }

    }
    public BaseResponse AcceptanceVote(SendTaskFromAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {

          BaseResponse response = new BaseResponse();
          var isVotedControl = dbContext.Votes.FirstOrDefault(x => x.DeveloperId == request.UserId && x.WordId == request.Id);
          if (isVotedControl != null)
          {
            response.IsSucceed = false;
            response.Message = "Bu Konuyu Daha Önce Oyladınız.";
          }
          else
          {
            var entity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id);
            entity.AcceptanceVote += 1;

            Votes vote = new Votes();
            vote.WordId = request.Id;
            vote.DeveloperId = request.UserId;
            vote.Value = true;
            dbContext.Votes.Add(vote);

            dbContext.SaveChanges();

            response.IsSucceed = true;
            response.Message = "Bu Konuyu Olumlu Olarak Oyladınız.";
          }



          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public BaseResponse RejectionVote(SendTaskFromAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {

          BaseResponse response = new BaseResponse();
          var isVotedControl = dbContext.Votes.FirstOrDefault(x => x.DeveloperId == request.UserId && x.WordId == request.Id);
          if (isVotedControl != null)
          {
            response.IsSucceed = false;
            response.Message = "Bu Konuyu Daha Önce Oyladınız.";
          }
          else
          {
            var entity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id);
            entity.RejectionVote += 1;

            Votes vote = new Votes();
            vote.WordId = request.Id;
            vote.DeveloperId = request.UserId;
            vote.Value = true;
            dbContext.Votes.Add(vote);

            dbContext.SaveChanges();

            response.IsSucceed = true;
            response.Message = "Bu Konuyu Olumsuz Olarak Oyladınız.";
          }
          return response;
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public void VotingIsEnded(SendTaskFromAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          InterestService _interest = new InterestService();
          var sameSeniorsCount = _interest.GetSameInterestDevelopersCount(request.UserId);

          var acceptanceVotesCount = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id).AcceptanceVote;
          var rejectionVotesCount = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id).RejectionVote;
          if (acceptanceVotesCount + rejectionVotesCount == sameSeniorsCount)
          {
            if (acceptanceVotesCount < rejectionVotesCount)
            {
              var entity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id);
              entity.Status = 6;
              dbContext.SaveChanges();
            }
            else
            {
              var entity = dbContext.TempWord.FirstOrDefault(x => x.Id == request.Id);
              var item = new Dictionary_Development_System_Data.Dictionary();
              //var willDeleteVotes = dbContext.Votes.Where(x => x.WordId == request.Id).ToList();
              //var tempVotes = new List<Votes>();
              //if(willDeleteVotes != null)
              //{
              //  foreach (var vote in willDeleteVotes)
              //  {
              //    tempVotes.Add(vote);
              //  }
              //  foreach (var vote in tempVotes)
              //  {
              //    willDeleteVotes.Remove(vote);
              //  }
              //  dbContext.SaveChanges();
              //}

              item.Content = entity.Content;
              item.CreatedDate = entity.CreatedDate;
              item.UpdatedDate = DateTime.Now;
              item.InterestId = entity.InterestId;
              item.Word = entity.Word;
              item.DeveloperId = entity.DeveloperId ?? 0;

              dbContext.Dictionary.Add(item);
              dbContext.TempWord.Remove(entity);

              dbContext.SaveChanges();
            }
          }
          else
          {
            return;
          }
        }
      }
      catch (Exception ex)
      {
        throw ex;
      }
    }
    public List<WordView> GetMyReported(SendTaskFromAdminRequest request)
    {
      try
      {
        using (DDS_Context dbContext = new DDS_Context())
        {
          List<WordView> response = new List<WordView>();

          var dictionaryEntity = dbContext.Dictionary.Where(x => x.UserID == request.UserId).ToList();

          if (dictionaryEntity != null)
          {
            foreach (var item in dictionaryEntity)
            {
              WordView temp = new WordView();
              temp.Word = item.Word;
              temp.Interest.InterestName = item.Interest.Name;
              temp.Interest.InerestId = item.InterestId;
              temp.Status = "Sözlüğe Eklendi";
              var developer = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
              temp.DeveloperName = developer.Name;
              temp.DeveloperSurname = developer.Surname;
              temp.CreatedDate = Convert.ToString(item.CreatedDate);
              temp.Content = item.Content;

              response.Add(temp);
            }
          }

          var tempWordEntity = dbContext.TempWord.Where(x => x.UserId == request.UserId).ToList();

          if (tempWordEntity != null)
          {
            foreach (var item in tempWordEntity)
            {
              WordView temp = new WordView();
              temp.Word = item.Word;
              temp.Interest.InterestName = item.Interest.Name;
              temp.Interest.InerestId = item.InterestId;

              switch (item.Status)
              {
                case 1:
                  temp.Status = "Yönetici onayı bekliyor";
                  break;
                case 2:
                  temp.Status = "Geliştirici Üzerinde Çalışıyor";
                  break;
                case 3:
                  temp.Status = "Geliştiricinin Çalışması Onay Bekliyor";
                  break;
                case 4:
                  temp.Status = "Oylanıyor";
                  break;
                case 5:
                  temp.Status = "Yönetici Tarafından Reddedildi";
                  break;
                case 6:
                  temp.Status = "Oylamada Kabul Görmedi";
                  break;
                default:
                  temp.Status = "TANIMLANAMADI";
                  break;
              }
              var developer = dbContext.User.FirstOrDefault(x => x.Id == item.DeveloperId);
              if (developer != null)
              {
                temp.DeveloperName = developer.Name;
                temp.DeveloperSurname = developer.Surname;
              }
              temp.CreatedDate = Convert.ToString(item.CreatedDate);

              response.Add(temp);
            }
            response.Reverse();
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
