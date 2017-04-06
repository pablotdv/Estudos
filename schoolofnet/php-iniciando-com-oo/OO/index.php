<?php

require_once("Car.php");
require_once("Motorcycle.php");

$ferrari = new Car("Ferrari", "Red");
$ferrari->engine = 488;
$ferrari->setDoors(2);

$mustang = new Car("Mustagn", "Yellow");
$mustang->engine = 300;
$mustang->setDoors(4);

$motor = new Motorcycle("Honda", "Blue");
$motor->engine = 150;

echo $motor->getBrand();