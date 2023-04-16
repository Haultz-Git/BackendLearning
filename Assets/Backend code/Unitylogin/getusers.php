<?php
$servername = "localhost";
$username = "root";
$password = "";
$dbname = "unitystuff";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);

// Check connection
if ($conn->connect_error) {
  die("Connection failed: " . $conn->connect_error);
}
echo "Connection sucessful <br>";

$sql = "SELECT id, username FROM users";
$result = $conn->query($sql);

if ($result->num_rows > 0) {
  // output data of each row
  while($row = $result->fetch_assoc()) {
    echo "userid: " . $row["id"]. "/ username: " . $row["username"]. " " . "<br>";
  }
} else {
  echo "0 results";
}
$conn->close();
?>