import {FormToJson} from "../FormToJson.js";
import {TinhThanhPho} from "../TinhThanhPho.js"
import {BangNguoiDung} from "../BangNguoiDung.js";

$(function () {
    //date-mask
    $('[data-mask]').inputmask();
});

window.addEventListener('load', function () {
    //thiết lập bảng người dùng
    let options = BangNguoiDung.getOptions();
    thietLapNutXoa(options);
    let bangNguoiDung = new BangNguoiDung("example1", options);
    globalThis.bangNguoiDung = bangNguoiDung.dataTable;
    bangNguoiDung.layDuLieu();

    //đặt lại validate cho các form
    $('#formThongTin').removeData('validator').removeData('unobtrusiveValidation');
    $.validator.unobtrusive.parse($('#formThongTin'));

    //nạp danh sách tỉnh thành phố
    TinhThanhPho.nap('tinh', 'quanhuyen');

    //sự kiện click nút thêm
    thietLapNutThem();

    //sự kiện click nút lưu
    thietLapNutLuu();
});


function thietLapNutThem() {
    document.getElementById("nut-them").addEventListener('click', function () {
        globalThis.trangThai = "Them";
    });
}

function thietLapNutLuu() {
    globalThis.trangThai = "";
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
                }, body: body
            }).then(res => {
                if (res.status === 200) {
                    $('#modal-lg').modal('hide');
                }
            });
        }

    });
}

function thietLapNutXoa(options) {
    options.createdRow = function (row, data, index, cells) {
        cells[cells.length - 1].getElementsByClassName('xoa')[0].addEventListener('click', function () {
            xoaNguoiDung.call(this, this.getAttribute("data-id")); 
        });
    };
}


/**
 *
 * @param id {string}
 */
function xoaNguoiDung(id) {
    let modal = document.getElementById('xac-nhan-xoa');
    let $modal = $(modal);
    $modal.modal('show');
    let Toast = Swal.mixin({
        toast: true,
        position: 'top-end',
        showConfirmButton: false,
        timer: 3000
    });
    
    modal.getElementsByClassName('tiep-tuc')[0].onclick = async () => {
        await fetch(`/Api/NguoiDung/${id}`, {method: 'DELETE'})
            .then(res => {
                switch (res.status) {
                    case 204:
                        Toast.fire({
                            icon: 'success',
                            title: `<h6 style='margin:7px 0px 0px 20px'>Thành công</h6>`
                        });
                        let dongCanXoa = $(this).parents('tr');
                        bangNguoiDung.row(dongCanXoa).remove().draw();
                        break;
                    default:
                        Toast.fire({
                            icon: 'error',
                            title: '<h6 style=\'margin: 7px 0px 0px 20px\'>Bạn cần chọn ít nhất 1 bản ghi.</h6>',
                            
                        })
                        break;
                }
            })
            .catch(err => {
                Toast.fire({
                    icon: 'error',
                    title: 'Có lỗi'
                })
            });

        $modal.modal('hide');
    };

    modal.getElementsByClassName('dong')[0].onclick = function () {
        $modal.modal('hide');
    };


}
