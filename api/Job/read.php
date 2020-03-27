<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
 
// include database and object files
include_once '../config/database.php';
include_once '../objects/job.php';
  
// instantiate database and job object
$database = new Database();
$db = $database->getConnection();
  
// initialize object
$job = new Job($db);
  
// query offers
$result = $job->read();
$num = $result->rowCount();


if($num>0){

    // jobs array
    $jobs_arr=array();
    $jobs_arr["records"]=array();


    while($row = $result->fetch(PDO::FETCH_ASSOC)){
        extract($row);
        $job_item=array(

            "Id" => $Identifier,
            "Name" => $Name,
            "IdJobType" => $IdentifierJobType

        ); 
        array_push($jobs_arr["records"], $job_item);
    }

       // show jobTypes data in json format
       echo json_encode($jobs_arr);
}
else{
    // set response code - 404 Not found
    http_response_code(404);
    
    // tell the user no jobTypes found
    echo json_encode(
        array("message" => "No products found.")
    );
}