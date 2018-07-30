using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Dictionary_Development_System_Presentation
{
  public enum Status
  {
    WaitAdmin = 1,
    OnDeveloper = 2,
    WaitAdminConfirmation = 3,
    InVote = 4,
    AdminRejected = 5,
    CommitteeRejected = 6
  }
}
