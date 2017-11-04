$("#rateit5").bind('rated', function (event, value) {
    if (value == 0.5) { value = 1, message = "Not that great."; }
    else if (value == 1) { value = 2, message = "Not that great."; }
    else if (value == 1.5) { value = 3, message = "Not really worth your time."; }
    else if (value == 2) { value = 4, message = "Not really worth your time."; }
    else if (value == 2.5) { value = 5, message = "So-so. If you can't find anywhere else and are bored."; }
    else if (value == 3) { value = 6, message = "So-so. If you can't find anywhere else and are bored."; }
    else if (value == 3.5) { value = 7, message = "Solid."; }
    else if (value == 4) { value = 8, message = "Solid."; }
    else if (value == 4.5) { value = 9, message = "Don't miss out - you'll regret it."; }
    else if (value == 5) { value = 10, message = "Don't miss out - you'll regret it."; }
    $('#value5').text(message);
    $("#StarRating").val(value);
    $('.rateit button.rateit-reset').removeClass("fillZero");
    $('#rateit-reset-2').addClass("rateit-reset");

});
$("#rateit5").bind('reset', function (event, value) {
    value = 0;
    message = "Don't bother.";
    $('#value5').text(message);
    $("#StarRating").val(value);
    $('#rateit-reset-2').addClass("fillZero");
});