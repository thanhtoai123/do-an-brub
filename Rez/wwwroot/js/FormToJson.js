/**
 *
 * @param {string} id
 */
export function FormToJson(id) {
    let form = document.getElementById(id);
    let formData = new FormData(form);
    let doiTuong = {};
    for (const iter of formData) {
        let doan = iter[0].split(".");
        let neo = doiTuong;
        let neoCu = null;
        doan.forEach(key => {
            if (!Object.hasOwnProperty.call(neo, key)) {
                neo[key] = {};
            }
            neoCu = neo;
            neo = neo[key];
        });
        let keyCuoi = doan[doan.length - 1];
        if (Array.isArray(neoCu[keyCuoi])) {
            neoCu[keyCuoi].push(iter[1]);
        } else if (
            typeof (neoCu[keyCuoi]) == 'object' &&
            Object.getOwnPropertyNames(neoCu[keyCuoi]).length === 0
        ) {
            neoCu[keyCuoi] = iter[1];
        } else if (typeof (neo[keyCuoi]) !== typeof (Object)) {
            let giaTriCu = neoCu[keyCuoi];
            neoCu[keyCuoi] = [];
            neoCu[keyCuoi].push(giaTriCu, iter[1]);
        }
    }
    return doiTuong;
}
