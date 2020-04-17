<?php

include 'PdoConnection.php';

$reponse = $bdd->query('SELECT pseudo, score FROM starwars.score ORDER BY score DESC LIMIT 5');
$rows = $reponse->fetchAll(PDO::FETCH_ASSOC);

echo(json_encode($rows));
