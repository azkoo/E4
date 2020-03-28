<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
 
// include database and object files
include_once '../config/database.php';
include_once '../objects/jobType.php';
  
// instantiate database and jobType object
$database = new Database();
$db = $database->getConnection();
  
// initialize object
$jobType = new JobType($db);
  
// query offers
$result = $jobType->read();
$num = $result->rowCount();


if($num>0){

    // jobTypes array
    $jobTypes_arr=array();
    $jobTypes_arr["records"]=array();


    while($row = $result->fetch(PDO::FETCH_ASSOC)){
        extract($row);
        $jobType_item=array(

            "Id" => $Identifier,
            "Name" => $Name 
        ); 
        array_push($jobTypes_arr["records"], $jobType_item);
    }

       // show jobTypes data in json format
       echo json_encode($jobTypes_arr);
}
else{
    // set response code - 404 Not found
    http_response_code(404);
    
    // tell the user no jobTypes found
    echo json_encode(
        array("message" => "No products found.")
    );
}