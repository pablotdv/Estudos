<?php
class Car
{
    public $brand;
    public $color;
    public $engine;

    public function getEngine($type = "horsepower")
    {
        return "{$this->engine} {$type}";
    }
}
