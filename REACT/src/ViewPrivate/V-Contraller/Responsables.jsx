import { Frame } from "./0-Componentes/"
import { useContext } from "react"
import { ContextUser } from "../Context/ContextUser"
export const Responsables = () => {
    const { Data } = useContext( ContextUser )
    return(
        <Frame 
        Encabezado={"Selecciona un responsable para el nuevo artículo"}
        Estructura={{
            nombre:'',
            apellidoP:'',
            apellidoM:'',
            fkrol:Data[5].pk
        }}
        Tabla={"Responsable"}
        FilaBD={6}
        FilaNav={4}
        Link={"5"}
        />
    )
}