

viewModel = {
//anytime an item is added or removed from the Array, Knockout will update any UI elements that are bound to this collection.
lookupCollection : ko.observableArray()
};

/**Here we directly do an AJAX get to retrieve some data from the server.
Once the server returns data (essentially the list of Lookup objects as JSON), we populate the lookupCollection in our viewModel.
s we are pushing data into the observable collection, KO is updating the UI for us automatically.**/

$(document).ready(function () {
  $.ajax({
    type: "GET",
    url: "/Lookup/GetIndex"
  }).done(function (data) {
    $(data).each(function (index, element) {
      var mappedItem =
        {
          Id: ko.observable(element.Id),
          Key: ko.observable(element.Key),
          Value: ko.observable(element.Value),
          Mode: ko.observable("display")
        };
      viewModel.lookupCollection.push(mappedItem);
    });
    ko.applyBindings(viewModel);
  }).error(function (ex) {
    alert("Error");
    });

});

$(document).on("click", ".kout-edit", null, function (ev) {
  var current = ko.dataFor(this);
  current.Mode("edit");
})

$(document).on("click", ".kout-update", null, function (ev) {
  var current = ko.dataFor(this);
  current.Mode("display");
})

$(document).on("click", ".kout-cancel", null, function (ev) {
  var current = ko.dataFor(this);
  current.Mode("display");
})

$(document).on("click", "#create", null, function (ev) {
  var current = {
    Id: ko.observable(0),
    Key: ko.observable(),
    Value: ko.observable(),
    Mode: ko.observable("edit")
  }
  viewModel.lookupCollection.push(current);
});

function saveData(currentData) {
  var postUrl = "";
  var submitData = {
    Id: currentData.Id(),
    Key: currentData.Key(),
    Value: currentData.Value()

  };
  if (currentData.Id && currentData.Id > 0) {
    postUrl = "/Lookup/Edit"
  }
  else {
    postUrl = "/Lookup/Create"
  }
  $.ajax({
    type: "POST",
    contentType: "application/json",
    url: postUrl,
    data: JSON.stringify(submitData)
  }).done(function (id) {
    currentData.Id(id);
  }).error(function (ex) {
    alert("Error Saving");
  })
}
