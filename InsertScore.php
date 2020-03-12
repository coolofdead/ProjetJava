<?php

include 'PdoConnection.php';

$pseudo = $_GET['pseudo'];
$score = $_GET['score'];

try {
    $bdd->exec('INSERT INTO score (pseudo, score) VALUES ("' . $pseudo . '",' . $score . ')');
} catch (Error $error) {
    echo $error;
}
