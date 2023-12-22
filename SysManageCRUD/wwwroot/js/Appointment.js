var datatable;

$(document).ready(function () {
    cargarDatatable();
});
function cargarDatatable() {
    datatable = $("#tblAppointments").DataTable({
        "ajax": {
            "url": "/admin/appointment/GetAppointments",
            "type": "GET",
            "datatype": "json"
        },
        "columns": [

            { "data": "idAppointment", "width": "5%" },
            { "data": "patient.patientName", "width": "10%" },
            { "data": "doctor.doctorName", "width": "10%" },
            { "data": "location.hospitalName", "width": "10%" },
            { "data": "date", "width": "10%" },
            {
                "data": "idAppointment",
                "render": function (data) {
                    return `<div class="text-center">
                        <a href="/admin/appointment/edit/${data}" class="btn btn-success text-white" style="cursor:pointer; width:100px">
                         <i class="bi bi-pencil-square"></i> Edit
                        </a>
                        &nbsp;
                        <a onclick=Delete("/admin/appointment/delete/${data}") class="btn btn-danger text-white" style="cursor:pointer; width:100px">
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




