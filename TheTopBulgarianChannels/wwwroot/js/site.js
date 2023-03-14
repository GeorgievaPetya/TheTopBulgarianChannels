$(document).ready(function () {
    $('#myTable').DataTable({
        "scrollY": "450px",
        "scrollCollapse": true,
        "paging": true,
        columnDefs: [
            { orderable: false, targets: 4 }
        ],
        order: [[1, 'asc']]
    });
});