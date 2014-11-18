function Score(){
    this.stats=0;
    this.statsHolder=document.getElementById('scoreHolder');
}

Score.prototype.upScore=function upScore(num){
    this.stats+=num;
    this.statsHolder.innerHTML=this.stats + '';
};

var score=new Score();
