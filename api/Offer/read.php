<?php

// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
 
// include database and object files
include_once '../config/database.php';
include_once '../objects/offer.php';
  
// instantiate database and offer object
$database = new Database();
$db = $database->getConnection();
  
// initialize object
$offer = new Offer($db);
  
// query offers
$result = $offer->read();
$num = $result->rowCount();


if($num>0){

    // offers array
    $offers_arr=array();
    $offers_arr["records"]=array();


    while($row = $result->fetch(PDO::FETCH_ASSOC)){
        extract($row);
        $offer_item=array(

            "Id" => $Identifier,
            "Name" => $Name,
            "Reference" => $Reference,
            "IdJob" => $IdentifierJob,
            "IdContractType" => $IdentifierContractType,
            "PublishDate" => $PublishDateTime,
            "Duration" => $Duration,
            "StartContractDate" => $StartContractDate,
            "PostCount" => $PostCount,
            "JobDescription" => $JobDescription,
            "ProfilDescription" => $ProfilDescription,
            "Street" => $Street,
            "City" => $City,
            "ZipCode" => $ZipCode,
            "IdProducer" => $IdentifierProducer   
        ); 
        array_push($offers_arr["records"], $offer_item);
    }

       // show offers data in json format
       echo json_encode($offers_arr);
}
else{
    // set response code - 404 Not found
    http_response_code(404);
    
    // tell the user no products found
    echo json_encode(
        array("message" => "No products found.")
    );
}


?>