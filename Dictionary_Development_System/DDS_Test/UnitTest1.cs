using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using Dictionary_Development_System_Data;
using System.Linq;

namespace DDS_Test
{
  [TestClass]
  public class UnitTest1
  {
    [TestMethod]
    public void CreateInterest()
    {
      using(DDS_Context dbContext = new DDS_Context())
      {
        dbContext.Interest.Add(new Interest { Id = 1, Name = "Computer", CreatedDate = DateTime.Now, UpdatedDate = DateTime.Now });
        dbContext.SaveChanges();
      }
    }

    [TestMethod]
    public void GetKeyword()
    {
      try
      {

        using (DDS_Context dbContext = new DDS_Context())
        {
          var keywordList = dbContext.TempWord.Select(x => new { x.DeveloperId, x.Content }).ToList();
          dbContext.SaveChanges();
        }
      }
      catch (Exception ex)
      {

        throw ex;
      }
    }
  }
}
