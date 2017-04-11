<?php

$container['conn'] =  function($c) {
    return new \Source\Conn($c['dsn'], $c['user'], $c['pass']);
};

$container['product'] =  function($c) {
    return new \Source\Product($c['conn']);
};