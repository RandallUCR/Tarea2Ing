// Please see documentation at https://docs.microsoft.com/aspnet/core/client-side/bundling-and-minification
// for details on configuring this project to bundle and minify static web assets.

// Write your JavaScript code.


function getDataById(id) {
    var parametros = { "id": id };
    $.ajax(
        {
            data: parametros,
            url: '/Curso/consultarById',
            type: 'post',
            beforeSend: function () { },
            success: function (response) {
                var curso = response.split('|');

                $('#id_curso').text(curso[0]);
                $('#siglas_curso').val(curso[1]);
                $('#nombre_curso').val(curso[2]);
                $('#creditos_curso').val(curso[3]);
                $('#cupos_curso').val(curso[4]);

                $('#modalEdit').modal("show");
            }
        }
    );
}

function editarCurso() {
    var id = document.getElementById('id_curso').innerText;
    var siglas = document.getElementById('siglas_curso').value;
    var nombre = document.getElementById('nombre_curso').value;
    var creditos = document.getElementById('creditos_curso').value;
    var cupos = document.getElementById('cupos_curso').value;

    var parametros = {
        "id_curso": id,
        "siglas_curso": siglas,
        "nombre_curso": nombre,
        "creditos_curso": creditos,
        "cupos_curso": cupos
    };
    $.ajax(
        {
            data: parametros,
            url: '/Curso/Editar',
            type: 'post',
            beforeSend: function () { },
            success: function (response) {
                if (response == 0) {
                    window.location.href = "/";
                } else {
                    alert('Ha ocurrido un error');
                    $('#modalEdit').modal("dispose");
                }
            }
        }
    );
}

function eliminarCurso(id) {
    var parametros = { "id": id };
    $.ajax(
        {
            data: parametros,
            url: '/Curso/Eliminar',
            type: 'post',
            beforeSend: function () { },
            success: function (response) {
                if (response == 0) {
                    window.location.href = "/";
                } else {
                    alert('Ha ocurrido un error')
                }
            }
        }
    );
}