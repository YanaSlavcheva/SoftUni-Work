function calcSupply(startAge, endAge, kg) {
    var years = endAge - startAge;
    var amount = years*365*kg;
    console.log(amount + 'kg of water melon would be enough until I am ' + endAge + ' years old.');
}

calcSupply(29, 129, 2);
