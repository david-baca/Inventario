export const Barra = ({ReadBD:FR}) => {
    const handleChange = (event) => {
        const value = event.target.value;
        FR(value)
      };

    return(
        <input onChange={handleChange} className="bg-white p-2 text-end rounded-xl
        w-[350px] border-gray-100 border" placeholder="Buscar    🔍︎"/>
    )
}

export const BtnAdd = ({ Crear:CrearForm }) => {

    return(
        <button onClick={()=>CrearForm()} className="bg-gray-400 border-green-500 text-white hover:bg-green-500 p-2 text-end rounded-xl
        w-[100%]">
            Agregar
        </button>
    )
}