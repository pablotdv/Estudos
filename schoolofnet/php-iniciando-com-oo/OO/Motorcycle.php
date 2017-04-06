<?php

require_once("Vehicle.php");

class Motorcycle extends Vehicle
{
    public function getBrand()
    {
        return $this->brand;
    }
}
