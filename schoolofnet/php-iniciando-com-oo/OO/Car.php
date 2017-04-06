<?php

require_once("Vehicle.php");

class Car extends Vehicle
{
    public $doors;

    public function getBrand()
    {
        return $this->Brand();
    }
}
