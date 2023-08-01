<%@ Page Language="C#" AutoEventWireup="true" Inherits="preview_dotnet_templates_the_big_picture_index" Codebehind="index.aspx.cs" %>

<!DOCTYPE html PUBLIC "-//W3C//DTD XHTML 1.0 Transitional//EN" "http://www.w3.org/TR/xhtml1/DTD/xhtml1-transitional.dtd">

<html xmlns="http://www.w3.org/1999/xhtml">
<head runat="server">
    <meta charset="utf-8">
    <meta http-equiv="X-UA-Compatible" content="IE=edge">
    <meta name="viewport" content="width=device-width, initial-scale=1">
    <meta name="description" content="">
    <meta name="author" content="Srikanth">
    <title>EvitaSoftSolution</title>
    <!-- Bootstrap Core CSS -->
    <link href="css/bootstrap.min.css" rel="stylesheet">
    <!-- Custom CSS -->
    <link href="css/the-big-picture.css" rel="stylesheet">
    <link href="css/font-icon.css" rel="stylesheet" type="text/css" />
    <link href="css/jquery.fancybox.css" rel="stylesheet" type="text/css" />
    <link href="css/flexslider.css" rel="stylesheet" type="text/css" />
    <link href="css/main.css" rel="stylesheet" type="text/css" />
    <link href="css/responsive.css" rel="stylesheet" type="text/css" />
    <link href="css/animate.min.css" rel="stylesheet" type="text/css" />
    <!-- ============ Google fonts ============ -->
    <link href='http://fonts.googleapis.com/css?family=EB+Garamond' rel='stylesheet'
        type='text/css' />
    <link href='http://fonts.googleapis.com/css?family=Open+Sans:400,600,700,300,800'
        rel='stylesheet' type='text/css' />
    <link rel="stylesheet" href="https://maxcdn.bootstrapcdn.com/font-awesome/4.5.0/css/font-awesome.min.css">
    <!-- HTML5 Shim and Respond.js IE8 support of HTML5 elements and media queries -->
    <!-- WARNING: Respond.js doesn't work if you view the page via file:// -->
    <!--[if lt IE 9]>
        <script src="https://oss.maxcdn.com/libs/html5shiv/3.7.0/html5shiv.js"></script>
        <script src="https://oss.maxcdn.com/libs/respond.js/1.4.2/respond.min.js"></script>
    <![endif]-->
</head>
<body id="hme">
    <form id="form1" runat="server">
    <div id="custom-bootstrap-menu" class="navbar navbar-default navbar-fixed-top" role="navigation">
        <div class="container">
            <div class="navbar-header page-scroll">
                <a class="navbar-brand" href="#">EvitaSoftSolution</a>
                <button type="button" class="navbar-toggle" data-toggle="collapse" data-target=".navbar-menubuilder">
                    <span class="sr-only">Toggle navigation</span><span class="icon-bar"></span><span
                        class="icon-bar"></span><span class="icon-bar"></span>
                </button>
            </div>
            <div class="collapse navbar-collapse navbar-menubuilder">
                <ul class="nav navbar-nav navbar-right">
                    <li><a class="page-scroll" href="#hme">Home</a> </li>
                    <li><a class="page-scroll" href="#services">Services</a> </li>
                    <li><a class="page-scroll" href="#intro">About Us</a> </li>
            
                    <li><a class="page-scroll"href= '<%=ResolveUrl("~/login") %>'><span class="glyphicon glyphicon-log-in"></span>  Login</a> </li>
                </ul>
            </div>
        </div>
    </div>
    <!-- Login -->
    <!-- Start Carousel Main Slider -->
    <section class="carousel carousel-fade slide home-slider" id="fullslider" data-ride="carousel"
        data-interval="4500" data-pause="false"> 
    <!-- Carousel-Indicators -->
	<ol class="carousel-indicators"> 
		<li data-target="#fullslider" data-slide-to="0" class="active"></li>
		<li data-target="#fullslider" data-slide-to="1" class=""></li>		
        <li data-target="#fullslider" data-slide-to="2" class=""></li>		
        <li data-target="#fullslider" data-slide-to="3" class=""></li>	    	
	</ol>
    <!-- Carousel-Inner -->
	<div class="carousel-inner"> 
		<div class="item active bg1">
         <div class="banner-overlay">
         <!-- Slide - 1 -->
			<div class="container">
				<div class="row">			
					<div class="col-md-6 col-sm-8 col-xs-12 animated notranstion">						
						<br class="hidden-sm hidden-xs"/>
					
                      <div class="wow" data-wow-duration="1500ms" data-wow-delay="100ms">
                        <h1 class="carouselText1 text-left wow fadeInUp" data-wow-duration="1000ms" data-wow-delay="150ms">Welcome to EVITASOFTSOLUTION</h1>
						  <p class="wow fadeInUp" data-wow-duration="1000ms" data-wow-delay="200ms">
                            EvitaSoftSolution is software development company based in Mumbai, India. specialising in custom software development, web design and development and specialized in Gas Agencies Solutions.
                          </p>
                            <br/>
                           <div class="text-left buttonleft hidden-xs">
                           <a href="#" class="btn btn-lg btn-borderwhite wow fadeInUp" data-wow-duration="1500ms" data-wow-delay="1200ms">Get Started</a> 
                           </div>
                      </div>
                      						
					</div>
                    <div class="col-md-6 col-sm-4 hidden-xs animated">                                      
							<img src="img/slider/slide1-1.png" alt="" class="slide1-1 wow  fadeInRight"/>
					</div>
				</div>
			</div>
            </div>
		</div> <!-- End Slide - 1 -->
		<div class="item bg2">
          <div class="banner-overlay">
         <!-- Slide - 2 -->
			<div class="container">
				<div class="row">
					<div class="col-md-6 col-sm-4 hidden-xs animated">                                      
						<img src="img/slider/slide1-1.png" alt="" class="slide1-2 wow fadeInLeft img-responsive"/>
					</div>
					<div class="col-md-6 col-sm-8 col-xs-12 animated text-right">	
                         <br class="hidden-sm hidden-xs" />					
					    <h3 class="carouselText2 wow fadeInDown" data-wow-duration="600ms" data-wow-delay="100ms">
                         Work smart with us
                        </h3>
                    	<br />
						<div class="car-highlight1 wow fadeInUp text-left" data-wow-duration="300ms" data-wow-delay="0ms">
						 Provides results which meets your requirement!
						</div>
						<br/>
						<div class="car-highlight2 wow fadeInUp" data-wow-duration="1200ms" data-wow-delay="150ms">
						 Save your Time to improve your services.
						</div>
						<br/>
						<%--<div class="car-highlight3 wow fadeInUp" data-wow-duration="1800ms" data-wow-delay="300ms">
						 we deliver solutions that offer high levels of consistency in quality and performance.
						</div>--%>                       
					</div>
				</div>
			</div>
            </div>
		</div> <!-- End Slide - 2 -->
		<div class="item bg3">
          <div class="banner-overlay">
         <!-- Slide - 3 -->
			<div class="container">
				<div class="row">
					<div class="col-md-12 text-center animated">      
                    <h1 class="carouselText1 wow fadeInUp" data-wow-duration="1000ms" data-wow-delay="150ms">Our Vision</h1>
                       <ul class="list-unstyled car-mediumtext2">                        
                        <li>
                        <h3 class="car-highlight1 wow fadeInDown" data-wow-duration="1200ms" data-wow-delay="300ms">
                        Contributig in client's Success
                        </h3>
                        </li>
                        <li>
                        <h3 class="car-highlight2 hidden-xs wow fadeInDown" data-wow-duration="1800ms" data-wow-delay="600ms">
                        Increase Productivity
                        </h3>
                        </li>                       
                        <li>
                        <h3 class="car-highlight3 wow fadeInDown" data-wow-duration="2400ms" data-wow-delay="900ms">
                        Quality Deliverable
                        </h3>
                        </li>
                       </ul>
					</div>					
				</div>
			</div>
            </div>
		</div> <!-- End Slide - 3 -->
       <div class="item bg4"> <!-- Slide - 4 -->
         <div class="banner-overlay">
          <div class="container">
				<div class="row">
                    <div class="col-md-6 col-sm-4  hidden-xs animated">                                      
						<%--<img src="img/slider/slide1-1.png" alt="" class="slide1-2 wow fadeInLeft img-responsive"/>--%>
					</div>
                    <div class="col-md-6 col-sm-8 col-xs-12 animated">					
						<div class="wow" data-wow-duration="1500ms" data-wow-delay="100ms">
                         <br />
							<h1 class="carouselText1 col-gapall wow zoomIn" data-wow-duration="1500ms" data-wow-delay="500ms">LET’S INVENT A BETTER FUTURE TOGETHER.</h1>
							<br />
                            <ul class="list-unstyled car-mediumtext">
                            <li class="wow fadeInRight" data-wow-duration="1500ms" data-wow-delay="100ms"><i class="fa fa-check-square wow fadeInDown" data-wow-duration="1500ms" data-wow-delay="100ms"></i>We value and expect integrity in all that we do.</li>
                            <li class="wow fadeInRight" data-wow-duration="1500ms" data-wow-delay="500ms"><i class="fa fa-check-square wow fadeInDown" data-wow-duration="1500ms" data-wow-delay="100ms"></i>
                              We recognize that the foundation of our growth and success is making each and every client project a success.

                            </li>
                            <li class="wow fadeInRight" data-wow-duration="1500ms" data-wow-delay="1000ms"><i class="fa fa-check-square wow fadeInDown" data-wow-duration="1500ms" data-wow-delay="100ms"></i>
                             Our specialty lies in helping organizations to use their product or business effectively, in a way that supports their overall goals and strategic priorities.
                            </li>
                            </ul>
                            <br />                         
						</div>						
					</div>		
                </div>
           </div>
           </div>
        </div> <!-- End Slide - 4 -->		 
	</div>
	<!-- End Carousel-Inner -->
    <!-- Carousel - Control -->
	<a class="left carousel-control animated fadeInLeft" href="#fullslider" data-slide="prev"><i class="fa fa-chevron-left"></i></a>
	<a class="right carousel-control animated fadeInRight" href="#fullslider" data-slide="next"><i class="fa fa-chevron-right"></i></a>	
    </section>
    <!--  End Carousel Main Slider  -->
    <!-- services section -->
    <section id="services" class="services service-section">
  <div class="container">
    <div class="row">
      <div class="col-md-4 col-sm-6 services"> <span  class="icon icon-tools"></span>
        <div class="services-content">
          <h5>Website Design & Hosting</h5>
          <p>EvitaSoftSolution is expert in Website Design providing wings to your ideas and dreams. With our cost effective and value added website designing and development services, we have managed to gain the faith of our clients who are from varied domains both in the domestic and international market.</p>
        </div>
      </div>
      <div class="col-md-4 col-sm-6 services"> <span class="icon icon-briefcase"></span>
        <div class="services-content">
          <h5>Custom Software Development</h5>
          <p> Whether you are a start-up or an established business, we are ready to assist you at every stage of the software development life cycle — from conceptualization and consulting to development and support.</p>
        </div>
      </div>
       <div class="col-md-4 col-sm-6 services"> <span class="icon icon-trophy"></span>
        <div class="services-content">
          <h5>Customer Support</h5>
         <p>We are here to develop long term relationships with our clientele. Falcon-Software is always prepared to help when focus shifts from one priority to the next.</p>
        </div>
      </div>
     
    </div>
  </div>
</section>
    <!-- services section -->
    <!-- about section -->
    <section id="intro" class="section intro no-padding">
  <div class="container-fluid">
    <div class="row no-gutter">
      <div class="flexslider">
        <ul class="slides">
          <li>
            <div class="col-md-6">
              <div class="avatar"> <img src="img/intro-img1.jpg" alt="" class="img-responsive"> </div>
            </div>
            <div class="col-md-6">
              <blockquote>
                <h1>About Evita Soft Solution</h1>
                <p>Evita Soft Solution is a professional Software development and web designing company based at Mumbai, India. Evita Soft Solution greatest strength has been our ability to share skills and creativity with our clients. Our working culture thrives on differences, but our people share a number of essential qualities. Our workforce is exceptionally diverse. Our expert web designers and development personel ensures that you get a search engine friendly, aesthetically appealing and user friendly website. We start with your given parameters and work till your satisfaction.our team comprises of skilled professionals having experience working with a variety business segments.</p>
                <%--<p>We possess the best team of skilled Software Development Professionals and Creative Designer who constantly work with clients to meet their strategic objectives by providing high-quality, technology driven solutions and creative designs.</p>--%>
              </blockquote>
            </div>
          </li>
          <li>
            <div class="col-md-6">
              <div class="avatar"> <img src="img/intro-img2.jpg" alt="" class="img-responsive"> </div>
            </div>
            <div class="col-md-6">
              <blockquote>
                <h1>Our Digital Dreems </h1>
                 <p>We listen to our customers and work with them to invent a better future on our Digital Business Platform—together. We are committed to customer outcomes, not just ideas. We help customers achieve results that exceed their expectations.Our customers' success is our success. We put customers first. Always.</p>
                <%--<p> We know software. You know your business. Together, we can achieve great things. Count on us to be a reliable business partner—financially sound, globally connected and completely dedicated to your digital transformation.</p>             --%>
              </blockquote>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</section>
    <!-- about section -->
    <!-- Work -->
    <!-- works -->
    <div id="work" class="works">
        <div class="row">
            <div class="col-sm-5 wowload fadeInLeft">
                <div class="spacer1">
                    <h2>
                        Why us ?</h2>
                    <ul>
                        <li><i class="fa fa-check"></i>High Customer Satisfaction</li>
                        <li><i class="fa fa-check"></i>Quality Project Delivery</li>
                        <li><i class="fa fa-check"></i>Transparent Development Process</li>
                        <li><i class="fa fa-check"></i>We Use The Latest Technology</li>
                        <li><i class="fa fa-check"></i>Excellent Customer Support</li>
                    </ul>
                </div>
            </div>
            <div class="col-sm-7 wowload fadeInRight">
                <div id="carousel-works" class="carousel slide" data-ride="carousel">
                    <div class="carousel-inner" role="listbox">
                        <div class="item active">
                            <img src="img/intro-img3.jpg" class="img-responsive"><a href="#" class="view"><i
                                class="fa fa-external-link"></i> View</a></div>
                        <div class="item">
                            <img src="img/intro-img4.jpg" class="img-responsive"><a href="#" class="view"><i
                                class="fa fa-external-link"></i> View</a></div>
                        <div class="item">
                            <img src="img/intro-img6.jpg" class="img-responsive"><a href="#" class="view"><i
                                class="fa fa-external-link"></i> View</a></div>
                    </div>
                    <!-- Controls -->
                    <a class="left carousel-control" href="#carousel-works" role="button" data-slide="prev">
                        <i class="fa fa-3x fa-angle-left"></i></a><a class="right carousel-control" href="#carousel-works"
                            role="button" data-slide="next"><i class="fa fa-3x fa-angle-right"></i></a>
                </div>
            </div>
        </div>
    </div>
    <!-- works -->
    
    <!-- work section -->
    <section id="works" class="works section no-padding">
  
</section>
    <!-- work section -->
   
    <!-- Testimonials section -->
    <section id="testimonials" class="section testimonials no-padding">
  <div class="container-fluid">
    <div class="row no-gutter">
      <div class="flexslider">
        <ul class="slides">
          <li>
            <div class="col-md-12">
              <blockquote>
                <h1>"Software is a great combination between artistry and engineering." </h1>
                <p>-Bill Gates
                            </p>
              </blockquote>
            </div>
          </li>
          <li>
            <div class="col-md-12">
              <blockquote>
                <h1>"To be a good professional engineering, Always start to study late for exams.
                Because it teaches you  how to manage time and tackle emergencies.</h1>
                <p>-Bill Gates</p>
              </blockquote>
            </div>
          </li>
          <li>
            <div class="col-md-12">
              <blockquote>
                <h1>"In this digital age, we have an opportunity to transform lives of people in ways that was hard to imagine just a couple of decades ago.</h1>
                <p>-Narendra Modi</p>
              </blockquote>
            </div>
          </li>
          <li>
            <div class="col-md-12">
              <blockquote>
                <h1>"PERFECTION consist not in doing extraordinary things, but in doing ordinary things EXTRAORDINARILY well." </h1>
                <p>Arnauld, Angelique</p>
              </blockquote>
            </div>
          </li>
        </ul>
      </div>
    </div>
  </div>
</section>
    <!-- Testimonials section -->
    
   
    <!-- Footer section -->
    <footer class="footer">
  <div class="footer-top section-tb">
    <div class="container">
      <div class="row">
        <div class="footer-col col-md-4">
          <h5>Our Office Location</h5>
          <p>9th Floor, Kamlacharan, Above Vijay Bank,<br>
            Near Jawahar Nagar Fatak, Goregaon(West),<br>
            Mumbai-400 062.<br>
            <p>Copyright © 2016 evita soft solution. All Rights Reserved.<a href="#"> evitaappliances.com</a></p>
        </div>
        <div class="footer-col col-md-3">
          <h5>Services We Offer</h5>
          <p>
          <ul>
            <li><a href="#">Web design</a></li>
            <li><a href="#">Web Hosting</a></li>
            <li><a href="#">Custom Softwares</a></li>
           <%-- <li><a href="#">Social Media</a></li>
            <li><a href="#">User Experience</a></li>--%>
          </ul>
          </p>
        </div>
        <div class="footer-col col-md-3">
          <h5>Like us Share us</h5>
          <ul class="footer-share">
            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
            <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
          </ul>
        </div>
         <div class="footer-col col-md-2">
          <h5>Follow</h5>
          <ul class="footer-share">
            <li><a href="#"><i class="fa fa-facebook"></i></a></li>
            <li><a href="#"><i class="fa fa-twitter"></i></a></li>
            <li><a href="#"><i class="fa fa-linkedin"></i></a></li>
            <li><a href="#"><i class="fa fa-google-plus"></i></a></li>
          </ul>
        </div>
      </div>
    </div>
  </div>
  <!-- footer top --> 
  
</footer>
    <!-- Footer section -->
    <script src="js/jquery.js" type="text/javascript"></script>
    <script src="js/bootstrap.min.js" type="text/javascript"></script>
    <script src="js/jquery.easing.min.js" type="text/javascript"></script>
    <script src="js/jquery.flexslider-min.js"></script>
    <script src="js/jquery.fancybox.pack.js"></script>
    <script src="js/wow.js" type="text/javascript"></script>
    <script src="js/retina.min.js"></script>
    <script src="js/modernizr.js"></script>
    <script src="js/main.js"></script>
    <script type="text/javascript">
        //WOW Scroll Spy
        var wow = new WOW({
            //disabled for mobile
            mobile: false
        });
        wow.init();
    </script>
    </form>
</body>
</html>
