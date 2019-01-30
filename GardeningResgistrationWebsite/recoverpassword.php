<?php
   session_start();
   ?>
<!DOCTYPE html>
<html lang="en">
   <head>
      <title>Andy</title>
      <meta charset="utf-8">
      <meta name="viewport" content="width=device-width, initial-scale=1">
      <link rel="stylesheet" href="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/css/bootstrap.min.css">
      <script src="https://ajax.googleapis.com/ajax/libs/jquery/1.11.3/jquery.min.js"></script>
      <script src="http://maxcdn.bootstrapcdn.com/bootstrap/3.3.5/js/bootstrap.min.js"></script>
      <link rel="stylesheet" type="text/css" href="house.css">
      <script>
         function validateForm(){
         	var pass = document.forms["myForm"]["password"].value;
         	var pass2 = document.forms["myForm"]["confirm"].value;
         	var question = document.forms["myForm"]["question"].value;
         if (pass !== pass2){
         	alert("Warning!! Passwords must match!!!");
            return false;
         }else if (pass.length < 6) {
                 alert("Password is too short");
         		return false;
             }else if (pass.length > 15) {
                 alert("Password is too long");
         			return false;
         				}else if (pass2.length < 6) {
         					alert("Password is too short");
         						return false;
         							}else if (pass2.length > 15) {
         								alert("Password is too long");
         									return false;
         								}
         }
      </script>
   </head>
   <body>
      <div class="container-fluid">
         <div class="jumbotron">
            <h1 align="center">Recover Password</h1>
         </div>
         <ul id="pager" class="pager">
            <li class="previous"><a href="index.php"><span class="glyphicon glyphicon-triangle-left"></span> Go back</a></li>
         </ul>
         <div class="row">
            <div class="empty col-sm-12 col-md-4 col-lg-4"></div>
            <div class="col-sm-12 col-md-4 col-lg-4">
               <form class="form-signin" name="myForm" id="myForm" method="post" action="changepassword.php" onsubmit="return validateForm()">
                  <div class="form-group">
                     <input type="text" name="question" id="question" placeholder="Answer your security question here!" class="form-control" required/>
                  </div>
                  <div class="form-group">
                     <input type="password" name="password" id="password" placeholder="New Password" class="form-control" required/>
                  </div>
                  <div class="form-group">
                     <input type="password" name="confirm" id="confirm" placeholder="Confirm Password" class="form-control" required />
                  </div>
                  <div align="center" class="form-group">
                     <button  class="sub btn btn-submit" type="submit" >Save  <span class="glyphicon glyphicon-check"></span> </button>
                  </div>
               </form>
            </div>
         </div>
      </div>
   </body>
</html>
