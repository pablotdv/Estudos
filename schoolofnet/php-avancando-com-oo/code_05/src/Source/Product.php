<?php

namespace Source;

class Product
{
    private $db;

    public function __construct(IConn $conn)
    {
        $this->db = $conn->connect();
    }

    public function list()
    {
        $query = "Select * from products";
        $stmt = $this->db->prepare($query);
        $stmt->execute();
        return $stmt->fetchAll(\PDO::FETCH_ASSOC);
    }
}
