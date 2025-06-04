var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/MenuInstructor.html");
    $("#tblEquipos").DataTable(); // Inicializar la tabla
});

async function ConsultarEquipo() {
    const idEquipo = $("#txtIdEquipo").val();

    if (!idEquipo) {
        $("#dvMensaje").text("Debe ingresar el ID del equipo.");
        return;
    }

    const URL = `${BaseURL}api/Equipos/Consultar?IdEquipo=${idEquipo}`;

    try {
        const equipo = await $.get(URL);

        if (!equipo || !equipo.IdEquipo) {
            $("#dvMensaje").text("No se encontró un equipo con ese ID.");
            $("#tblEquipos").DataTable().clear().draw();
            return;
        }

        $("#dvMensaje").text("");
        const tabla = $("#tblEquipos").DataTable();
        tabla.clear();

        tabla.row.add([
            equipo.IdEquipo,
            equipo.Nombre,
            equipo.Descripcion,
            equipo.Categoria
        ]);

        tabla.draw();
    } catch (err) {
        $("#dvMensaje").text("Error al consultar el equipo: " + err.statusText);
    }
}