$(document).ready(function(){
    for (var i = 1; i < 4; i++) {
        $('body').append('<div id="div' + i + '">Text of div' + i + '</div>');
    }

    $('div:last-of-type').prepend('<p>I don\'t belong here!</p>');

})


