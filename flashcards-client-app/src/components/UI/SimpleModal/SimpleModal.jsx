import React, { useEffect } from 'react'
import classes from "./SimpleModel.module.css"

const SimpleModal = ({children, visible, setVisible}) => {

  useEffect(() => {
  if (visible) {
    document.body.style.overflow = 'hidden';
  } else {
    document.body.style.overflow = 'unset';
  }
  return () => {
    document.body.style.overflow = 'unset';
  };
}, [visible]);

  const rootClasses = [classes.sympleModal]
  if(visible){
    rootClasses.push(classes.sympleModal_active)
  }
  
  return (
    <div className={rootClasses.join(" ")} onClick={() => setVisible(false)}>
      <div className={classes.sympleModalContent} onClick={e => e.stopPropagation()}>
        {children}
      </div>
    </div>
  )
}

export default SimpleModal