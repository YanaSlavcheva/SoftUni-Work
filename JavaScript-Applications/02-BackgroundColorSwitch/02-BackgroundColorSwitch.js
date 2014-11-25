$(document).ready(function () {
    console.log( "ready!" );
    $("#form").submit(function (e) {
        var classInput = $('#class').val();
        var color = $('#color').val();
        $("#" + classInput).css("background-color",color);
        e.preventDefault();
    })
})