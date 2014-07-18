function bitChecker(value) {
    var mask = 1 << 3;
    var check = mask & value;
//    console.log(check);
    if(check == 8) {
      console.log('true');
    }
    else {
        console.log('false');
    }
}

bitChecker(333);
bitChecker(425);
bitChecker(2567564754);

