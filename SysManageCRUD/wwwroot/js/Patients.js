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
        "columns": [
            { "data": "idPatient","width": "50px" },
            { "data": "name", "width": "150px" },
            { "data": "lastName", "width": "100px" },
            { "data": "age", "width": "50px" },
            { "data": "description", "width": "200px" },
            {
                "data": "IdPatient",
                "render": function (data) {
                    return `
                      <div class="text-center">
                        <a href="/admin/patient/edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-pencil-square"></i> Editar
                        </a>
                        &nbsp;
                        <a onclick=Delete("/admin/patient/DeletePatient/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-x-square"></i> Delete
                        </a>
                      </div>`;
                }
            }
        ]
    });
}