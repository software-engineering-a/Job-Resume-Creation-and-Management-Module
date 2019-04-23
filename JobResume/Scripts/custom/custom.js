$('#city2').hide();
$("#city").change(function () {
    if ($('#city').val() == "Other") {
        $('#city1').hide();
        $('#city2').show();
    }
});

$('#addcity').click(function () {
    $("#city").prepend(new Option($('#newcity').val(), $('#newcity').val()));
    $('#city2').hide();
    $('#city1').show();
});


$('#country2').hide();
$("#country").change(function () {
    if ($('#country').val() == "Other") {
        $('#country1').hide();
        $('#country2').show();
    }
});

$('#addcountry').click(function () {
    $("#country").prepend(new Option($('#newcountry').val(), $('#newcountry').val()));
    $('#country2').hide();
    $('#country1').show();
});


$('#lastdegree2').hide();
$("#lastdegree").change(function () {
    if ($('#lastdegree').val() == "Other") {
        $('#lastdegree1').hide();
        $('#lastdegree2').show();
    }
});

$('#addlastdegree').click(function () {
    $("#lastdegree").prepend(new Option($('#newlastdegree').val(), $('#newlastdegree').val()));
    $('#lastdegree2').hide();
    $('#lastdegree1').show();
});


$('#scndlastdegree2').hide();
$("#scndlastdegree").change(function () {
    if ($('#scndlastdegree').val() == "Other") {
        $('#scndlastdegree1').hide();
        $('#scndlastdegree2').show();
    }
});

$('#addscndlastdegree').click(function () {
    $("#scndlastdegree").prepend(new Option($('#newscndlastdegree').val(), $('#newscndlastdegree').val()));
    $('#scndlastdegree2').hide();
    $('#scndlastdegree1').show();
});


$('#lastinstitute2').hide();
$("#lastinstitute").change(function () {
    if ($('#lastinstitute').val() == "Other") {
        $('#lastinstitute1').hide();
        $('#lastinstitute2').show();
    }
});

$('#addlastinstitute').click(function () {
    $("#lastinstitute").prepend(new Option($('#newlastinstitute').val(), $('#newlastinstitute').val()));
    $('#lastinstitute2').hide();
    $('#lastinstitute1').show();
});

$('#scndlastinstitute2').hide();
$("#scndlastinstitute").change(function () {
    if ($('#scndlastinstitute').val() == "Other") {
        $('#scndlastinstitute1').hide();
        $('#scndlastinstitute2').show();
    }
});

$('#addscndlastinstitute').click(function () {
    $("#scndlastinstitute").prepend(new Option($('#newscndlastinstitute').val(), $('#newscndlastinstitute').val()));
    $('#scndlastinstitute2').hide();
    $('#scndlastinstitute1').show();
});