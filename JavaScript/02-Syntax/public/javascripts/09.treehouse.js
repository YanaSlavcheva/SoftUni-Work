function treeHouseCompare(a, b) {
    var houseArea = 4*a*a/3;
//    console.log(houseArea);
    var treeArea = b*b*(4*Math.PI+3)/9;
//    console.log(treeArea);
    if(treeArea > houseArea) {
      console.log('tree/' + treeArea.toFixed(2));
    }
    else{
        console.log('house/' + houseArea.toFixed(2));
    }
}

treeHouseCompare(3, 2);
treeHouseCompare(3, 3);
treeHouseCompare(4, 5);
