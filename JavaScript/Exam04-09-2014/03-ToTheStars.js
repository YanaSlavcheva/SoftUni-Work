function solve (input) {
    //input
    var star01 = input[0].split(/[ ]+/);
    star01 = star01.filter(Boolean);
//    console.log(star01);
    var star01Name = star01[0].toLowerCase();
    var star01X = Number(star01[1]);
    var star01Y = Number(star01[2]);

    var star02 = input[1].split(/[ ]+/);
    star02 = star02.filter(Boolean);
//    console.log(star02);
    var star02Name = star02[0].toLowerCase();
    var star02X = Number(star02[1]);
    var star02Y = Number(star02[2]);

    var star03 = input[2].split(/[ ]+/);
    star03 = star03.filter(Boolean);
//    console.log(star03);
    var star03Name = star03[0].toLowerCase();
    var star03X = Number(star03[1]);
    var star03Y = Number(star03[2]);

    var initCoords = input[3].split(/[ ]+/);
    initCoords = initCoords.filter(Boolean);
    var normX = Number(initCoords[0]);
    var normY = Number(initCoords[1]);

    var numMoves = Number(input[4]);
//    console.log(numMoves);

    //main logic
    var positionName = checkIfInSpace(normX, normY);
    console.log(positionName);
    for (var moves = 0; moves < numMoves; moves++) {
        normY ++;
        positionName = checkIfInSpace(normX, normY);
        console.log(positionName);
    }




    function checkIfInSpace(normX, normY){
        var position = 'space';

        var relPosStar01 = checkIfInStar(normX, normY, star01X, star01Y, star01Name);
        var relPosStar02 = checkIfInStar(normX, normY, star02X, star02Y, star02Name);
        var relPosStar03 = checkIfInStar(normX, normY, star03X, star03Y, star03Name);

        if(relPosStar01 !== 'space') {
            position = relPosStar01;
        } else if (relPosStar02 !== 'space'){
            position = relPosStar02;
        } else if (relPosStar03 !== 'space'){
            position = relPosStar03;
        }

        return position;

        function checkIfInStar(normX, normY, starX, starY, starName){
            var position;
            var checkX = (normX >= starX - 1) && (normX <= starX + 1);
            var checkY = (normY >= starY - 1) && (normY <= starY + 1);

            if(checkX && checkY) {
                position = starName;
            } else {
                position = 'space';
            }
            return position;
        }
    }
}

solve(['Sirius 3 7              ',
        'Alpha-Centauri            7              5',
        '              Gamma-Cygni 10 10',
    '8 1',
    '6']);

solve(['Terra-Nova 16 2',
    'Perseus 2.6 4.8',
    'Virgo 1.6 7',
    '2 5',
    '4']);