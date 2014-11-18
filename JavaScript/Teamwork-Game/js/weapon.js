// ------------------------------------------- GUN --------------------------------------------------
function Gun(id) {
    this.domElement = document.getElementById(id);
    this.angle = 0;
    this.direction = '';
    this.leftInterval = 0;
    this.rightInterval = 0;
    this.len = this.domElement.clientHeight;
// coordinates of gun's bottom
    this.x = this.domElement.offsetLeft + this.domElement.offsetWidth / 2;
    this.y = this.domElement.offsetTop + this.domElement.offsetHeight;
    this.noPellets = true;
}


Gun.prototype.rotate = function rotate() {

    this.changeAngle();

    //applying CSS3 rotation
    this.domElement.style.transform = 'rotate(' + this.angle + 'deg)';
    this.domElement.style.mozTransform = 'rotate(' + this.angle + 'deg)';
    this.domElement.style.webkitTransform = 'rotate(' + this.angle + 'deg)';
    this.domElement.style.OTransform = 'rotate(' + this.angle + 'deg)';
    this.domElement.style.msTransform = 'rotate(' + this.angle + 'deg)';
};

Gun.prototype.changeAngle = function changeAngle() {

    if (this.direction === 'left') {
        if (this.angle > -70) {
            this.angle -= 1;
        }
    }

    if (this.direction === 'right') {
        if (this.angle < 70) {
            this.angle += 1;
        }
    }
};


Gun.prototype.setDirection = function setDirection(direction) {
    this.direction = direction;
};

Gun.prototype.showFire = function showFire() {
    if (this.noPellets === true) {
        this.domElement.getElementsByTagName('img')[0].style.visibility = 'visible';
    }
};

Gun.prototype.hideFire = function hideFire() {
    this.domElement.getElementsByTagName('img')[0].style.visibility = 'hidden';
};

Gun.prototype.shotSound = function shotSound() {
    document.getElementById('shot').currentTime = 0;
    document.getElementById('shot').play();
};


// --------------------------------------------------- PELLET -----------------------------------------------

function Pellets() {
    this.id = [];
    this.angles = {};
    this.left = {};
    this.top = {};
    this.count = 20;
    this.speed = 3;
    this.paratroopers = {};
// this.dFragment = document.createDocumentFragment();
}

Pellets.prototype.setParatroopers = function setParatroopers(paratroopers) {
    this.paratroopers = paratroopers;
};


Pellets.prototype.y = function y(gun, x, angle) {
    var a,
        y;

    if (angle > 0) {
        a = Math.tan((90 - angle) * (Math.PI / 180));
        y = gun.y - a * (x - gun.x);
    } else if (angle < 0) {
        a = Math.tan((90 - Math.abs(angle)) * (Math.PI / 180));
        y = gun.y - a * (gun.x - x);
    } else {
        y = gun.y - gun.len;
    }

    return y;
};

Pellets.prototype.add = function add(gun) {

    if (this.count < 0) {
        gun.noPellets = false;
        return;
    }

    gun.shotSound();
    gun.noPellets = true;

    var pellet = document.createElement("IMG");

    pellet.src = 'images/pellet.png';
    this.id.push('pellet' + this.id.length);
    pellet.id = 'pellet' + (this.id.length - 1);
    pellet.className = 'pellet';
    pellet.name = 'pellet';
    //applying CSS3 rotation
    pellet.style.transform = 'rotate(' + gun.angle + 'deg)';
    pellet.style.mozTransform = 'rotate(' + gun.angle + 'deg)';
    pellet.style.webkitTransform = 'rotate(' + gun.angle + 'deg)';
    pellet.style.OTransform = 'rotate(' + gun.angle + 'deg)';
    pellet.style.msTransform = 'rotate(' + gun.angle + 'deg)';

    var angleRad = gun.angle * (Math.PI / 180),
        left = (Math.round(gun.x + Math.sin(angleRad) * gun.len)),
        top = Math.round(this.y(gun, Math.round(gun.x + Math.sin(angleRad) * gun.len), gun.angle));


    pellet.style.left = left + 'px';
    pellet.style.top = top + 'px';

    this.left[pellet.id] = left;
    this.top[pellet.id] = top;
    this.angles[pellet.id] = gun.angle;


    document.getElementById('container').appendChild(pellet);

    this.count--;
};

Pellets.prototype.move = function move() {

    var container = document.getElementById('container'),
        pellets = document.getElementsByName('pellet'),
        i;

    if (pellets.length <= 0) {
        this.id = [];
        this.angles = {};
        this.left = {};
        this.top = {};
        return;
    }

    for (i = 0; i < this.id.length; i += 1) {

        var id = this.id[i],
            left = this.left[id],
            top = this.top[id],
            angle = this.angles[id];

        var pellet = document.getElementById(id);

        if (pellet != null) {
            if (angle > 0) {
                left += this.speed;
            } else if (angle < 0) {
                left -= this.speed;
            }

            if (angle === 0) {
                top -= this.speed / 1;
            } else {
                top = Math.round(this.y(gun, left, angle));
            }


            this.left[id] = left;
            this.top[id] = top;
            pellet.style.left = left + 'px';
            pellet.style.top = top + 'px';


            if (!(left < container.clientWidth && top > 0 && left > 0)) {
                container.removeChild(pellet);
            }
        }
    }

};


Pellets.prototype.searchTarget = function searchTarget(troopers) {
    var indexPellet,
        indexTrooper,
        idPellets = [],
        idTroopers = [];

    var pellets = document.getElementsByName('pellet');

    for (indexPellet = 0; indexPellet < pellets.length; indexPellet += 1) {

        var pellet = pellets[indexPellet];

        if (pellet == null) break;

        var leftPellet = parseInt(pellet.style.left),
            topPellet = parseInt(pellet.style.top);

        var troopers = document.getElementsByName('paratrooper');

        for (indexTrooper = 0; indexTrooper < troopers.length; indexTrooper += 1) {

            var trooper = troopers[indexTrooper];

            if (trooper == null) break;

            var leftTrooper = parseInt(trooper.style.left) ,
                topTrooper = parseInt(trooper.style.top) ,
                heightTrooper = pellet.clientHeight * 18 ,
                widthTrooper = pellet.clientWidth * 18;

            if (leftPellet >= leftTrooper && leftPellet <= leftTrooper + widthTrooper &&
                topPellet >= topTrooper && topPellet <= topTrooper + heightTrooper &&
                this.paratroopers.state[trooper.id].indexOf('landed') === -1) {

                pellet.className += ' border';
                trooper.className += ' border';
                document.getElementById('container').removeChild(pellet);
                document.getElementById('container').removeChild(trooper);
                score.upScore(1);
                break;
            }

        }
    }

    var i;
};

// SetInterval Functions ---------------------------------------------------------
function upPelletCount(pellets) {
    pellets.setIntervalMove = setInterval(function () {
        if (pellets.count < 20) pellets.count++;
        document.getElementById('shots').innerHTML = pellets.count;
    }, 700);
}


function setLeftIntervalMovePellets(pellets) {
    pellets.setIntervalMove = setInterval(function () {
        pellets.move();
        pellets.searchTarget();
    }, 1);
}

function setLeftIntervalRotate(gun) {
    if (gun.rightInterval) clearInterval(gun.rightInterval);
    gun.leftInterval = setInterval(function () {
        gun.rotate();
    }, 5);
    gun.rightInterval = 0;
}

function setRightIntervalRotate(gun) {
    if (gun.leftInterval) clearInterval(gun.leftInterval);
    gun.rightInterval = setInterval(function () {
        gun.rotate();
    }, 5);
    gun.leftInterval = 0;
}

// Event Gun Functions ---------------------------------------------------------------------


document.body.onresize = function resize(e) {

    gun = new Gun('weapon');
    document.getElementById('gameScreen').style.height = window.innerHeight * 0.8 + 'px';
    document.getElementById('button').style.fontSize = window.innerWidth * 0.05 + 'px';
    document.getElementById('title').style.fontSize = window.innerWidth * 0.2 + 'px';

    if (window.innerWidth * 0.03 > 12) {
        document.getElementById('infoRow').style.fontSize = window.innerWidth * 0.03 + 'px';
    } else {
        document.getElementById('infoRow').style.fontSize = 15 + 'px';
    }
};

document.getElementById('gameScreen').style.height = window.innerHeight * 0.8 + 'px';
document.getElementById('button').style.fontSize = window.innerWidth * 0.05 + 'px';

if (window.innerWidth * 0.03 > 12) {
    document.getElementById('infoRow').style.fontSize = window.innerWidth * 0.03 + 'px';
} else {
    document.getElementById('infoRow').style.fontSize = 15 + 'px';
}

// Execute code
var gun = new Gun('weapon'),
    pellets = new Pellets();

