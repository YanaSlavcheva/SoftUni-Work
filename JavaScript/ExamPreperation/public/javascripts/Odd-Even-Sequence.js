function solve(input) {
    var numbers = input[0].split(/[ ()]+/);
    numbers = numbers.filter(Boolean).map(Number);

    var maxCounter = 1;
    var counter = 1;
    for (var i = 0; i < numbers.length - 1; i++) {

        //when we have zero (but not on the first position)
        if (i > 0 && numbers[i] == 0) {
            numbers[i] = numbers[i - 1] + 1;
        }

        //we check if our two numbers are odd or even
        var isOddCurrent = numbers[i] % 2 !== 0;
        var isOddNext = numbers[i + 1] % 2 !== 0;

        //if we have eben number and zero after it
        if (!isOddCurrent && numbers[i + 1] === 0) {
            isOddNext = !isOddCurrent;

        }

        //main case - we have odd and even numbers or the first number is 0
        if (isOddCurrent !== isOddNext || numbers[i] === 0) {
            counter++;

            //each time we change our current counter
            //we update the maxCounter if it has smaller value
            if (maxCounter < counter) {
                maxCounter = counter;
            }

        //if we don't have odd and even number
        //we end the current sequence and we restart the counter
        } else {
            counter = 1;
        }
    }
    console.log(maxCounter);
}

//the code below must not be copied to the judge system!
solve(['(1) 0 0 0 0 2']);

