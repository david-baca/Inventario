import { Frame } from "./0-Componentes/"
import { useContext } from "react"
import { ContextUser } from "../Context/ContextUser"
export const Categorias = () => {
    const { Data } = useContext( ContextUser )
    return(
        <Frame 
        Encabezado={"Selecciona una categoría para el nuevo artículo"}
        Estructura={{
            marca:'',
            modelo: '',
            descripcion: '',
            fkCatalogo:Data[0].pk
        }} 
        Tabla={"Categoría"}
        FilaBD={1}
        FilaNav={0}
        Link={"1"}
        />
    )
}