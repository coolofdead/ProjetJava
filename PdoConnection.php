<?php

$host = 'localhost';
$dbName = 'starwars;';
$user = 'root';

try {
    $bdd = new PDO('mysql:host=' . $host . ';dbname=' . $dbName . 'charset=utf8', $user);
    $bdd->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (Exception $e) {
    die('Erreur : ' . $e->getMessage());
}
