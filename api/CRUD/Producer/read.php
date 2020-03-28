<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
 
// include database and object files
include_once '../../config/database.php';
include_once '../../objects/producer.php';
  
// instantiate database and producer object
$database = new Database();
$db = $database->getConnection();
  
// initialize object
$producer = new Producer($db);
  

// query producers
$result = $producer->read();
$num = $result->rowCount();

// check if more than 0 record found
if($num>0){
  
    // producers array
    $producers_arr=array();
    $producers_arr["records"]=array();
  
    // retrieve our table contents
    // fetch() is faster than fetchAll()
    // http://stackoverflow.com/questions/2770630/pdofetchall-vs-pdofetch-in-a-loop
    while ($row = $result->fetch(PDO::FETCH_ASSOC)){
        // extract row
        // this will make $row['name'] to
        // just $name only
        extract($row);
        
        $producer_item=array(
            "Id" => $Id,
            "Name" => $Name,
            // "description" => html_entity_decode($description),
            "Password" => $Password,
            "Website" => $Website,
            //"Phone" => $Phone,
            //"Fax" => $Fax,
            //"City" => $City,
            //"Address1" => $Address1,
            //"Address2" => $Address2,
            //"Email" => $Email,
            //"CastingCounter" => $CastingCounter,
            //"IdCastingPack" => $IdCastingPack            
    
        );  
  
        array_push($producers_arr["records"], $producer_item);
    }
  
    // set response code - 200 OK
    //http_response_code(200);
  
    // show producers data in json format
    echo json_encode($producers_arr);
}
else{

    // set response code - 404 Not found
    http_response_code(404);
    
    // tell the user no products found
    echo json_encode(
        array("message" => "No products found.")
    );
}