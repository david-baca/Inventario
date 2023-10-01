import { Frame } from "./0-Componentes/"
export const Catalogos = () => {
    return(
        <Frame 
        Encabezado={"Selecciona un catalogo para el nuevo artículo"}
        Estructura={{nombre:''}} 
        Tabla={"Catalogos"}
        FilaBD={0}
        FilaNav={0}
        Link={"0_1"}
        />
    )
}