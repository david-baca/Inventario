import { useState, useEffect, useContext } from "react"
import { GetFK, Put, Post, FormModal, Delete, BtnAdd, Barra, Mapeador, AlertModal, Body, Get, TrueModal }from "."
import { ContextUser } from "../../Context/ContextUser";

export const Frame = ({Estructura, Tabla, FilaBD, FilaNav, Link, Encabezado}) =>{
    //Datos de Context (Datos publicos)
    const { AddData, Data } = useContext( ContextUser )
    //(Datos Locales)
    const [BD, setBD] = useState();
    let busqueda
    //Datos de Modal
    const [DelOpen, setDelOpen] = useState(false)
    const [EditOpen, setEdit] = useState(false)
    const [CreateOpen, setCreate] = useState(false)
    const [TrueOpen, setTrueOpen] = useState(false)

    //Funciones de context
    const CreateModelBD = (element) => AddData({D:element, FD:FilaBD, L:Link, E:Tabla, FV:FilaNav})
    //Funciones de Datoslocales con Peticiones axios
    const Cargar = async () => {
        if(FilaBD == 1){
            const Datos = await GetFK({Entidad:Tabla, Text:busqueda, FK:Estructura.fkCatalogo});
            setBD( Datos )
            return
        }
        if(FilaBD == 6){
            const Datos = await GetFK({Entidad:Tabla, Text:busqueda, FK:Estructura.fkrol});
            setBD( Datos )
            return
        }
        const Datos = await Get({Entidad:Tabla, Datos:busqueda});
        setBD( Datos )
    }

    const Eliminar = async (Item) => {
        const Mensaje = await Delete({Entidad:Tabla,Pk:Item})
        if(Data[FilaBD]){
            if (Item == Data[FilaBD].pk) CreateModelBD(null)
        }
        if(!Mensaje.success){
            alert(Mensaje.message) 
            return
        }
        await Cargar()
        await EliminarOff()
        await TrueOn(Mensaje.message)
    }
    const Agregar = async (Item) =>{
        const Mensaje = await Post({Entidad:Tabla,Datos:Item})
        await Cargar()
        await CrearOff()
        await TrueOn(Mensaje.message)

    }
    const Editar = async (Item) =>{
        const Mensaje = await Put({Entidad:Tabla,Datos:Item})
        if(Data[FilaBD]){
            if (Item.pk == Data[FilaBD].pk) CreateModelBD(Item)
        }
        if(!Mensaje.success){
            alert(Mensaje.message) 
            return
        }
        await Cargar()
        await EditOff()
        await TrueOn(Mensaje.message)
    }
    const Buscar = async (Search) =>{
        busqueda = Search
        await Cargar()
    }
    //Funciones de Modal
    const CrearOn= () => setCreate(Estructura)
    const CrearOff= () => setCreate(false)

    const EditOn = (element) => {
        setEdit(element)
    }
    const EditOff = () => setEdit(false)

    const EliminarOn = (elemet) => setDelOpen(elemet)
    const EliminarOff = () => setDelOpen(false)

    const TrueOn = (element) => setTrueOpen(element)
    const TrueOff = () => setTrueOpen(false)

    //Funcion de carga de elementos locales
    useEffect(() =>{Buscar();},[]); // Array de dependencias vacío, indica que el efecto solo se ejecutará una vez.
    
    return(    
    <Body 
        Encabezado={Encabezado}
        Buscador={<Barra ReadBD={Buscar}/>}
        BtnAdd={<BtnAdd Crear={CrearOn}/>}
        Map={<Mapeador 
            Data={BD} 
            FCreateModelBD={CreateModelBD} 
            Eliminar={EliminarOn}
            Editar={EditOn}
            />}
        ModDel={<AlertModal Off={EliminarOff} FDelete={Eliminar} IsOpen={DelOpen}/>}
        ModCreat={<FormModal Off={CrearOff} Func={Agregar} Obj={CreateOpen}/>}
        ModUpdate={<FormModal Off={EditOff} Func={Editar} Obj={EditOpen}/>}
        ModTrue={<TrueModal Off={TrueOff} IsOpen={TrueOpen}/>}
    />
    

    )
}