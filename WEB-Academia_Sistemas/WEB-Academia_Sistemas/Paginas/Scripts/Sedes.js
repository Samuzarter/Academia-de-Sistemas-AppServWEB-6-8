var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    $("#tblSedes").DataTable(); 
});

async function ConsultarSede() {
    const idSede = $("#txtIdSede").val();

    if (!idSede) {
        $("#dvMensaje").text("Debe ingresar el ID de la sede.");
        return;
    }

    const URL = `${BaseURL}api/Sedes/Consultar?IdSede=${idSede}`;

    try {
        const sede = await $.get(URL);

        if (!sede || !sede.IdSede) {
            $("#dvMensaje").text("No se encontró una sede con ese ID.");
            $("#tblSedes").DataTable().clear().draw();
            return;
        }

        $("#dvMensaje").text("");
        const tabla = $("#tblSedes").DataTable();
        tabla.clear();

        tabla.row.add([
            sede.IdSede,
            sede.Nombre,
            sede.Direccion,
            sede.Telefono,
            sede.Ciudad
        ]);

        tabla.draw();
    } catch (err) {
        $("#dvMensaje").text("Error al consultar la sede: " + err.statusText);
    }
}