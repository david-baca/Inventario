import {Link} from 'react-router-dom'
export const HomePage = () => {
  return (
  <>
    <div className="w-screen h-screen bg-black-500 bg-slate-900 flex justify-center items-center">
      <h1 className="font-bold text-3xl text-white">
        Bienvenido a Home Page
      </h1>
      <Link to={"/"} className="bg-red-500 rounted-md p-2">
      Volver al anterior
      </Link>
    </div>
  </> 
  )
}
  