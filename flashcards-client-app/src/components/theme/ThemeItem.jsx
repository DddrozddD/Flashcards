import React, { use } from "react"
import "../../styles/pages/Theme.css"
import DeleteButton from "../UI/deleteButton/DeleteButton"
import Button from "../UI/button/Button"
import { useNavigate } from "react-router-dom"

export const ThemeItem =(props) => {
    const deleteTheme = (e) => {
        e.preventDefault();
        e.stopPropagation();
        props.deleteTheme(props.theme.id);
    }
    const navigate = useNavigate();
    return (
        <div className="theme">
            <div className="theme_content" onClick={() => navigate(`/themes/${props.theme.id}`)}>
                <p className="theme_id" style={{display: "none"}}>{props.theme.id}</p>
                <h2 className="theme_title">{props.theme.title}</h2>
                <h3 className="theme_description">{props.theme.description}</h3>
                <div style={{display: "flex"}}>
                <DeleteButton style={{marginLeft: "auto"}} onClick={deleteTheme}/>
                </div>
            </div>
        </div>
    )
}