function solve(input) {
    var numbers = input[0].split(/[ ()]+/);
    numbers = numbers.filter(Boolean).map(Number);

    var maxCounter = 1;
    var counter = 1;
    for (var i = 0 ; i < numbers.length - 1; i++) {

        if (i > 0 && numbers[i] == 0) {
            numbers[i] = numbers[i - 1] + 1;
        }



        var isOddCurrent = numbers[i] % 2 !== 0;
        var isOddNext = numbers[i + 1] % 2 !== 0;
        if(!isOddCurrent && numbers[i+1]===0) {
            isOddNext = !isOddCurrent;

        }
        if (isOddCurrent !== isOddNext || numbers[i] ===0) {
            counter++;
            if (maxCounter < counter) {
                maxCounter = counter;
            }
        } else {

            counter = 1;

        }


    }
    console.log(maxCounter);
}

solve(['(1) 0 0 0 0 2']);

