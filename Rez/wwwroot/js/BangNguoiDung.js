export class BangNguoiDung {
    /**
     * @type {jquery}
     */
    dataTable;

    /**
     *
     * @param selector {string} id Element
     * @param options
     */
    constructor(selector, options = BangNguoiDung.getOptions()) {
        this.dataTable = $(document.getElementById(selector)).DataTable(options);
        this.thietLap();
    }

    thietLap() {
        this.thietLapVeSoThuTu();
        this.thietLapEvent();
    }

    /**
     *
     * @returns {Promise<*>}
     */
    layDuLieu() {
        return fetch('/Api/NguoiDung')
            .then(res => res.json())
            .then(json => json.forEach(x => {
                this.dataTable.row.add(x).draw();
            }));
    }

    thietLapVeSoThuTu() {
        this.dataTable.on('order.dt search.dt', () => {
            this.dataTable.column(0, {
                search: 'applied',
                order: 'applied'
            }).nodes().each(function (cell, i) {
                cell.innerHTML = i + 1;
            });
        }).draw();
    }

    thietLapEvent() {
        this.dataTable.on('childRow', function () {
            console.log('da tao!!!');
        })
    }

    static getOptions() {
        return {
            responsive: true,
            lengthChange: false,
            autoWidth: false,
            buttons: ["copy", "csv", "excel", "pdf", "print", "colvis"],
            columns: [
                {data: null, defaultContent: ""},
                {data: "hoVaTen"},
                {data: "taiKhoanDangNhap"},
                {data: "phanLoai", defaultContent: ""},
                {data: "thoiGianTao"},
                {data: null, defaultContent: "admin"},
                {
                    data: null, render: function (data, type, full, meta) {
                        return `
                    <i data-toggle="modal" data-target="#modal-lg" class="fas fa-pencil-alt p-1 mr-2" title="Sửa" data-id="${full.id}"></i>
                    <i data-toggle="modal" data-target="#xac-nhan-xoa" class="fas fa-trash-alt p-1 xoa" title="Xóa" data-id="${full.id}"></i>
                    `;
                    }
                }
            ],
            fixedColumns: true,
            columnDefs: [{
                sortable: false,
                class: "index",
                targets: 0
            }],
            order: [[1, 'asc']]
        };
    }
}

/**
 *
 * @param callback {Function}
 * @param error {Function}
 */
function xoaNguoiDung(callback = null, error = null) {
    let id = this.getAttribute('data-id');
    return fetch(`/Api/NguoiDung/${id}`, {method: 'DELETE'}).then(callback).catch(error);
}