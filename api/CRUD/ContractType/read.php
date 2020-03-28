<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
 
// include database and object files
include_once '../config/database.php';
include_once '../objects/contractType.php';
  
// instantiate database and contractType object
$database = new Database();
$db = $database->getConnection();
  
// initialize object
$contractType = new ContractType($db);
    
// query offers
$result = $contractType->read();
$num = $result->rowCount();


if($num>0){

    // contractTypes array
    $contractTypes_arr=array();
    $contractTypes_arr["records"]=array();


    while($row = $result->fetch(PDO::FETCH_ASSOC)){
        extract($row);
        $contractType_item=array(

            "Id" => $Identifier,
            "Name" => $Name

        ); 
        array_push($contractTypes_arr["records"], $contractType_item);
    }

       // show contractTypes data in json format
       echo json_encode($contractTypes_arr);
}
else{
    // set response code - 404 Not found
    http_response_code(404);
    
    // tell the user no jobTypes found
    echo json_encode(
        array("message" => "No products found.")
    );
}