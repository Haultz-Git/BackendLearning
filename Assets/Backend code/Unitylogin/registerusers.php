<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitystuff";

//variables submitted by users
$register_userName = $_POST["register_username"];
$register_password = $_POST["register_password"];
$register_email = $_POST["register_email"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//First Check if the username or email is already taken
$sql = "SELECT username FROM users WHERE username LIKE '" . $register_userName . "' OR email LIKE '" . $register_email . "' ";
$result = $conn->query($sql);

if ($result->num_rows > 0){
  echo "Register account process Failed : The username or email already exist";
}
else{
  $sql = " INSERT INTO users (username , password , email) VALUES ( '" . $register_userName . "','" . $register_password . "','" . $register_email . "')";

if($conn -> query($sql)== TRUE){
  echo "Registered account Sucesfully";
}
}
  
$conn->close();
?>