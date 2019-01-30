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
   </head>
   <body>
      <!--Wrapper-->
      <div class="container-fluid">
         <!--Header-->
         <div class="jumbotron">
            <h1 align="center">Login</h1>
         </div>
         <!--Contents-->
         <div class="row">
            <div class="col-sm-12 col-md-4 col-lg-4 col-md-offset-4 col-lg-offset-4">
               <!--Login form-->
               <form class="form-signin" name="myform" method="post" action="loginvalidation.php">
                  <div class="form-group">
                     <input type="text" name="username" placeholder="Username" class="form-control" required/>
                  </div>
                  <div class="form-group">
                     <input type="password" name="password" placeholder="**********" class="form-control" required/>
                  </div>
                  <div align="center" class="form-group">
                     <button  class="sub btn btn-submit" type="submit" >Login  <span class="glyphicon glyphicon-log-in"></span> </button>
                  </div>
                  <div align="center" class="form-group">
                     <a href="recoverpassword.php" class="sub btn btn-submit">Recover your password  <span class="glyphicon glyphicon-edit"></span></a>
                  </div>
               </form>
            </div>
         </div>
      </div>
   </body>
</html>