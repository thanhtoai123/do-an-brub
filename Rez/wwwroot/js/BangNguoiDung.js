import {FormToJson} from "./FormToJson.js";
import {TinhThanhPho} from "./TinhThanhPho.js"


async function layDuLieu() {
    /**
     * @type {[]}
     */
    let data = await fetch('/Api/NguoiDung').then(res => res.json());
    let table = $('#example1').DataTable();
    data.$values.forEach(x => {
        console.log(x);
        table.row.add(x).draw();
    })
}

$(function () {
    $("#example1").DataTable({
        "responsive": true,
        "lengthChange": false,
        "autoWidth": false,
        "buttons": ["copy", "csv", "excel", "pdf", "print", "colvis"],
        "columns": [
            {"data": null, "defaultContent": ""},
            {data: "hoVaTen"},
            {data: "taiKhoanDangNhap"},
            {data: "phanLoai", defaultContent: ""},
            {data: "thoiGianTao"},
            {data: null, defaultContent: "admin"},
            {data: null, defaultContent: ""},
            {data: null, render: function(data, type,full, meta) {
                return '<button class="btn btn-mini btn-primary pull-right"> Enabled</button>' + '<button class="btn btn-mini btn-danger pull-right"> Disabled</button>'
            }}
        ],
        "fixedColumns": true,
        "columnDefs": [{
            "sortable": false,
            "class": "index",
            "targets": 0
        }],
        "order": [[1, 'asc']],
    }).buttons().container().appendTo('#example1_wrapper .col-md-6:eq(0)');

    //date-mask
    $('[data-mask]').inputmask();

    layDuLieu();

    $('#example1').DataTable().on('order.dt search.dt', function () {
        $('#example1').DataTable().column(0, {search: 'applied', order: 'applied'}).nodes().each(function (cell, i) {
            cell.innerHTML = i + 1;
        });
    }).draw();
});


$(document).ready(
    function () {
        $('#formThongTin').removeData('validator').removeData('unobtrusiveValidation');
        $.validator.unobtrusive.parse($('#formThongTin'));

        TinhThanhPho.nap('tinh', 'quanhuyen');
        globalThis.trangThai = "";

        //sự kiện click nút thêm
        document.getElementById("nut-them").addEventListener('click', function () {
            globalThis.trangThai = "Them";
        });

        document.getElementById("nut-luu").addEventListener('click', function () {
            if ($('#formThongTin').valid()) {
                let json = FormToJson('formThongTin');
                let phanLoai = document.querySelector("#phan-loai-form .active").getAttribute('href');
                let url = "";

                json.SoYeuLyLich.SinhNgay = json.SoYeuLyLich.SinhNgay.split("/").reverse().join('/');

                switch (phanLoai) {
                    case "#admin": {
                        delete json.truong;
                        delete json.phuHuynh;
                        delete json.donViCongTac;
                        delete json.trinhDo;
                        url = "/api/quantri";
                    }
                        break;
                    case "#giangvien": {
                        delete json.truong;
                        delete json.phuHuynh;
                        url = "/api/giangvien";
                    }
                        break;
                    case "#hocvien": {
                        delete json.donViCongTac;
                        delete json.trinhDo;
                        url = "/api/hocvien";
                    }
                        break;
                }

                let body = JSON.stringify(json);

                fetch(url, {
                    method: 'POST', headers: {
                        'content-type': 'application/json'
                    },
                    body: body
                }).then(res => {
                    if (res.status === 200) {
                        $('#modal-lg').modal('hide');
                    }
                });
            }

        });
    }
)