import { useNavigate } from "react-router-dom";
export const NavBoton = ({color, titulo, sub, funcion, direccion}) => {

    const Navegacion = useNavigate();
     const Navegar = () =>{
        if(direccion != null){
            Navegacion('/Create/'+direccion, {replace: true})
        }
     }

    return(
        <div onClick={Navegar} className="mt-5 mb-5 w-[100%] flex flex-row border-[2px] shadow-sm 
        hover:shadow-md  rounded-e-md transition-all cursor-pointer">
            <div className={`${color} w-4 flex`}>
            </div>
            <div className="pt-3 pb-3 flex flex-row">
                <div className="ps-1 pe-1 flex items-center border-[2px] border-gray-200 rounded-e-md ms-1 me-1 center">
                <h1>{funcion}</h1>
                </div>
                <div className="flex flex-col justify-center">
                    
                    {sub && (
                        <h1 className="text-gray-500 text-xs">• {sub}</h1>
                    )}
                    <h1 className="text-sm ms-2 font-medium text-gray-600">{titulo}</h1>
                    
                </div>
            </div>
        </div>
    )
}

export const ENavBoton = ({color, titulo, sub, funcion, direccion}) => {

    const Navegacion = useNavigate();
     const Navegar = () =>{
        if(direccion != null){
            Navegacion('/Edit/'+direccion, {replace: true})
        }
     }

    return(
        <div onClick={Navegar} className="mt-5 mb-5 w-[100%] flex flex-row border-[2px] shadow-sm 
        hover:shadow-md  rounded-e-md transition-all">
            <div className={`${color} w-4 flex`}>
            </div>
            <div className="pt-3 pb-3 flex flex-row">
                <div className="ps-1 pe-1 flex items-center border-[2px] border-gray-200 rounded-e-md ms-1 me-1 center">
                <h1>{funcion}</h1>
                </div>
                <div className="flex flex-col justify-center">
                    
                    {sub && (
                        <h1 className="text-gray-500 text-xs">• {sub}</h1>
                    )}
                    <h1 className="text-sm ms-2 font-medium text-gray-600">{titulo}</h1>
                    
                </div>
            </div>
        </div>
    )
}
