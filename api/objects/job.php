<?php
class Job{

        // database connection and table name
        private $conn;
        private $table = "jobType";
    
        //Attribute
        private $Identifier
        private $Name
        private $IdentifierJobType
    
        // constructor with $db as database connection
        public function __construct($db){
            $this->conn = $db;
       }
    
        function read(){
    
            $query = 'SELECT Job.Name FROM Job
            ORDER BY Job.Name DESC';
            
            // prepare query statement
            $stmt = $this->conn->prepare($query);
        
            // execute query
            $stmt->execute();
        
            return $stmt;
        }

}


?>