import Imagen from './assets/alert.svg'
export const Error = ({alert}) => {
    return (

      <div className="flex flex-col items-center justify-center w-screen h-screen">
        <div className="">
          <img src={Imagen} className='h-[30px]'/>
        </div>
        <h1 className="text-3xl font-bold">
          {alert}
        </h1>
        <a href='../' className='p-2 m-2 text-white bg-black ps-7 pe-7 font-blood'>
          - regresar
        </a>
        {/* <Link to={"../"}>
          regresar
        </Link> */}
      </div>
      
    )
  }