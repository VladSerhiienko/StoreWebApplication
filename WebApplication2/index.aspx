<%@ Page Language="C#" AutoEventWireup="true" CodeBehind="index.aspx.cs" Inherits="StoreWebApplication.WebApp" %>
<%@ Import Namespace="System.Diagnostics" %>
<%@ Import Namespace="StoreWebApplication" %>

<!DOCTYPE html>

<html>
<head lang="en">
    <meta charset="UTF-8" />
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <title>Sports & Hobbies</title>
    <meta name="description" content="Sports & Hobbies: Winners never quit and quitters never win" />
    <meta name="keywords" content="sport, hobby, inspiration, web design, css, modern, effects, svg" />
    <meta name="author" content="Vlad Serhiienko" />
    <link rel="shortcut icon" href="../favicon.ico">
    <link rel="stylesheet" type="text/css" href="css/normalize.css" />
    <link rel="stylesheet" type="text/css" href="css/demo2.css" />
    <link rel="stylesheet" type="text/css" href="css/tabs.css" />
    <link rel="stylesheet" type="text/css" href="css/tabstyles.css" />
    <link rel="stylesheet" type="text/css" href="css/component.css" />
    <script src="js/modernizr.custom.js"></script>
    <script src="js/modernizr.custom.sum.js"></script>
    <script src="js/masonry.pkgd.min.js"></script>
    <script src="js/imagesloaded.pkgd.min.js"></script>
    <script src="js/classie.js"></script>
    <script src="js/colorfinder-1.1.js"></script>
    <script src="js/gridScrollFx.js"></script>
    <script src="js/dynamicTabs.js"></script>
</head>
<body>

<script>

    var storeSections = {
        electronics: "electronics",
        multimedia: "multimedia",
        clothing: "clothing",
        toys: "toys",
        all: "all",
    };

    Object.freeze(storeSections);
    function sectionClicked(section) {
        var storeUrl = window.location.protocol + '//' + window.location.host + window.location.pathname + '?store-item-kind=' + section;
        window.location.assign(storeUrl);
    }

</script>

<div class="container">
    <header class="codrops-header">
        <h1>Sports & Hobbies Issues<span>Winners never quit and quitters never win</span></h1>
        <p class="support">Your browser does not support <strong>flexbox</strong>! <br />Please view this demo with a <strong>modern browser</strong>.</p>
    </header>
    <section>
        <div class="tabs tabs-style-linetriangle">
            <nav>
                <ul>
                    <li <% Response.Write(StoreDatabase.HtmlSectionDesc(Request, 1)); %>><a href="#section-linetriangle-1" onclick="sectionClicked(storeSections.all)"><span>All Products</span></a></li>
                    <li <% Response.Write(StoreDatabase.HtmlSectionDesc(Request, 2)); %>><a href="#section-linetriangle-2" onclick="sectionClicked(storeSections.electronics)"><span>Electronics</span></a></li>
                    <li <% Response.Write(StoreDatabase.HtmlSectionDesc(Request, 3)); %>><a href="#section-linetriangle-3" onclick="sectionClicked(storeSections.clothing)"><span>Clothing</span></a></li>
                    <li <% Response.Write(StoreDatabase.HtmlSectionDesc(Request, 4)); %>><a href="#section-linetriangle-4" onclick="sectionClicked(storeSections.multimedia)"><span>Multimedia</span></a></li>
                    <li <% Response.Write(StoreDatabase.HtmlSectionDesc(Request, 5)); %>><a href="#section-linetriangle-5" onclick="sectionClicked(storeSections.toys)"><span>Toys</span></a></li>
                </ul>
            </nav>
            <div class="content-wrap">
                <section <% Response.Write(StoreDatabase.HtmlSectionContainerDesc(Request, 1)); %>><p>All Products</p></section>
                <section <% Response.Write(StoreDatabase.HtmlSectionContainerDesc(Request, 2)); %>><p>Electronics</p></section>
                <section <% Response.Write(StoreDatabase.HtmlSectionContainerDesc(Request, 3)); %>><p>Clothing</p></section>
                <section <% Response.Write(StoreDatabase.HtmlSectionContainerDesc(Request, 4)); %>><p>Multimedia</p></section>
                <section <% Response.Write(StoreDatabase.HtmlSectionContainerDesc(Request, 5)); %>><p>Toys</p></section>
            </div>
        </div>
    </section>

    <section class="grid-wrap">
        <ul class="grid swipe-rotate" id="grid">
            <% Response.Write(StoreDatabase.CompileToHtml(Request)); %>
        </ul>
    </section>

    
    <section class="codrops-header">
        <h1>Prime Factorization<span>Server generates the random number and extracts its prime factors</span></h1>
        <% Response.Write(PrimeFactorizer.CompileToHtmlRandom()); %>
    </section>
    <section class="related">
        <h1>Vlad Serhiienko</h1> 
    </section>
</div>
<script>
    new GridScrollFx( document.getElementById('grid'), { viewportFactor : 0.4 });
    (function() { [].slice.call(document.querySelectorAll('.tabs')).forEach(function(el) { new CBPFWTabs(el); }); })();
</script>
</body>
</html>