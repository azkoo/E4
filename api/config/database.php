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

*/
?>