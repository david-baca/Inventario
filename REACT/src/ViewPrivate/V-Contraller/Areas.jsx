import { Frame } from "./0-Componentes/"
export const Areas = () => {
    return(
        <Frame 
        Encabezado={"Selecciona un área para el nuevo artículo"}
        Estructura={{nombre:''}} 
        Tabla={"Área"}
        FilaBD={4}
        FilaNav={3}
        Link={"4"}
        />
    )
}