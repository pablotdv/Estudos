<?php

namespace Source;

class ServiceProduct implements IServiceProduct
{
    private $db;
    private $product;

    public function __construct(IConn $conn, IProduct $product)
    {
        $this->db = $conn->connect();
        $this->db = $product;
    }

    public function list()
    {
        $query = "Select * from products";
        $stmt = $this->db->prepare($query);
        $stmt->execute();
        return $stmt->fetchAll(\PDO::FETCH_ASSOC);
    }

    public function save()
    {
    }

    public function update()
    {
    }

    public function delete()
    {
    }
}
