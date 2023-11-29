import {useState, useEffect} from "react"
import { Get } from "../Conexion/Conexion"
import { Toolbox, Barra, BtnAdd, Displey } from "../Components/";

export const Categorias = () => {
    let Search
    const [ PackageBD, setPackageBD] = useState();
    const Estrcutura = {pk: 0,marca: "",modelo: "",descripcion: "",fkCatalogo: 1};
    const [ bandera, setbandera] = useState(true); 

    const Recargar=()=>{
        setbandera(true);
    }

    const Cargar = async () => {
        const pack = await Get({Entidad:"Categoría", Text:Search, FK:1});
        setPackageBD( pack )
    }
    const Buscar = (item) => {
        Search= item
        Cargar()
    }
    
    useEffect(() =>{
        Cargar()
        setbandera(false)
    },[bandera]);

    const Kit = Toolbox({Entidad:"Categoría", Reload:Recargar});


    return (
        <>        
            <Visore Encabezado={"Control de Categoría"} changeEdit={Buscar} 
            clickCrear={()=>Kit.Kit_creation.TolsCreate.On(Estrcutura)}>
            </Visore>

            <Displey 
            Data={PackageBD}
            Delete={Kit.Kit_Eliminate.Tols.On}
            Edit={Kit.Kit_Edit.TolsEdit.On}
            />
            {Kit.Kit_Edit.TolsEdit.View}
            {Kit.Kit_Edit.MsjTrue.View}
            {Kit.Kit_Eliminate.Tols.View}
            {Kit.Kit_Eliminate.MsjTrue.View}
            {Kit.Kit_creation.TolsCreate.View}
            {Kit.Kit_creation.MsjTrue.View}
        </>
    );
}

export const Visore =({Encabezado:T,changeEdit:E,clickCrear:C})=>{
    return(
        <div className="w-full pt-2">
            <div className="flex justify-between p-1 ps-5 pe-5">
                <h1 className="font-bold text-[25px] justify-items-center">
                     {T}
                </h1>
                <div className="flex justify-end p-5">
                    <section className="flex">
                        <div className="me-5">
                            <Barra ReadBD={E}/>
                        </div>
                        <div className="w-[200px]">
                            <BtnAdd Crear={C}/>
                        </div>
                    </section>
                </div>
            </div>
        </div>
    )
}
