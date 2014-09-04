function solve (input){
    var bill = Number(input[0]);
    var mood = input[1];

    var tip = calcTip(bill, mood);
    var tipRounded = tip.toFixed(2);

    console.log(tipRounded);

    function calcTip (bill, mood){
        var tip;
        var tempTip;
        var firstDigit;
        if(mood === 'happy') {
            tip = bill * 0.1;
        } else if (mood === 'married') {
            tip = bill * 0.0005;
        } else if (mood === 'drunk') {
            tempTip = bill * 0.15;
            firstDigit = getFirstDigit(tempTip);
            tip = Math.pow(tempTip, firstDigit);
        } else {
            tip = bill * 0.05;
        }

        function getFirstDigit(num){
            var str = Math.round( num ).toString();
            return Number( str.substring( 0, 1 ) );
        }
        return tip;
    }
}

solve(['120.44','happy']);
solve(['716.00','married']);
