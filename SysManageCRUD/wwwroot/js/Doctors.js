﻿var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblDoctors").DataTable({
        "ajax": {
            "url": "/admin/doctor/GetDoctors",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "idDoctor", "width": "5%" },
            { "data": "doctorName", "width": "10%" },
            { "data": "specialty.specialtyName", "width": "15%" },

            {
                "data": "idDoctor",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/admin/doctor/edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        &nbsp;
                        <a onclick=Delete("/admin/doctor/delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-x-square"></i> Delete
                        </a>
                      </div>
                      `;
                }, "width": "50%"
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




