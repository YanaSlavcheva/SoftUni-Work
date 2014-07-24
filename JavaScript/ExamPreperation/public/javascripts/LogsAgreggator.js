function pesho (input) {
    var n = input[0];
    var assArr = {};
    for (var i = 0; i < n; i++) {
        var tempRow = input[i+1].split(' ');
        var ip = tempRow[0];
        var user = tempRow[1];
        var minute = parseInt(tempRow[2]);

        if(!(user in assArr)) {
          assArr[user]= {};
          assArr[user][ip] = minute;
        } else if((user in assArr) && !(ip in assArr[user])){
            assArr[user][ip] = minute;
        } else {
            assArr[user][ip] += minute;
        }
    }
    console.log(assArr);

    //output
    var userkeys = [];
    for (var keyUser in assArr) {
        if(assArr.hasOwnProperty(keyUser)) {
          userkeys.push(keyUser);
        }
    }
    userkeys.sort();

    var output = '';
    for (var i = 0; i < userkeys.length; i++) {
        var userIPKeys = []; // this must be in the loop
        var sumMinutes = 0;
        for (var innerkey in assArr[userkeys[i]]) {
            if(assArr[userkeys[i]].hasOwnProperty(innerkey)) {
                userIPKeys.push(innerkey);
                sumMinutes += assArr[userkeys[i]][innerkey];
            }
        }
        output += userkeys[i] + ': ' + sumMinutes + ' [' + userIPKeys.sort().join(', ') + ']\n';

    }
    console.log(output);


}

pesho(['7',
    '192.168.0.11 peter 33',
    '10.10.17.33 alex 12',
    '10.10.17.35 peter 30',
    '10.10.17.34 peter 120',
    '10.10.17.34 peter 120',
    '212.50.118.81 alex 46',
    '212.50.118.81 alex 4'
])
