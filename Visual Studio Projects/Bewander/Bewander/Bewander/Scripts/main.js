/*--- Home/Index ---*/
/*Slideshow*/
var element = document.getElementById("slideshow");
var duration = 400; /* fade duration in millisecond */
var hidtime = 0; /* time to stay hidden */
var showtime = 7000; /* time to stay visible */

var running = 0 /* Used to check if fade is running */
var iEcount = 1 /* Element Counter */

var iTotalE = element.getElementsByTagName('div').length;

/*Sets the images opacity*/
function SetOpa(Opa) {
    element.style.opacity = Opa;
    element.style.MozOpacity = Opa;
    element.style.KhtmlOpacity = Opa;
    element.style.filter = 'alpha(opacity=' + (Opa * 100) + ');';
}

/*Begins the slideshow*/
setTimeout(function StartFade() {
    if (running != 1) {
        running = 1
        FadeOut()
    }
}, showtime);

function FadeOut() {
    /*Decrease image opacity until eqauls 0*/
    for (i = 0; i <= 1; i += 0.01) {
        setTimeout("SetOpa(" + (1 - i) + ")", i * duration);
    }
    setTimeout("FadeIn()", (duration + hidtime));
}

function FadeIn() {
    /*Increase image opacity unitl equals 1*/
    for (i = 0; i <= 1; i += 0.001) {
        setTimeout("SetOpa(" + i + ")", i * duration);
    }

    /*Decides wether to move to the next image or start over*/
    if (iEcount == iTotalE) {
        iEcount = 1
        document.getElementById("slice" + iEcount).style.display = "block";
        document.getElementById("slice" + iTotalE).style.display = "none";
    } else {
        document.getElementById("slice" + (iEcount + 1)).style.display = "block";
        document.getElementById("slice" + iEcount).style.display = "none";
        iEcount = iEcount + 1
    }
    setTimeout("FadeOut()", (duration + showtime));
}
/*End of Slideshow*/

/*---UserProfiles/ProfilePage---*/
/*Toggle Content*/
function toggleContent(contentName) {
    var contentName = document.getElementById(contentName);
    var contentSection = document.getElementById("content-profile");
    var contentClasses = document.getElementsByClassName("content-section");
    $(contentSection).slideToggle('3000');

    for (var i = 0; i < contentClasses.length; i++) {
        contentClasses[i].style.display = 'none';
    }

    setTimeout(function Display() {
        contentName.style.display = 'inline';
    }, 400);

    $(contentSection).slideToggle('5000');
}

