function checkDigit(n) {
    //we get rid of the first and second digit (right-to-left)
    var divBy100 = n/100;
    var rounded = Math.floor(divBy100);

    //we check if the first digit (right-to-left) - former third, is 3
    if(rounded % 10 == 3) {
      console.log('true');
    }
    else {
        console.log('false');
    }
}

checkDigit(1235);
checkDigit(25368);
checkDigit(123456);