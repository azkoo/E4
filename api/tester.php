<?php

include_once 'objects/contractType.php';
include_once 'config/database.php';




    // instantiate database and contractType object
    //$database = getConnection();
    //echo $database;
    $db = getConnection();
    
    // initialize object
    $contractType = new ContractType($db);
    $result = new ContractType($db);

    $result->reader();
    
    
    //$row = mysqli_fetch_array($result);
    //$name = $row['name'];
    //echo $name;
    //$num = $result->rowCount();

    

    return $result;


?>