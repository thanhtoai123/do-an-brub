/**
 * 
 * @param {Object} json 
 */



//
// (new FormData(FormDOM)).entries()
//
// Ten : Nam
// SoYeuLyLich.Ten : Nam
// SoYeuLyLich.ChoOHienTai.NoiO : TruongChinh

let ketQua = {
    Ten: "Nam",
    SoYeuLyLich: {
        Ten: "Nam",
        ChoOHienTai: {
            NoiO: "TruongChinh"
        }
    }
}


// form --> json
// client
// [form --> json string]
//
// json string ---post--> server
//
// Nguoi.SoYeuLyLich.Ten [form name]
// "Nguoi.SoYeuLyLich.Ten" [json key]
// "Nguoi.SoYeuLyLich.Ten" [json string]
// Không hiểu đoạn này bind với thằng nào
// [Nguoi] [SoYeuLyLich Ten]
// Table Nguoi inserted
// SoYeuLyLich không có gì cả
// Ten không có gì cả
// "Nguoi.SoYeuLyLich.Ten : "Nam"" string ->
// "Nguoi : {SoYeuLyLich : {Ten : "Nam"}}"" string

function stringToString(json) {
    for (const [key, value] of Object.entries(json)) {
        let paths = key.split(".");

        let iter = paths.entries();
        let archor = json;
        for (const _key of paths) {
            if (!Object.hasOwnProperty.call(archor, _key)) {
                archor[_key] = {};
            }
            archor = archor[_key];
        }

        archor = json;
        for (let index = 0; index < paths.length - 1; index++) {
            archor = archor[paths[index]];
        }

        archor[paths[paths.length - 1]] = value;

        delete json[key];
    }
}

function main() {
    let a = {
        "b.a": 4,
        "b.b.a": 5,
    }

    stringToString(a);

    console.log(a);
}

main();