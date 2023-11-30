import {useState, useEffect} from "react"
import { Get } from "../Conexion/Conexion"
import { Toolbox, Barra} from "../Components/";

export const Historial = () => {

    let Search
    const [ PackageBD, setPackageBD] = useState();
    const [ bandera, setbandera] = useState(true); 

    const Recargar=()=>{
        setbandera(true);
    }

    const Cargar = async () => {
        const pack = await Get({Entidad:"Historial", Text:Search});
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
    console.log(PackageBD)

    return (
        <>        
            <Visore Encabezado={"Control de Historial"} changeEdit={Buscar} 
            clickCrear={()=>Kit.Kit_creation.TolsCreate.On(Estrcutura)}>
            </Visore>
            
            <div className="overflow-auto max-w-100 min-h-[87vh] max-h-[87vh] p-5">
                <table className='bg-white'>
                    <thead>
                        <tr>
                            <td className='p-2 border border-gray-300'>#</td>
                            <td className='w-full p-2 border border-gray-300 '>Descripcion</td>
                            <td className='border border-gray-300 p-2'>Fecha</td>
                            <td className='border border-gray-300 p-2'>Usuario</td>
                            <td className='border border-gray-300 p-2'>Accion</td>
                        </tr>
                    </thead>
                    <tbody>
                        {PackageBD && (PackageBD.map((element, Index) => ( 
                            <tr key={element.pk}>
                                <td className='p-2 border border-gray-100'>
                                    {Index}
                                </td>
                                <td className='p-2 border border-gray-100'>
                                    {element.descripcion}
                                </td>    
                                <td className='p-2 border border-gray-100'>
                                    {element.fecha}
                                </td> 
                                <td className='p-2 border border-gray-100'>
                                    {element.usuario.n_Usuario}
                                </td>   
                                <td className='p-2 border border-gray-100'>
                                    {element.accion}
                                </td>                      
                            </tr>
                        )))}
                    </tbody>
                </table>
            </div>
        </>
    )
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
                    </section>
                </div>
            </div>
        </div>
        )
}