<?php
class Offer{

    // database connection and table name
    private $conn;
    private $table = "offer";

    //Attribute
    public $Identifier;
    public $Name;
    public $Reference;
    public $Description;
    public $Picture;
    public $PostNumber;
    public $PublicationStart;
    public $ContractStart;
    public $Period;
    public $Inspect;
    public $IdProducer;
    public $IdContactType;
    public $IdJob;  

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



/*
{
	Name":"Jean",
    Reference":"Ref", 
    Description":"Description", 
    Picture":"http://example.com/dir1/xyz123.png", 
    PostNumber":"1", 
    PublicationStart":"30/03/2020", 
    ContractStart":"30/03/2020", 
    Period":"2 months", 
    Inspect":"yes", 
    IdProducer":"1", 
    IdContactType":"1", 
    IdJob":"1"

	}
*/

?>