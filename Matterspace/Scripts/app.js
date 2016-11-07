$(function () {

    // enable tooltips everywhere
    $('[data-toggle="tooltip"]')
        .tooltip({
            trigger: "hover"
        })
        .on("show.bs.tooltip",
            function () {
                // tooltips should not be displayed when there's an active li.nav-item
                if ($("ul.navbar-with-dropdown-menu li.nav-item.active").length)
                    return false;
            });

    // will remove the active class from all nav items
    $("body")
        .click(function () {
            $("ul.navbar-with-dropdown-menu li.nav-item").removeClass("active");
        });

    // will toggle the active class from nav items
    $("ul.navbar-with-dropdown-menu li.nav-item")
        .click(function (e) {
            // hides the tooltip
            $('[data-toggle="tooltip"]').tooltip("hide");

            // hides other dropdowns
            $("ul.navbar-with-dropdown-menu li.nav-item").removeClass("active");

            // toggles the active class. This will show or display the dropdown menu
            $(this).toggleClass("active");
            e.stopPropagation();
        });

});