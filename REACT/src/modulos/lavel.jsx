// import PropTypes from 'prop-types'
import { useState } from "react";

export const Login = ({ nombre }) => {

    const [inicial, setInicial] = useState(nombre);

    const GenerarSaludo = () => {
        
        setInicial( `hola ${nombre}` );
    
    }
  
    return (
      <>
        <h1>
            {inicial}
        </h1>
        <button onClick={GenerarSaludo}>
          Generar un saludo
        </button>
      </>
    );
  };
// FirstApp.PropTypes = {
//     nombre : PropTypes.string
//   }