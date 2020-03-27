<?php
class Offer{

    // database connection and table name
    private $conn;
    private $table = "offer";

    //Attribute
    private $Identifier
    private $Name
    private $Reference
    private $IdentifierJob
    private $IdentifierContractType
    private $PublishDateTime
    private $Duration
    private $StartContractDate
    private $PostCount
    private $JobDescription
    private $ProfilDescription
    private $Street
    private $City
    private $ZipCode    
    private $IdentifierProducer

    // constructor with $db as database connection
    public function __construct($db){
         $this->conn = $db;
    }
  
    function read() {

        $query = 'SELECT * FROM Offer';
        
        // prepare query statement
        $stmt = $this->conn->prepare($query);
    
        // execute query
        $stmt->execute();
    
        return $stmt;
        
    }

}





?>