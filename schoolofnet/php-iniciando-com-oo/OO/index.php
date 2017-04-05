<?php

require_once("Car.php");
require_once("Motorcycle.php");

$ferrari = new Car("Ferrari", "Red");
$ferrari->engine = 488;
$ferrari->doors = 2;

$mustang = new Car("Mustagn", "Yellow");
$mustang->engine = 300;
$mustang->doors = 4;

$motor = new Motorcycle();
$motor->brand = "Honda";
$motor->color = "Blue";
$motor->engine = 150;

echo $motor->brand;