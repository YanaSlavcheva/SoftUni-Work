$(document).ready(function(){
    var index = 0;
    var numberOfSlides = $('.pic').length;

    //hide all but the first slide
    for (var i = 1; i < numberOfSlides; i++) {
        $('#' + i).fadeToggle(1000);
    }



    $('#btnNext').click(function () {
        $('#' + index).fadeToggle(1000);
        index = index + 1;
        if(index >= numberOfSlides) {
            index = 0;
        }
        $('#' + index).fadeToggle(1000);
    })

    $('#btnPrev').click(function () {
        $('#' + index).fadeToggle(1000);
        index = index - 1;
        if(index < 0) {
            index = numberOfSlides - 1;
        }
        $('#' + index).fadeToggle(1000);
    })


    setTimeout(function loop() {   //calls click event after a certain time

            $('#' + index).fadeToggle(1000);
            index = index + 1;
            if(index >= numberOfSlides) {
                index = 0;
            }
            $('#' + index).fadeToggle(1000);

            setTimeout(loop, 5000);

    }, 5000);



})
