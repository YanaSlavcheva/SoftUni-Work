function solve (input) {

    //get input
    var message = input[0];
    var numbers = message.split(/[^0-9]+/);
    numbers = numbers.filter(Boolean).map(Number);
//    console.log(numbers);

    //convert to HEX
    for (var i = 0; i < numbers.length; i++) {
        numbers[i] = numbers[i].toString(16).toUpperCase();
    }
//    console.log(numbers);

    //add padding
    for (var i = 0; i < numbers.length; i++) {
        numbers[i] = padZeroes(numbers[i]);
    }
//    console.log(numbers);

    //output - concat with 0x and -
    for (var i = 0; i < numbers.length; i++) {
        numbers[i] = '0x' + numbers[i];
    }
//    console.log(numbers);

    console.log(numbers.join('-'));


    function padZeroes(num) {
        var size = 4;
        var s = "000" + num;
        return s.substr(s.length-size);
    }

}

solve(['5tffwj(//*7837xzc2---34rlxXP%$".']);
solve(['482vMWo(*&^%$213;k!@41341((()&^>><///]42344p;e312']);
solve(['20']);
