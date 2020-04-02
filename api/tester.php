<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
header("Access-Control-Allow-Methods: POST");
header("Access-Control-Max-Age: 3600");
header("Access-Control-Allow-Headers: Content-Type, Access-Control-Allow-Headers, Authorization, X-Requested-With");

include_once 'objects/contractType.php';
include_once 'objects/offer.php';
include_once 'config/database.php';




    // instantiate database and contractType object    
    $db = getConnection();
    $idDataTest = json_decode(file_get_contents("php://input"));
    $idTest = 2;

    // initialize object
    $contractType = new ContractType($db);
    //$offer = new Offer($db);


    //$offer->ReadOffer($db);
    //$contractType->ReadContractType($db);
    $contractType->ReadOneContractType($db, $idDataTest);
    //$contractType->CreateContractType($db, $contractType);
    //$contractType->UpdateContractType($db, $idTest);
    //$contractType->DeleteContractType($db);    
    //$test = ContractType::reader($db);
    //echo($test);

/*
    // get posted data
    $data = json_decode(file_get_contents("php://input"));
        
    // make sure data is not empty
    if(
        !empty($data->Name)        
    ){
    
        // set contract type property values
        $contractType->Name = $data->Name;            
    
        // create the contract type
        if($contractType->CreateContractType($db)){
    
            // set response code - 201 created
            http_response_code(201);
    
            // tell the user
            echo json_encode(array("message" => "Contract type was created."));
        }
    
        // if unable to create the contract type, tell the user
        else{
    
            // set response code - 503 service unavailable
            http_response_code(503);
    
            // tell the user
            echo json_encode(array("message" => "Unable to create contract type."));
        }
    }
    
    // tell the user data is incomplete
    else{
    
        // set response code - 400 bad request
        http_response_code(400);
    
        // tell the user
        echo json_encode(array("message" => "Unable to create product. Data is incomplete."));
    }
*/

?>