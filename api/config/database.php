<?php


function getConnection(){

     $serverName = "DESKTOP-HRSC6EQ\\SQLEXPRESS"; //serverName\instanceName
     $connectionInfo = array( "Database"=>"MegaCastingBD", "UID"=>"sa", "PWD"=>"Sql2017");
     $conn = sqlsrv_connect( $serverName, $connectionInfo);

     if( $conn ) {
          echo "Connexion établie.<br />";
     }else{
          echo "La connexion n'a pu être établie.<br />";
          die( print_r( sqlsrv_errors(), true));
     }

     

return $conn;

}


/*

C:\Users\Azkoo\AppData\Local\Temp --> pilote dl

$sql = "SELECT * FROM ContractType";
     $params = array();
     $options =  array( "Scrollable" => SQLSRV_CURSOR_KEYSET );
     $stmt = sqlsrv_query( $conn, $sql, $params, $options );

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

*/
?>