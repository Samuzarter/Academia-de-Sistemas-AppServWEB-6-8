const BaseURL = "http://acsiappservweb.runasp.net/";

$(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
});

async function RegistrarPago() {
    const idEstudiante = parseInt($("#txtIdEstudiante").val());
    const valor = parseFloat($("#txtValor").val());
    const fechaPago = $("#txtFechaPago").val();
    const metodoPago = $("#txtMetodoPago").val();

    // Validación básica
    if (!idEstudiante || !valor || !fechaPago || !metodoPago) {
        $("#dvMensaje").removeClass("text-success").addClass("text-danger").html("Por favor, complete todos los campos.");
        return;
    }

    const datosPago = {
        IdEstudiante: idEstudiante,
        Valor: valor,
        FechaPago: fechaPago,
        MetodoPago: metodoPago
    };

    try {
        const response = await fetch(BaseURL + "api/Pagos/Insertar", {
            method: "POST",
            headers: {
                "Content-Type": "application/json"
            },
            body: JSON.stringify(datosPago)
        });

        if (!response.ok) {
            const errorText = await response.text();
            throw new Error("Error del servidor: " + errorText);
        }

        $("#dvMensaje")
            .removeClass("text-danger")
            .addClass("text-success")
            .html("¡Pago registrado correctamente!");

        $("#frmPagoEstudiante")[0].reset();

    } catch (error) {
        $("#dvMensaje")
            .removeClass("text-success")
            .addClass("text-danger")
            .html("Error al registrar el pago: " + error.message);
    }
}
