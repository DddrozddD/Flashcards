import React from 'react'
import classes from "./DeleteButton.module.css"

const DeleteButton = ({deleteItem, ...props}) => {
   
    
  return (
    <p {...props} stopPropagation className={classes.delete_button} >Delete</p>
  )
}

export default DeleteButton