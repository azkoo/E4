<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
 
class contractType{

    // database connection and table name
    private $conn;
    private $table = "ContractType";

    //Attribute
    public $Id;
    public $Name;
    

    // constructor with $db as database connection
    public function __construct($db){
         $this->conn = $db;
    }

  
    function ReadContractType($db) {
        //DB MIS EN PARAMETRE
        //$db = getConnection();

        // contractTypes array
        $sql = "SELECT * FROM ContractType";
        $params = array();
        $options =  array( "Scrollable" => SQLSRV_CURSOR_KEYSET );
        $stmt = sqlsrv_query( $db, $sql, $params, $options );

        $row_count = sqlsrv_num_rows( $stmt );

        if($row_count>0){

            // jobTypes array
            $jobTypes_arr=array();
            $jobTypes_arr["records"]=array();


            while($row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)){
                extract($row);
                $jobType_item=array(

                    "Id" => $Id,
                    "Name" => $Name 
                ); 
                array_push($jobTypes_arr["records"], $jobType_item);
            }

            // show jobTypes data in json format
            echo json_encode($jobTypes_arr);
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

    function ReadOneContractType($db, $id){

        // contractTypes array
        $sql = "SELECT * FROM ContractType WHERE Id = ?";
        $params = array($id->Id);
        $options =  array( "Scrollable" => SQLSRV_CURSOR_KEYSET );
        $stmt = sqlsrv_query( $db, $sql, $params, $options );

        // jobTypes array
        $jobTypes_arr=array();
        $jobTypes_arr["records"]=array();

        while($row = sqlsrv_fetch_array($stmt, SQLSRV_FETCH_ASSOC)){
            extract($row);
            $jobType_item=array(

                "Id" => $Id,
                "Name" => $Name 
            ); 
            array_push($jobTypes_arr["records"], $jobType_item);
        }
        echo json_encode($jobTypes_arr);

    }





    function CreateContractType($db, $contractType){

        $query = "INSERT INTO ContractType(Name) VALUES(?)";
        $data = json_decode(file_get_contents("php://input") );


        if(!empty($data->Name)){

            $contractType->Name = $data->Name;
            $params = array($data->Name);
            $stmt = sqlsrv_query( $db, $query, $params );
        }
        
        

        if($stmt){
            return true;
        }
        else
        {
            return false;
        }

        }






    function UpdateContractType( $db, $id){

        $data = json_decode(file_get_contents("php://input"));

        if (empty($data->Name)) {
            header("HTTP/1.0 400 Bad Request");
        }

        else {
            $query = "UPDATE ContractType SET Name = ? WHERE Id = ?";

            $params = array($data->Name, $id);
            $stmt = sqlsrv_query($db, $query, $params);            
            if (sqlsrv_rows_affected($stmt) === 0) {
                header("HTTP/1.0 400 Bad Request");
                echo("data didn't update.");
            }
            else {
                header("HTTP/1.0 202 Accepted");
                http_response_code(200);
                echo("data updated.");
            }
        }

    }

    function DeleteContractType($db){
        //Get the json input
        $data = json_decode(file_get_contents("php://input"));

        if (empty($data->Id)) {
            header("HTTP/1.0 400 Bad Request");
            echo("data empty");
        }

        else {

            //Attributes needed for the sql query
            $query = "DELETE FROM ContractType WHERE Id = " . $data->Id;
            
            //sql query
            $stmt = sqlsrv_query($db, $query);     
            
            if (sqlsrv_rows_affected($stmt) === 1) {
                header("HTTP/1.0 202 Accepted");
                http_response_code(200);
                echo("\n data deleted.");
            }
            else {                
                header("HTTP/1.0 400 Bad Request");
                echo("data didn't delete.");
            }
        }

    }

}

/*
{
	Name":"Jean",
    Reference":"Ref", 
    Description":"Description", 
    Picture":"http://example.com/dir1/xyz123.png", 
    PostNumber":"1", 
    PublicationStart":"30/03/2020", 
    ContractStart":"30/03/2020", 
    Period":"2 months", 
    Inspect":"yes", 
    IdProducer":"1", 
    IdContactType":"1", 
    IdJob":"1"

	}
*/

?>