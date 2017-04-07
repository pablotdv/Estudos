<?php 

require_once("IConn.php");
require_once("Product.php");
require_once("Conn.php");

//$db = new \PDO("mysql:host=localhost;dbname=test_oo","root","123123");

$db = new Conn("mysql:host=localhost;dbname=test_oo", "root", "123123");

$product = new Product($db);

$list = $product->list();

var_dump($list);