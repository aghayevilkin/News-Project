$(document).ready(function () {


    $(".socialBTN").click(function () {
        var id = $(this).data().id;
        var par = $(this).parent().parent().parent()
        var paaa = par.find("#SocialSub").attr('class');
        $("." + paaa).toggle("slow", function () {

        });
    });

    $("#image").click(function () {
        $("#imgSubBtn").removeClass("d-none");

    });


    $(".blog-bookmarked").click(function () {
        var newsId = $(this).data().id;
        var par = $(this).parent().parent().parent()
        var paaa = par.find(".blog-bookmarked").attr('class');
        var This = $(this);
        var IsAdded = false;

        if ($(this).hasClass("added")) {
            IsAdded = true;
        }

        if (IsAdded == true) {
            $.ajax({

                url: "/news/removeFromBookmarked/",
                type: "get",
                dataType: "json",

                data: { newsId: newsId },
                success: function (response) {
                    if (response == 200) {
                        This.removeClass('fas');
                        This.addClass('far');
                        This.removeClass('added');
                        toastr.success('News exited without saving', { timeOut: 2000 });
                        console.log(response)
                    } else {
                        toastr.error('News exited without not saving', { timeOut: 2000 });
                    }

                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });
        } else {
            $.ajax({

                url: "/news/addToBookmarked/",
                type: "get",
                dataType: "json",

                data: { newsId: newsId },
                success: function (response) {
                    if (response == 200) {
                        This.removeClass('far');
                        This.addClass('fas');
                        This.addClass('added');
                        toastr.success('News Saved', { timeOut: 2000 });
                        console.log(response)
                    }
                    else {
                        toastr.error('News Not Saved.', { timeOut: 2000 });
                    }

                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });
        }

    });


    $(document).ready(function () {

        $(".news-like").on("click", function () {
            var newsId = $(this).data().id;
            var par = $(this).parent().parent().parent()
            var newsDislike = par.find(".news-dislike");
            var This = $(this);
            var IsAdded = false;


            if ($(this).hasClass("like-added")) {
                IsAdded = true;
            }

            if (IsAdded == false) {
                $.ajax({

                    url: "/news/addLike/",
                    type: "get",
                    dataType: "json",

                    data: { newsId: newsId },
                    success: function (response) {
                        location.reload();
                        if (response == 200) {
                            This.addClass('like-added');
                            event.stopPropagation();
                            toastr.success('Liked', { timeOut: 2000 });
                            
                        }
                        else if (response == 999) {
                            newsDislike.removeClass('dislike-added');
                            This.addClass('like-added');
                            toastr.success('Liked', { timeOut: 2000 });
                            
                        }
                        else {
                            toastr.error('News Not Saved.', { timeOut: 2000 });
                        }

                    },
                    error: function (response) {

                        console.log("error: " + response);
                    }

                });
            }

        });

        $(".news-dislike").click(function () {
            var newsId = $(this).data().id;
            var par = $(this).parent().parent().parent()
            var newslike = par.find(".news-like");
            var This = $(this);
            var IsAdded = false;

            if ($(this).hasClass("dislike-added")) {
                IsAdded = true;
            }

            if (IsAdded == false) {
                $.ajax({

                    url: "/news/addDisLike/",
                    type: "get",
                    dataType: "json",

                    data: { newsId: newsId },
                    success: function (response) {
                        location.reload();
                        if (response == 200) {
                            This.addClass('dislike-added');
                            toastr.success('Disliked', { timeOut: 2000 });
                            
                        }
                        else if (response == 999) {
                            newslike.removeClass('like-added');
                            This.addClass('dislike-added');
                            toastr.success('Disliked', { timeOut: 2000 });
                            
                        }
                        else {
                            toastr.error('News Not Saved.', { timeOut: 2000 });
                        }

                    },
                    error: function (response) {

                        console.log("error: " + response);
                    }

                });
            }

        });



        

    });



    $("#subscribe-form").submit(function (e) {
        e.preventDefault();

        var email = $("#subscribe-input").val();

        var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;

        if (email == "") {
            toastr.error('Please, input your email address.', { timeOut: 2000 });
        }
        else if (!pattern.test(email)) {
            toastr.error('Not a valid e-mail address.', { timeOut: 2000 });
        }
        else {
            $.ajax({

                url: "/contact/addSubscribe/",
                type: "get",
                dataType: "json",

                data: { email: email },
                success: function (response) {
                    if (response == 200) {
                        //success
                        $("#subscribe-input").val('');
                        toastr.success('Now you are our subscriber, Thank you!', { timeOut: 2000 });

                    } else if (response == 411) {
                        //error
                        toastr.error('You can subscribe once with this email!', { timeOut: 2000 });
                    }
                    else {
                        //error
                        toastr.error('Please, input your email address.', { timeOut: 2000 });
                    }
                },
                error: function (response) {

                    console.log("error: " + response);
                }

            });

        }

    });

});



function readURL(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#file_upload')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}

function readURLTwo(input) {
    if (input.files && input.files[0]) {
        var reader = new FileReader();

        reader.onload = function (e) {
            $('#file_uploadTwo')
                .attr('src', e.target.result);
        };
        reader.readAsDataURL(input.files[0]);
    }
}