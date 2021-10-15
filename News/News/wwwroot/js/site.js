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