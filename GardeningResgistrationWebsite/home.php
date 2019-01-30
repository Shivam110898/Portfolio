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
         $servername = "localhost";
         $username = "s42882_andy";
         $password = "gardening";
         $dbname = "andy";
         
         // Create connection
         $conn = new mysqli($servername, $username, $password, $dbname);
         // Check connection
         if ($conn->connect_error) {
             die("Connection failed: " . $conn->connect_error);
         } 
         ?>
      <div class="container-fluid">
         <div align="center" class="jumbotron">
            <div align="right" class="col-sm-12 col-md-12 col-lg-12">
               <a href="logout.php" onClick="return confirm('Are you sure you want to logout?');" class="btn ">
               <span class="glyphicon glyphicon-log-out"></span> Log out
               </a>
            </div>
            <h1>Andy Gardening Services</h1>
         </div>
         <div class="row col-sm-12 col-md-12 col-lg-12">
            <div class="well well-sm col-sm-12 col-md-7 col-lg-7">
               <div align="right" class="date"><strong><?php echo "Today's Date: " . date("d/m/Y") . "<br>";?></strong></div>
               <div align="center" class="upcoming-jobs ">
                  <h3>Upcoming Jobs</h3>
                  <table class="table table-responsive">
                     <thead>
                        <tr>
                           <th>Customer ID</th>
                           <th>Name</th>
                           <th>Job</th>
                           <th>Date</th>
                           <th>Time</th>
                           <th>Options</th>
                        </tr>
                     </thead>
                     <tbody>
                        <?php
                           $sql= "SELECT job.customer_id, job.job_id, customer.customer_id, customer.forename, job.job_description, job.job_time, job.job_Date
                                 FROM customer, job
                              WHERE job.customer_id = customer.customer_id
                           	AND job.job_done = '0'
                              ORDER BY job.job_Date, job.job_time
                              limit 10
                              ";
                           	$result = $conn->query($sql);
                           
                           	if ($result->num_rows > 0) {
                              while($row = $result->fetch_assoc()) {
                                  echo "<tr>
                           	<td>".$row["customer_id"]."</td>
                           	<td>".$row["forename"]."</td>
                           	<td>".$row["job_description"]."</td>
                           	<td>".date('d/m/Y', strtotime($row['job_Date']))."</td>
                           	<td>".$row["job_time"]."</td>
                           	<td><div class='dropdown'>
                           			<button class='btn dropdown-toggle' type='button' data-toggle='dropdown'>
                           				<span class='glyphicon glyphicon-menu-hamburger'></span></button>
                           					<ul class='dropdown-menu dropdown-menu-right'>
                           					<li><form action='update.php' method='post'>
                           							<button type='submit'  style='width: 100%;' class='btn btn-submit'> 
                           								<span class='glyphicon glyphicon-check'></span>   Job Done
                           							</button>
                           							<input type='hidden' name='job_id' value='".$row['job_id']."'>
                           						</form>
                           					</li>
                           					<li><form action='viewjob.php' method='post'>
                           							<button type='submit' style='width: 100%;' class='btn btn-submit'> 
                           								<span class='glyphicon glyphicon-sunglasses'></span>   View Job
                           							</button>
                           							<input type='hidden' name='job_id' value='".$row['job_id']."'>
                           						</form>
                           						</li>
                           					</ul>
                           		</div>
                           	<td></tr>";
                              }
                           } 
                           ?>  
                     </tbody>
                  </table>
                  <button type="button" class="btn btn-submit " data-toggle="modal" data-target="#myModal">
                  <span class='glyphicon glyphicon-plus'></span>  Add Job</button>
                  <!-- Modal -->
                  <div class="modal fade" id="myModal" role="dialog">
                     <div class="modal-dialog">
                        <!-- Modal content-->
                        <div class="modal-content">
                           <div class="modal-header">
                              <button type="button" class="close" data-dismiss="modal">&times;</button>
                              <h4 align="center" class="modal-title">Add New Job</h4>
                           </div>
                           <div class="modal-body">
                              <form id="myform" action="addnewjob.php" method="post">
                                 <div class="form-group" >
                                    <input type="text" class="form-control" id="fname" name="forename" placeholder="Forename" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="text" class="form-control" id="sname" name="surname" placeholder="Surname" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="email" class="form-control" id="mail" name="email" placeholder="Email" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="text" class="form-control" id="adrs" name="address" placeholder="Address" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="text" class="form-control" id="pcode" name="postcode" placeholder="Postcode" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="text" class="form-control" id="t_no" name="t_no" placeholder="Telephone No.">
                                 </div>
                                 <div class="form-group">
                                    <input type="text" class="form-control" id="m_no" name="m_no" placeholder="Mobile No." required>
                                 </div>
                                 <div class="form-group">
                                    <input type="text" class="form-control" id="j_description" name="job_description" placeholder="Job Description" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="date" class="form-control" id="date" name="jobDate" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="text" class="form-control" id="j_cost" name="job_cost" placeholder="Job Cost" required>
                                 </div>
                                 <div class="form-group">
                                    <input type="time" class="form-control" id="j_time" name="job_time" required>
                                 </div>
                                 <button type="submit" class="btn btn-default">Submit</button>
                              </form>
                           </div>
                           <div class="modal-footer">
                              <button type="button" class="btn btn-default" data-dismiss="modal">Close</button>
                           </div>
                        </div>
                     </div>
                  </div>
               </div>
            </div>
            <div class="well well-sm col-sm-12 col-md-5 col-lg-5">
               <div align="center" class="completed-jobs">
                  <h3>Completed Jobs</h3>
                  <table class="table table-responsive">
                     <thead>
                        <tr>
                           <th>Customer ID</th>
                           <th>Name</th>
                           <th>Job</th>
                           <th>Options</th>
                        </tr>
                     </thead>
                     <tbody>
                        <?php
                           $sql= "SELECT job.customer_id, job.job_id,  customer.customer_id, customer.forename, customer.surname, job.job_description
								  FROM customer, job
								  WHERE job.customer_id = customer.customer_id
								  AND job.job_done = '1'
								  AND invoice_created = '0'
								  ORDER BY customer.customer_id asc
								  Limit 10";
                           $result = $conn->query($sql);
                           
                           if ($result->num_rows > 0) {
                           while($row = $result->fetch_assoc()) {
                            echo "<tr>
                           <td>".$row["customer_id"]."</td>
                           <td>".$row["forename"]."</td>
                           <td>".$row["job_description"]."</td>
                           <td>
								<div class='dropdown'>
									<button class='btn dropdown-toggle' type='button' data-toggle='dropdown'>
										<span class='glyphicon glyphicon-menu-hamburger'></span>
									</button>
										<ul class='dropdown-menu dropdown-menu-right'>
											<li>
												<form action='createinvoice.php' method='post'>
													<button type='submit' style='width: 100%;' class='btn btn-submit'> 
														<span class='glyphicon glyphicon-pencil'></span>   Create Invoice
													</button>
													<input type='hidden' name='job_id' value='".$row['job_id']."'>
												</form>
											</li>
											<li>
												<form action='viewjob.php' method='post'>
													<button type='submit' style='width: 100%;' class='btn btn-submit'> 
														<span class='glyphicon glyphicon-sunglasses'></span>   View Job
													</button>
													<input type='hidden' name='job_id' value='".$row['job_id']."'>
												</form>
											</li>
										</ul>
								</div>
                           </td>
                           </tr>";
                           }
                           } 
                           ?>   
                     </tbody>
                  </table>
               </div>
            </div>
         </div>
         <div class="row col-sm-12 col-md-12 col-lg-12">
            <div class="well col-sm-12 col-md-12 col-lg-12">
               <div  align="center" class="existing-jobs">
                  <h3>Existing Customers</h3>
                  <table class="table table-responsive">
                     <thead>
                        <tr>
                           <th>Customer ID</th>
                           <th>Forename</th>
                           <th>Surname</th>
                           <th>New Job</th>
                        </tr>
                     </thead>
                     <tbody>
                        <?php
                           $sql = "SELECT customer.customer_id, customer.forename, customer.surname
								   FROM customer
								   ORDER BY customer_id ASC";
                           $result = $conn->query($sql);             
                           while($row = $result->fetch_assoc()) {
                            echo 
							"<tr>
								<td>".$row["customer_id"]."</td>
								<td>".$row["forename"]."</td>
								<td>".$row["surname"]."</td>
								<td>
									<div class='dropup' name='dropdown'>
										<button class='btn dropdown-toggle' type='button' data-toggle='dropdown'>
											<span class='glyphicon glyphicon-plus'></span>
										</button>
											<ul class='dropdown-menu dropdown-menu-right'>
												<li>
													<div class='dropup-content'>
														<div class='dropup-header'>
															<button type='button' class='close' data-dismiss='modal'>&times;</button>
																<h4 align='center' class='modal-title'>Add New Job for Existing Customer</h4>
															</div>
														<div class='modal-body'>
															<form name='newform' action='addnewjobModal.php' method='post' onsubmit='return validateForm()'>
																<div class='form-group'>
																	<input type='text' class='form-control' id='j_description' name='job_description' placeholder='Job Description'>
																</div>	
																<div class='form-group'>
																	<input type='date' class='form-control' id='date' name='jobDate' required>
																</div>	
																<div class='form-group'>
																	<input type='text' class='form-control' id='j_cost' name='job_cost' placeholder='Job Cost' required>
																</div>
																<div class='form-group'>
																	<input type='time' class='form-control' id='j_time' name='job_time' required>
																</div>
																<button align='center' type='submit' class='btn btn-default'>Submit</button>
																<input type='hidden' name='customer_id' value='".$row['customer_id']."'>
															</form>
														<div class='modal-footer'>
															<button type='button' class='btn btn-default' data-dismiss='modal'>Close</button>
														</div>
													</div>
												</li>
											</ul>
									</div>
								</td>
						   </tr>";
                           }
                           ?>   
                     </tbody>
                  </table>
               </div>
            </div>
         </div>
      </div>
   </body>
</html>