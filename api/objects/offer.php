<?php
class Offer{

    // database connection and table name
    private $conn;
    private $table = "offer";

    //Attribute
    public $Id;
    public $Name;
    public $Reference;
    public $Description;
    public $Picture;
    public $PostNumber;
    public $PublicationStart;
    public $ContractStart;
    public $Period;
    public $Inspect;
    public $IdProducer;
    public $IdContactType;
    public $IdJob;  

    // constructor with $db as database connection
    public function __construct($db){
         $this->conn = $db;
    }
  
    function ReadOffer($db) {

        //DB MIS EN PARAMETRE
        //$db = getConnection();

        // contractTypes array
        $sql = "SELECT * FROM Offer";
        $params = array();
        $options =  array( "Scrollable" => SQLSRV_CURSOR_KEYSET );
        $stmt = sqlsrv_query( $db, $sql, $params, $options );

        $row_count = sqlsrv_num_rows( $stmt );

        if($row_count>0){

            // jobTypes array
            $offer_arr=array();
            $offer_arr["records"]=array();


            while($row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)){
                extract($row);                
                $offer_item=array(

                    "Id" => $Id,
                    "Name" => $Name,
                    "Reference" => $Reference,
                    "Description" => $Description,
                    "Picture" => $Picture,
                    "PostNumber" => $PostNumber,
                    "PublicationStart" => $PublicationStart,
                    "ContractStart" => $ContractStart,
                    "Period" => $Period,
                    "Inspect" => $Inspect,
                    "IdProducer" => $IdProducer,                    
                    "IdContractType" => $IdContractType,
                    "IdJob" => $IdJob                    
                    
                );

                echo("\n1 tour de boucle");                
                array_push($offer_arr["records"], $offer_item);
            }

            // show jobTypes data in json format
            echo json_encode($offer_arr);      
            echo("\ntest json_encode");      
            
        } 
        else {

            // set response code - 404 Not found
            http_response_code(404);

            // tell the user no jobTypes found
            echo json_encode(
                array("message" => "No products found.")
            );
        }
        
    }

}

?>