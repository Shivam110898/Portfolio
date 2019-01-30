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
      <script type="text/javascript">
         function printPage() {
             //Get the print button and put it into a variable
             var printButton = document.getElementById("printButton");
         var pager = document.getElementById("pager");
             //Set the print button visibility to 'hidsden' 
             printButton.style.visibility = 'hidden';
         pager.style.visibility = 'hidden';
             //Print the page content
             window.print()
             //Set the print button to 'visible' again 
             printButton.style.visibility = 'visible';
         pager.style.visibility = 'visible';
         
         }
      </script>
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
         
         $sql1 = "UPDATE job
         	SET invoice_created = '1'
         	WHERE job_id = '$job_id'"; 
         	$conn->query($sql1);
         	
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
         <ul id="pager" class="pager">
            <li class="previous"><a href="home.php"><span class="glyphicon glyphicon-triangle-left"></span> Previous</a></li>
         </ul>
         <button id="printButton" class="pull-right btn btn-info" onclick="printPage()"><span class="glyphicon glyphicon-print"></span> Print</button>
         <div class="row heading">
            <div align="center" class="col-sm-12 col-md-5 col-lg-5">
               <address>
                  <strong>
                     <h3>Andy Gardening Services</h3>
                  </strong>
                  <h4>29 Southfield Rd</h4>
                  <h4>Huddersfield</h4>
                  <h4>HD5 8SA </h4>
                  <h4>07846 767800</h4>
               </address>
            </div>
         </div>
         <div class="content col-sm-12 col-md-12 col-lg-12">
            <div align="right" class="boxed"><?php echo "Date: " . date("d/m/Y") . "<br>";?></div>
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
         <div align="right" class="col-sm-12 col-md-12 col-lg-12">
            <p>Andrew Lindsay</p>
            <p>Owner of Andy Gardening Services</p>
            <p>_________________________________ </p>
            <strong>Thankyou for your business!</strong>
         </div>
         <div align="left" class="col-sm-12 col-md-12 col-lg-12">
            <span style="padding-bottom:20px"> 
            <br>
            <p><i>*Please provide the payment within 15 days of recieving this invoice</i></p>
            <p><i>*Make the payment using check or cash</i></p>
         </div>
      </div>
   </body>
</html>