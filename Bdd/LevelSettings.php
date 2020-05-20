<?php

include 'PdoConnection.php';

$levelId = $_GET['level_id'];

try {
    $reponse = $bdd->query('SELECT turret_goal, spaceship_goal FROM starwars.levelSettings WHERE level_id='.$levelId);
    $rows = $reponse->fetchAll(PDO::FETCH_ASSOC);

    echo(json_encode($rows[0]));
} catch (Error $error) {
    echo $error->getMessage();
}