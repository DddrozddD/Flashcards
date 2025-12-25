import React from 'react'
import  Button from '../UI/button/Button';
import  Input  from '../UI/input/Input';

export const ThemeForm = ({create, newTheme, setNewTheme}) => {

    const handleSumbit = (e) => {
        e.preventDefault();
        create();
    }
    

  return (
    <form>
            <Input 
            value = {newTheme.title}
            onChange = {e => setNewTheme({...newTheme, title: e.target.value})}
            placeholder="Title of new theme"/>
            <br/>
            <Input 
            value = {newTheme.description}
            onChange = {e=> setNewTheme({...newTheme, description: e.target.value})}
            placeholder="Descrition of new theme"/>
            <br/>
            <Button onClick = {handleSumbit}>
              Create
            </Button>
          </form>
  )
}
