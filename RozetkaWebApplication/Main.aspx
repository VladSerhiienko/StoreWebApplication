<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="Main.aspx.cs" Inherits="RozetkaWebApplication.Main" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="RozetkaWebApplication" %>
<!DOCTYPE html>
<html lang="en" class="no-js">
	<head>
		<meta charset="UTF-8" />
		<meta http-equiv="X-UA-Compatible" content="IE=edge"> 
		<meta name="viewport" content="width=device-width, initial-scale=1"> 
		<title>ROZETKA | TarasTeslyuk | Labworks</title>
        <meta name="description" content="ROZETKA: Inspiration for cell phones" />
		<meta name="keywords" content="inspiration, grid, thumbnail, transition, subtle, web design, rozetka, cell, phone, art, inspiration" />
		<meta name="author" content="Taras Teslyuk" />
		<link rel="shortcut icon" href="../favicon.ico">
		<link href='http://fonts.googleapis.com/css?family=Raleway:400,800,500,600' rel='stylesheet' type='text/css'>
		<link rel="stylesheet" type="text/css" href="css/normalize.css" />
		<link rel="stylesheet" type="text/css" href="css/demo.css" />
		<link rel="stylesheet" type="text/css" href="css/set2.css" />
		<link rel="stylesheet" type="text/css" href="fonts/font-awesome-4.2.0/css/font-awesome.min.css" />
		<!--[if IE]>
  		<script src="http://html5shiv.googlecode.com/svn/trunk/html5.js"></script>
		<![endif]-->
	</head>
	<body>
        <div class="container">
            <div class="codrops-top clearfix">
                <a class="codrops-icon codrops-icon-prev" href="mailto:teslyukt@gmail.com"><span>Feedback</span></a>
                <span class="right">
                </span>
            </div>
            <header class="codrops-header">
                <h1>ROZETKA <span>An inspirational collection of cell phone art</span></h1>
            </header>
            <div class="content">
                    <% Response.Write(RozetkaDatabase.CompileToHtml(RozetkaDatabase.SelectItems())); %>
            </div>
            <section class="related">
                <h3>Taras Teslyuk </h3>
                <p><strong>Labworks 1-4</strong></p>
            </section>
        </div><!-- /container -->
		<script>
			// For Demo purposes only (show hover effect on mobile devices)
			[].slice.call( document.querySelectorAll('a[href="#"') ).forEach( function(el) {
				el.addEventListener( 'click', function(ev) { ev.preventDefault(); } );
			} );
		</script>
	</body>
</html>
