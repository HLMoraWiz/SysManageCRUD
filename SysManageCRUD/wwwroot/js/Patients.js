var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblPatients").DataTable({
        "ajax": {
            "url": "/admin/Patient/GetPatients",
            "type": "GET",
            "datatype": "json"
        },
        "responsive": true,
        "columns": [
            { "data": "idPatient","width": "5%" },
            { "data": "name", "width": "20%" },
            { "data": "lastName", "width": "20%" },
            { "data": "age", "width": "20%" },
            { "data": "description", "width": "20%" },
            {
                "data": "idPatient",
                "render": function (data) {
                    return `
                      <div class="text-center">
                        <a href="/admin/patient/edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100%">
                         <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        &nbsp;
                        <a onclick=Delete("/admin/patient/DeletePatient/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100%">
                         <i class="bi bi-x-square"></i> Delete
                        </a>
                      </div>`;
                }
            }
        ]
    });
}