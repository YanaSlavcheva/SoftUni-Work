// Class Plane
function Plane(){
    this.gameLoop=false;
    this.id=[];
    this.side=[];
    this.left=[];
    //this.top=[];
    //this.position=[];
    this.speed=4;
    this.planesFrequency=3; //from 0 - to 100
}

// Class Metods
Plane.prototype.add=function add(){
    var singlePlane=document.createElement('img');
    var container=document.getElementById('container');
    this.id.push('plane' + this.id.length);
    singlePlane.id='plane' + (this.id.length-1);
    this.side[singlePlane.id]=randSide(randGenerator(10));
    singlePlane.name='plane';
    singlePlane.src='images/' + choseImg(this.side[singlePlane.id]);
    singlePlane.className='plane';
    singlePlane.style.width=randPlaneSize() + 'px';
    this.left[singlePlane.id]=planeStartCoords(this.side[singlePlane.id], singlePlane);
    this.top[singlePlane.id]=randGenerator(150);
    singlePlane.style.top=this.top[singlePlane.id] + 'px';
    singlePlane.style.left=this.left[singlePlane.id] + 'px';
    singlePlane.style.position='absolute';
    container.appendChild(singlePlane);
};

Plane.prototype.move=function move(){

    var plane=document.getElementsByName('plane'),
        container=document.getElementById('container');

    if(plane.length<=0){
        this.id=[];
        this.side=[];
        this.left=[];
        this.top=[];
        this.position=[];
        this.planeSoundStop();
        return;
    }

    for(var i=0; i<this.id.length; i++){
        var id=this.id[i];
        var side=this.side[id];
        var left=this.left[id];
        //var top=this.top[id];
        //var position=this.position[id];

        var singlePlane=document.getElementById(id);

        //move the planes
        if(singlePlane!=null) {
            if (side == 'left') {
                left += this.speed;
            }
            if (side == 'right') {
                left -= this.speed;
            }

            this.left[id] = left;

            singlePlane.style.left = left + 'px';
            this.planeSoundStart();

            //remove the planes
            if(left > parseInt(screen.width) + 5 ||
                parseInt(singlePlane.style.left) < (parseInt(singlePlane.style.width) * -1) - 5) {
                container.removeChild(singlePlane);
            }
        }
    }
};

Plane.prototype.collision=function collision(){

    var pellets=document.getElementsByName('pellet');
    var planes=document.getElementsByName('plane');
    if(pellets.length <= 0)  return;
    if(planes.length <= 0)  return;
    for(var pellet in pellets){
        for(var plane in planes){
            if(planes.hasOwnProperty(plane) && pellets.hasOwnProperty(pellet)) {
                if (planes[plane] != null && pellets[pellet] != null) {
                    var planesLeft=parseInt(planes[plane].style.left);
                    var planesTop=parseInt(planes[plane].style.top);
                    var planesWidth=parseInt(planes[plane].style.width);
                    var pelletsLeft=parseInt(pellets[pellet].style.left);
                    var pelletsTop=parseInt(pellets[pellet].style.top);
                    if((pelletsTop<=planesTop && pelletsTop >= (planesTop - 30)) &&
                        (pelletsLeft >= planesLeft && pelletsLeft <= (planesLeft + planesWidth))){
                        planes[plane].parentNode.removeChild(planes[plane]);
                        pellets[pellet].parentNode.removeChild(pellets[pellet]);
                        this.planeExplodeSoundStart();
                        this.createImgBurningPlane(planesTop, planesLeft, planesWidth);
                        score.upScore(5);
                    }
                }
            }
        }
    }
};

// Sounds
Plane.prototype.planeSoundStart=function planeSoundStart(){
    document.getElementById('planeFly').play();
};

Plane.prototype.planeSoundStop=function planeSoundStop(){
    document.getElementById('planeFly').pause();
};

Plane.prototype.planeExplodeSoundStart=function planeExplodeSoundStart(){
    document.getElementById('planeExplode').currentTime=0;
    document.getElementById('planeExplode').play();
};

// Exploading planes
Plane.prototype.createImgBurningPlane=function createImgBurningPlane(planeTop, planeLeft, planeWidth){
    var img = document.createElement('img');
    img.src = 'images/explosion.png';
    img.style.position = 'absolute';
    img.style.width = planeWidth + 'px';
    img.style.left = planeLeft + 'px';
    img.style.top = planeTop + 'px';
    document.getElementById('container').appendChild(img);
    img.className = 'fadeAnimation';

    setTimeout(function(){
        img.parentNode.removeChild(img);
    }, 1500);
};

Plane.prototype.paratrooperGenerator = function paratrooperGenerator(trooper){

    var container = document.getElementById('container');
    var planes = document.getElementsByName('plane');

    if(planes.length <= 0) return;

    var randomIndex = parseInt(Math.random() * planes.length),
        top =  parseInt(planes[randomIndex].style.top),
        left = parseInt(planes[randomIndex].style.left);

    if(left < 0.1 * container.clientWidth  || left > container.clientWidth * 0.9) return;

    trooper.add(left, top);
};


// Some Functions
function randGenerator(frequency){
    return Math.floor(Math.random() * frequency);
}

function randSide(generateNum){
    switch(generateNum%2){
        case 0:
            return 'left';
            break;
        case 1:
            return 'right';
            break;
    }
}

function planeStartCoords(side, element){
    switch(side){
        case 'left':
            return parseInt(element.style.width) * -1;
            break;
        case 'right':
            return parseInt(screen.width);
            break;
    }
}

function choseImg(side){
    switch(side){
        case 'left':
            return 'leftPlane.png';
            return;
        case 'right':
            return 'rightPlane.png';
            return;
    }
}

function randPlaneSize(){
    var widthContainer = parseInt(window.innerWidth);
    var rand = Math.floor(Math.random() * widthContainer * 0.2);
    if(rand < widthContainer*0.1){
        return widthContainer*0.1;
    }
    return rand;
}

// setIntervals
function planeFly(){
    setInterval(function() {
        if(plane.gameLoop==true) {
            if (randGenerator(100) < plane.planesFrequency) {
                plane.add();
            }
            plane.move();
        }
    }, 15);
    setInterval(function() {
            plane.collision();
    }, 9);

}

function getParatrooper(){
    setInterval(function() {
        plane.paratrooperGenerator(trooper)
    }, 1000);
}

// Do it
window.onload=function adder(){

};

var plane=new Plane();

//document.getElementById('start').addEventListener('click',function(){plane.gameLoop=true},false);
