import { Frame } from "./0-Componentes/"
export const Fuentes = () => {
    return(
        <Frame 
        Encabezado={"Selecciona una fuente para el nuevo artículo"}
        Estructura={{nombre:''}} 
        Tabla={"Fuente"}
        FilaBD={3}
        FilaNav={2}
        Link={"3"}
        />
    )
}