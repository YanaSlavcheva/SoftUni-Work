function normalSliding(index, numberOfSlides) {
    $('#' + index).animate({'margin-left': '-400px'}, 500);
    setTimeout(function () {
        //hide old pic
        if (index == 0) {
            $('#' + (numberOfSlides - 1)).toggle();
        } else {
            $('#' + (index - 1)).toggle();
        }
    }, 500);

    index = index + 1;
    if (index >= numberOfSlides) {
        index = 0;
    }

    $('#' + index).css('margin-left', '400px');
    //show new pic
    $('#' + index).toggle();
    $('#' + index).animate({'margin-left': '0'}, 500);
    return index;
}

$(document).ready(function(){
    var index = 0;
    var numberOfSlides = $('.pic').length;

    //hide all but the first slide
    for (var i = 1; i < numberOfSlides; i++) {
        $('#' + i).toggle();
    }

    //make the sliding
    $('#btnNext').click(function () {
        index = normalSliding(index, numberOfSlides);
    })

    $('#btnPrev').click(function () {
        $('#' + index).animate({'margin-left':'400px'},500);
        setTimeout(function(){
            //hide old pic
            if(index == 0) {
                $('#' + (numberOfSlides - 1)).toggle();
            } else {
                $('#' + (index - 1)).toggle();
            }
        }, 500);

        index = index + 1;
        if(index >= numberOfSlides) {
            index = 0;
        }

        $('#' + index).css('margin-left', '-400px');
        //show new pic
        $('#' + index).toggle();
        $('#' + index).animate({'margin-left':'0'},500);
    })

    //makes pics sliding with no buttons involved
    //button actions and this function do not interact properly
    //they work perfectly fine each at a time though :)
    // TODO: The timer need to be reseted every time a button is clicked

    setTimeout(function loop() {
        index = normalSliding(index, numberOfSlides);
        setTimeout(loop, 5000);
    }, 5000);
})
