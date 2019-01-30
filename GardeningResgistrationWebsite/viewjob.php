<?php
   session_start();
   IF(isset($_SESSION['username'])==FALSE){
   	echo
   "<script language='javascript'>
   		window.alert('You have not logged in!')</script>";
   		session_destroy();
   		echo "<script language='javascript'>window.location.href='index.php'</script>";
   		}      
   		?>
<!DOCTYPE html>
<html lang="en">
   <head>
      <title>Andy Gardening Services</title>
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
      <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
      <link rel="stylesheet" type="text/css" href="house.css">
   </head>
   <body>
      <?php
         $servername = "localhost" ;
         $username = "s42882_andy" ;
         $password = "gardening" ;
         $dbname = "andy" ;
         
         //create connection 
         $conn = new mysqli($servername, $username, $password, $dbname);
         
         //check connection
         if ($conn->connect_error) {
            die("Connection failed: " . $conn->connect_error);
         } 
         $job_id = $_POST["job_id"];
         
         $sql = "SELECT customer.customer_id, customer.forename, customer.surname, customer.email, customer.address, customer.postcode, customer.telephone_no, customer.mobile_no, 
         	job.job_id, job.job_description, job.job_date, job.job_time, job.job_cost
         	FROM customer, job
         	WHERE customer.customer_id = job.customer_id
         	AND job.job_id = '$job_id'";
         $result = ($conn -> query ($sql)) ; 
          if ($result->num_rows > 0) {
            while($row = $result->fetch_assoc()) { 
         ?>
      <div class="container-fluid">
         <div align="center" class="jumbotron">
            <div align="right" class="col-sm-12 col-md-12 col-lg-12">
               <a href="logout.php" onClick="return confirm('Are you sure you want to logout?');" class="btn btn-info">
               <span class="glyphicon glyphicon-log-out"></span> Log out
               </a>
            </div>
            <h1>View Job</h1>
         </div>
         <ul id="pager" class="pager">
            <li class="previous"><a href="home.php"><span class="glyphicon glyphicon-triangle-left"></span> Previous</a></li>
         </ul>
         <div class="empty col-sm-12 col-md-3 col-lg-3"></div>
         <div align="center" class="well well-sm content col-sm-12 col-md-6 col-lg-6">
            <table class="table table-bordered table-responsive">
               <thead>
                  <tr>
                     <th>Forename</th>
                     <td><?php echo $row["forename"]; ?></td>
                  </tr>
                  <tr>
                     <th>Surname</th>
                     <td><?php echo $row["surname"]; ?></td>
                  </tr>
                  <tr>
                     <th>Email</th>
                     <td><?php echo $row["email"]; ?></td>
                  </tr>
                  <tr>
                     <th>Address</th>
                     <td><?php echo $row["address"]; ?></td>
                  </tr>
                  <tr>
                     <th>Postcode</th>
                     <td><?php echo $row["postcode"]; ?></td>
                  </tr>
                  <tr>
                     <th>Telephone no</th>
                     <td><?php echo $row["telephone_no"]; ?></td>
                  </tr>
                  <tr>
                     <th>Mobile No</th>
                     <td><?php echo $row["mobile_no"]; ?></td>
                  </tr>
                  <tr>
                     <th>Job Description</th>
                     <td><?php echo $row["job_description"]; ?></td>
                  </tr>
                  <tr>
                     <th>Job Date</th>
                     <td><?php echo date('d/m/Y', strtotime($row['job_date'])); ?></td>
                  </tr>
                  <tr>
                     <th>Job Time</th>
                     <td><?php echo $row["job_time"]; ?></td>
                  <tr/>
                  <tr>
                     <th>Job Cost</th>
                     <td>£ <?php echo $row["job_cost"]; 
                        }
                        } 
                        $conn->close();?></td>
                  </tr>
               </thead>
            </table>
         </div>
      </div>
   </body>
</html>