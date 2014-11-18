function titleAnimation() {

    function changeFontSize (delay) {

        setTimeout(function () {
            currentSize += 3;
            title.style.fontSize = currentSize + 'px';
            if (currentSize <= maxSize) {

                changeFontSize(delay);
            } else {

                setTimeout(showMenu, 200);
               title.className = 'shake';
            }
        }, delay);
    }

    function showMenu(){
        document.getElementById('startMenu').style.display = 'inline-block';
    }

//  Game Title --------------------------------------------------------------
    document.getElementById('gameTitle').style.display ='block';

    var maxSize =  window.innerWidth * 0.2,
        title = document.getElementById('title');

    document.getElementById('button').style.display = 'none';
    title.style.display = 'inline-block';

    var currentSize = 10;

    changeFontSize(10);

// Menu ------------------------------------------------------------------------
    var menu = document.getElementById('startMenu');

    menu.style.fontSize = window.innerWidth * 0.03 + 'px';
}


document.getElementById('button').addEventListener('click',titleAnimation,false);
