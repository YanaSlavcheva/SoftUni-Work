function solve(input) {
    //input
    var text = input[0];
    var words = text.split(/[^A-Za-z]+/);

    //we get rid of the ghosts in the array
    words = words.filter(Boolean);

    //main logic
    var output = [];
    for (var a = 0; a < words.length; a++) {
        for (var b = 0; b < words.length; b++) {
            for (var c = 0; c < words.length; c++) {
                if (a !== b) {
                    var check = words[a] + words[b] === words[c];

                    if (check) {
                        var cognateWord = words[a] + '|' + words[b] + '=' + words[c];
                        if (output.indexOf(cognateWord) < 0) {
                            output.push(cognateWord);
                        }
                    }
                }
            }
        }
    }

    //output
    if (output.length < 1) {
        console.log('No');
    } else {
        console.log(output.join('\n'));
    }
}

//the code below must not be copied to the judge system!
solve(['Uni(lo,.ve=I love SoftUni (Soft)']);
