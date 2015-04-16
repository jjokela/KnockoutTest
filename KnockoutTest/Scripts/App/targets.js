var my = my || {}; //my namespace

my.vm = function () {
    var reservoirs = ko.mapping.fromJS([]);
    var selectedReservoir = ko.observable();
    var chosenTraps = ko.observableArray();
    var currentTrap = ko.observable();
    var loadInitialData = function () {
        ko.mapping.fromJS(my.data, {}, this.reservoirs);
    };
    var hae = function () {
        $.getJSON("FooBar", "data=data", function (data) {
            console.log("success: " + data);
            $("#janssoni").text(JSON.stringify(data));
        })
            .fail(function () {
                console.log("error");
            });
    };
    var postaa = function () {
        $.ajax({
            url: "",
            contentType: "application/json",
            type: "POST",
            data: JSON.stringify(ko.mapping.toJS(this.chosenTraps)),
            success: function (data) {
                alert("That is it!");
            }
        });
    };

    return {
        reservoirs: reservoirs,
        selectedReservoir: selectedReservoir,
        chosenTraps: chosenTraps,
        currentTrap: currentTrap,
        loadInitialData: loadInitialData,
        hae: hae,
        postaa: postaa
    }
}();

ko.applyBindings(my.vm); // This makes Knockout get to work
my.vm.loadInitialData();

my.selectReservoir = function (res, element) {
    console.log(res);
    console.log(element);
    my.vm.selectedReservoir(res);
}

my.selectTrap = function (trap, element) {
    console.log(trap);
    console.log(element);
    my.vm.currentTrap(trap);
}

$("table.reservoirs tbody tr").click(function () {
    console.log("Handler for .click() called.");
    my.selectReservoir(ko.dataFor(this), this);
});

// items don't exist yet when the dom is created, on() can register to those elements
$("body").on("click", "table.traps tbody tr", function () {
    console.log("Handler for .click() called.");
    my.selectTrap(ko.dataFor(this), this);
});

