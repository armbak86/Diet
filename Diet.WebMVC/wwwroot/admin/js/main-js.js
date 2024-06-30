jQuery(document).ready(function ($) {
    'use strict';

    // Delete Button Action On Datatabeles
    let btns = $(".btn-delete");
    if (btns) {
        btns.each(function (index, btn) {
            btn = $(btn)
            let id = btn.data("id");
            let page = btn.data("page");

            btn.on("click", async function () {
                const result = await Swal.fire({
                    title: "آیا از حذف مطمئن هستید؟",
                    text: "قسمت پاک شده امکان بازگردانی ندارد!",
                    icon: "warning",
                    showCancelButton: true,
                    cancelButtonColor: "#3085d6",
                    confirmButtonColor: "#d33",
                    confirmButtonText: "بلی",
                    cancelButtonText: "خیر",
                });

                if (result.isConfirmed) {
                    window.location.href = `/${page}/Delete?id=${id}`;
                }
            })
        })
    }


    // Notification list
    if ($(".notification-list").length) {

        $('.notification-list').slimScroll({
            height: '250px'
        });

    }


    // Menu Slim Scroll List

    if ($(".menu-list").length) {
        $('.menu-list').slimScroll({

        });
    }


    // Sidebar scrollnavigation 

    if ($(".sidebar-nav-fixed a").length) {
        $('.sidebar-nav-fixed a')

            // Remove links that don't actually link to anything

            .click(function (event) {
                // On-page links
                if (
                    location.pathname.replace(/^\//, '') == this.pathname.replace(/^\//, '') &&
                    location.hostname == this.hostname
                ) {
                    // Figure out element to scroll to
                    var target = $(this.hash);
                    target = target.length ? target : $('[name=' + this.hash.slice(1) + ']');
                    // Does a scroll target exist?
                    if (target.length) {
                        // Only prevent default if animation is actually gonna happen
                        event.preventDefault();
                        $('html, body').animate({
                            scrollTop: target.offset().top - 90
                        }, 1000, function () {
                            // Callback after animation
                            // Must change focus!
                            var $target = $(target);
                            $target.focus();
                            if ($target.is(":focus")) { // Checking if the target was focused
                                return false;
                            } else {
                                $target.attr('tabindex', '-1'); // Adding tabindex for elements not focusable
                                $target.focus(); // Set focus again
                            };
                        });
                    }
                };
                $('.sidebar-nav-fixed a').each(function () {
                    $(this).removeClass('active');
                })
                $(this).addClass('active');
            });

    }


    // tooltip

    if ($('[data-toggle="tooltip"]').length) {

        $('[data-toggle="tooltip"]').tooltip()

    }


    // popover

    if ($('[data-toggle="popover"]').length) {
        $('[data-toggle="popover"]').popover()

    }

    // Chat List Slim Scroll

    if ($('.chat-list').length) {
        $('.chat-list').slimScroll({
            color: 'false',
            width: '100%'


        });
    }
});