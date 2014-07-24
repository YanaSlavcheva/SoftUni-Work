function solve(input) {
    var words = input[0].split(' ');

    //we get the length of the longest word
    var maxLength = 0;
    for (var i = 0; i < words.length; i++) {
        if (words[i].length > maxLength) {
            maxLength = words[i].length;
        }
    }

    //we convert word from string to array of single strings(chars)
    for (var i = 0; i < words.length; i++) {
        words[i] = words[i].split('');
    }

    //now we fill letters with the reordered single strings(chars)
    var letters = '';
    for (var lett = 0; lett < maxLength; lett++) {
        for (var index = 0; index < words.length; index++) {

            //pop removes the last member of array and gives it back as value also
            if (words[index].length > 0) {
                letters += words[index].pop();
            }
        }
    }

    //we convert letters from string to array of single strings(chars)
    letters = letters.split('');

    //now we rearrange the letters
    for (var i = 0; i < letters.length; i++) {
        var numMoves;
        numMoves = letters[i].toLowerCase().charCodeAt(0) - 96;
        var newPosition;
        newPosition = (numMoves + i) % letters.length;

        //we get our current character
        var currChar = letters[i];

        //first we remove our single string from the array
        letters.splice(i, 1);

        //then we add it to the new position
        letters.splice(newPosition, 0, currChar);
    }
    console.log(letters.join(''));
}

//the code below must not be copied to the judge system!
solve(['Fun exam right']);