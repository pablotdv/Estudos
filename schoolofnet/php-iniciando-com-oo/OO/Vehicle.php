<?php

abstract class Vehicle
{
    public $brand;
    protected $color;
    public $engine;

    public function __construct($brand = null, $color = null)
    {
        $this->brand = $brand;
        $this->color = $color;
    }

    public function getEngine($type = "horsepower")
    {
        return "{$this->engine} {$type}";
    }

    abstract public function getBrand();
}
