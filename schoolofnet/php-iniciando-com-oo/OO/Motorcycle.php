<?php

require_once("Vehicle.php");

class Motorcycle extends Vehicle
{
    public function getBrand()
    {
        return $this->brand;
    }
    public function __construct($brand = null, $color = null)
    {
        parent::__construct($brand, strtoupper($color));        
    }
}
