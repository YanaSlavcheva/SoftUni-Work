<?php
date_default_timezone_set('Europe/Sofia');
$today = $_GET['today'];
$invoices = $_GET['invoices'];

$datePieces = explode('/', $today);
$today = strtotime($datePieces[1].'/'.$datePieces[0].'/'.$datePieces[2]);
$deliveries = array();

foreach ($invoices as $invoice) {
    $tempInvoice = preg_split('/\s*\|\s*/', $invoice);
    $currDate = $tempInvoice[0];
    $tempDatePieces = explode('/', $currDate);
    $currDate = strtotime($tempDatePieces[1].'/'.$tempDatePieces[0].'/'.$tempDatePieces[2]);

    $currCompany = $tempInvoice[1];
    $currMedicine = $tempInvoice[2];
    $currPrice = (double)$tempInvoice[3];
    $currPrice .='';

    if ($currDate >= strtotime('-5 years', $today )){
        
        if (!array_key_exists($currDate, $deliveries) ||
            !array_key_exists($currCompany, $deliveries[$currDate])) {
            $deliveries[$currDate][$currCompany][$currPrice][] = $currMedicine;
            
        } else {
            $oldKey = key($deliveries[$currDate][$currCompany]);
            $newKey =($oldKey + $currPrice) . '' ;
            $deliveries[$currDate][$currCompany][$newKey] = $deliveries[$currDate][$currCompany][$oldKey];
            $deliveries[$currDate][$currCompany][$newKey][] = $currMedicine;
            unset($deliveries[$currDate][$currCompany][$oldKey]);
        }
    }
}

ksort($deliveries);
echo "<ul>";

foreach ($deliveries as $date => $companies) {
    ksort($companies);
    echo '<li><p>'.date("d/m/Y", $date).'</p>';
    
    foreach ($companies as $company => $values) {
        echo '<ul><li><p>'.$company.'</p>';
        
        foreach ($values as $value => $medicine) {
            asort($medicine);
            echo '<ul><li><p>'.implode(",",$medicine).'-'.$value.'lv</p></li></ul>';
        }
        echo '</li></ul>';
    }
    echo '</li>';
}
echo "</ul>";

//print_r($deliveries);