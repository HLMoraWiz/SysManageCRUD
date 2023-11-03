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
            { "data": "idPatient", "width": "5%" },
            { "data": "Name", "width": "40%" },
            { "data": "LastName", "width": "20%" },
            { "data": "Age", "width": "20%" },
            { "data": "Description", "width": "20%" },
            {
                "data": "idPatient",
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