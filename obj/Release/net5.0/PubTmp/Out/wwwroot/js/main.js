// header scroll
(function($) {
  $.fn.menumaker = function(options) {  
   var cssmenu = $(this), settings = $.extend({
     format: "dropdown",
     sticky: false
   }, options);
   return this.each(function() {
     $(this).find(".button").on('click', function(){
       $(this).toggleClass('menu-opened');
       var mainmenu = $(this).next('ul');
       if (mainmenu.hasClass('open')) { 
         mainmenu.slideToggle().removeClass('open');
       }
       else {
         mainmenu.slideToggle().addClass('open');
         if (settings.format === "dropdown") {
           mainmenu.find('ul').show();
         }
       }
     });
     cssmenu.find('li ul').parent().addClass('has-sub');
  multiTg = function() {
       cssmenu.find(".has-sub").prepend('<span class="submenu-button"></span>');
       cssmenu.find('.submenu-button').on('click', function() {
         $(this).toggleClass('submenu-opened');
         if ($(this).siblings('ul').hasClass('open')) {
           $(this).siblings('ul').removeClass('open').slideToggle();
         }
         else {
           $(this).siblings('ul').addClass('open').slideToggle();
         }
       });
     };
     if (settings.format === 'multitoggle') multiTg();
     else cssmenu.addClass('dropdown');
     if (settings.sticky === true) cssmenu.css('position', 'fixed');
  resizeFix = function() {
    var mediasize = 1000;
       if ($( window ).width() > mediasize) {
         cssmenu.find('ul').show();
       }
       if ($(window).width() <= mediasize) {
         cssmenu.find('ul').hide().removeClass('open');
       }
     };
     resizeFix();
     return $(window).on('resize', resizeFix);
   });
    };
  })(jQuery);
  
  (function($){
  $(document).ready(function(){
  $("#cssmenu").menumaker({
     format: "multitoggle"
  });
  });
  })(jQuery);
  
  
// $(document).ready(function(){
//     $(window).scroll(function(){
//       var scrollTop = $(window).scrollTop();
//       if (scrollTop > 249) {
//           $('.header').addClass('fadeOutLeft');
//           $('.header').removeClass('fadeInLeft');
//           $('.header-sticky').addClass('fadeInDown');
//           $('.header-sticky').removeClass('fadeOutUp');
//           $('.header-sticky').addClass('animated');      
//       } else {
//           $('.header').addClass('fadeInLeft');
//           $('.header').removeClass('fadeOutLeft');
//           $('.header-sticky').addClass('fadeOutUp');
//           $('.header-sticky').removeClass('fadeInUp');
  
//       }
//     });
//   });
  
//   end

// expert

$('.responsive').slick({
  dots: true,
  infinite: true,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 4,
  autoplay:true,
  responsive: [
      {
      breakpoint: 1024,
      settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
      }
      },
      {
      breakpoint: 600,
      settings: {
          slidesToShow: 2,
          slidesToScroll: 2
      }
      },
      {
      breakpoint: 480,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      }
  
  ]
});



// testimonial
$('.testimonial').slick({
  dots: true,
  infinite: true,
  speed: 300,
  slidesToShow: 1,
  slidesToScroll: 1,
  autoplay:true,
  responsive: [
      {
      breakpoint: 1024,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1,
          infinite: true,
          dots: true
      }
      },
      {
      breakpoint: 600,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      },
      {
      breakpoint: 480,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      }
  
  ]
});


// university

$('.university-logo').slick({
  dots: true,
  infinite: true,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 4,
  autoplay:true,
  responsive: [
      {
      breakpoint: 1024,
      settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
      }
      },
      {
      breakpoint: 600,
      settings: {
          slidesToShow: 2,
          slidesToScroll: 2
      }
      },
      {
      breakpoint: 480,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      }
  
  ]
});


// university02

$('.university-logo-02').slick({
  dots: true,
  infinite: true,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 4,
  autoplay:true,
  responsive: [
      {
      breakpoint: 1024,
      settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
      }
      },
      {
      breakpoint: 600,
      settings: {
          slidesToShow: 2,
          slidesToScroll: 2
      }
      },
      {
      breakpoint: 480,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      }
  
  ]
});


// compare-university*****Choose Your University Wisely!
$('.compare-university-slide').slick({
  dots: true,
  infinite: true,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 4,
  autoplay:true,
  responsive: [
      {
      breakpoint: 1024,
      settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
      }
      },
      {
      breakpoint: 600,
      settings: {
          slidesToShow: 2,
          slidesToScroll: 2
      }
      },
      {
      breakpoint: 480,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      }
  
  ]
});


// Talk to our Experts!
$('.talk-expert').slick({
  dots: true,
  infinite: true,
  speed: 300,
  slidesToShow: 4,
  slidesToScroll: 4,
  autoplay:true,
  responsive: [
      {
      breakpoint: 1024,
      settings: {
          slidesToShow: 3,
          slidesToScroll: 3,
          infinite: true,
          dots: true
      }
      },
      {
      breakpoint: 600,
      settings: {
          slidesToShow: 2,
          slidesToScroll: 2
      }
      },
      {
      breakpoint: 480,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      }
  
  ]
});

// Popular Universities Comparison
$('.popular-uni-compare').slick({
  dots: true,
  infinite: true,
  speed: 300,
  slidesToShow: 3,
  slidesToScroll: 3,
  autoplay:true,
  responsive: [
      {
      breakpoint: 1024,
      settings: {
          slidesToShow: 2,
          slidesToScroll: 2,
          infinite: true,
          dots: true
      }
      },
      {
      breakpoint: 600,
      settings: {
          slidesToShow: 2,
          slidesToScroll: 2
      }
      },
      {
      breakpoint: 480,
      settings: {
          slidesToShow: 1,
          slidesToScroll: 1
      }
      }
  
  ]
});



//jQuery time
var current_fs, next_fs, previous_fs; //fieldsets
var left, opacity, scale; //fieldset properties which we will animate
var animating; //flag to prevent quick multi-click glitches

$(".next").click(function(){
	if(animating) return false;
	animating = true;
	
	current_fs = $(this).parent();
	next_fs = $(this).parent().next();
	
	//activate next step on progressbar using the index of next_fs
	$("#progressbar li").eq($("fieldset").index(next_fs)).addClass("active");
	
	//show the next fieldset
	next_fs.show(); 
	//hide the current fieldset with style
	current_fs.animate({opacity: 0}, {
		step: function(now, mx) {
			//as the opacity of current_fs reduces to 0 - stored in "now"
			//1. scale current_fs down to 80%
			scale = 1 - (1 - now) * 0.2;
			//2. bring next_fs from the right(50%)
			left = (now * 50)+"%";
			//3. increase opacity of next_fs to 1 as it moves in
			opacity = 1 - now;
			current_fs.css({
        'transform': 'scale('+scale+')',
        'position': 'absolute'
      });
			next_fs.css({'left': left, 'opacity': opacity});
		}, 
		duration: 800, 
		complete: function(){
			current_fs.hide();
			animating = false;
		}, 
		//this comes from the custom easing plugin
		easing: 'easeInOutBack'
	});
});

$(".previous").click(function(){
	if(animating) return false;
	animating = true;
	
	current_fs = $(this).parent();
	previous_fs = $(this).parent().prev();
	
	//de-activate current step on progressbar
	$("#progressbar li").eq($("fieldset").index(current_fs)).removeClass("active");
	
	//show the previous fieldset
	previous_fs.show(); 
	//hide the current fieldset with style
	current_fs.animate({opacity: 0}, {
		step: function(now, mx) {
			//as the opacity of current_fs reduces to 0 - stored in "now"
			//1. scale previous_fs from 80% to 100%
			scale = 0.8 + (1 - now) * 0.2;
			//2. take current_fs to the right(50%) - from 0%
			left = ((1-now) * 50)+"%";
			//3. increase opacity of previous_fs to 1 as it moves in
			opacity = 1 - now;
			current_fs.css({'left': left});
			previous_fs.css({'transform': 'scale('+scale+')', 'opacity': opacity});
		}, 
		duration: 800, 
		complete: function(){
			current_fs.hide();
			animating = false;
		}, 
		//this comes from the custom easing plugin
		easing: 'easeInOutBack'
	});
});

$(".submit").click(function(){
	return false;
})

