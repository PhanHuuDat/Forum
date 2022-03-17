//go top
$(document).ready(function () {
    $(".go_top").on("click", function () {
        $("html, body").animate({ scrollTop: "0" });
    });
});

//home layout script
$("#home").ready(function () {
    $('[data-toggle="tooltip"]').tooltip();

    //toggle new post popup
    document.getElementById("nPostTrigger")
        .addEventListener("click", function () {
            var x = document.getElementById("newPost");
            if (x.style.display === "none") {
                x.style.display = "block";

                $('#rtfNewPost').summernote();
                $('#nPostContent .note-editable').html("<p>What's up?</p>");
                $('#nPostTitle').val("");
            } else {
                x.style.display = "none";
            }
        }, false);

    //toggle cmt popup
    document.getElementById("nCmtTrigger")
        .addEventListener("click", function () {
            var x = document.getElementById("newCmt");
            if (x.style.display === "none") {
                x.style.display = "block";

                $('#rtfNewCmt').summernote();
                $('#nCmtContent .note-editable').html("<p>Lorem ipsum dolor sit amet!</p>");
                $('#nCmtContent').val("");
            } else {
                x.style.display = "none";
            }
        }, false);

    //toggle expand cmt
    $("#collapseTrg").on("click", function () {
        expandText();
    });

    $("#newscontent").ready(function () {
        insertExpandPoint();
    })

});

//profile layout script
$("#profile").ready(function () {
    toggleAccordion();
    document.getElementById("defaultOpen").click();

    $("#profile #editBtn").on("click", function () {
        toggleEdit();
    });
});


function expandText() {
    var dots = document.getElementById("dots");
    var moreText = document.getElementById("more");
    var btnText = document.getElementById("collapseTrg");

    if (dots.style.display === "none") {
        dots.style.display = "inline";
        btnText.innerHTML = "Expand";
        moreText.style.display = "none";
    } else {
        dots.style.display = "none";
        btnText.innerHTML = "colapse";
        moreText.style.display = "inline";
    }
}

function insertExpandPoint() {
    var origin = $("#newsBody").html();
    var insertContent = '<span id="dots">...</span><span id="more">';
    if (origin.length < 720) {
        return;
    } else {
        origin = origin.split('');
        origin.splice(720, 0, insertContent);
        $("#newsBody").html(origin.join(''));
        $("#newsBody").append("</span>");
    }
}

function toggleAccordion() {
    var acc = document.getElementsByClassName("arccordionTrg");
    var i;

    for (i = 0; i < acc.length; i++) {
        acc[i].addEventListener("click", function () {
            /* Toggle between adding and removing the "active" class,
            to highlight the button that controls the panel */
            this.classList.toggle("active");

            /* Toggle between hiding and showing the active panel */
            var panel = this.nextElementSibling;
            if (panel.style.display === "block") {
                panel.style.display = "none";
            } else {
                panel.style.display = "block";
            }
        });
    }
}

function openTab(evt, tabName) {
    var i, tabcontent, tablinks;
    tabcontent = document.getElementsByClassName("tabcontent");
    for (i = 0; i < tabcontent.length; i++) {
        tabcontent[i].style.display = "none";
    }
    tablinks = document.getElementsByClassName("tabLk");
    for (i = 0; i < tablinks.length; i++) {
        tablinks[i].className = tablinks[i].className.replace(" active", "");
    }
    document.getElementById(tabName).style.display = "block";
    evt.currentTarget.className += " active";
}

function toggleEdit() {
    var elements = $("#changeInfo input");
    for (i = 0; i < elements.length; i++) {
        if (elements[i].id == "id") {
            continue;
        }
        elements[i].toggleAttribute("readonly");
    }
    elements = $("#changeInfo select");
    console.log(elements);
    elements[0].disabled = !elements[0].disabled;

    elements = $("#changeInfo #submitBtn")
    console.log(elements);
    elements[0].disabled = !elements[0].disabled;
}