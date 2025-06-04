var BaseURL = "http://acsiappservweb.runasp.net/";

$(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    $('#tblCursosInscritos').DataTable(); // Inicializar tabla vacía
});

async function ConsultarCursos() {
    const idEstudiante = $("#txtIdEstudiante").val();
    const URL = BaseURL + "api/Estudiantes/CursosInscritos?idEstudiante=" + idEstudiante;

    try {
        // Ya no verificamos token ni enviamos Authorization porque el endpoint no tiene auth
        const response = await fetch(URL, {
            method: 'GET',
            // No headers necesarios si no hay auth
        });

        if (!response.ok) {
            throw new Error(`Error HTTP: ${response.status}`);
        }

        const cursos = await response.json();
        const tabla = $('#tblCursosInscritos').DataTable();
        tabla.clear();

        if (cursos.length === 0) {
            $("#dvMensaje").html("El estudiante no se encuentra inscrito en ningún curso.");
        } else {
            cursos.forEach(curso => {
                tabla.row.add([
                    curso.Nombre,
                    curso.Descripcion,
                    curso.Duracion,
                    curso.FechaInicio ? curso.FechaInicio.split('T')[0] : '',
                    curso.FechaFin ? curso.FechaFin.split('T')[0] : ''
                ]);
            });
            tabla.draw();
            $("#dvMensaje").html("");
        }

    } catch (error) {
        $("#dvMensaje").html("Error al consultar cursos: " + error.message);
    }
}
