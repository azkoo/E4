<?php

        // database connection and table name
        private $conn;
        private $table = "contractType";
    
        //Attribute
        private $Identifier
        private $Name
    
        // constructor with $db as database connection
        public function __construct($db){
            $this->conn = $db;
       }
    
        function read(){
    
            $query = 'SELECT ContractTpye.Name FROM ContractType
                      ORDER BY ContractType.Name DESC';
            
            // prepare query statement
            $stmt = $this->conn->prepare($query);
        
            // execute query
            $stmt->execute();
        
            return $stmt;
        }


?>