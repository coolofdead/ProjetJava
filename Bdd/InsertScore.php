<?php

include 'PdoConnection.php';

$pseudo = $_GET['pseudo'];
$score = $_GET['score'];

try {
    $statement = $bdd->prepare('INSERT INTO score (pseudo, score) VALUES (:pseudo, :score)');
    $statement->execute([
        ":pseudo" => $pseudo,
        ":score" => $score,
    ]);
} catch (Error $error) {
    echo $error->getMessage();
}
