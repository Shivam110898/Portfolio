<?php
session_start();
?>
<!DOCTYPE html>
<html>
<body>
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
//get Login form values
$username             = $_POST['username'];
$password             = $_POST['password'];
$_SESSION['username'] = $username;

//check if the Login form values match database
$sql    = "SELECT clientid , password FROM user WHERE clientid = '$username' AND password = '$password'";
$result = ($conn->query($sql));

//if the credentials don't match then show error message
IF ($result->num_rows == 0) {
    echo "<script language='javascript'>
		window.alert('The login credentials are incorrect!')
		window.location.href='index.php'
		exit();
</script>";
}
//else allow access
else {
    header("Location: home.php");
}
//close connnection
$conn->close();
?>
</body>
</html>
		
		
		
		
		
		
		