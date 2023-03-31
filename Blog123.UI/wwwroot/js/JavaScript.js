function update() {
    sel = document.getElementById("selection");
    display = document.getElementById("forUserName");
    display.value = $("#selection").find(':selected').data('second');
}

//var valueId = $("#selection").change(function () {
//    ($(this).find(':selected').data('id').ToString());
//    display = document.getElementById("forUserID");
//    display.value = valueId;
//});

function update2() {
    sel = document.getElementById("selection2");
    display = document.getElementById("forCategory");
    display.value = $("#selection").find(':selected');
}