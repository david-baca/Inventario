import { Frame } from "./0-Componentes/"
export const Roles = () => {
    return(
        <Frame 
        Encabezado={"Selecciona un rol para el nuevo artículo"}
        Estructura={{nombre:''}} 
        Tabla={"Roles"}
        FilaBD={5}
        FilaNav={4}
        Link={"4_1"}
        />
    )
}