$(function () {
    $.getJSON("api/products/", function (responsedata) {
        $.each(responsedata, function (key,val) {
            var str = val.Name + ": $" + val.Price;

            $("<li>", { text: str }).appendTo('#products');
        });
    }); 
});
//GET api/products/+id
function find() {
    let id = $('#produdctId').val();
    $.getJSON("api/products/" + id, function (data) {
        let str = data.Name + ": $" + data.Price;
        $('#product').text(str);
    }).fail(
        function (xhr, text, err) {
            $('#product').text("error : " + err);
        }
    );
}