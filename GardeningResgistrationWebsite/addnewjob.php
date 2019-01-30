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
$fname           = $_POST['forename'];
$sname           = $_POST['surname'];
$email           = $_POST['email'];
$address         = $_POST['address'];
$pcode           = $_POST['postcode'];
$tel_no          = $_POST['t_no'];
$mob_no          = $_POST['m_no'];
$job_description = $_POST['job_description'];
$job_date        = $_POST['jobDate'];
$job_time        = $_POST['job_time'];
$job_cost        = $_POST['job_cost'];

//SQL statement to insert the customer details in the 'customer' table
$sql1 = "INSERT INTO customer (forename, surname, email, address, postcode, telephone_no, mobile_no)
        VALUES ('$fname','$sname','$email','$address','$pcode','$tel_no','$mob_no');";
$conn->query($sql1);
//Get the 'id' of the last customer inserted into the 'customer' table
$sql3   = "	SELECT customer_id 
		FROM customer
        ORDER BY customer_id DESC
        LIMIT 1;";
$result = $conn->query($sql3);

$row		 = $result->fetch_assoc();
$customer_id = $row['customer_id'];
//SQL statement to insert the job details for the customer in the 'job' table
$sql2        = "INSERT INTO job (job_description, job_date, job_time, job_cost, customer_id)
				VALUES ('$job_description','$job_date','$job_time','$job_cost','$customer_id')";

//if the query is successful then redirect back to the home page
if ($conn->query($sql2) === TRUE) {
    header("Location: home.php");
}
//else show an error message
else {
    echo "Error: " . $sql . "<br>" . $conn->error;
}
//close connection
$conn->close();
?>