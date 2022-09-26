export class TinhThanhPho {

    /**
     * 
     * @param {string} inputTinhId 
     * @param {string} inputQuanHuyenId 
     */
    static async nap(inputTinhId, inputQuanHuyenId) {

        /**
         * @type {{Id : string, Ten : string QuanHuyen : {Id : string, Ten : string}[]}[]}
         */
        let text_data = JSON.parse(localStorage.getItem('data_tinh'));

        if (text_data == null) {
            let data = await fetch('/api/tinh', { method: 'GET' }).then(res => res.json());
            localStorage.setItem('data_tinh', JSON.stringify(data));
            text_data = data;
        }

        let inputTinh = document.getElementById(inputTinhId);
        /**
         * @type {HTMLSelectElement}
         */
        let inputQuanHuyen = document.getElementById(inputQuanHuyenId);

        text_data.forEach(tinh => {
            let option = document.createElement('option');
            option.value = tinh.id;
            option.textContent = tinh.ten;
            inputTinh.options.add(option);
        });

        inputTinh.addEventListener('change', function () {
            while (inputQuanHuyen.options.length !== 1) {
                inputQuanHuyen.options.remove(inputQuanHuyen.options.length - 1);
            }

            text_data.find(x => x.id === inputTinh.value).quanHuyen.forEach(quanHuyen => {
                let option = document.createElement('option');
                option.value = quanHuyen.id;
                option.textContent = quanHuyen.ten;
                inputQuanHuyen.options.add(option);
            })

        });
    }

}