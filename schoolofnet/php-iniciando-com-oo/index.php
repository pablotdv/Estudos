<?php

class People 
{
    public function getHello($name) 
    {
        return "Hello {$name}!";
    }
}

$p = new People;
echo $p->getHello("Pablo T de Vargas");