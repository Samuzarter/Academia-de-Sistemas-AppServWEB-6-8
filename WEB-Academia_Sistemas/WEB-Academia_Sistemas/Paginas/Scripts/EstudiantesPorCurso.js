var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/MenuInstructor.html");
    $("#tblEstudiantes").DataTable(); // Inicializar tabla
    LlenarCursosDelInstructor(); 
});

async function ConsultarEstudiantesPorCurso() {
    const idInstructor = getCookie("Id");
    const idCurso = $("#ddlCursos").val();

    if (!idInstructor || !idCurso) {
        $("#dvMensaje").text("Debe ingresar el ID del instructor y del curso.");
        return;
    }

    const URL = `${BaseURL}api/Instructore/VerEstudiantesPorCurso?idInstructor=${idInstructor}&idCurso=${idCurso}`;

    try {
        const estudiantes = await $.get(URL);
        if (!estudiantes || estudiantes.length === 0) {
            $("#dvMensaje").text("No se encontraron estudiantes.");
            $("#tblEstudiantes").DataTable().clear().draw();
            return;
        }

        $("#dvMensaje").text("");
        const tabla = $("#tblEstudiantes").DataTable();
        tabla.clear();

        estudiantes.forEach(est => {
            tabla.row.add([
                est.IdEstudiante, 
                est.Nombre,
                est.Apellido,
                est.Correo,
                est.Telefono
            ]);
        });


        tabla.draw();
    } catch (err) {
        $("#dvMensaje").text("Error al consultar estudiantes: " + err.statusText);
    }
}

async function LlenarCursosDelInstructor() {
    const idInstructor = getCookie("Id");

    if (!idInstructor) {
        $("#dvMensaje").html("No se encontró el ID del instructor en la cookie.");
        return;
    }

    const urlCursos = `${BaseURL}api/Instructore/VerCursosAsignados?idInstructor=${idInstructor}`;
    console.log("URL:", urlCursos);

    try {
        const cursos = await ConsultarServicio(urlCursos);
        console.log("Cursos recibidos:", cursos); // <- Agregado para debug

        if (!cursos || cursos.length === 0) {
            $("#dvMensaje").html("No se encontraron cursos asignados.");
            return;
        }

        $("#ddlCursos").empty().append('<option value="">Seleccione un curso</option>');

        cursos.forEach(curso => {
            console.log("Curso individual:", curso); // <- Agregado
            $("#ddlCursos").append(`<option value="${curso.IdCurso}">${curso.Nombre}</option>`);
        });
    } catch (error) {
        $("#dvMensaje").html("Error al cargar cursos: " + error.message);
    }
}

