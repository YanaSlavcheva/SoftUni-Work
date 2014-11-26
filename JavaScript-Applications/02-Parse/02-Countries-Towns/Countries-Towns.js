$(document).ready(function () {
    var PARSE_APP_ID = "VD2IJAYdZcgtax88W55r1puTklLw8DqT8C8FTCBU";
    var PARSE_REST_API_KEY = "KuBgS9qiJIuwVEaOUXwYNWRhVvS9462Ct9wutoSt";

    $.ajax({
        method: "GET",
        headers: {
            "X-Parse-Application-Id": PARSE_APP_ID,
            "X-Parse-REST-API-Key": PARSE_REST_API_KEY
        },
        url: "https://api.parse.com/1/classes/Country"
    }).done(function(data) {
        for (var c in data.results) {
            var country = data.results[c];
            var countryItem = $('<li>');
            countryItem.text(country.name);
            countryItem.appendTo($("#countries"));
        }
    }).fail(function() {
        alert('Cannot load countries.');
    });
})


