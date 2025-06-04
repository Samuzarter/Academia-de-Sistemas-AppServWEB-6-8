var BaseURL = "http://acsiappservweb.runasp.net/";

const categorias = {
    1: "Programación",
    2: "Redes"
};

const modalidades = {
    1: "Presencial",
    2: "Virtual"
};

jQuery(function () {
    $("#dvMenu").load("../Paginas/Menu.html");
    LlenarTablaCursos();
});

async function LlenarTablaCursosConAcciones(URL, idTabla) {
    const cursos = await ConsultarServicioAuth(URL);
    if (!Array.isArray(cursos)) return;

    if (!$.fn.DataTable.isDataTable(idTabla)) {
        $(idTabla).DataTable({
            language: {
                url: "//cdn.datatables.net/plug-ins/1.13.6/i18n/es-ES.json"
            }
        });
    }

    let tabla = $(idTabla).DataTable();
    tabla.clear();

    cursos.forEach(curso => {
        tabla.row.add([
            curso.IdCurso,
            curso.Nombre,
            curso.Descripcion,
            curso.Duracion,
            curso.Costo,
            categorias[Number(curso.IdCategoria)] || "Desconocida",
            modalidades[Number(curso.IdModalidad)] || "Desconocida",
            `<button class="btn btn-success btnInscribirse" data-id="${curso.IdCurso}">Inscribirse</button>`
        ]);
    });


    tabla.draw();

    $(idTabla).off("click", ".btnInscribirse");
    $(idTabla).on("click", ".btnInscribirse", function () {
        let idCurso = $(this).data("id");
        alert("Te inscribiste al curso ID: " + idCurso);
        // Aquí puedes integrar lógica real
    });
}

function LlenarTablaCursos() {
    let URL = BaseURL + "api/Cursos/ConsultarTodos";
    LlenarTablaCursosConAcciones(URL, "#tblCursos");
}

// Las demás funciones quedan igual (EjecutarComando, Consultar, etc.)
