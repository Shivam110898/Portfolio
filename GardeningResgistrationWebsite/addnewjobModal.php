<?php
//set database variables
$servername = "localhost";
$username   = "s42882_andy";
$password   = "gardening";
$dbname     = "andy";

//create connection 
$conn = new mysqli($servername, $username, $password, $dbname);

//check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
//get new job form values
$customer        = $_POST["customer_id"];
$job_description = $_POST['job_description'];
$job_date        = $_POST['jobDate'];
$job_time        = $_POST['job_time'];
$job_cost        = $_POST['job_cost'];

//SQL statement to insert new job in the 'job table'
$sql2 = "INSERT INTO job (job_description, job_date, job_time, job_cost, customer_id)
		VALUES ('$job_description','$job_date','$job_time','$job_cost','$customer')";
//if query is successfull then redirect to the home page
if ($conn->query($sql2) === TRUE) {
    header("Location: home.php");
}
//else show error message
else {
    echo "Error: " . $sql2 . "<br>" . $conn->error;
}
//close connection
$conn->close();
?>