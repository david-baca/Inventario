import {useState, useEffect} from "react"
import { Get } from "../Conexion/Conexion"
import { Toolbox, Barra, BtnAdd, Displey } from "../Components/";

export const Provedor = () => {
    let Search
    const [ PackageBD, setPackageBD] = useState();
    const Estrcutura = {nombre: "",};
    const [ bandera, setbandera] = useState(true); 

    const Recargar=()=>{
        setbandera(true);
    }

    const Cargar = async () => {
        const pack = await Get({Entidad:"Provedor"});
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

    const Kit = Toolbox({Entidad:"Provedor", Reload:Recargar});


    return (
        <>        
            <Visore Encabezado={"Control de Provedor"} changeEdit={Buscar} 
            clickCrear={()=>Kit.Kit_creation.TolsCreate.On(Estrcutura)}>
            </Visore>

            <div className="overflow-auto max-w-100 min-h-[87vh] max-h-[87vh] p-5">
                <table className='bg-white'>
                    <thead>
                        <tr>
                            <td className='p-2 border border-gray-300'>#</td>
                            <td className='w-full p-2 border border-gray-300 '>Nombre</td>
                            <td className='border border-gray-300 p-2'>Acciones</td>
                        </tr>
                    </thead>
                    <tbody>
                        {PackageBD && (PackageBD.map((element, Index) => ( 
                            <tr key={element.pk}>
                                <td className='p-2 border border-gray-100'>
                                    {Index}
                                </td>
                                <td className='p-2 border border-gray-100'>
                                    {element.nombre}
                                </td>
                                <td className='ps-2 flex gap-3 border border-gray-200'>
                                    <button onClick={()=>{Kit.Kit_Edit.TolsEdit.On(element)}} className='bg-yellow-300 p-1 px-4'>
                                        Editar
                                    </button>
                                    

                                    <button onClick={()=>{Kit.Kit_Eliminate.Tols.On(element.pk)}} className='bg-red-400 px-4 p-1 text-white'>
                                        Eliminar
                                    </button>
                                </td>
                                
                            </tr>
                        )))}
                    </tbody>
                </table>
            </div>

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
