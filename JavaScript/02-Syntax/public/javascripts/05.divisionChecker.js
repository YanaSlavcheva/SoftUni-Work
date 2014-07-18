function divisionBy3(num) {
    var str = num.toString();
//    console.log(str);
//    console.log(typeof str);
    var sumDigits = 0;
    for (var i = 0; i < str.length; i++) {
        var digit = parseInt(str.charAt(i));
        sumDigits = digit + sumDigits;
//        console.log(str.charAt(i));
//        console.log(str[i]);
    }
//    console.log(sumDigits);
    if(sumDigits % 3 == 0) {
        console.log('the number is divided by 3 without remainder');
    }
    else {
        console.log('the number is NOT divided by 3 without remainder');
    }
}

divisionBy3(12);
divisionBy3(188);
divisionBy3(591);