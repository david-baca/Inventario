import ImgDelete from "../assets/Delete.svg"
import ImgUpdate from "../assets/Edit.svg"
import { ModulEdit } from "./";
export const Displey = ({Data:BD, Edit:E, Delete:D,}) => {
    return (
        <div className="flex justify-between w-full max-h-full p-5">
            <div className="max-h-[65vh] overflow-auto flex flex-wrap w-full bg-gray-500 fle-row">
            {BD && (
                BD.map((element, Index) => 
                ( 
                    <div className="relative" key={Index}>
                        <div className="bg-white max-w-[200px] min-w-[200px] m-5">
                            <div className="flex flex-col w-full p-2 text-center bg-white">
                                <div className='relative flex flex-col items-end w-full'>
                                    <button onClick={()=>E({...element})} className=' bg-white p-1 m-1 border-yellow-400 border-[2px] rounded-lg'> <img src={ImgUpdate}/> </button>
                                    <button onClick={()=>{D(element.pk)}}  className='p-1 m-1 border-red-400 border-[2px] rounded-lg'> <img src={ImgDelete}/> </button>
                                </div>
                                <div className=' font-bold text-center w-full flex justify-center items-center h-[140px]'>
                                {element.nombre && (
                                    <h1>{element.nombre}</h1> 
                                )}
                                {element.descripcion && (
                                    <h1>{element.descripcion}</h1> 
                                )}
                                </div>
                            </div>
                        </div>
                    </div>
                ))
            )}
            {!BD && (

                <div className=" h-[10rem] w-full bg-white flex justify-center items-center">
                    <h1 className="font-bold">No hay datos en la BD</h1>
                </div>
            )}
            </div>
        </div>

    )
}

export const Mapeador = ({Data:D, FCreateModelBD:F, Eliminar:Delete, Editar:Update}) => {
    return (
        <div className="flex justify-between w-full max-h-full p-5">
            <div className="max-h-[65vh] overflow-auto flex flex-wrap w-full bg-gray-500 fle-row">
            {D && (
                D.map((element, Index) => 
                ( 
                    <div className="relative" key={Index}>
                        <div
                        className=" absolute bg-white max-w-[200px] min-w-[200px] m-5">
                            <div className="flex flex-col w-full p-2 text-center bg-white">
                                <div className='relative flex flex-col items-end w-full'>
                                    <button className=' bg-white p-1 m-1 border-yellow-400 border-[2px] rounded-lg'> <img src={ImgUpdate}/> </button>
                                    <button className='p-1 m-1 border-red-400 border-[2px] rounded-lg'> <img src={ImgDelete}/> </button>
                                    <button onClick={() => F({...element})}  className='p-1 m-1 border-red-400 border-[2px] rounded-lg'> select </button>
                                </div>
                                <div className=' font-bold text-center w-full flex justify-center items-center h-[140px]'>
                                {element.nombre && (
                                    <h1>{element.nombre}</h1> 
                                )}
                                {element.descripcion && (
                                    <h1>{element.descripcion}</h1> 
                                )}
                                </div>
                            </div>
                        </div>

                        <div className="bg-white max-w-[200px] min-w-[200px] m-5">
                            <div className="flex flex-col w-full p-2 text-center bg-white">
                                <div className='relative flex flex-col items-end w-full'>
                                    <button onClick={()=>Update({...element})} className=' bg-white p-1 m-1 border-yellow-400 border-[2px] rounded-lg'> <img src={ImgUpdate}/> </button>
                                    <button onClick={()=>Delete({...element})}  className='p-1 m-1 border-red-400 border-[2px] rounded-lg'> <img src={ImgDelete}/> </button>
                                </div>
                                <div className=' font-bold text-center w-full flex justify-center items-center h-[140px]'>
                                {element.nombre && (
                                    <h1>{element.nombre}</h1> 
                                )}
                                {element.descripcion && (
                                    <h1>{element.descripcion}</h1> 
                                )}
                                </div>
                            </div>
                        </div>
                    </div>
                ))
            )}
            {!D && (

                <div className=" h-[10rem] w-full bg-white flex justify-center items-center">
                    <h1 className="font-bold">No hay datos en la BD</h1>
                </div>
            )}
            </div>
        </div>

    )
}

{/* <div className="relative" key={Index}>
                        <div onClick={() => F({...element})} 
                        className=" absolute bg-white max-w-[200px] min-w-[200px] m-5">
                            <div className="flex flex-col w-full p-2 text-center bg-white">
                                <div className='relative flex flex-col items-end w-full'>
                                    <button className=' bg-white p-1 m-1 border-yellow-400 border-[2px] rounded-lg'> <img src={ImgUpdate}/> </button>
                                    <button className='p-1 m-1 border-red-400 border-[2px] rounded-lg'> <img src={ImgDelete}/> </button>
                                </div>
                                <div className=' font-bold text-center w-full flex justify-center items-center h-[140px]'>
                                {element.nombre && (
                                    <h1>{element.nombre}</h1> 
                                )}
                                {element.descripcion && (
                                    <h1>{element.descripcion}</h1> 
                                )}
                                </div>
                            </div>
                        </div>

                        <div className="bg-white max-w-[200px] min-w-[200px] m-5">
                            <div className="flex flex-col w-full p-2 text-center bg-white">
                                <div className='relative flex flex-col items-end w-full'>
                                    <button onClick={()=>Update({...element})} className=' bg-white p-1 m-1 border-yellow-400 border-[2px] rounded-lg'> <img src={ImgUpdate}/> </button>
                                    <button onClick={()=>Delete({...element})}  className='p-1 m-1 border-red-400 border-[2px] rounded-lg'> <img src={ImgDelete}/> </button>
                                </div>
                                <div className=' font-bold text-center w-full flex justify-center items-center h-[140px]'>
                                {element.nombre && (
                                    <h1>{element.nombre}</h1> 
                                )}
                                {element.descripcion && (
                                    <h1>{element.descripcion}</h1> 
                                )}
                                </div>
                            </div>
                        </div>
                    </div> */}