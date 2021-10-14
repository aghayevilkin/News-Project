$(document).ready(function () {
    $("#categoryId").change(function () {
        $("#subcategoryId").empty();
        $.ajax({
            type: 'GET',
            url: '@Url.Action("LoadSubCategory")',

            dataType: 'json',

            data: { id: $("#categoryId").val() },

            success: function (subcategories) {
                $("#subcategoryId").append('<option value="' + -1 + '">' + "Select Sub Category" + '</option>');

                $.each(subcategories, function (i, subcategory) {
                    $("#subcategoryId").append('<option value="' + subcategory.value + '">' + subcategory.text + '</option>');
                });
            },
            /*error: function*/
        });
        return false;
    })
})