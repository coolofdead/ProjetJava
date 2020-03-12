<?php

include 'PdoConnection.php';

$reponse = $bdd->query('SELECT * FROM score ORDER BY score DESC LIMIT 5');
$rows = $reponse->fetchAll();

foreach ($rows as $row) {
    $rowJson = json_encode($row);
    echo $rowJson;
}
