import React from 'react'
import "../../styles/pages/Theme.css"
import { ThemeItem } from './ThemeItem'

export const ThemeList = ({themes, title, deleteTheme}) => {
    if(!themes.length){
        return <h1 style={{textAlign: "center"}}>Themes not found</h1>
    }
    return (
        <>
            <h1 style={{textAlign: "center"}}>
                 {title}
            </h1>
            <div className="themes_list">
                {themes.map(theme => {
                    return <ThemeItem theme = {theme} key={theme.id} deleteTheme={deleteTheme}/>
                })}
            </div>
        </>
  )
}
