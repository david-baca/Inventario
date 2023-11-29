export const DashBtn = ({Titulo})=>{
    return(
        <button className="mt-5 mb-5 w-[100%] flex flex-row border-[2px] shadow-sm 
        hover:shadow-md bg-orange-500 text-white p-4  rounded-e-md transition-all cursor-pointer">
            {Titulo}
        </button>
    )
}