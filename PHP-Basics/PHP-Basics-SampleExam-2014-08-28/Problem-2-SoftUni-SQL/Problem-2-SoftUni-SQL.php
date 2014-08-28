<?php
$users =[];
$errorSQL = 0;
$commands = $_GET['commands'];
//    [
//    "UPDAtE users SET (age = 30) WHERE (user_id = 1)",
//    "INSERT INTO users (login, age, gender) VALUES (yana, 20, female)",
//    "UPDATE users SET (age = 30) WHERE (user_id = 1)",
//    "INSERT INTO users (login, age) VALUES (yana, 20, female)",
//   "INSERT INTO users (login, age, gender) VALUES (yana, 20, female)",
//   "INSERT INTO users (user_id, login, gender) VALUES (12, yana, female)",
//    "INSERT INTO users (login, age, gender) VALUES (yana, 20, female)",
//    "INSrRT INTO users (login, age, gender) VALUES (yana, 20, female)",
//     "UPDATE users SET (age = 30) WHERE (user_id = 1)",
//     "UPDATE users SET (age = 30) WHERE (age = undefined)",
//      "DELETE FROM users WHERE (age = 30)"
//
//];
foreach ($commands as $command) {
    if (substr($command, 0, 6) == "INSERT") {
        $startFields = strpos($command, '(') + 1;
        $lengthFields = strpos($command, ')') - $startFields;
        $startValues = strrpos($command, '(') + 1;
        $lengthValues = strrpos($command, ')') - $startValues;
        $fieldsStr = substr($command, $startFields, $lengthFields);
        $fieldsArr = explode(', ', $fieldsStr);
        //$updateConditionArr = explode(', ', $fieldsStr);
        $valuesStr = substr($command, $startValues, $lengthValues);
        $valuesArr = explode(', ', $valuesStr);
        if (count($valuesArr)==count($fieldsArr)) {

            if(in_array('login',$fieldsArr)) {
                $tempArr = array_combine($fieldsArr, $valuesArr);
                if (array_key_exists('user_id', $tempArr)) {
                    $currentId = $tempArr['user_id'];
                    unset($tempArr['user_id']);
                }
                if(!array_key_exists('age', $tempArr)) {
                    $tempArr['age'] = "undefined";
                }
                if(!array_key_exists('gender', $tempArr)) {
                    $tempArr['gender'] = "undefined";
                }
                //var_dump($tempArr);
                krsort($tempArr);
                if (isset($currentId)) {
                    $users[$currentId] = $tempArr;
                    unset($currentId);
                } else {
                    $users[]= $tempArr;
                }
            } else {
                $errorSQL++;
                continue;
            }
        } else {
            $errorSQL++;
            continue;
        }
    } elseif (substr($command, 0, 6) == "UPDATE") {
        $startFields = strpos($command, '(') + 1;
        $endFields = strpos($command, ')') - $startFields;
        $startValues = strrpos($command, '(') + 1;
        $endValues = strrpos($command, ')') - $startValues;

        $changeStr = substr($command, $startFields, $endFields);
        $changeArr = explode('=', $changeStr);
        //var_dump($changeArr);
        $changeField = trim($changeArr[0]);
        $changeValue = trim($changeArr[1]);

        $updateConditionStr = substr($command, $startValues, $endValues);
        $updateConditionArr = explode('=', $updateConditionStr);
        $updateConditionField = trim($updateConditionArr[0]);
        $updateConditionValue = trim($updateConditionArr[1]);
        //var_dump($updateConditionArr);

        //first check if update field exist
        $changeFieldIsCorrect = ($changeField == 'age' || $changeField == 'gender'|| $changeField == 'login');
        $updateConditionFieldIsCorrect = ($updateConditionField == 'age' || $updateConditionField == 'gender'|| $updateConditionField == 'login');
        if (sizeof($users) > 0) {
            if ($updateConditionField == 'user_id') {
                if (array_key_exists($updateConditionValue, $users)) {
                    $users[$updateConditionValue][$changeField] = $changeValue;
                } else {
                    $errorSQL++;
                    continue;
                }
            } elseif ($changeFieldIsCorrect  && $updateConditionFieldIsCorrect) {
                $error = true;
                foreach ($users as $id => $user) {
                    if (array_key_exists($updateConditionField, $users[$id]) && $users[$id][$updateConditionField] == $updateConditionValue ) {
                        $users[$id][$changeField] = $changeValue;
                        $error = false;
                    }
                }
                if ($error) {
                    $errorSQL++;
                    continue;
                }

            } else {
                $errorSQL++;
                continue;
            }
        } else {
            $errorSQL++;
            continue;
        }

    } elseif (substr($command, 0, 6)== "DELETE") {
        $startField = strpos($command, '(') + 1;
        $endField = strpos($command, ')') - $startField;
        $conditionStr = substr($command, $startField, $endField);
        $conditionArr = explode('=', $conditionStr);

        $conditionField = trim($conditionArr[0]);
        $conditionValue = trim($conditionArr[1]);

       if ($conditionField == 'user_id') {
           if (array_key_exists($conditionValue, $users)) {
               unset ($users[$conditionValue]);
           }
       } elseif ($conditionField == 'age' || $conditionField == 'gender' || $conditionField == 'login') {
           foreach ($users as $id => $row) {
               if ($users[$id][$conditionField] == $conditionValue ) {
                    unset ($users[$id]);
               }
           }

       } else {
           $errorSQL++;
       }

    } else {
        $errorSQL++;
    }
}

if (count($users) > 0) {
    echo '<table><thead><tr><th>user_id</th><th>login</th><th>gender</th><th>age</th></tr></thead><tbody>';
    foreach ($users as $id => $otherFields) {
        echo '<tr><td>'.$id.'</td><td>'.$otherFields['login'].'</td><td>'.$otherFields['gender'].'</td><td>'.$otherFields['age'].'</td></tr>';
    }
    echo '</tbody><tfoot><tr><td colspan="4">Errors='.$errorSQL.'</td></tr></tfoot></table>';

} else {
    echo 'You have '.$errorSQL.' error/s';
}
//var_dump($users);
//var_dump($errorSQL);
