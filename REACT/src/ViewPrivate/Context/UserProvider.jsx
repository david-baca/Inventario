import { useState } from "react"; 
import { ContextUser } from "./ContextUser";
import { useNavigate } from "react-router-dom";

export const UserProvider = ({ children }) => {
    const navigate = useNavigate();
    const [UserLogin, setUserLogin] = useState();
    const [Data, setData] = useState([]);
    
    const [Nav, setNav] = useState([
        {Tabla:"Categoría", Titulo:"pendiente"},
        {Tabla:"Provedores", Titulo:"pendiente"},
        {Tabla:"Fuente", Titulo:"pendiente"},
        {Tabla:"Área", Titulo:"pendiente"},
        {Tabla:"Responsable", Titulo:"pendiente"},
        {Tabla:"Artículo", Titulo:"No.Inventario"}]);

    const AgregarData = ({D:BD, FD:FilaD, L:Link_next, E:Entidad, FV:FilaV}) => {
        let newData = [...Data];
        newData[FilaD] = BD
        setData(newData);
        
        if(!BD){ EditarNav({req:null, FV:FilaV}); return null }

        if(FilaD == 1 && BD){EditarNav({req:{Titulo:BD.descripcion, Tabla:Entidad, Funcion:"C"}, FV:FilaV, L:Link_next})
        }
        else{EditarNav({req:{Titulo:BD.nombre, Tabla:Entidad, Funcion:"C"},FV:FilaV, L:Link_next})
        }
    }

    const EditarNav = ({req:objeto,FV:FilaV, L:Link_next})=>{
        if(objeto == null){
            let newNav = [...Nav];
            newNav[FilaV].Titulo = "pendiente"
            setNav(newNav);
            return 0
        }
        let newNav = [...Nav];
        newNav[FilaV] = objeto
        setNav(newNav);

        if(Data[7] && Data[7].pk){
            navigate('/Edit/'+Link_next, {replace: true})
        }else{
        navigate('/Create/'+Link_next, {replace: true})
        }
    }

    const CleenData = () =>{
        setData([])
        setNav([{Tabla:"Categoría", Titulo:"pendiente"},
            {Tabla:"Provedor", Titulo:"pendiente"},
            {Tabla:"Fuente", Titulo:"pendiente"},
            {Tabla:"Área", Titulo:"pendiente"},
            {Tabla:"Responsable", Titulo:"pendiente"},
            {Tabla:"Artículo", Titulo:"No.Inventario"}])

    }

    const CargarData = (item) => {
        let newData = [
            item.catalogo,
            item.categoria,
            item.provedor,
            item.fuente,
            item.area,
            item.rol,
            item.responsable,
            item.articulo,
        ]
        let newNav = [
            {Tabla:"Categoría", Titulo:item.categoria.descripcion, Funcion:"E"},
            {Tabla:"Provedores", Titulo:item.provedor.nombre, Funcion:"E"},
            {Tabla:"Fuente", Titulo:item.fuente.nombre, Funcion:"E"},
            {Tabla:"Área", Titulo:item.area.nombre, Funcion:"E"},
            {Tabla:"Responsable", Titulo:item.responsable.nombre, Funcion:"E"},
            {Tabla:"Artículo", Titulo:item.articulo.token, Funcion:"E"} 
        ]
        setNav(newNav)
        setData(newData)
    }

    const AgregarUsuario = (objeto) =>{
        setUserLogin(true)
        return 0
    }

    

    return (

        <ContextUser.Provider 
        value={{Data:Data, AddData:AgregarData,
                Nav:Nav, CleenData:CleenData, CargarData:CargarData,
                 UserLogin, AgregarUsuario}}>
            {children}
        </ContextUser.Provider>
    )
  }









