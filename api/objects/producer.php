<?php
class Producer{
  
    // database connection and table name
    private $conn;
    private $table = "producer";
  
    // object properties
    public $id;
    public $Name;
    public $Password;
    public $Website;
    public $Phone;
    public $Fax;
    public $City;
    public $Address1;
    public $Address2;
    public $Email;
    public $CastingCounter;
    public $IdCastingPack;

  
    // constructor with $db as database connection
    public function __construct($db){
        $this->conn = $db;
    }

    // read products
    function read(){
  
        // select all query
        $query = 'SELECT
                    producer.Id, producer.Name, producer.Password, producer.Website
                    FROM ' 
                    . $this->table .                    
                    '
                         ORDER BY
                         producer.Name DESC';
    
        // prepare query statement
        $stmt = $this->conn->prepare($query);
    
        // execute query
        $stmt->execute();
    
        return $stmt;
    }
}
?>