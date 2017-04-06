<?php 

$db = new \PDO("mysql:host=localhost;dbname=test_oo","root","123123");
$query = "Select * from products";
$stmt = $db->prepare($query);
$stmt->execute();
$list = $stmt->fetchAll(\PDO::FETCH_ASSOC);
var_dump($list);