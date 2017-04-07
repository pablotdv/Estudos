<?php

require_once("IConn.php");
require_once("Product.php");
require_once("Conn.php");
require_once("Container.php");

//$db = new \PDO("mysql:host=localhost;dbname=test_oo","root","123123");

$db = Container::getConn();

$product = Container::getProduct();//new Product($db);

$list = $product->list();

var_dump($list);
