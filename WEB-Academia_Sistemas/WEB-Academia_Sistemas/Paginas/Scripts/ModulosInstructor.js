var BaseURL = "http://acsiappservweb.runasp.net/";

jQuery(function () {
    $("#dvMenu").load("../Paginas/MenuInstructor.html");
    LlenarTablaModulos();
});

async function LlenarTablaModulos() {
    try {
        // Paso 1: Obtener el ID del instructor (ajusta esto a tu lógica real de sesión/autenticación)
        const idInstructor = getCookie("Id");
        if (!idInstructor) {
            $("#dvMensaje").html("ID de instructor no encontrado.");
            return;
        }

        // Paso 2: Obtener los cursos asignados al instructor
        const cursosUrl = BaseURL + "api/Instructore/VerCursosAsignados?idInstructor=" + idInstructor;
        const cursos = await ConsultarServicioAuth(cursosUrl);

        if (!cursos || cursos.length === 0) {
            $("#dvMensaje").html("No se encontraron cursos asignados al instructor.");
            return;
        }

        const idsCursos = cursos.map(curso => curso.IdCurso);

        // Paso 3: Obtener todos los módulos
        const modulosUrl = BaseURL + "api/Modulos/ConsultarTodos";
        const todosLosModulos = await ConsultarServicioAuth(modulosUrl);

        if (!todosLosModulos || !Array.isArray(todosLosModulos)) {
            $("#dvMensaje").html("No se pudieron cargar los módulos.");
            return;
        }

        // Paso 4: Filtrar los módulos que pertenecen a los cursos del instructor
        const modulosFiltrados = todosLosModulos.filter(modulo =>
            idsCursos.includes(modulo.IdCurso)
        );

        // Paso 5: Llenar la tabla con DataTables
        $("#tblModulos").DataTable().clear().destroy();
        $("#tblModulos").DataTable({
            data: modulosFiltrados,
            columns: [
                { data: "IdModulo" },
                { data: "Titulo" },
                { data: "Contenido" },
                { data: "LinkVideo" },
                { data: "IdCurso" }
            ]
        });

    } catch (error) {
        console.error("Error al cargar módulos filtrados:", error);
        $("#dvMensaje").html("Ocurrió un error al cargar los módulos.");
    }
}



async function EjecutarComando(Metodo, Funcion) {
    let URL = BaseURL + "api/ModulosInstructor/" + Funcion;

    const modulo = new ModuloInstructor(
        parseInt($("#txtIdModulo").val()) || 0,
        $("#txtTitulo").val(),
        $("#txtContenido").val(),
        $("#txtLinkVideo").val(),
        parseInt($("#txtIdCurso").val())
    );

    const Rpta = await EjecutarComandoServicioRptaAuth(Metodo, URL, modulo);
    LlenarTablaModulos();
}

async function Consultar() {
    let IdModulo = $("#txtIdModulo").val();
    let URL = BaseURL + "api/ModulosInstructor/ConsultarXId?IdModulo=" + IdModulo;
    const modulo = await ConsultarServicioAuth(URL);
    if (modulo != null) {
        $("#txtTitulo").val(modulo.Titulo);
        $("#txtContenido").val(modulo.Contenido);
        $("#txtLinkVideo").val(modulo.LinkVideo);
        $("#txtIdCurso").val(modulo.IdCurso);
    } else {
        $("#dvMensaje").html("El módulo no está en la base de datos");
        $("#txtTitulo").val("");
        $("#txtContenido").val("");
        $("#txtLinkVideo").val("");
        $("#txtIdCurso").val("");
    }
}

class ModuloInstructor {
    constructor(IdModulo, Titulo, Contenido, LinkVideo, IdCurso) {
        this.IdModulo = IdModulo;
        this.Titulo = Titulo;
        this.Contenido = Contenido;
        this.LinkVideo = LinkVideo;
        this.IdCurso = IdCurso;
    }
}
