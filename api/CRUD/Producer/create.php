<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");
  
// get database connection
include_once '../../config/database.php';
  
// instantiate product object
include_once '../../objects/producer.php';
  
$database = new Database();
$db = $database->getConnection();
  
$producer = new Producer($db);
  
// get posted data
$data = json_decode(file_get_contents("php://input"));


if ( $data == true)
{
    /*echo(file_get_contents("php://input"));
    echo(" 1 ". $data->Name . "\n");
    echo(" 2 ". $data->Password . "\n");
    echo(" 3 ". $data->Website . "\n");  
    echo(" 4 ". $data->Phone . "\n");    
    echo(" 5 ". $data->Fax . "\n");    
    echo(" 6 ". $data->City . "\n");    
    echo(" 7 ". $data->Adress1 . "\n");    
    echo(" 8 ". $data->Adress2 . "\n");    
    echo(" 9 ". $data->Email . "\n");    
    echo(" 10 ". $data->CastingCounter . "\n");   
    echo(" 11 ". $data->IdCastingPack . "\n");*/
    echo($producer->Name);

}
    
  
// make sure data is not empty
if(
    //!empty($data->id) &&
    !empty($data->Name) &&
    !empty($data->Password) &&
    !empty($data->Website) &&  
    !empty($data->Phone) &&    
    !empty($data->Fax) &&    
    !empty($data->City) &&    
    !empty($data->Adress1) &&    
    !empty($data->Adress2) &&    
    !empty($data->Email) &&    
    !empty($data->CastingCounter) &&   
    !empty($data->IdCastingPack)
){
  
        // set product property values
        //$product->id = $data->id;
        $producer->Name = $data->Name;
        $producer->Password = $data->Password;
        $producer->Website = $data->Website;
        $producer->Phone = $data->Phone;
        $producer->Fax = $data->Fax;
        $producer->City = $data->City;
        $producer->Address1 = $data->Adress1;
        $producer->Address2 = $data->Adress2;
        $producer->Email = $data->Email;
        $producer->CastingCounter = $data->CastingCounter;
        $producer->IdCastingPack = $data->IdCastingPack;
    
  
    // create the product
    if($producer->create()){
  
        // set response code - 201 created
        http_response_code(201);
  
        // tell the user
        echo json_encode(array("message" => "Product was created."));
    }
  
    // if unable to create the product, tell the user
    else{
  
        // set response code - 503 service unavailable
        http_response_code(503);
  
        // tell the user
        echo json_encode(array("message" => "Unable to create product."));
    }
}
  
// tell the user data is incomplete
else{
  
    // set response code - 400 bad request
    http_response_code(400);
  
    // tell the user
    echo json_encode(array("message" => "Unable to create product. Data is incomplete."));
}
?>