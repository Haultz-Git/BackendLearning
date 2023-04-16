<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unity2";

//variables submitted by users
$level = $_POST["level"];
$score = $_POST["score"];
$usernameplayer = $_POST["username"];

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
//First Check if the username or email is already taken
//$sql = "INSERT INTO `asd` ( `level`, `score`, `username`) VALUES ('" .$level."', '" .$score."', '" .$username."');";
$sql = "INSERT INTO `asd` ( `level`, `score`, `username`) VALUES ( '" . $level ."', '" . $score ."', '" . $usernameplayer ."')";

if($conn -> query($sql)== TRUE){
  echo "Registered account Sucesfully";
}
  
$conn->close();
?>