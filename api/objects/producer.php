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
    public $Adress1;
    public $Adress2;
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
    
    // create product
    function create(){
  
        // query to insert record
        $query = "INSERT INTO
                    " . $this->table . "
                SET
                    Name=:Name,  Password=:Password,
                     Website=:Website, Phone=:Phone, Fax=:Fax, 
                     City=:City, Adress1=:Adress1, Adress2=:Adress2, Email=:Email,
                     CastingCounter=:CastingCounter, IdCastingPack=:IdCastingPack";
    
        // prepare query
        $stmt = $this->conn->prepare($query);
    
        // sanitize
        $this->Name=htmlspecialchars(strip_tags($this->Name));
        $this->Password=htmlspecialchars(strip_tags($this->Password));
        $this->Website=htmlspecialchars(strip_tags($this->Website));
        $this->Phone=htmlspecialchars(strip_tags($this->Phone));
        $this->Fax=htmlspecialchars(strip_tags($this->Fax));
        $this->City=htmlspecialchars(strip_tags($this->City));
        $this->Adress1=htmlspecialchars(strip_tags($this->Adress1));
        $this->Adress2=htmlspecialchars(strip_tags($this->Adress2));
        $this->Email=htmlspecialchars(strip_tags($this->Email));        
        $this->CastingCounter=htmlspecialchars(strip_tags($this->CastingCounter));
        $this->IdCastingPack=htmlspecialchars(strip_tags($this->IdCastingPack));
    
        // bind values
        $stmt->bindParam(":Name", $this->Name);
        $stmt->bindParam(":Password", $this->Password);
        $stmt->bindParam(":Website", $this->Website);
        $stmt->bindParam(":Phone", $this->Phone);
        $stmt->bindParam(":Fax", $this->Fax);
        $stmt->bindParam(":City", $this->City);
        $stmt->bindParam(":Adress1", $this->Adress1);
        $stmt->bindParam(":Adress2", $this->Adress2);
        $stmt->bindParam(":Email", $this->Email);
        $stmt->bindParam(":CastingCounter", $this->CastingCounter);
        $stmt->bindParam(":IdCastingPack", $this->IdCastingPack);
    
        // execute query
        if($stmt->execute()){
            return true;
        }
    
        return false;
      
}
}
?>