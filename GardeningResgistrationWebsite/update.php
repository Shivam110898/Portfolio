<?php
$servername = "localhost";
$username   = "s42882_andy";
$password   = "gardening";
$dbname     = "andy";

// Create connection
$conn = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
$job_id = $_POST["job_id"];
$sql    = "UPDATE job
		SET job_done = '1'
		WHERE job_id = '$job_id'";

if ($conn->query($sql) === TRUE) {
    header("Location: home.php");
} else {
    echo "Error updating record: " . $conn->error;
}

$conn->close();
?>