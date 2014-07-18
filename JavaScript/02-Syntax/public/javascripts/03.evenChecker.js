function evenNumber(value) {
    var checker = true;
    if(value % 2 !== 0) {
      checker = false;
    }
    console.log(checker);
}

evenNumber(3);
evenNumber(127);
evenNumber(588);
