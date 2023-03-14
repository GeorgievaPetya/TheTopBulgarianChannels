$(document).ready(function () {
    var table = $('#myTableYouTube').DataTable({
        "scrollY": "340px",
        "scrollCollapse": true,
        "paging": true,
        columnDefs: [
            { orderable: false, targets: 4 }
        ],
        order: [[1, 'asc']]
    });
});
$('#myTableYouTube tbody').on('click', 'tr', function () {
    var data = table.row(this).data();
    alert('You clicked on ' + data[0] + "'s row");
});
$(document).ready(function () {
    var table = $('#myTableInstagram').DataTable({
        "scrollY": "340px",
        "scrollCollapse": true,
        "paging": true,
        columnDefs: [
            { orderable: false, targets: 3 }
        ],
        order: [[1, 'asc']]
    });
});
$('#myTableInstagram tbody').on('click', 'tr', function () {
    var data = table.row(this).data();
    alert('You clicked on ' + data[0] + "'s row");
});
$(document).ready(function () {
    var table = $('#myTableTwitter').DataTable({
        "scrollY": "340px",
        "scrollCollapse": true,
        "paging": true,
        columnDefs: [
            { orderable: false, targets: 3 }
        ],
        order: [[1, 'asc']]
    });
});
$('#myTableTwitter tbody').on('click', 'tr', function () {
    var data = table.row(this).data();
    alert('You clicked on ' + data[0] + "'s row");
});
$(document).ready(function () {
    var table = $('#myTableFacebook').DataTable({
        "scrollY": "340px",
        "scrollCollapse": true,
        "paging": true,
        columnDefs: [
            { orderable: false, targets: 2 }
        ],
        order: [[1, 'asc']]
    });
});
$('#myTableFacebook tbody').on('click', 'tr', function () {
    var data = table.row(this).data();
    alert('You clicked on ' + data[0] + "'s row");
});
$(document).ready(function () {
    var table = $('#myTableTikTok').DataTable({
        "scrollY": "340px",
        "scrollCollapse": true,
        "paging": true,
        columnDefs: [
            { orderable: false, targets: 3 }
        ],
        order: [[1, 'asc']]
    });
});
$('#myTableTikTok tbody').on('click', 'tr', function () {
    var data = table.row(this).data();
    alert('You clicked on ' + data[0] + "'s row");
});