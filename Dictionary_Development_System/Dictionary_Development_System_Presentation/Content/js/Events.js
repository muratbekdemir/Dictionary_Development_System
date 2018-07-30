function ReportButtonClick(word) {
  var data = {}
  data.word = word
  data.InterestId = $('#InterestsDropdownlist').val();
  $.ajax({
    type: 'POST',
    data: data,
    url: "/Word/Report",
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        window.location.href = '/User/Index';
      }
      else {
        alert("BİLDİRİM YAPABİLMENİZ İÇİN GİRİŞ YAPMANIZ GEREKMEKTEDİR.")
        window.location.href = '/Account/Login';
      }
    }
  });
}

function adminSelectedDeveloperName(wordId, listId) {
  var button = $('#assignButton_' + wordId);
  button.removeAttr('disabled');
  if (listId == "0") {
    button.prop('disabled', true);
  }
}

function adminAssignTaskDeveloperButton(developerId, wordId) {
  var data = {}
  data.DeveloperId = developerId;
  data.WordId = wordId;
  $.ajax({
    type: 'POST',
    data: data,
    url: "/Admin/AssignWordToDeveloper",
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        $('#ReportedWordRow_' + wordId).remove();
      }
    }
  });
}

function adminRejectTask(wordId) {
  var data = {}
  data.WordId = wordId;
  $.ajax({
    type: 'POST',
    data: data,
    url: "/Admin/RejectWord",
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        $('#ReportedWordRow_' + wordId).remove();
      }
    }
  });
}

function PendingWordsAppendInModel(word, wordId) {
  $('.modal-title').html(word);
  var content = "#content_" + wordId;

  $('.modal-body').html($(content).text());

  var confirmButton = $('<button id="confirmationButton" onclick="confirmPendingTask(' + wordId + ')" type="button" class="btn btn-success">Onayla</button>');
  $('#appendLocation').html(confirmButton);
  var denialButton = $('<button id="denialButton" onclick="denyPendingTask(' + wordId + ')" style = "margin-left:5px;" type="button" class="btn btn-danger">Reddet</button>');
  $('#appendLocation').append(denialButton);

  //var confirmationActionLink = "/Admin/SendTaskToVoting/" + wordId;
  //var denialAction = "/Admin/DenyTask/" + wordId;

  //$("#confirmationButton").attr("onclick", confirmPendingTask(wordId));   /*confirmPendingTask function eklenecek*/
  //$("#denialButton").attr("onclick", denyPendingTask(wordId));      /*denyPendingTask function*/
  //--------------------------------------------
  //var confirmButton = document.createElement('button');
  //confirmButton.type = 'button';
  //confirmButton.classList = 'btn btn-success';
  //confirmButton.innerText = 'Onayla';
  //confirmButton.onlick = confirmPendingTask(wordId);

  //var denialButton = document.createElement('button');
  //denialButton.type = 'button';
  //denialButton.classList = 'btn btn-danger';
  //denialButton.innerText = 'Reddet';
  //denialButton.style = "margin-left:5px;"
  //denialButton.attributes = denyPendingTask(wordId);

  //$('#appendLocation').html(confirmButton);
  //$('#appendLocation').append(denialButton);

}

function confirmPendingTask(wordId) {
  var data = {}
  data.Id = wordId;
  $.ajax({
    type: "POST",
    url: '/Admin/SendTaskToVoting',
    data: data,
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        window.location.href = '/Admin/GetPendingWords';
      }
      else {
        alert(returnData.Message)
      }
    },
    dataType: "json"
  });
}

function denyPendingTask(wordId) {
  var data = {}
  data.Id = wordId;
  $.ajax({
    type: "POST",
    url: '/Admin/DenyTask',
    data: data,
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        window.location.href = '/Admin/GetPendingWords';
      }
      else {
        alert(returnData.Message)
      }
    },
    dataType: "json"
  });
}

function GetRatingWordsAppendInModel(word, wordId) {

  $('.modal-title').html(word);
  var content = "#content_" + wordId;

  $('.modal-body').html($(content).text());

  var confirmButton = $('<button id="confirmationButton" onclick="acceptanceVote(' + wordId + ')" type="button" class="btn btn-success">Onayla</button>');
  $('#appendLocation').html(confirmButton);
  var denialButton = $('<button id="denialButton" onclick="rejectionVote(' + wordId + ')" style = "margin-left:5px;" type="button" class="btn btn-danger">Reddet</button>');
  $('#appendLocation').append(denialButton);

  //var confirmationActionLink = "/Developer/AcceptanceVote/" + wordId;
  //var denialAction = "/Developer/RejectionVote/" + wordId;

  //$("#confirmationButton").attr("href", confirmationActionLink);
  //$("#denialButton").attr("href", denialAction);
}

function acceptanceVote(wordId) {
  var data = {}
  data.Id = wordId;
  $.ajax({
    type: "POST",
    url: '/Developer/AcceptanceVote',
    data: data,
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        window.location.href = '/Developer/GetRatingWords';
      }
      else {
        alert(returnData.Message)
      }
    },
    dataType: "json"
  });
}

function rejectionVote(wordId) {
  var data = {}
  data.Id = wordId;
  $.ajax({
    type: "POST",
    url: '/Developer/RejectionVote',
    data: data,
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        window.location.href = '/Developer/GetRatingWords';
      }
      else {
        alert(returnData.Message)
      }
    },
    dataType: "json"
  });
}

function VotingWordsAppendInModel(word, wordId) {
  $('.modal-title').html(word);
  var content = "#content_" + wordId;
  $('.modal-body').html($(content).text());
}

function SendTaskButtonClick(wordId) {
  var data = {}
  data.WordId = wordId;
  data.Content = CKEDITOR.instances['editor'].getData();
  $.ajax({
    type: "POST",
    url: '/Developer/SendTaskToAdmin',
    data: data,
    success: function (returnData) {
      if (returnData.IsSucceed) {
        alert(returnData.Message)
        window.location.href = '/Developer/GetDeveloperTasks';
      }
      else {
        alert(returnData.Message)
      }
    },
    dataType: "json"
  });

}

function fillInterestOption() {
  $.ajax({
    type: "POST",
    url: '/Interest/GetAllInterests',
    success: function (returnData) {
      
      $("#interestOptionList").html('<option value="0">Lütfen Bir İlgi Alanı Seçin</option>');
      $.each(returnData, function (key, value) {
        $("#interestOptionList")
          .append($("<option></option>")
            .attr("value", value.Id)
            .text(value.Name));
      });
    },
    dataType: "json"
  });
}

function resetButtonClick() {
  $('.forReset').val('');
}

function addUserButton() {
  if (($('.forReset').val() != null && $('.forReset').val() != "" ) && $('#interestOptionList').val() != 0 && $('#RoleOptionList').val() != 0) {
    if ($('#userPassword').val() == $('#userPasswordAgain').val()) {
      var data = {}
      data.Name = $('#userName').val();
      data.Surname = $('#userSurname').val();
      data.Email = $('#userEmail').val();
      data.Password = $('#userPassword').val();
      data.Role = $('#RoleOptionList').val();
      data.InterestId = $('#interestOptionList').val();
      $.ajax({
        type: "POST",
        url: '/Admin/AddEditUser',
        data: data,
        success: function (returnData) {
          if (returnData.IsSucceed) {
            alert(returnData.Message)
            window.location.href = '/Admin/GetUsers';
          }
          else {
            alert(returnData.Message)
          }
        },
        dataType: "json"
      });
    }
    else {
      alert("PAROLA OLUŞTURURKEN BİR HATA OLUŞTU. TEKRAR DENEYİN.")
      $('#userPassword').val('');
      $('#userPasswordAgain').val('');
    }
  }
  else {
    alert('LÜTFEN BİLGİLERİ EKSİKSİZ GİRİN.')
  }
}

function EditUserButton(UserId, UserName, UserSurname) {
  $('.modal-title').html($('#userNameSurnameRow_' + UserId).text());
  $('#editUserName').val(UserName);
  $('#editUserSurname').val(UserSurname)
  $('#editUserEmail').val($('#userEmailRow_' + UserId).text());
  $('#editUserPassword').val($('#UserRow_' + UserId).attr('pass'))
  $('#EditUserPasswordAgain').val($('#UserRow_' + UserId).attr('pass'))
  $.ajax({
    type: "POST",
    url: '/Interest/GetAllInterests',
    success: function (returnData) {
      $("#interestOptionListEdit").html('')
      $.each(returnData, function (key, value) {
        $("#interestOptionListEdit")
          .append($("<option></option>")
            .attr("value", value.Id)
            .text(value.Name));
      });
      var interestval = $("#userInterestRow_" + UserId).attr('val');
      $('#interestOptionListEdit option[value="' + interestval + '"]').attr('selected', true);
    },
    dataType: "json"
  });
  var roleval = $("#userRoleRow_" + UserId).attr('val');
  $('#EditRoleOptionList option[value="' + roleval + '"]').attr('selected', true);
  $('#appendLocation').html('<button type="button" onclick="ApplyEditionButton(' + UserId + ')" class="btn btn-success">Uygula</button>');
}

function ApplyEditionButton(UserId) {
  debugger;
  if ($("#editUserName").val() != "" &&
    $("#editUserSurname").val() != "" &&
    $("#editUserEmail").val() != "" &&
    $("#editUserPassword").val() != "" &&
    $("#EditUserPasswordAgain").val() != "" &&
    $('#interestOptionListEdit').val() != 0 &&
    $('#EditRoleOptionList').val() != 0) {
    if ($('#editUserPassword').val() == $('#EditUserPasswordAgain').val()) {
      var data = {}
      data.Id = UserId;
      data.Name = $('#editUserName').val();
      data.Surname = $('#editUserSurname').val();
      data.Email = $('#editUserEmail').val();
      data.Password = $('#editUserPassword').val();
      data.Role = $('#EditRoleOptionList option:selected').val();
      data.InterestId = $('#interestOptionListEdit option:selected').val()
      $.ajax({
        type: "POST",
        url: '/Admin/AddEditUser',
        data: data,
        success: function (returnData) {
          if (returnData.IsSucceed) {
            alert(returnData.Message)
            window.location.href = '/Admin/GetUsers';
          }
          else {
            alert(returnData.Message)
          }
        },
        dataType: "json"
      });
    }
    else {
      alert("PAROLA OLUŞTURURKEN BİR HATA OLUŞTU. TEKRAR DENEYİN.")
      $('#userPassword').val('');
      $('#userPasswordAgain').val('');
    }

  }
  else {
    alert('LÜTFEN BİLGİLERİ EKSİKSİZ GİRİN.')
  }
}

function AddInterest() {
  debugger;
  if ($('#InterestNameBox').val() != "") {
    var data = {}
    data.InterestName = $('#InterestNameBox').val();
    $.ajax({
      type: "POST",
      url: '/Interest/AddInterest',
      data: data,
      success: function (returnData) {
        if (returnData.IsSucceed) {
          alert(returnData.Message)
          window.location.href = '/Admin/GetUsers';
        }
        else {
          alert(returnData.Message)
        }
      },
      dataType: "json"
    });
  }
  else {
    alert("EKLEMEK İSTEDİĞİNİZ İLGİ ALANININ ADINI YAZINIZ.")
  }
}

$('#InterestNameBox').keyup(function (e) {
  if (e.keyCode == 13) {
    AddInterest();
  }
});

//$("#searchButtonForWord").on("click", function () {

//  var data = {
//    Word: $('#searchTextboxForWord').val()
//  };
//  $.ajax({
//    type: "POST",
//    url: '/Word/Search',
//    data: data,
//    success: function (returnData) {
//      if (returnData.IsSucceed) {
//        debugger;
//        alert(returnData.Content)        

//      }
//      else {
//        alert(returnData.Message)
//      }
//    },
//    dataType: "json" 
//  });
//});

//$(".wordTextbox").keyup(function (event) {
//  if (event.keyCode === 13) {
//    searchWord();
//  }
//});

//function searchWord() {
//  debugger;
//  var data = {}
//  data.Word = $('.wordTextbox').val();
//  $.post("/Word/Search", function (data) {
//  });

//  $.ajax({
//    type: "POST",
//    url: '/Word/Search',
//    data: data
//  });
//}
