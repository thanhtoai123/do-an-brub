import { TinhThanhPho } from "./TinhThanhPho.js"

$(function () {
    $("#example1").DataTable({
        "responsive": true,
        "lengthChange": false,
        "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"]
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');
    $('#example2').DataTable({
        "paging": true,
        "lengthChange": false,
        "searching": false,
        "ordering": true,
        "info": true,
        "autoWidth": false,
        "responsive": true,
    });

    $.validator.setDefaults({
        submitHandler: function () {
            alert("Form successful submitted!");
        }
    });

    $('#formThongTin').validate({
        rules: {
            hovaten: {
                required: true,
            },
            gioitinh: {
                required: true,
            },
            ngaysinh: {
                required: true,
            },
            sodienthoai: {
                required: true,
                number: true,
            },
            email: {
                required: true,
                email: true,
            },
            phuongxa: {
                required: true,
            },
            donvicongtac: {
                required: true,
            },
            truong: {
                required: true,
            },
            phuhuynh: {
                required: true,
            },
        },
        messages: {
            hovaten: {
                required: "Vui lòng không bỏ trống",
            },
            gioitinh: {
                required: "Vui lòng không bỏ trống",
            },
            ngaysinh: {
                required: "Vui lòng không bỏ trống",
            },
            sodienthoai: {
                required: "Vui lòng không bỏ trống",
                number: "Vui lòng nhập số điện thoại",
            },
            email: {
                required: "Vui lòng không bỏ trống",
                email: "Vui lòng nhập đúng định dạng email",
            },
            phuongxa: {
                required: "Vui lòng không bỏ trống",
            },
            donvicongtac: {
                required: "Vui lòng không bỏ trống",
            },
            truong: {
                required: "Vui lòng không bỏ trống",
            },
            phuhuynh: {
                required: "Vui lòng không bỏ trống",
            },
        },
        errorElement: 'span',
        errorPlacement: function (error, element) {
            error.addClass('invalid-feedback');
            element.closest('.form-group').append(error);
        },
        highlight: function (element, errorClass, validClass) {
            $(element).addClass('is-invalid');
        },
        unhighlight: function (element, errorClass, validClass) {
            $(element).removeClass('is-invalid');
        }
    });

    //date-mask
    $('[data-mask]').inputmask()
});


$(document).ready(
    function () {
        TinhThanhPho.nap('tinh', 'quanhuyen');
        globalThis.trangThai = "";

        //sự kiện click nút thêm
        document.getElementById("nut-them").addEventListener('click', function () {
            globalThis.trangThai = "Them";
        });

        document.getElementById("nut-luu").addEventListener('click', function () {
            let form = new FormData(document.getElementById("formThongTin"));

            let x = document.querySelector(".active [name='phanloai']");
            let doiTuong = x.id;
            let tab = x.parentElement.href;

            let json = Object.fromEntries(form.entries());
            console.log(json);

        });
    }
)