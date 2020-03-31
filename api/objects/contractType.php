<?php
// required headers
header("Access-Control-Allow-Origin: *");
header("Content-Type: application/json; charset=UTF-8");
 
class contractType{

    // database connection and table name
    private $conn;
    private $table = "ContractType";

    //Attribute
    public $Identifier;
    public $Name;
    

    // constructor with $db as database connection
    public function __construct($db){
         $this->conn = $db;
    }

  
    function reader() {

        $db = getConnection();
        $contractType = new ContractType($db);
        $result = new ContractType($db);

        $query = 'SELECT * FROM ContractType';
        $test = "fail";
        
        //ce code ci récupère les données en bdd.
        if (sqlsrv_query($this->conn, $query)) 
        {

            $stmt = sqlsrv_query($this->conn, $query);
        }
        else
        {
            //si jamais ça échoue affiche "fail"
            echo $test;
        }

        //TEST DE LECTURE DES DONNES JE BLOQUE CA MARCHE PAS 
        //(copier coller du read() du tuto adapté au ContractType)


        // query offers


        // ---------------- TO KNOW ----------------

        // Le code précédent fonctionne et trouve le bon nombre d'objets
        // en base de donnée chez moi. Je n'arrive juste pas à afficher autre chose que 
        // Ressource id #5 ou Ressource id #6 ça varie (je ne pense pas que ça soit une erreur
        //juste que ça ne peut pas afficher les données dans un format lisible)

        // le ligne de code commenté en dessous vient du tuto, ce n'est pas  
        // censé etre NOTRE fct read() mais une fonction php qui lit les données (je n'ai r trouvé dans le manual php par rapport à cette fct).
        // J'ai donc changé ma fct read() en reader() afin d'utiliser l'autre read() (et ne
        // pas boucler sur ma fct) mais ça marche pas,      
        //  avant de changer de nom j'avais des BOUCLES INFINI fait attention
        // J'utilise le fichier tester.php afin de tester mon reader() mais il y a peut etre plus simple
        ///// cette ligne //$result = $contractType->read();


        $num = $result->rowCount();
        echo $num;



        if($num=0){

            // contractTypes array
            $contractTypes_arr=array();
            $contractTypes_arr["records"]=array();


            while($row = $result->fetch(PDO::FETCH_ASSOC)){
                extract($row);
                $contractType_item=array(

                    "Id" => $Identifier,
                    "Name" => $Name

                ); 
                array_push($contractTypes_arr["records"], $contractType_item);
            }

            // show contractTypes data in json format
            echo json_encode($contractTypes_arr);
        }
        else{

            // set response code - 404 Not found
            http_response_code(404);
            
            // tell the user no jobTypes found
            echo json_encode(
                array("message" => "No products found.")
             );
        
        
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