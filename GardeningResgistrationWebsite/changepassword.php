<?php
//session start
session_start();
//set database variables
$servername = "localhost";
$username   = "s42882_andy";
$password   = "gardening";
$dbname     = "andy";
// Create connection
$conn       = new mysqli($servername, $username, $password, $dbname);
// Check connection
if ($conn->connect_error) {
    die("Connection failed: " . $conn->connect_error);
}
//get the answer to the security question
$question = $_POST['question'];
//get the question from the database and see if it matches the input made by the user
$sql1     = "SELECT question FROM user WHERE question = '$question'";
$result   = ($conn->query($sql1));
//if not then display an error message
IF ($result->num_rows == 0) {
    echo "<script language='javascript'>
		window.alert('Your answer is incorrect!')
		window.location.href='recoverpassword.php'
		exit();
</script>";
//else change the password to new password entered by the user
} else {
    $change_Password = strtoupper($_POST['password']);
    $sql2            = "UPDATE user 
		SET password = '$change_Password'
		WHERE question = '$question'";
	//if the password is changed then show an success message
    if ($conn->query($sql2) === TRUE) {
        echo "<script language='javascript'>
		window.alert('The password has been changed')
		window.location.href='index.php'
		exit();
</script>";
	//else show an error message and redirect to Recover Password page
    } else {
        echo "<script language='javascript'>
		window.alert('The password could not be changed!')
		window.location.href='recoverpassword.php'
		exit();
</script>";
    }
}
//close connection
$conn->close();
?> 