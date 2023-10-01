import { Frame } from "./0-Componentes/"
export const Provedores = () => {
    return(
        <Frame 
        Encabezado={"Selecciona un provedor para el nuevo artículo"}
        Estructura={{
            nombre:''
        }} 
        Tabla={"Provedor"}
        FilaBD={2}
        FilaNav={1}
        Link={"2"}
        />
    )
}