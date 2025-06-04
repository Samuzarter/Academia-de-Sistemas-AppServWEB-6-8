var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    $("#tblEstudiantes").DataTable(); // Inicializar tabla
});

async function ConsultarEstudiantesPorCurso() {
    const idInstructor = $("#txtIdInstructor").val();
    const idCurso = $("#txtIdCurso").val();

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
                est.Documento,
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
