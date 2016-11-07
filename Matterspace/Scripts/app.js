$(function () {

    // will remove the active class from all nav items
    $("body")
        .click(function() {
            $("ul.navbar-with-dropdown-menu li.nav-item").removeClass("active");
        });

    // will toggle the active class from nav items
    $("ul.navbar-with-dropdown-menu li.nav-item")
        .click(function (e) {
            $(this).toggleClass("active");
            e.stopPropagation();
        });
});