var AjaxApi = (url, data) =>  $.ajax({
    url: url,
    data: data,
    type: "POST",
    contentType: "application/json; charset=utf-8",
    dataType: "JSON"
});

function GetDifficulty(i) { return ["High", "Medium", "Low"][i] }
function GetStatus(i) { return ["On-going", "Done"][i] }

let setActive = (elem) => $(elem).find('a').addClass("active");


$('#btnSearch').click(function () {
    dataTable.ajax.reload();
});
$('#formSearch').on("submit", function (e) {
    e.preventDefault();
    dataTable.ajax.reload();
});

$(function () {
    var forms = $('div[class="modal-content"] form');
    $.each(forms,() => {
        $(this).on("submit", (e) => {
            e.preventDefault();
        })
    })
})

$(function () {
    $.notify.defaults({
        // whether to hide the notification on click
        clickToHide: true,
        // whether to auto-hide the notification
        autoHide: true,
        // if autoHide, hide after milliseconds
        autoHideDelay: 5000,
        // show the arrow pointing at the element
        arrowShow: true,
        // arrow size in pixels
        arrowSize: 5,
        // position defines the notification position though uses the defaults below
        //position: '...',//Default
        position: 'top center',
        // default positions
        //elementPosition: 'bottom left',//Default
        elementPosition: 'top center',
        //globalPosition: 'top right',//Default
        globalPosition: 'top center',
        // default style
        style: 'bootstrap',
        // default class (string or [string])
        className: 'error',
        // show animation
        showAnimation: 'slideDown',
        // show animation duration
        showDuration: 400,
        // hide animation
        hideAnimation: 'slideUp',
        // hide animation duration
        hideDuration: 200,
        // padding between element and notification
        gap: 2
    });

})