import React from 'react'
import btnClasses from './Button.module.css'

 const Button = ({children, ...props}) => {
  return (
    <button {...props} className={btnClasses.btn}>
        {children}
    </button>
  )
}


export default Button