function convertKWtoHP(value){
    var convertedValue = value/0.745699872;
//    var rounded = convertedValue.toFixed(2);
    var rounded = Math.round(convertedValue*100)/100; //both ways work, but the second one is more fun :)
    console.log(rounded);
}

convertKWtoHP(75);
convertKWtoHP(150);
convertKWtoHP(1000);
