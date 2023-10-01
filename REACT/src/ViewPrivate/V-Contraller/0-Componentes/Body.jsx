export const Body = ({
    Encabezado:E,
    Buscador:Barra, 
    BtnAdd:Add, 
    Map:Mapeador, 
    ModTrue:Exist,
    ModDel:Del,
    ModCreat:Creat,
    ModUpdate:Update
}) => {

    return(
        <div className="w-full pt-2">
            
            <div className="flex justify-between p-1 ps-5 pe-5">
                <h1 className="font-bold text-[25px] justify-items-center">
                    {E}
                </h1>
            </div>

            <div className="flex justify-end p-5">
                <section className="flex">
                    <div className="me-5">
                        {Barra}
                    </div>
                    <div className="w-[200px]">
                        {Add}
                    </div>
                </section>
            </div>
            
            {Mapeador}

            {Exist}
            
            {Del}
            {Creat}
            {Update}
        </div>
    )
}
