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
            var countryId = country['objectId'];
            var countryItem = $('<li id="' + countryId + '" class="country"' + '>');
            countryItem.text(country.name);
            countryItem.appendTo($('#countries'));

            // Append towns
            countryItem.append('<ul id="inner' + countryId + '">');
            findListOfTowns(country, countryId);
            countryItem.append('</ul>');
            countryItem.children().toggle();
        }

        //COUNTRIES
        // Add country
        var buttonAdd = $('#addCountry');
        buttonAdd.click(addCountries);

        // Delete country
        var buttonDelete = $('#deleteCountry');
        buttonDelete.click(deleteCountries);

        // Update country
        var buttonUpdate = $('#updateCountry');
        buttonUpdate.click(updateCountries);

        // TOWNS
        // Add town
        var buttonAddTown = $('#addTown');
        buttonAddTown.click(addTowns); // TODO: Create function

        // Delete town
        var buttonDeleteTown = $('#deleteTown');
        buttonDeleteTown.click(deleteTowns); // TODO: Create function

        // Update town
        var buttonUpdateTown = $('#updateTown');
        buttonUpdateTown.click(updateTowns); // TODO: Create function

    }).fail(function() {
        alert('Cannot load countries.');
    });

    function addTowns() {
        var townToAdd = $('#addedTown').val();
        console.log(townToAdd);
        var countryForTown = $('#countryForTown').val();
        console.log(countryForTown);
        var countryId = extractCountryId(countryForTown);
        console.log(countryId);
        $.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                "Content-Type": "application/json"
            },
            url: "https://api.parse.com/1/classes/Town",
            data: JSON.stringify(
                {"name": townToAdd, "country" :{
                    "__type": "Pointer",
                    "className": "Country",
                    "objectId": countryId
                }}
            )
        }).done(function (data) {
            alert('Town added successfully. Please, refresh!');
        }).fail(function () {
            alert('Cannot add town.');
        });
    }

    function deleteTowns() {
        var townToDelete = $('#deletedTown').val();
        var townId = extractTownId(townToDelete);
        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Town/" + townId
        }).done(function (data) {
            alert('Town deleted successfully. Please, refresh!');
        }).fail(function () {
            alert('Cannot delete town.');
        });
    }

    function addCountries() {
        var countryToAdd = $('#addedCountry').val();
        $.ajax({
            method: "POST",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                "Content-Type": "application/json"
            },
            url: "https://api.parse.com/1/classes/Country",
            data: JSON.stringify(
                {"name": countryToAdd}
            )
        }).done(function (data) {
            alert('Country added successfully. Please, refresh!');
        }).fail(function () {
            alert('Cannot add country.');
        });
    }

    function extractCountryId(country) {
        var countryId = "";
        var countriesInLi = $('.country');
        $.each(countriesInLi, function (index, value) {
            var currCountry = value["innerText"];
            if (currCountry === country) {
                countryId = value["id"];
            }
        });
        return countryId;
    }

    function extractTownId(town) {
        var townId = "";
        var townInLi = $('.town');
        $.each(townInLi, function (index, value) {
            var currTown = value["innerText"];
            if (currTown === town) {
                townId = value["id"];
            }
        });
        return townId;
    }

    function deleteCountries() {
        var countryToDelete = $('#deletedCountry').val();
        var countryId = extractCountryId(countryToDelete);
        $.ajax({
            method: "DELETE",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Country/" + countryId
        }).done(function (data) {
            alert('Country deleted successfully. Please, refresh!');
        }).fail(function () {
            alert('Cannot delete country.');
        });
    }

    function updateCountries() {
        var countryToUpdate = $('#currentName').val();
        var countryId = extractCountryId(countryToUpdate);
        var countryNewName = $('#newName').val();

        $.ajax({
            method: "PUT",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                "Content-Type": "application/json"
            },
            url: "https://api.parse.com/1/classes/Country/" + countryId,
            data: JSON.stringify(
                {"name": countryNewName}
            )
        }).done(function (data) {
            alert('Country renamed successfully. Please, refresh!');
        }).fail(function () {
            alert('Cannot rename country.');
        });

    }

    function updateTowns() {
        var townToUpdate = $('#currentNameTown').val();
        var townId = extractTownId(townToUpdate);
        var townNewName = $('#newNameTown').val();

        $.ajax({
            method: "PUT",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY,
                "Content-Type": "application/json"
            },
            url: "https://api.parse.com/1/classes/Town/" + townId,
            data: JSON.stringify(
                {"name": townNewName}
            )
        }).done(function (data) {
            alert('Town renamed successfully. Please, refresh!');
        }).fail(function () {
            alert('Cannot rename town.');
        });

    }

    function findListOfTowns(country, countryId) {
        $.ajax({
            method: "GET",
            headers: {
                "X-Parse-Application-Id": PARSE_APP_ID,
                "X-Parse-REST-API-Key": PARSE_REST_API_KEY
            },
            url: "https://api.parse.com/1/classes/Town"
        }).done(function (data) {
            console.log('entered findlisttowns');
            for (var t in data.results) {
                var town = data.results[t];
                var townId = town['objectId'];
                var temp = town['country'];
                var countryIdLinked = temp['objectId'];

                if(countryId === countryIdLinked) {
                    var townItem = $('<li id="' + townId + '" class="town"' + '>');
                    townItem.text(town.name);
                    townItem.appendTo($('#inner' + countryId));
                }
            }
        }).fail(function () {
            alert('Cannot append towns.');
        });
    }
})

