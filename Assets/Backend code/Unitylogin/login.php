<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitystuff";

//variables submitted by users
$loginUsername = $_POST["loginUsername"];
$loginPassword = $_POST["loginPassword"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}

$sql = "SELECT password FROM users WHERE username = '" . $loginUsername . "'";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    if($row["password"] == $loginPassword){
        echo 0;
    }
  }
} else {
  echo "0 results";
}
$conn->close();
?>