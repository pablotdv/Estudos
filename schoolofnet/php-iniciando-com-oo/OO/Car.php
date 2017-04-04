<?php
class Car
{
    public $brand;
    public $color;
    public $engine;

    public function getEngine()
    {
        return $this->engine." horsepower";
    }
}
