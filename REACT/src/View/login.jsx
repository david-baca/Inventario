import { useNavigate } from "react-router-dom";
import { ContextUser } from "../Context";
import { useContext } from 'react'
import { Logueo } from '../Conexion/Conexion'

export const Login = () => {
		const { setUsuario } = useContext(ContextUser);
		const navigate = useNavigate();

		const Verificacion = async (event) => {
			event.preventDefault();
			const form = event.target;
			const User = form.elements.User.value;
			const Password = form.elements.Password.value;

			if(await Logueo({Usuario:User, Contraseña:Password})){
				await setUsuario(true);
				navigate('/Dash/', { replace: true });
			}else{
				alert('Usuario o contraseña incorrecto')
			}
			
			
		};

		 // Puedes imprimir el objeto en la consola para verificar

    return (
    <div className="min-h-screen bg-gray-100 py-6 flex flex-col justify-center sm:py-12">
	<div className="relative py-3 sm:max-w-xl sm:mx-auto min-w-[500px]">
		<div
			className="absolute inset-0 bg-gradient-to-r from-blue-300 to-blue-600 shadow-lg transform -skew-y-6 sm:skew-y-0 sm:-rotate-6 sm:rounded-3xl">
		</div>
		<div className="relative px-4 py-10 bg-white shadow-lg sm:rounded-3xl sm:p-20">
			<div className="max-w-md mx-auto">
				<div>
					<h1 className="text-4xl font-semibold">UPQROO</h1>
          <h2 className="text-gray-400">Iniciar sesión</h2>
				</div>
				<form onSubmit={Verificacion} className="divide-y divide-gray-200">
					<div className="py-8 text-base leading-6 space-y-4 text-gray-700 sm:text-lg sm:leading-7">
						<div className="relative">
							<input required autoComplete="off" id="User" name="text" type="text" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:borer-rose-600" placeholder="Usuario" />
							<label htmlFor="User" className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Usuario</label>
						</div>
						<div className="relative">
							<input required autoComplete="off" id="Password" name="Password" type="password" className="peer placeholder-transparent h-10 w-full border-b-2 border-gray-300 text-gray-900 focus:outline-none focus:borer-rose-600" placeholder="Contraseña" />
							<label htmlFor="Password" className="absolute left-0 -top-3.5 text-gray-600 text-sm peer-placeholder-shown:text-base peer-placeholder-shown:text-gray-440 peer-placeholder-shown:top-2 transition-all peer-focus:-top-3.5 peer-focus:text-gray-600 peer-focus:text-sm">Contraseña</label>
						</div>
						<button type="submit" className="relative bg-blue-500 text-white w-full rounded-md px-2 py-1">
							Iniciar Sesión
						</button>
					</div>
				</form>
			</div>
		</div>
	</div>
</div>
    )
  }
  