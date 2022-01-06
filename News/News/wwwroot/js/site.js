













$(document).ready(function () {

    //var likeCountJ = $("#likeCountJ").text();
    //var dislikeCountJ = $("#dislikeCountJ").text();
    //console.log(likeCountJ);
    //console.log(dislikeCountJ);


    //var url = '/News/GetNews'

    //$.getJSON(url, function (data) {
    //    var array = $.map(data, function (value, index) {
    //        return value;
    //    });


    //    $.each(array, function (indis, value) {
    //        var news = '<tbody><tr><td>' + Object.values(value)[0] + '</td><td>' + Object.values(value)[1] + '</td><td>' + Object.values(value)[2] + '</td><td>' + Object.values(value)[3] + '</td><td>' + Object.values(value)[4] + '</td></tr></tbody>';
    //        var NewS = '<div class="col-sm-6 p-r-25 p-r-15-sr991"><div class="m-b-45"><a class="wrap-pic-w hov1 trans-03 news-clip-path" href="/news/details/' + Object.values(value)[0] + '"><img style="background-size: cover; background-position: center center; height: 225px; " src="/Uploads/Images/News/' + Object.values(value)[4] + '" alt="IMG"></a><div class="news-content"><span class="f1-s-3 cateBlog"><span class="dis-block how1-child2 f1-s-5 cl0 bo-all-1 trans-03 p-rl-5 p-t-2" style="color: #aaaaaa; border-color: #aaaaaa; ">' + Object.values(value)[2] + '</span><i class="fas added  fa-bookmark fa-2x blog-bookmarked" data-id="' + Object.values(value)[0] + '" aria-hidden="true"></i></span><div class="when"><div class="when-date"><div class="date-day">01</div><div class="date-month">Jan</div></div><div class="when-time">00:38</div></div><div class="p-t-16"><h5 class="p-b-5 m-2"><a class="f1-m-3 cl2 hov-cl10 trans-03" href="/news/details/' + Object.values(value)[0] + '">' + Object.values(value)[1] + '</a></h5><div class="stats"><div class="stats-i-container stats-like-active stats_likes news-like  like-added" data-id="' + Object.values(value)[0] + '" data-likecount="' + likeCountJ + '"><span class="stats-i"><i class="fas fa-thumbs-up likeCount" aria-hidden="true">' + likeCountJ + '</i></span></div><div class="stats-i-container stats-like-active stats_dislikes news-dislike " data-id="' + Object.values(value)[0] + '" data-dislikecount="' + dislikeCountJ + '"><span class="stats-i"><i class="fas fa-thumbs-down dislikeCount" aria-hidden="true"></i>' + dislikeCountJ + '</span></div><div class="stats-i-container stats_views"><span class="stats-i"><i class="fas fa-eye" aria-hidden="true"></i> ' + Object.values(value)[3] + '</span></div></div></div></div></div></div>';


    //        $('#NewS').append(NewS);
    //    });
    //});


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


    $("#message-form").submit(function (e) {
        e.preventDefault();

        var name = $("#name-input").val();
        var email = $("#email-input").val();
        var subject = $("#subject-input").val();
        var content = $("#content-input").val();

        var pattern = /^\b[A-Z0-9._%-]+@[A-Z0-9.-]+\.[A-Z]{2,4}\b$/i;

        if (name == "") {
            toastr.error('Please, input your name.', { timeOut: 2000 });

        } else if (email == "") {
            toastr.error('Please, input your email address.', { timeOut: 2000 });
        }
        else if (subject == "") {
            toastr.error('Please, enter subject.', { timeOut: 2000 });
        } else if (content == "") {
            toastr.error('Please, enter message.', { timeOut: 2000 });
        }
        else if (!pattern.test(email)) {
            toastr.error('Not a valid e-mail address.', { timeOut: 2000 });
        }
        else {
            $.ajax({

                url: "/contact/addMessage/",
                type: "get",
                dataType: "json",

                data: { email: email, name: name, subject: subject, content: content },
                success: function (response) {
                    if (response == 200) {
                        //success
                        $("#name-input").val('');
                        $("#email-input").val('');
                        $("#subject-input").val('');
                        $("#content-input").val('');
                        toastr.success('You have now sent us a message, Thank you!', { timeOut: 2000 });

                    } else {
                        //error
                        toastr.error('Please, fill out the form completely.', { timeOut: 2000 });
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







