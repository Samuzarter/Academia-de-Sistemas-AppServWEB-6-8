var BaseURL = "http://acsiappservweb.runasp.net/";

$(function () {
    $("#dvMenu1").load("../Paginas/MenuEstudiante.html");

    // Inicializar la tabla si no está ya inicializada
    if (!$.fn.DataTable.isDataTable('#tblCursosInscritos')) {
        $('#tblCursosInscritos').DataTable({
            language: {
                url: "//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json"
            }
        });
    }
});

async function ConsultarCursos() {
    const idEstudiante = getCookie("Id"); // Se espera que ya esté autenticado

    if (!idEstudiante) {
        $("#dvMensaje").html("No se encontró el ID del estudiante en las cookies.");
        return;
    }

    const URL = BaseURL + "api/Estudiantes/CursosInscritos?idEstudiante=" + idEstudiante;

    try {
        const response = await fetch(URL, {
            method: 'GET'
        });

        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }

        const cursos = await response.json();
        const tabla = $('#tblCursosInscritos').DataTable();
        tabla.clear();

        if (!cursos || cursos.length === 0) {
            $("#dvMensaje").html("El estudiante no está inscrito en ningún curso.");
        } else {
            cursos.forEach(curso => {
                tabla.row.add([
                    curso.IdCurso,
                    curso.Nombre,
                    curso.Descripcion,
                    curso.Duracion,
                    curso.Costo
                ]);
            });
            tabla.draw();
            $("#dvMensaje").html("");
        }

    } catch (error) {
        $("#dvMensaje").html("Error al consultar cursos: " + error.message);
    }
}
