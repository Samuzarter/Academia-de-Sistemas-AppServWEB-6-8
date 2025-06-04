const BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/MenuInstructor.html");
});

async function CrearModulo() {
    const idInstructor = $("#txtIdInstructor").val();
    const idCurso = $("#txtIdCurso").val();
    const titulo = $("#txtTitulo").val();
    const contenido = $("#txtContenido").val();
    const linkVideo = $("#txtLinkVideo").val();

    if (!idInstructor || !idCurso || !titulo || !contenido) {
        $("#dvMensaje").text("Todos los campos excepto el link de video son obligatorios.");
        return;
    }

    const modulo = {
        Titulo: titulo,
        Contenido: contenido,
        LinkVideo: linkVideo,
        IdCurso: parseInt(idCurso)
    };

    try {
        const respuesta = await $.ajax({
            url: `${BaseURL}api/Instructore/CrearModulos?idInstructor=${idInstructor}`,
            method: "POST",
            contentType: "application/json",
            data: JSON.stringify(modulo)
        });

        $("#dvMensaje").removeClass("text-danger").addClass("text-success").text(respuesta);
    } catch (err) {
        $("#dvMensaje").removeClass("text-success").addClass("text-danger").text("Error al crear el módulo: " + err.statusText);
    }
}