import React from 'react'
import classess from "./Select.module.css"

const Select = ({options, defaultValue, value, onChange}) => {
  return (
    <>
    <select className={classess.select_button} value={value} onChange={event => onChange(event.target.value)}>
        <option disabled value="">{defaultValue}</option>
        {
            options.map(option => 
            <option key={option.value} value={option.value}>{option.name}
            </option>)
        }
        </select>
    </>
  )
}

export default Select