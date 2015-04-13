viewModel.selectedReservoir = ko.observable();
viewModel.chosenTraps = ko.observableArray();
viewModel.currentTrap = ko.observable();

ko.applyBindings(viewModel);

$("table.reservoirs tbody tr").click(function () {
    console.log("Handler for .click() called.");
    selectReservoir(ko.dataFor(this), this);
});

// items don't exist yet when the dom is created, on() can register to those elements
$("body").on("click", "table.traps tbody tr", function () {
    console.log("Handler for .click() called.");
    selectTrap(ko.dataFor(this), this);
});

var selectReservoir = function (res, element) {
    console.log(res);
    console.log(element);
    viewModel.selectedReservoir(res);
}

var selectTrap = function (trap, element) {
    console.log(trap);
    console.log(element);
    viewModel.currentTrap(trap);
}

var postaa = function () {
    $.ajax({
        url: "",
        contentType: "application/json",
        type: "POST",
        data: JSON.stringify(ko.mapping.toJS(viewModel.chosenTraps)),
        success: function (data) {
            alert("That is it!");
        }
    });
}

var hae = function () {
    $.getJSON("FooBar", function (data) {
        console.log("success: " + data);
        $("#janssoni").text(JSON.stringify(data));
    })
  .fail(function () {
      console.log("error");
  });
}
