<?php
class Product{
  
    // database connection and table name
    private $conn;
    private $table_name = "Producer";
  
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
        $query = "SELECT
                    j.Name as Job_name, j.id, j.Name, j.Password, j.Website, j.Phone, j.Fax,
                    j.Fax, j.City, j.Address1, j.Address2, j.Email, j.CastingCounter, j.IdCastingPack
                    FROM " 
                    . $this->table_name .                    
                    //" p LEFT JOIN
                    //    categories c ON p.category_id = c.id
                    " ORDER BY
                        j.Name DESC";
    
        // prepare query statement
        $stmt = $this->conn->prepare($query);
    
        // execute query
        $stmt->execute();
    
        return $stmt;
    }
}
?>