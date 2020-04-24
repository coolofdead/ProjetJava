<?php

include 'PdoConnection.php';

$levelId = $_GET['level_id'];

try {
    $reponse = $bdd->query('SELECT enemies_health_percentage FROM starwars.levelSettings WHERE level_id='.$levelId);
    $rows = $reponse->fetchAll(PDO::FETCH_ASSOC);

    echo($rows[0]['enemies_health_percentage']);
} catch (Error $error) {
    echo $error->getMessage();
}