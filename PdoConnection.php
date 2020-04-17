<?php

$host = 'localhost';
$port = '3308';
$dbName = 'starwars';
$user = 'root';
$password = '';

try {
    $bdd = new PDO("mysql:dbname=$dbName;host=$host;port=$port", $user, $password);
    $bdd->setAttribute(PDO::ATTR_ERRMODE, PDO::ERRMODE_EXCEPTION);
} catch (Exception $e) {
    die('Erreur : ' . $e->getMessage());
}
