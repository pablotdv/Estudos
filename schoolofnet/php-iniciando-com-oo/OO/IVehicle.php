<?php

interface IVehicle 
{
    // public $brand;
    // protected $color;
    // public $engine;

    // public function __construct($brand = null, $color = null)
    // {
    //     $this->brand = $brand;
    //     $this->color = $color;
    // }

    public function getEngine($type = null);

    public function getBrand();

    public function getColor();
}