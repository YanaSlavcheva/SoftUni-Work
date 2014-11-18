function Soldiers() {
    this.id = [];
    this.left = [];
    this.top = [];
    this.numSetInterval = [];
    this.state = [];
    this.landedHeight = [];
    this.width = [];
    this.gameLoop = true;
}

Soldiers.prototype.add = function add(left, top) {
    var containerHalfWidth = document.getElementById('gameScreen').clientWidth / 2,
        imageName;

    imageName = 'images/landedParatroop.png';

    this.id.push('parachutist' + this.id.length);
    this.top.push(top);
    this.left.push(left);
    this.width.push(containerHalfWidth * 0.35);
    this.domElement = document.createElement('img');
    this.domElement.setAttribute('id', this.id[this.id.length - 1]);
    this.domElement.setAttribute('class', 'paratrooper');
    this.domElement.name = 'paratrooper';
    this.domElement.setAttribute('src', imageName);
    this.domElement.style.top = this.top[this.id.length - 1] + 'px';
    this.domElement.style.width = this.width[0] + 'px';
    this.domElement.style.left = left + 'px';
    document.getElementById('container').appendChild(this.domElement);
};

Soldiers.prototype.falling = function falling() {

    if (this.gameLoop === false) return;

    var containerHeight = document.getElementById('container').clientHeight * 0.98,
        containerHalfWidth = document.getElementById('container').clientWidth / 2 ,
        baseHalfWidth = document.getElementById('base').clientWidth / 2,
        baseHeight = document.getElementById('base').clientHeight ,
        imageNameFalling,
        imageNameLanded,
        i = 0;

    var paratroopers = document.getElementsByName('paratrooper');


    for (i = 0; i < paratroopers.length; i += 1) {

        imageNameFalling = 'images/paratroop.png';
        imageNameLanded = 'images/landedParatroop.png';

        var soldier = paratroopers[i],
            startLeftPositionOfBase = containerHalfWidth - 2 * baseHalfWidth ,
            endRightPositionOfBase = containerHalfWidth,
            left = parseInt(soldier.style.left),
            top = parseInt(soldier.style.top),
            id = soldier.id,
            landedHeight,
            landedState;


        if (startLeftPositionOfBase <= left && left <= endRightPositionOfBase) {

            landedHeight = containerHeight - soldier.clientHeight - baseHeight;
            landedState = 'landed of weapon';
        } else if (startLeftPositionOfBase > left) {
            landedHeight = containerHeight - soldier.clientHeight;
            landedState = 'landed left';
        } else if (left > endRightPositionOfBase) {
            landedHeight = containerHeight - soldier.clientHeight;
            landedState = 'landed right';
        }

        if (this.state[id] === undefined || this.state[id].substring(0, 6) !== 'landed') {
            if (top < containerHeight * 0.3) {
                soldier.style.top = (top + 5) + 'px';
                top += 5;
                if (!this.state[id]) this.state[id] = 'fall';
            } else if (top >= containerHeight * 0.3 && top < landedHeight) {
                if (this.state[id] === 'fall') {
                    this.state[id] = 'fall with parachute';
                    soldier.setAttribute('src', imageNameFalling);
                    this.domElement.setAttribute('class', 'paratrooper shakeParatrooper');
                }
                soldier.style.top = (top + 1) + 'px';
                top += 1;
            } else {

                if (this.state[id] === 'fall with parachute') {
                    this.state[id] = landedState;
                    this.landedHeight[id] = top;
                    soldier.setAttribute('src', imageNameLanded);
                }
            }
        } else {
            soldier.style.top = this.landedHeight[id] + 'px';
        }
    }

};

Soldiers.prototype.attackWeapon = function attackWeapon() {

    function move(paratrooper, dir) {
        if (dir == 'left') {
            paratrooper.style.left = (parseInt(paratrooper.style.left) + 1) + 'px';
        }

        if (dir == 'right') {
            paratrooper.style.left = (parseInt(paratrooper.style.left) - 1) + 'px';
        }

    }

    function removePlanes() {
        var allPlanes = document.getElementsByName('plane');
        for (var i = 0; i < allPlanes.length; i++) {
            allPlanes[i].parentNode.removeChild(allPlanes[i]);
        }
    }

    var id,
        paratroopersLeft = [],
        paratroopersRight = [],
        paratroopersCenter = [],
        countLeft = 0,
        countRight = 0;


    for (id in this.state) {
        var paratrooper = document.getElementById(id);

        if (this.state[id] === 'landed left') {

            paratroopersLeft.push(paratrooper);


        } else if (this.state[id] === 'landed right') {

            paratroopersRight.push(paratrooper);
        }

        if (this.state[id] === 'landed of weapon') {

            paratroopersCenter.push(paratrooper);

        }


        if (Object.keys(paratroopersLeft).length >= 3) {

            removePlanes();

            var base = document.getElementById('base'),
                baseWidth = base.clientWidth,
                baseLeft = base.offsetLeft - baseWidth / 2,
                i = 0;

            for (i in paratroopersLeft) {
                var left = parseInt(paratroopersLeft[i].style.left);

                if (left < baseLeft) {
                    move(paratroopersLeft[i], 'left');
                } else {
                    if (document.getElementById('gifL').style.display !== 'inline-block') {
                        document.getElementById('gifL').style.display = 'inline-block';
                        setTimeout(function(){
                            document.getElementById('gifL').src = 'images/finInvasionLeftLast.png';
                            document.getElementById('gifC').style.display = 'inline-block';
                            document.getElementById('nakovFinal').play();
                        }, 2000);
                    }
                }
            }


        }

        if (Object.keys(paratroopersRight).length >= 3) {

            removePlanes();

            var base = document.getElementById('base'),
                baseWidth = base.clientWidth,
                baseRight = base.offsetLeft + baseWidth * 0.7,
                i = 0;

            for (i in paratroopersRight) {
                var left = parseInt(paratroopersRight[i].style.left);

                if (left > baseRight) {
                    move(paratroopersRight[i], 'right');
                } else {
                    if (document.getElementById('gifR').style.display !== 'inline-block') {
                        document.getElementById('gifR').style.display = 'inline-block';
                        setTimeout(function(){
                            document.getElementById('gifR').src = 'images/finInvasionRightLast.png';
                            document.getElementById('gifC').style.display = 'inline-block';
                            document.getElementById('nakovFinal').play();
                        }, 2000);
                    }
                }
            }
        }

        if (Object.keys(paratroopersCenter).length >= 1) {

            removePlanes();
            var gif = document.getElementById('gifC');
            gif.style.display = 'block';

            document.getElementById('nakovFinal').play();
        }
    }

};


function setIntervalParatrooper(trooper) {
    var isGif = false;
    trooper.setIntervalMove = setInterval(function () {
        trooper.falling();
        trooper.attackWeapon();
    }, 100);
}

var trooper = new Soldiers();
pellets.setParatroopers(trooper);








