$(document).ready(function () {
    var input = [{"manufacturer":"BMW","model":"E92 320i","year":2011,"price":50000,"class":"Family"},
        {"manufacturer":"Porsche","model":"Panamera","year":2012,"price":100000,"class":"Sport"},
        {"manufacturer":"Peugeot","model":"305","year":1978,"price":1000,"class":"Family"}];

    $('table').append('<tbody>');

    for (var i = 0; i < input.length; i++) {
        var manufacturer = input[i].manufacturer;
        var model = input[i].model;
        var year = input[i].year;
        var price = input[i].price;
        var classCar = input[i].class;

        $('table').append('<tr><td>' + manufacturer + '</td><td>' + model + '</td><td>' +
                                        year + '</td><td>' + price + '</td><td>' + classCar + '</tr>');
    }

    $('table').append('</tbody>');

    console.log(typeof (input));
})