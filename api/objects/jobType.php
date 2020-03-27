<?php
class JobType{
    
    // database connection and table name
    private $conn;
    private $table = "jobType";

    //Attribute
    private $Identifier
    private $Name

    // constructor with $db as database connection
    public function __construct($db){
        $this->conn = $db;
   }

    function read(){

        $query = 'SELECT JobType.Name FROM JobType
        ORDER BY JobType.Name DESC';
        
        // prepare query statement
        $stmt = $this->conn->prepare($query);
    
        // execute query
        $stmt->execute();
    
        return $stmt;
    }
}


?>