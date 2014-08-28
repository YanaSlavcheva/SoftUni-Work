<?php
$parts = explode(", ", $_GET["list"]);

//we make array with keys the names of the parts
$counter["CPU"]= 0;
$counter["ROM"]= 0;
$counter["RAM"]= 0;
$counter["VIA"]= 0;

$prices["CPU"] = 85;
$prices["ROM"] = 45;
$prices["RAM"] = 35;
$prices["VIA"] = 45;

$expenses = 0;

for ($i = 0; $i < count($parts); $i++) {
    foreach ($counter as $part => $count) {
        if ($parts[$i] == $part) {
            $counter[$part]++;
            break;
        }
	}
}

$fullPravets = min($counter);
foreach ($counter as $part => $count) {
        //calculate all expenseses
        if ($count >= 5) {
            $expenses += 0.5 * ($count * $prices[$part]);
        } else {
            $expenses +=($count * $prices[$part]);
        }

        //calculate parts left
        $currReminderOfPart = $count - $fullPravets;
        $partsProfit += 0.5 * $currReminderOfPart * $prices[$part] ;
        $partsLeft += $currReminderOfPart;

}

$balance = ($partsProfit + ($fullPravets * 420)) - $expenses;

//output
echo "<ul><li>".$fullPravets." computers assembled</li><li>".$partsLeft." parts left</li></ul>";
if ($balance > 0 ) {
	echo "<p>Nakov gained ".$balance." leva</p>";
} else {
	echo "<p>Nakov lost ".$balance." leva</p>";
}


