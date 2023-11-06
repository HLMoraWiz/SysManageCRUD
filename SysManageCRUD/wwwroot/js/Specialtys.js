var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblSpecialtys").DataTable({
        "ajax": {
            "url": "/admin/Specialty/GetSpecialtys",
            "type": "GET",
            "datatype": "json"
        },
        "responsive": true,
        "columns": [
            { "data": "idSpecialty","width": "5%" },
            { "data": "specialtyName", "width": "20%" },
            {
                "data": "idSpecialty",
                "render": function (data) {
                    return `
                      <div class="text-center">
                        <a href="/admin/specialty/edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100%">
                         <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        &nbsp;
                        <a onclick=Delete("/admin/specialty/Delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100%">
                         <i class="bi bi-x-square"></i> Delete
                        </a>
                      </div>`;
                }
            }
        ]
    });
}

function Delete(url) {
    Swal.fire({
        title: '¿Are you sure to delete this information?',
        text: 'This content cannot delete.',
        icon: 'warning',
        showCancelButton: true,
        confirmButtonColor: '#3085d6',
        confirmButtonText: 'Yes, Delete it'
    }).then((result) => {
        if (result.isConfirmed) {
            $.ajax({
                type: 'DELETE',
                url: url,
                success: function (data) {
                    if (data.success) {
                        toastr.success(data.message);
                        datatable.ajax.reload();
                    } else {
                        toastr.error(data.message);
                    }
                }
            });
        }
    });
}
