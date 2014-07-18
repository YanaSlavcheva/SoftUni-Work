function isPrime(value){
    var checker = true;
    for (var i = 2; i < value; i++) {
        if(value % i == 0) {
          checker = false;
        }
    }
    console.log(checker);
}

isPrime(7);
isPrime(254);
isPrime(587);
