function solve (input){
    //input
    var input = input;
    var allLines = [];
    for (var i = 0; i < input.length; i++) {
        allLines[i] = input[i].split(/[ ]+/);
        allLines[i] = allLines[i].filter(Boolean);
    }
//    console.log(allLines);

    //main logic
    var assArr = {};

    for (var i = 0; i < allLines.length; i++) {
        var fileName = allLines[i][0];
        var extension = allLines[i][1];
        var MB = parseFloat(allLines[i][2]);

        if(!(extension in assArr)) {
            assArr[extension]= {};
            assArr[extension]['files'] = [];
            assArr[extension]['files'].push(fileName);
            assArr[extension]['memory'] = MB;
        } else if(extension in assArr){
            assArr[extension]['files'].push(fileName);
            assArr[extension]['memory'] += MB;
        }
    }
//    console.log(assArr);
//    console.log(JSON.stringify(assArr));

    //output - we need to sort when printing and toFixed!
    //first we get the keys from assArr and sort them
    var extensionKeys = [];
    for (var keyExtension in assArr) {
        if(assArr.hasOwnProperty(keyExtension)) {
            extensionKeys.push(keyExtension);
        }
    }
    extensionKeys.sort();
//    console.log(extensionKeys);

    //second we need to sort the FILES array

    for (var i = 0; i < extensionKeys.length; i++) {
        assArr[extensionKeys[i]]['files'].sort();
    }

    for (var i = 0; i < extensionKeys.length; i++) {
        assArr[extensionKeys[i]]['memory'] = assArr[extensionKeys[i]]['memory'].toFixed(2);

    }
//    console.log(JSON.stringify(assArr));

    //and the output... I need to make new assArr and fill it by the order of the keys
    var assArrSorted = {};
    for (var i = 0; i < extensionKeys.length; i++) {
        assArrSorted[extensionKeys[i]]= {};
        assArrSorted[extensionKeys[i]] = assArr[extensionKeys[i]];
        assArrSorted[extensionKeys[i]]['files'] = assArr[extensionKeys[i]]['files'];
        assArrSorted[extensionKeys[i]]['memory'] = assArr[extensionKeys[i]]['memory'];

    }
    console.log(JSON.stringify(assArrSorted));



}

solve(['        sentinel          .exe            15MB           ',
    'zoomIt .msi 3MB',
    'skype .exe 45MB',
    'trojanStopper .bat 23MB',
    'kindleInstaller .exe 120MB',
    'setup .msi 33.4MB',
    'winBlock .bat 1MB']);

